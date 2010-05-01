using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDBone
    {
        string                          Name            { get; set; }   // char[20]
        short                           Parent          { get; set; }   // short
        short                           Child           { get; set; }   // short
        short                           Type            { get; set; }   // short
        byte                            IKBone          { get; set; }   // byte
        GenVector3                      Position        { get; set; }   // float[3]
    }

    public class PMDBone : IPMDBone
    {
        public string                   Name            { get; set; }
        public short                    Parent          { get; set; }
        public short                    Child           { get; set; }
        public short                    Type            { get; set; }
        public byte                     IKBone          { get; set; }
        public GenVector3               Position        { get; set; }
    }

    public interface IPMDBoneCollection : IList<IPMDBone>
    {
    }

    public class PMDBoneCollection : List<IPMDBone>, IPMDBoneCollection
    {
    }
}
