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

        internal bool TryAdd(I3DObject box)
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
            else if (0 <= (this.RemainingVolume - box.Volume) 
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
        /// <summary>
        /// Searches for a specific box ID in each warehouselocation and returns the storageshelf index position
        /// </summary>
        /// <param name="id">ID of the box that is searched</param>
        /// <returns></returns>
        internal int FindBoxInWarehouseLocation(int id)
        {
            int indexPositionOfBOx = -1;

            for (int i = 0; i < this.StorageSpace.Count; i++)
            {
                if (this.StorageSpace[i].Id == id)
                {
                    indexPositionOfBOx = i;
                }
            }

            return indexPositionOfBOx;
        }
        /// <summary>
        /// Removes a box based on a index position in a storagerack
        /// </summary>
        /// <param name="index"></param>
        /// <returns>A bool that specifies if function was sucessful</returns>
        internal bool RemoveBoxByIndex(int index)
        {
            bool boxRemoved = false;

            if (index >= 0)
            {
                this.StorageSpace.RemoveAt(index);
                boxRemoved = true;
            }

            return boxRemoved;
        }

        public IEnumerator<I3DObject> GetEnumerator()
        {
            foreach (var box in StorageSpace)
            {
                if (box != null)
                yield return box;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var box in StorageSpace)
            {
                if(box!=null)
                yield return box;
            }
        }

        internal WareHouseLocation Content()
        {
            WareHouseLocation clonedStorageRack = new WareHouseLocation();
            clonedStorageRack.ContainsFragile = this.ContainsFragile;
            clonedStorageRack.RemainingVolume = this.RemainingVolume;
            clonedStorageRack.ReaminingWeight = this.ReaminingWeight;

            foreach (var boxes in this.StorageSpace)
            {
                I3DObject clonedBox = boxes.Clone() as I3DObject;
                clonedStorageRack.StorageSpace.Add(clonedBox);
            }

            return clonedStorageRack;
        }

    }
}
