using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class NewBoxInput
    {
        public int Id { get; }
        public decimal Weight { get; }
        public string Description { get; }
        public bool isFragile { get; }
        public int LengthX { get; }
        public int LengthY { get; }
        public int LengthZ { get; }

        public NewBoxInput(int id, decimal weight, string description, int lengthX, int lengthY, int lengthZ)
        {
            this.Id = id;
            this.Weight = weight;
            this.Description = description;
            this.LengthX = lengthX;
            this.LengthY = lengthY;
            this.LengthZ = lengthZ;
        }
        public NewBoxInput(int id, decimal weight, string description, int lengthX)
        {
            this.Id = id;
            this.Weight = weight;
            this.Description = description;
            this.LengthX = lengthX;
        }

    }
}
