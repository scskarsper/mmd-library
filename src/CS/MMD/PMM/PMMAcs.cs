using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public interface IPMMAcsData
    {
	    byte                            AcsNo           { get; set; }
	    uint                            AcsFrameUpNo    { get; set; }
	    byte                            AcsCount        { get; set; }
        IList<string>                   WindowNames     { get; set; }
        IPMMAcsCollection               Acses           { get; set; }
    }

    public class PMMAcsData : IPMMAcsData
    {
	    public byte                     AcsNo           { get; set; }
	    public uint                     AcsFrameUpNo    { get; set; }
	    public byte                     AcsCount        { get; set; }
        public IList<string>            WindowNames     { get; set; }
        public IPMMAcsCollection        Acses           { get; set; }
    }

    public interface IPMMAcs
    {
        byte                            Index           { get; set; }
        string                          Name            { get; set; }
	    string                          File            { get; set; }
	    byte                            ID              { get; set; }
        IPMMAcsInitKey                  InitKey         { get; set; }
        IPMMAcsKeyCollection            Keys            { get; set; }
        IPMMAcsState                    State           { get; set; }
    }

    public class PMMAcs : IPMMAcs
    {
        public byte                     Index           { get; set; }
        public string                   Name            { get; set; }
	    public string                   File            { get; set; }
	    public byte                     ID              { get; set; }
        public IPMMAcsInitKey           InitKey         { get; set; }
        public IPMMAcsKeyCollection     Keys            { get; set; }
        public IPMMAcsState             State           { get; set; }
    }

    public interface IPMMAcsCollection : IList<IPMMAcs>
    {
    }

    public class PMMAcsCollection : List<IPMMAcs>, IPMMAcsCollection
    {
    }

    public interface IPMMAcsInitKey : IPMMKey
    {
	    byte                            Display         { get; set; }
	    uint                            Model           { get; set; }
        uint                            Bone            { get; set; }
	    GenVector3                      Position        { get; set; }
	    GenVector3                      Angle           { get; set; }
	    uint                            Size            { get; set; }
	    byte                            Shadow          { get; set; }
	    byte                            Selected        { get; set; }
    }

    public class PMMAcsInitKey : PMMKey, IPMMAcsInitKey
    {
	    public byte                     Display         { get; set; }
	    public uint                     Model           { get; set; }
        public uint                     Bone            { get; set; }
	    public GenVector3               Position        { get; set; }
	    public GenVector3               Angle           { get; set; }
	    public uint                     Size            { get; set; }
	    public byte                     Shadow          { get; set; }
	    public byte                     Selected        { get; set; }
    }

    public interface IPMMAcsKey : IPMMAcsInitKey
    {
        uint                            DataIndex       { get; set; }
    }

    public class PMMAcsKey : PMMAcsInitKey, IPMMAcsKey
    {
        public uint                     DataIndex       { get; set; }
    }

    public interface IPMMAcsKeyCollection : IList<IPMMAcsKey>
    {
    }

    public class PMMAcsKeyCollection : List<IPMMAcsKey>, IPMMAcsKeyCollection
    {
    }

    public interface IPMMAcsState
    {
	    byte                            Display         { get; set; }
	    uint                            Model           { get; set; }
        uint                            Bone            { get; set; }
	    GenVector3                      Angle           { get; set; }
        uint                            Size            { get; set; }
	    GenVector3                      Position        { get; set; }
	    byte                            Shadow          { get; set; }
    }

    public class PMMAcsState : IPMMAcsState
    {
	    public byte                     Display         { get; set; }
	    public uint                     Model           { get; set; }
        public uint                     Bone            { get; set; }
	    public GenVector3               Angle           { get; set; }
        public uint                     Size            { get; set; }
	    public GenVector3               Position        { get; set; }
	    public byte                     Shadow          { get; set; }
    }
}
