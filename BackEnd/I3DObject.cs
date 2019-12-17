using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    interface I3DObject : ICloneable
    {
        int id { get; }
        long volume { get; }
        decimal weight { get; }
        long maxDimension { get; }
        string description { get; }
        bool isFragile { get; }
        decimal insuranceValue { get; }

    }
}
