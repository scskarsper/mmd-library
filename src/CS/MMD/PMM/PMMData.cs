using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public interface IPMMData
    {
        string                          FileName        { get; set; }
        IPMMHeader                      Header          { get; set; }
        IList<string>                   ModelNames      { get; set; }
        IPMMModelCollection             Models          { get; set; }
        IPMMCameraData                  CameraData      { get; set; }
        IPMMLightData                   LightData       { get; set; }
        IPMMAcsData                     AcsData         { get; set; }
        IPMMFrameWindow                 FrameWindow     { get; set; }
        IPMMWav                         Wav             { get; set; }
        IPMMAvi                         Avi             { get; set; }
        IPMMBmp                         Bmp             { get; set; }
        IPMMViewInfo                    ViewInfo        { get; set; }
    }

    public class PMMData : IPMMData
    {
        public string                   FileName        { get; set; }
        public IPMMHeader               Header          { get; set; }
        public IList<string>            ModelNames      { get; set; }
        public IPMMModelCollection      Models          { get; set; }
        public IPMMCameraData           CameraData      { get; set; }
        public IPMMLightData            LightData       { get; set; }
        public IPMMAcsData              AcsData         { get; set; }
        public IPMMFrameWindow          FrameWindow     { get; set; }
        public IPMMWav                  Wav             { get; set; }
        public IPMMAvi                  Avi             { get; set; }
        public IPMMBmp                  Bmp             { get; set; }
        public IPMMViewInfo             ViewInfo        { get; set; }

        public static IPMMData FromFile(string file)
        {
            using(var s= File.OpenRead(file))
            {
                var data        = FromStream(s);
                data.FileName   = file;
                return data;
            }
        }

        public static IPMMData FromStream(Stream s)
        {
            using(var r= new PMMReader(s))
                return r.Read();
        }
    }
}
