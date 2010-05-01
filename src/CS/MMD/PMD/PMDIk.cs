using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDIk
    {
        short                           Ik              { get; set; }   // short
        short                           Target          { get; set; }   // short
      //byte                            Count           { get; set; }   // byte
        short                           Value1          { get; set; }   // short
        float                           Value2          { get; set; }   // float
        IList<short>                    Effects         { get; set; }   // short[Count]
    }

    public class PMDIk : IPMDIk
    {
        public short                    Ik              { get; set; }
        public short                    Target          { get; set; }
        public short                    Value1          { get; set; }
        public float                    Value2          { get; set; }
        public IList<short>             Effects         { get; set; }

        public PMDIk()
        {
            Effects = new List<short>();
        }
    }

    public interface IPMDIkCollection : IList<IPMDIk>
    {
    }

    public class PMDIkCollection : List<IPMDIk>, IPMDIkCollection
    {
    }
}
