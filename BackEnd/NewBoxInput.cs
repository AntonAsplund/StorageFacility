using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class NewBoxInput
    {
        public decimal Weight { get; }
        public string Description { get; }
        public bool IsFragile { get; }
        public int LengthX { get; }
        public int LengthY { get; }
        public int LengthZ { get; }

        public NewBoxInput()
        { 
        
        }
        public NewBoxInput(decimal weight, string description,bool isFragile, int lengthX, int lengthY, int lengthZ)
        {
            this.Weight = weight;
            this.Description = description;
            this.IsFragile = isFragile;
            this.LengthX = lengthX;
            this.LengthY = lengthY;
            this.LengthZ = lengthZ;
        }
        public NewBoxInput(decimal weight, string description,bool isFragile, int lengthX)
        {
            this.Weight = weight;
            this.Description = description;
            this.IsFragile = isFragile;
            this.LengthX = lengthX;
        }

    }
}
