using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStuffOOP
{
    //Imagine you have a call center with three levels of employees: fresher, technical lead (TL), product manager (PM). 
    //There can be multiple employees, but only one TL or PM. An incoming telephone call must be allocated to a fresher who is free. 
    //If a fresher can’t handle the call, he or she must escalate the call to technical lead. 
    //If the TL is not free or not able to handle it, then the call should be escalated to PM. 
    //Design the classes and data structures for this problem. Implement a method getCallHandler().

    enum ERank
    { 
        FRESHER = 0, TECH_LEAD = 1, PROD_MANAGER = 2 
    }

    abstract class Employee
    {
        // Properties
        public ERank Rank{get; private set;}
        public bool Busy{get; private set;}

        // Fields
        //protected static readonly CallService _callService = new CallService(SOME_GLOBAL_VALUE);

        // Constructors
        public Employee(ERank rank)
        {
            Rank = rank;
            Busy = false;
        }

        public void ServiceCall(Call call)
        {
            if(CanService(call))
            {
                Busy = true;
                call.Service(this);
            }
            else
            {
                // Only escalate if there is a superior rank available
                if(!Busy && (Rank != ERank.PROD_MANAGER))
                {
                    call.Escalate();
                }

                // Put the call back onto the queue
                _callService.AcceptCall(call);
            }
        }

        public void OnCallServiced(Call call)
        {
            if(this != call.CallHandler)
            {
                // TODO: this call was never accepted
                // somebody is innapropriately calling this method
            }
            else
            {
                Call nextCall = _callService.GetNextCall();
                if(nextCall == null)
                {
                    Busy = false;
                }
            }
        }

        protected abstract bool CanService(Call call);
    }

    class Fresher:Employee
    {
        public Fresher():base(ERank.FRESHER){}
        private override bool CanService(Call call) { /*...*/return true; }
    }

    class TechLead:Employee
    {    
        public TechLead():base(ERank.TECH_LEAD){}
        private override bool CanService(Call call) { /*...*/return true; }
    }

    class ProductManager:Employee
    {    
        public ProductManager():base(ERank.PROD_MANAGER){}
        public override bool CanService(Call call) { /*...*/return false; }
    }

    class Call
    {    
        public Employee CallHandler{get; private set;}
        public ERank AcceptableRank{get; private set;}

        public Call()
        {
            CallHandler = null;
            AcceptableRank = ERank.FRESHER;
        }

        public void Service(Employee callHandler)
        {
            CallHandler = callHandler;

            // notify the call handler when the call is serviced
            CallHandler.OnCallServiced(this);
        }

        public void Escalate()
        {
            if((int)AcceptableRank < (int)ERank.PROD_MANAGER)
            {
                //AcceptableRank = ERank(((int)AcceptableRank)+1);
                AcceptableRank = ERank.TECH_LEAD;
            }
        }
    }

    class CallCenter
    {
        private Employee[][] _employees;
        private Queue<Call>[] _rankedCallQueue;
        private Employee _prodManager;
        private Employee _techLead;

        public CallCenter(int numEmployees)
        {
            _prodManager = new ProductManager();
            _techLead = new TechLead();

            _rankedCallQueue = new Queue<Call>[((int)ERank.PROD_MANAGER)+1];
            _employees = new Employee[((int)ERank.PROD_MANAGER)+1][];

            for(int rank = 0; rank <= (int)ERank.PROD_MANAGER; rank++)
            {
                _rankedCallQueue[rank] = new Queue<Call>();
                switch((ERank)rank)
                {
                    case ERank.FRESHER:
                        _employees[rank] = new Employee[numEmployees];
                        for(int i = 0; i < numEmployees; i++)
                        {
                            _employees[rank][i] = new Fresher();
                        }
                        break;
                    case ERank.TECH_LEAD:
                        _employees[rank] = new Employee[] { new TechLead() };
                        break;
                    case ERank.PROD_MANAGER:
                        _employees[rank] = new Employee[]{new ProductManager()};
                        break;
                    default:
                        break;
                }
            }
        }

        public Employee GetCallHandler(Call call)
        {
            int rank = (int)call.AcceptableRank;
            for(int i = 0; i < _employees[rank].Length; i++)
            {
                if(!_employees[rank][i].Busy)
                {
                    return _employees[rank][i];
                }
            }
            return null;
        }

        public void AcceptCall(Call call)
        {
            Employee employee = GetCallHandler(call);
            if(employee == null)
            {
                _rankedCallQueue[(int)call.AcceptableRank].Enqueue(call);
            }
            else
            {
                employee.ServiceCall(call);
            }
        }

        public Call GetNextCall(ERank rank)
        {
            if (_rankedCallQueue[(int)rank].Count == 0)
            {
                return null;
            }
            else
            {
                return _rankedCallQueue[(int)rank].Dequeue();
            }
        }
    }
}
