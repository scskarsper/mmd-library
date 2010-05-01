using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public interface IPMMHeader
    {
        string                          Magic           { get; set; }   // char[30]
        int                             ViewWidth       { get; set; }   // int
        int                             ViewHeight      { get; set; }   // int
        int                             FrameWidth      { get; set; }   // int
        float                           ViewAngle       { get; set; }   // float
        byte[]                          Flags           { get; set; }   // char[6]
	    byte                            ModelNo         { get; set; }   // BYTE
	    byte                            ModelCount      { get; set; }   // BYTE
    }

    public class PMMHeader : IPMMHeader
    {
        public string                   Magic           { get; set; }
        public int                      ViewWidth       { get; set; }
        public int                      ViewHeight      { get; set; }
        public int                      FrameWidth      { get; set; }
        public float                    ViewAngle       { get; set; }
        public byte[]                   Flags           { get; set; }
	    public byte                     ModelNo         { get; set; }
	    public byte                     ModelCount      { get; set; }

        public PMMHeader()
        {
        }
    }
}
