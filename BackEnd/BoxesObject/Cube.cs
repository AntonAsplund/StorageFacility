using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BoxesObject
{
    /// <summary>
    /// An object of the type Cube, which inherts from I3DObject
    /// </summary>
    class Cube : I3DObject
    {
        public int id { get; }
        public long volume { get; }
        public decimal weight { get; }
        public long maxDimension { get; }
        public string description { get; }
        public int area { get; }
        public bool isFragile { get; }
        public decimal insuranceValue { get; }
        public int side { get; }

        public Cube(int id, decimal weight, string description, int side)
        {
            this.id = id;
            this.volume = side * side * side;
            this.weight = weight;
            this.maxDimension = side;
            this.description = description;
            this.area = (side * side) * 6;
            this.isFragile = false;
            this.insuranceValue = 0;
            this.side = side;
        }

        public object Clone()
        {
            Cube clonedCube = new Cube(this.id, this.weight, this.description, this.side);

            return clonedCube;
        }
    }
}
