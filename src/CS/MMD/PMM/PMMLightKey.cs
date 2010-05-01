using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public interface IPMMLightData
    {
        IPMMLightInitKey                InitKey         { get; set; }
        IPMMLightKeyCollection          Keys            { get; set; }
        IPMMLightState                  State           { get; set; }
    }

    public class PMMLightData : IPMMLightData
    {
        public IPMMLightInitKey         InitKey         { get; set; }
        public IPMMLightKeyCollection   Keys            { get; set; }
        public IPMMLightState           State           { get; set; }
    }

    public interface IPMMLightKey : IPMMLightInitKey
    {
        uint                            DataIndex       { get; set; }
    }

    public class PMMLightKey : PMMLightInitKey, IPMMLightKey
    {
        public uint                     DataIndex       { get; set; }
    }

    public interface IPMMLightKeyCollection : IList<IPMMLightKey>
    {
    }

    public class PMMLightKeyCollection : List<IPMMLightKey>, IPMMLightKeyCollection
    {
    }

    public interface IPMMLightInitKey : IPMMKey
    {
        GenVector3                      Color           { get; set; }
	    GenVector3                      Direction       { get; set; }
        byte                            Selected        { get; set; }
    }

    public class PMMLightInitKey : PMMKey, IPMMLightInitKey
    {
        public GenVector3               Color           { get; set; }
	    public GenVector3               Direction       { get; set; }
        public byte                     Selected        { get; set; }
    }

    public interface IPMMLightInitKeyCollection : IList<IPMMLightInitKey>
    {
    }

    public class PMMLightInitKeyCollection : List<IPMMLightInitKey>, IPMMLightInitKeyCollection
    {
    }

    public interface IPMMLightState
    {
        GenVector3                      Color           { get; set; }
	    GenVector3                      Direction       { get; set; }
    }

    public class PMMLightState : IPMMLightState
    {
        public GenVector3               Color           { get; set; }
	    public GenVector3               Direction       { get; set; }
    }

    public interface IPMMLightStateCollection : IList<IPMMLightState>
    {
    }

    public class PMMLightStateCollection : List<IPMMLightState>, IPMMLightStateCollection
    {
    }
}
