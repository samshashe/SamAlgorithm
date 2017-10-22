using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStuffOOP.DesignPatterns
{
    // A dependency injection container is a collection of registrations that map services to components
    // A service, in this context, is a way of identifying a particular functional capability – it could be a textual name, but is more often an interface type.
    // A registration captures the dynamic behaviour of the component within the system. The most noticeable aspect of this is the way in which instances of the component are created.
    // Autofac can accept registrations that create components using expressions, provided instances, or with Reflection based on System.Type.
    class DepInjAutofac2
    {
        public static void Main1(string[] args)
        {
            IQueryable<Memo> memos = new List<Memo>() {
                new Memo { Title = "Release Autofac 1.0", DueAt = new DateTime(2007, 12, 14) },
                new Memo { Title = "Write CodeProject Article", DueAt = DateTime.Now },
                new Memo { Title = "Release Autofac 2.3", DueAt = new DateTime(2019, 07, 01) }
            }.AsQueryable();

            // traditional way
            //var checker = new MemoChecker(memos, new PrintingNotifier(Console.Out));
            //checker.CheckNow();

            // Now using Autofac. Container registration normally happens at application startup
            var builder = new ContainerBuilder();
            builder.Register(c => new MemoChecker(c.Resolve<IQueryable<Memo>>(), c.Resolve<IMemoDueNotifier>()));

            builder.Register(c => new PrintingNotifier(c.Resolve<TextWriter>())).As<IMemoDueNotifier>();
            builder.RegisterInstance(memos);
            builder.RegisterInstance(Console.Out).As<TextWriter>().ExternallyOwned();

            using (var container = builder.Build())
            {
                container.Resolve<MemoChecker>().CheckNow();
            }


            Console.ReadKey();
        }

    }

    // A MemoChecker ... 
    class MemoChecker
    {
        IQueryable<Memo> _memos;
        IMemoDueNotifier _notifier;

        // Construct a memo checker with the store of memos and the notifier 
        // that will be used to display overdue memos. 

        // Dependency Injection makes the class more easily testable, configurable and maintainable.
        public MemoChecker(IQueryable<Memo> memos, IMemoDueNotifier notifier)
        {
            _memos = memos;
            _notifier = notifier;
        }

        // Check for overdue memos and alert the notifier of any that are found. 
        public void CheckNow()
        {
            var overdueMemos = _memos.Where(memo => memo.DueAt < DateTime.Now);

            foreach (var memo in overdueMemos)
                _notifier.MemoIsDue(memo);
        }
    }

    // A memo notifier that prints messages to a text stream. 
    class PrintingNotifier : IMemoDueNotifier
    {
        TextWriter _writer;

        // Construct the notifier with the stream onto which it will 
        // print notifications. 
        public PrintingNotifier(TextWriter writer)
        {
            _writer = writer;
        }

        // Print the details of an overdue memo onto the text stream. 
        public void MemoIsDue(Memo memo)
        {
            _writer.WriteLine(string.Format("Memo {0} is due!", memo.Title));
        }
    }

    public interface IMemoDueNotifier
    {
        void MemoIsDue(Memo memo);
    }

    public class Memo
    {
        public string Title { get; set; }
        public DateTime DueAt { get; set; }

    }
}
