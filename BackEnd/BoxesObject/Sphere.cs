using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BoxesObject
{
    /// <summary>
    /// An object of the type Sphere, which inherts from I3DObject
    /// The
    /// </summary>
    class Sphere : I3DObject
    {
        public int Id { get; }
        public long Volume { get; }
        public decimal Weight { get; }
        public long MaxDimension { get; }
        public string Description { get; }
        public int Area { get; }
        public bool IsFragile { get; }
        public decimal InsuranceValue { get; set; }
        public int radius { get; }

        public Sphere(int id, decimal weight, string description, bool isFragile, int radius)
        {
            this.Id = id;
            this.Volume = (radius * 2) * (radius * 2) * (radius * 2);
            this.Weight = weight;
            this.MaxDimension = (radius * 2);
            this.Description = description;
            this.Area = (((radius * 2) * (radius * 2)) * 6);
            this.IsFragile = isFragile;
            this.InsuranceValue = 0;
            this.radius = radius;
        }

        public object Clone()
        {
            Sphere clonedSphere = new Sphere(this.Id, this.Weight, this.Description, this.IsFragile, this.radius);

            return clonedSphere;
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
