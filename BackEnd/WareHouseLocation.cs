using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.BoxesObject;

namespace BackEnd
{
    class WareHouseLocation 
    {
        private long height;
        private long width;
        private long depth;
        private decimal maxWeight;
        private long maxVolume;
        private bool containsFragile;
        private long remainingVolume;
        private decimal reaminingWeight;
        private List<I3DObject> storageSpace;

        public WareHouseLocation()
        {
            this.height = 220;
            this.width = 200;
            this.depth = 140;
            this.maxWeight = 1000.00M;
            this.containsFragile = false;
            this.remainingVolume = height * width * depth;
            this.reaminingWeight = 1000.00M;
            this.storageSpace = new List<I3DObject>();
        }

        internal bool TryAdd(I3DObject box)
        {
            bool sucessfullyAdded = false;

            if (0 < (this.remainingVolume + box.volume) && 0 < (this.reaminingWeight+box.weight))
            {
                this.storageSpace.Add(box);
                sucessfullyAdded = true;
            }

            return sucessfullyAdded;
        }

        internal void TestMethodPrintAllId()
        {
            foreach (var obj in this.storageSpace)
            {
                Console.WriteLine(obj.id);
                Console.WriteLine(obj.area);
            }
        }

        //internal I3DObject ReCalculate()
        

        //internal WareHouseLocation Content()
        
    }
}
