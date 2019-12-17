using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BoxesObject
{
    /// <summary>
    /// An object of the type Sphere, which inherts from I3DObject
    /// </summary>
    class Sphere : I3DObject
    {
        public int id { get; }
        public long volume { get; }
        public decimal weight { get; }
        public long maxDimension { get; }
        public string description { get; }
        public bool isFragile { get; }
        public decimal insuranceValue { get; }
        public int radius { get; }

        public Sphere(int id, decimal weight, string description, int radius)
        {
            this.id = id;
            this.volume = (radius * 2) * (radius * 2) * (radius * 2);
            this.weight = weight;
            this.maxDimension = (radius * 2);
            this.description = description;
            this.isFragile = false;
            this.insuranceValue = 0;
            this.radius = radius;
        }

        public object Clone()
        {
            Sphere clonedSphere = new Sphere(this.id, this.weight, this.description, this.radius);

            return clonedSphere;
        }
    }
}
