using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public interface IPMMFrameWindow
    {
        uint                            FrameWidnowCount        { get; set; }
        uint                            FrameWidnowPosition     { get; set; }
        uint                            FrameWidnowLast         { get; set; }
        uint                            BoneWindowFace          { get; set; }
        byte                            PlayWindow_TraceModel   { get; set; }
        byte                            PlayWindow_Loop         { get; set; }
        byte                            PlayWindow_FrameStart   { get; set; }
        byte                            PlayWindow_FrameStop    { get; set; }
        uint                            PlayWindow_St           { get; set; }
        uint                            PlayWindow_Ed           { get; set; }
    }

    public class PMMFrameWindow : IPMMFrameWindow
    {
        public uint                     FrameWidnowCount        { get; set; }
        public uint                     FrameWidnowPosition     { get; set; }
        public uint                     FrameWidnowLast         { get; set; }
        public uint                     BoneWindowFace          { get; set; }
        public byte                     PlayWindow_TraceModel   { get; set; }
        public byte                     PlayWindow_Loop         { get; set; }
        public byte                     PlayWindow_FrameStart   { get; set; }
        public byte                     PlayWindow_FrameStop    { get; set; }
        public uint                     PlayWindow_St           { get; set; }
        public uint                     PlayWindow_Ed           { get; set; }
    }

    public class IPMMWav
    {
        byte                            Enable          { get; set; }
        string                          File            { get; set; }   // char[256]
    }

    public class PMMWav : IPMMWav
    {
        public byte                     Enable          { get; set; }
        public string                   File            { get; set; } 
    }

    public class IPMMAvi
    {
        GenVector3                      Position        { get; set; }
        string                          File            { get; set; }   // char[256]
        uint                            AviDisp         { get; set; }
    }

    public class PMMAvi : IPMMAvi
    {
        public GenVector3               Position        { get; set; }
        public string                   File            { get; set; }
        public uint                     AviDisp         { get; set; }
    }

    public interface IPMMBmp
    {
        GenVector3                      Position        { get; set; }
        string                          File            { get; set; }   // char[256]
        byte                            BmpDisp         { get; set; }
    }

    public class PMMBmp : IPMMBmp
    {
        public GenVector3               Position        { get; set; }
        public string                   File            { get; set; }
        public byte                     BmpDisp         { get; set; }
    }

    public interface IPMMViewInfo
    {
	    byte                            DisplayInfo     { get; set; }
        byte                            DisplayGrid     { get; set; }
        byte                            DisplayShadow   { get; set; }
	    float	                        FPS             { get; set; }
	    uint                            CaptureMode     { get; set; }
    }

    public class PMMViewInfo : IPMMViewInfo
    {
	    public byte                     DisplayInfo     { get; set; }
        public byte                     DisplayGrid     { get; set; }
        public byte                     DisplayShadow   { get; set; }
	    public float	                FPS             { get; set; }
	    public uint                     CaptureMode     { get; set; }
    }
}
