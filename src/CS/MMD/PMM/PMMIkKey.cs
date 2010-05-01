using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public interface IPMMIkData
    {
        IPMMModel                       Owner           { get; }
        IPMMIkInitKey                   InitKey         { get; set; }
        IPMMIkKeyCollection             Keys            { get; set; }
        IList<byte>                     States          { get; set; }
    }

    public class PMMIkData : IPMMIkData
    {
        public IPMMModel                Owner           { get; private set; }
        public IPMMIkInitKey            InitKey         { get; set; }
        public IPMMIkKeyCollection      Keys            { get; set; }
        public IList<byte>              States          { get; set; }

        public PMMIkData(IPMMModel owner)
        {
            Owner   = owner;
        }
    }

    public interface IPMMIkKey : IPMMIkInitKey
    {
        uint                            DataIndex       { get; set; }
    }

    public class PMMIkKey : PMMIkInitKey, IPMMIkKey
    {
        public uint                     DataIndex       { get; set; }
    }

    public interface IPMMIkKeyCollection : IList<IPMMIkKey>
    {
    }

    public class PMMIkKeyCollection : List<IPMMIkKey>, IPMMIkKeyCollection
    {
    }

    public interface IPMMIkInitKey : IPMMKey
    {
        byte                            Display         { get; set; }
        byte[]                          IKs             { get; set; }
        byte                            Selected        { get; set; }
    }

    public class PMMIkInitKey : PMMKey, IPMMIkInitKey
    {
        public byte                     Display         { get; set; }
        public byte[]                   IKs             { get; set; }
        public byte                     Selected        { get; set; }
    }
}
