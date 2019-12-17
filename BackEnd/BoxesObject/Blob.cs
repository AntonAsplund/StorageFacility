using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BoxesObject
{
    /// <summary>
    /// An object of the type Blob, which inherts from I3DObject
    /// </summary>
    class Blob : I3DObject
    {
        public int id { get; }
        public long volume { get; }
        public decimal weight { get; }
        public long maxDimension { get; }
        public string description { get; }
        public bool isFragile { get; }
        public decimal insuranceValue { get; }
        public int side { get; }

        public Blob(int id, decimal weight, string description, int side)
        {
            this.id = id;
            this.volume = side * side * side;
            this.weight = weight;
            this.maxDimension = side;
            this.description = description;
            this.isFragile = true;
            this.insuranceValue = 0;
            this.side = side;
        }
        public object Clone(Blob blobToClone)
        {
            Blob clonedBlob = new Blob(blobToClone.id, blobToClone.weight, blobToClone.description, blobToClone.side);

            return clonedBlob;
        }

        public object Clone()
        {
            Blob clonedBlob = new Blob(this.id, this.weight, this.description, this.side);

            return clonedBlob;
        }
    }
}
