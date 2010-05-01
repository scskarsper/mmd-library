using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public interface IPMMBoneData
    {
        IPMMModel                       Owner           { get; }
        IPMMBoneInitKeyCollection       InitKeys        { get; set; }
        IPMMBoneKeyCollection           Keys            { get; set; }
        IPMMBoneStateCollection         States          { get; set; }
    }

    public class PMMBoneData : IPMMBoneData
    {
        public IPMMModel                Owner           { get; private set; }
        public IPMMBoneInitKeyCollection InitKeys       { get; set; }
        public IPMMBoneKeyCollection    Keys            { get; set; }
        public IPMMBoneStateCollection  States          { get; set; }

        public PMMBoneData(IPMMModel owner)
        {
            Owner   = owner;
        }
    }

    public interface IPMMBoneKey : IPMMBoneInitKey
    {
        uint                            DataIndex       { get; set; }
    }

    public class PMMBoneKey : PMMBoneInitKey, IPMMBoneKey
    {
        public uint                     DataIndex       { get; set; }
    }

    public interface IPMMBoneKeyCollection : IList<IPMMBoneKey>
    {
    }

    public class PMMBoneKeyCollection : List<IPMMBoneKey>, IPMMBoneKeyCollection
    {
    }

    public interface IPMMBoneInitKey : IPMMKey
    {
        PMMIPL                          IplR            { get; set; }
        PMMIPL                          IplX            { get; set; }
        PMMIPL                          IplY            { get; set; }
        PMMIPL                          IplZ            { get; set; }
        GenVector3                      Translation     { get; set; }
        GenVector4                      Rotation        { get; set; }
        byte                            Selected        { get; set; }
    }

    public class PMMBoneInitKey : PMMKey, IPMMBoneInitKey
    {
        public PMMIPL                   IplR            { get; set; }
        public PMMIPL                   IplX            { get; set; }
        public PMMIPL                   IplY            { get; set; }
        public PMMIPL                   IplZ            { get; set; }
        public GenVector3               Translation     { get; set; }
        public GenVector4               Rotation        { get; set; }
        public byte                     Selected        { get; set; }
    }

    public interface IPMMBoneInitKeyCollection : IList<IPMMBoneInitKey>
    {
    }

    public class PMMBoneInitKeyCollection : List<IPMMBoneInitKey>, IPMMBoneInitKeyCollection
    {
    }

    public interface IPMMBoneState
    {
        GenVector3                      Translation     { get; set; }
        GenVector4                      Rotation        { get; set; }
        float                           RotationX       { get; set; }
        byte                            Moved           { get; set; }
        byte                            Selected        { get; set; }
    }

    public class PMMBoneState : IPMMBoneState
    {
        public GenVector3               Translation     { get; set; }
        public GenVector4               Rotation        { get; set; }
        public float                    RotationX       { get; set; }
        public byte                     Moved           { get; set; }
        public byte                     Selected        { get; set; }
    }

    public interface IPMMBoneStateCollection : IList<IPMMBoneState>
    {
    }

    public class PMMBoneStateCollection : List<IPMMBoneState>, IPMMBoneStateCollection
    {
    }
}
