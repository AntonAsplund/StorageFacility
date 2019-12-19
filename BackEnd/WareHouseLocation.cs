using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.BoxesObject;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BackEnd
{
    [Serializable]
    public class WareHouseLocation : IEnumerable<I3DObject>
    {
        private long Height { get; }
        private long Width { get; }
        private long Depth { get; }
        private decimal MaxWeight { get; }
        private long MaxVolume { get; }
        private bool ContainsFragile { get; set; }
        private long RemainingVolume { get; set; }
        private decimal RemainingWeight { get; set; }
        internal List<I3DObject> StorageSpace { get; set; }



        internal WareHouseLocation()
        {
            this.Height = 220;
            this.Width = 200;
            this.Depth = 140;
            this.MaxWeight = 1000.00M;
            this.MaxVolume = Height * Width * Depth;
            this.ContainsFragile = false;
            this.RemainingVolume = MaxVolume;
            this.RemainingWeight = MaxWeight;
            this.StorageSpace = new List<I3DObject>();
        }

        /// <summary>
        /// Tries to add a I3DObject to first rack with enough free space
        /// </summary>
        /// <param name="box">The object which is tried to be added onto a rack</param>
        /// <returns>A bool value which for true indicates a sucessfull addition to a rack</returns>
        internal bool TryAdd(I3DObject box)
        {
            bool sucessfullyAdded = false;
            if (box.IsFragile == true && this.RemainingWeight == this.MaxWeight 
                && 0 <= (this.RemainingVolume - box.Volume) 
                && 0 <= (this.RemainingWeight - box.Weight) 
                &&  this.Height > box.MaxDimension)
            {
                this.StorageSpace.Add(box);
                this.RemainingVolume = this.RemainingVolume - box.Volume;
                this.RemainingWeight = this.RemainingWeight - box.Weight;
                sucessfullyAdded = true;
            }
            else if (0 <= (this.RemainingVolume - box.Volume) 
                && 0 <= (this.RemainingWeight - box.Weight) 
                && this.ContainsFragile == false 
                && this.Height > box.MaxDimension)
            {
                this.StorageSpace.Add(box);
                this.RemainingVolume = this.RemainingVolume - box.Volume;
                this.RemainingWeight = this.RemainingWeight - box.Weight;
                sucessfullyAdded = true;
            }

            return sucessfullyAdded;
        }
        /// <summary>
        /// Searches for a specific box ID in each warehouselocation and returns the storageshelf index position
        /// </summary>
        /// <param name="id">ID of the box that is searched</param>
        /// <returns>The index position in the rack of the sought after box ID</returns>
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
                this.RemainingWeight = this.RemainingWeight + this.StorageSpace[index].Weight;
                this.RemainingVolume = this.RemainingVolume + this.StorageSpace[index].Volume;
                this.StorageSpace.RemoveAt(index);
                boxRemoved = true;
            }
            return boxRemoved;
        }

        /// <summary>
        /// Method which makes a deep-copy of a WareHouseLocation object and returns it.
        /// </summary>
        /// <returns>A WareHouseLocation object</returns>
        internal WareHouseLocation Content()
        {
            WareHouseLocation clonedStorageRack = new WareHouseLocation();
            clonedStorageRack.ContainsFragile = this.ContainsFragile;
            clonedStorageRack.RemainingVolume = this.RemainingVolume;
            clonedStorageRack.RemainingWeight = this.RemainingWeight;

            foreach (var boxes in this.StorageSpace)
            {
                I3DObject clonedBox = boxes.Clone() as I3DObject;
                clonedStorageRack.StorageSpace.Add(clonedBox);
            }

            return clonedStorageRack;
        }
        /// <summary>
        /// Overrides ToString() method and returns a string representation of all boxes id, description and weight in this storage rack
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string informationPrintedOnConsoleWindow = "";

            if (this.RemainingWeight == MaxWeight)
            {
                informationPrintedOnConsoleWindow += "No boxes on this storage rack \n";
            }

            foreach (var box in this.StorageSpace)
            {
                informationPrintedOnConsoleWindow += "\n " + box.ToString();
                informationPrintedOnConsoleWindow += "\n ---";
            }

            return informationPrintedOnConsoleWindow;
        }

        IEnumerator<I3DObject> IEnumerable<I3DObject>.GetEnumerator()
        {
            return this.StorageSpace.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this.StorageSpace.GetEnumerator();
        }
    }
}
