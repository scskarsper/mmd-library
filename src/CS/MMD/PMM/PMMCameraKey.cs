using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public interface IPMMCameraData
    {
        IPMMCameraInitKey               InitKey         { get; set; }
        IPMMCameraKeyCollection         Keys            { get; set; }
        IPMMCameraState                 State           { get; set; }
    }

    public class PMMCameraData : IPMMCameraData
    {
        public IPMMCameraInitKey        InitKey         { get; set; }
        public IPMMCameraKeyCollection  Keys            { get; set; }
        public IPMMCameraState          State           { get; set; }
    }

    public interface IPMMCameraKey : IPMMCameraInitKey
    {
        uint                            DataIndex       { get; set; }
    }

    public class PMMCameraKey : PMMCameraInitKey, IPMMCameraKey
    {
        public uint                     DataIndex       { get; set; }
    }

    public interface IPMMCameraKeyCollection : IList<IPMMCameraKey>
    {
    }

    public class PMMCameraKeyCollection : List<IPMMCameraKey>, IPMMCameraKeyCollection
    {
    }

    public interface IPMMCameraInitKey : IPMMKey
    {
        uint                            Distance        { get; set; }
        GenVector3                      Position        { get; set; }
        GenVector3                      Angle           { get; set; }
        PMMIPL                          IPL_X           { get; set; }
        PMMIPL                          IPL_Y           { get; set; }
        PMMIPL                          IPL_Z           { get; set; }
        PMMIPL                          IPL_R           { get; set; }
        PMMIPL                          IPL_Distance    { get; set; }
        PMMIPL                          IPL_Parse       { get; set; }
        byte                            IsOrth          { get; set; }
	    uint                            ParseAngle      { get; set; }
        byte                            Selected        { get; set; }
    }

    public class PMMCameraInitKey : PMMKey, IPMMCameraInitKey
    {
        public uint                     Distance        { get; set; }
        public GenVector3               Position        { get; set; }
        public GenVector3               Angle           { get; set; }
        public PMMIPL                   IPL_X           { get; set; }
        public PMMIPL                   IPL_Y           { get; set; }
        public PMMIPL                   IPL_Z           { get; set; }
        public PMMIPL                   IPL_R           { get; set; }
        public PMMIPL                   IPL_Distance    { get; set; }
        public PMMIPL                   IPL_Parse       { get; set; }
        public byte                     IsOrth          { get; set; }
	    public uint                     ParseAngle      { get; set; }
        public byte                     Selected        { get; set; }
    }

    public interface IPMMCameraInitKeyCollection : IList<IPMMCameraInitKey>
    {
    }

    public class PMMCameraInitKeyCollection : List<IPMMCameraInitKey>, IPMMCameraInitKeyCollection
    {
    }

    public interface IPMMCameraState
    {
        GenVector3                      Position        { get; set; }
        GenVector3                      ViewPosition    { get; set; }
        GenVector3                      Angle           { get; set; }
        byte                            IsParse         { get; set; }
    }

    public class PMMCameraState : IPMMCameraState
    {
        public GenVector3               Position        { get; set; }
        public GenVector3               ViewPosition    { get; set; }
        public GenVector3               Angle           { get; set; }
        public byte                     IsParse         { get; set; }
    }

    public interface IPMMCameraStateCollection : IList<IPMMCameraState>
    {
    }

    public class PMMCameraStateCollection : List<IPMMCameraState>, IPMMCameraStateCollection
    {
    }
}
