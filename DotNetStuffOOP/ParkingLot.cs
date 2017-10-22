using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStuffOOP
{
    public interface Permission
    {
        float getFee(Calendar start, Calendar end);
    }
    public enum ParkingSpaceType
    {
        MOTORBIKE, CAR, HANDICAPPED
    };
    public class ParkingLot
    {

        private List<ParkingSpace> freeRegularSpace;
        private List<ParkingSpace> freeHandicappedSpace;
        private List<ParkingSpace> freeCompactSpace;
        public ParkingLot() { }

        public ParkingSpace allocateFreeSpace(ParkingSpaceType pspaceType)
        {
            //get a ParkingSpace from the corresponding free list
            ParkingSpace pspace = ParkingSpace.defalultNonImplemented;
            pspace.setStart();
            return pspace;
        }

        public float reclaimFreeSpace(ParkingSpace pspace)
        {
            pspace.setEnd();

            //return free space to the list

            return pspace.getFee(perm);
        }

        private Permission perm;
    }

    public class ParkingSpace
    {
        
        public static ParkingSpace defalultNonImplemented;
        private int id;
        private ParkingSpaceType pspaceType;
        private ParkingMeter meter;

        public ParkingSpace(int id, ParkingSpaceType pspaceType)
        {
            //super();
            this.id = id;
            this.pspaceType = pspaceType;
        }

        public int getId()
        {
            return id;
        }

        public ParkingSpaceType getpspaceType()
        {
            return pspaceType;
        }

        private class ParkingMeter{
            public GregorianCalendar start;
            public GregorianCalendar end;
        }

        public void setStart()
        {
            meter.start = new GregorianCalendar();
        }
        public void setEnd()
        {
            meter.end = new GregorianCalendar();
        }

        public float getFee(Permission perm)
        {
            return perm.getFee(meter.start, meter.end);
        }
    }

    public abstract class Vehicle{
        public abstract bool park(ParkingLot pLot);
        public bool unpark(ParkingLot pLot)
        {
            if(pspace != null){
                pLot.reclaimFreeSpace(pspace);
                return true;
            }
            return false;
        }
        private ParkingSpace pspace;
    }

    public class Motorbike : Vehicle
    {
        public override bool park(ParkingLot pLot)
        {
            //get a ParkingSpace from the corresponding free list
            ParkingSpace pspace = ParkingSpace.defalultNonImplemented;
            if((pspace=pLot.allocateFreeSpace(ParkingSpaceType.MOTORBIKE))==null)
            {
                return false;
            }
            return true;
        }
    }

    public class Cars : Vehicle
    {
        public override bool park(ParkingLot pLot)
        {
            //get a ParkingSpace from the corresponding free list
            ParkingSpace pspace = ParkingSpace.defalultNonImplemented;
            if((pspace=pLot.allocateFreeSpace(ParkingSpaceType.CAR))==null)
            {
                return false;
            }
            return true;
        }
    }

    public class HandicappedCars : Vehicle
    {
        public override bool park(ParkingLot pLot)
        {
            //get a ParkingSpace from the corresponding free list
            ParkingSpace pspace = ParkingSpace.defalultNonImplemented;
            if ((pspace = pLot.allocateFreeSpace(ParkingSpaceType.HANDICAPPED)) == null && (pspace = pLot.allocateFreeSpace(ParkingSpaceType.CAR)) == null)
            {
                return false;
            }
            return true;
        }
    }
}
