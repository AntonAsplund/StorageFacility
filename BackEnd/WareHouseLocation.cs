using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.BoxesObject;

namespace BackEnd
{
    internal class WareHouseLocation : IEnumerable<I3DObject>
    {
        private long Height { get;}
        private long Width { get; }
        private long Depth { get; }
        private decimal MaxWeight { get; }
        private long MaxVolume { get; }
        private bool ContainsFragile { get; set; }
        private long RemainingVolume { get; set; }
        private decimal ReaminingWeight { get; set; }
        internal List<I3DObject> StorageSpace { get; set; }

        public WareHouseLocation()
        {
            this.Height = 220;
            this.Width = 200;
            this.Depth = 140;
            this.MaxWeight = 1000.00M;
            this.MaxVolume = Height * Width * Depth;
            this.ContainsFragile = false;
            this.RemainingVolume = MaxVolume;
            this.ReaminingWeight = MaxWeight;
            this.StorageSpace = new List<I3DObject>();
        }

        public bool TryAdd(I3DObject box)
        {
            bool sucessfullyAdded = false;
            if (box.IsFragile == true && this.ReaminingWeight == this.MaxWeight 
                && 0 <= (this.RemainingVolume - box.Volume) 
                && 0 <= (this.ReaminingWeight - box.Weight) 
                &&  this.Height > box.MaxDimension)
            {
                this.StorageSpace.Add(box);
                this.RemainingVolume = this.RemainingVolume - box.Volume;
                this.ReaminingWeight = this.ReaminingWeight - box.Weight;
                sucessfullyAdded = true;
            }
            if (0 <= (this.RemainingVolume - box.Volume) 
                && 0 <= (this.ReaminingWeight - box.Weight) 
                && this.ContainsFragile == false 
                && this.Height > box.MaxDimension)
            {
                this.StorageSpace.Add(box);
                this.RemainingVolume = this.RemainingVolume - box.Volume;
                this.ReaminingWeight = this.ReaminingWeight - box.Weight;
                sucessfullyAdded = true;
            }


            return sucessfullyAdded;
        }

        

        public IEnumerator<I3DObject> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //internal I3DObject ReCalculate()


        //internal WareHouseLocation Content()

    }
}
