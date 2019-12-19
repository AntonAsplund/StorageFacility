﻿using System;
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
        public int Id { get; }
        public long Volume { get; }
        public decimal Weight { get; }
        public long MaxDimension { get; }
        public string Description { get; }
        public int Area { get; }
        public bool IsFragile { get; }
        public decimal InsuranceValue { get; set; }
        public int xSide { get; }
        public int ySide { get; }
        public int zSide { get; }

        public Cuboid(int id, decimal weight, string description, bool isFragile, int xSide, int ySide, int zSide)
        {
            this.Id = id;
            this.Volume = xSide * ySide * zSide;
            this.Weight = weight;
            this.MaxDimension = Math.Max(xSide, Math.Max(ySide, zSide));
            this.Description = description;
            this.Area = ((xSide*ySide) *4) + ((ySide*zSide)*2);
            this.IsFragile = isFragile;
            this.InsuranceValue = 0;
            this.xSide = xSide;
            this.ySide = ySide;
            this.zSide = zSide;
        }

        public object Clone()
        {
            Cuboid clonedCuboid = new Cuboid(this.Id, this.Weight, this.Description, this.IsFragile, this.xSide, this.ySide, this.zSide);

            return clonedCuboid;
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
