using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    /// <summary>
    /// An interface which supplies BoxesObject with a common set of propertys
    /// </summary>
    public interface I3DObject : ICloneable
    {
        int Id { get; }
        long Volume { get; }
        decimal Weight { get; }
        long MaxDimension { get; }
        string Description { get; }
        int Area { get; }
        bool IsFragile { get; }
        decimal InsuranceValue { get; }

    }
}
