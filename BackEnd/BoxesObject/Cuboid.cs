using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BoxesObject
{
    /// <summary>
    /// An object of the type Cuboid, which inherts from I3DObject
    /// </summary>
    class Cuboid : I3DObject
    {
        public int id { get; }
        public long volume { get; }
        public decimal weight { get; }
        public long maxDimension { get; }
        public string description { get; }
        public int area { get; }
        public bool isFragile { get; }
        public decimal insuranceValue { get; }
        public int xSide { get; }
        public int ySide { get; }
        public int zSide { get; }

        public Cuboid(int id, decimal weight, string description, int xSide, int ySide, int zSide)
        {
            this.id = id;
            this.volume = xSide * ySide * zSide;
            this.weight = weight;
            this.maxDimension = Math.Max(xSide, Math.Max(ySide, zSide));
            this.description = description;
            this.area = ((xSide*ySide) *4) + ((ySide*zSide)*2);
            this.isFragile = false;
            this.insuranceValue = 0;
            this.xSide = xSide;
            this.ySide = ySide;
            this.zSide = zSide;
        }

        public object Clone()
        {
            Cuboid clonedCuboid = new Cuboid(this.id, this.weight, this.description, this.xSide, this.ySide, this.zSide);

            return clonedCuboid;
        }
    }
}
