﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BoxesObject
{
    /// <summary>
    /// An object of the type Sphere, which inherts from I3DObject
    /// </summary>
    [Serializable]
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

        internal Sphere(int id, decimal weight, string description, bool isFragile, int radius)
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
        /// <summary>
        /// Makes a deep copy of the object 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Sphere clonedSphere = new Sphere(this.Id, this.Weight, this.Description, this.IsFragile, this.radius);

            return clonedSphere;
        }
        /// <summary>
        /// Delivers a detailed description of the object through a string. Written with one detail on each line.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string stringRepresentation = "";
            int side = this.radius * 2;

            stringRepresentation = "ID: " + this.Id.ToString()
                                + "\n Description: " + this.Description
                                + "\n Weight: " + this.Weight.ToString() + "(kg)"
                                + "\n Dimensions: " + side.ToString() + " x " + side.ToString() + " x " + side.ToString() + "(cm)"
                                + "\n Sphere radius: " + this.radius.ToString() + "(cm)"
                                + "\n Fragile: " + this.IsFragile;

            return stringRepresentation;
        }
    }
}
