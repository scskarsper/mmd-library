using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public interface IPMMFaceData
    {
        IPMMModel                       Owner           { get; }
        IPMMFaceInitKeyCollection       InitKeys        { get; set; }
        IPMMFaceKeyCollection           Keys            { get; set; }
        IList<float>                    States          { get; set; }
    }

    public class PMMFaceData : IPMMFaceData
    {
        public IPMMModel                Owner           { get; private set; }
        public IPMMFaceInitKeyCollection InitKeys       { get; set; }
        public IPMMFaceKeyCollection    Keys            { get; set; }
        public IList<float>             States          { get; set; }

        public PMMFaceData(IPMMModel owner)
        {
            Owner   = owner;
        }
    }

    public interface IPMMFaceKey : IPMMFaceInitKey
    {
        uint                            DataIndex       { get; set; }
    }

    public class PMMFaceKey : PMMFaceInitKey, IPMMFaceKey
    {
        public uint                     DataIndex       { get; set; }
    }

    public interface IPMMFaceKeyCollection : IList<IPMMFaceKey>
    {
    }

    public class PMMFaceKeyCollection : List<IPMMFaceKey>, IPMMFaceKeyCollection
    {
    }

    public interface IPMMFaceInitKey : IPMMKey
    {
        float                           SkinValue       { get; set; }
        byte                            Selected        { get; set; }
    }

    public class PMMFaceInitKey : PMMKey, IPMMFaceInitKey
    {
        public float                    SkinValue       { get; set; }
        public byte                     Selected        { get; set; }
    }

    public interface IPMMFaceInitKeyCollection : IList<IPMMFaceInitKey>
    {
    }

    public class PMMFaceInitKeyCollection : List<IPMMFaceInitKey>, IPMMFaceInitKeyCollection
    {
    }
}
