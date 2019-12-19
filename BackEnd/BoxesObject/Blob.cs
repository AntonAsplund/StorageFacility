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
        public int Id { get; }
        public long Volume { get; }
        public decimal Weight { get; }
        public long MaxDimension { get; }
        public string Description { get; }
        public int Area { get; }
        public bool IsFragile { get; }
        public decimal InsuranceValue { get; set; }
        public int side { get; }

        internal Blob(int id, decimal weight, string description, int side)
        {
            this.Id = id;
            this.Volume = side * side * side;
            this.Weight = weight;
            this.MaxDimension = side;
            this.Description = description;
            this.Area = (side * side) * 6;
            this.IsFragile = true;
            this.InsuranceValue = 0;
            this.side = side;
        }
        public object Clone(Blob blobToClone)
        {
            Blob clonedBlob = new Blob(blobToClone.Id, blobToClone.Weight, blobToClone.Description, blobToClone.side);

            return clonedBlob;
        }

        public object Clone()
        {
            Blob clonedBlob = new Blob(this.Id, this.Weight, this.Description, this.side);

            return clonedBlob;
        }

        public override string ToString()
        {
            string stringRepresentation = "";

            stringRepresentation = "ID: " + this.Id.ToString();
            stringRepresentation += "\n Description: " + this.Description;
            stringRepresentation += "\n Weight: " + this.Weight.ToString();

            return stringRepresentation;
        }
    }
}
