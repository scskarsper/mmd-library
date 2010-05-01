using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MikuMiku
{
    public class FileReader : IDisposable
    {
        public Stream           BaseStream      { get { return Reader.BaseStream; } }
        public BinaryReader     Reader          { get; private set; }
        public Encoding         Encoding        { get; private set; }

        public FileReader(Stream s)
        {
            Reader      = new BinaryReader(s);
            Encoding    = Encoding.Default;
        }

        public void Dispose()
        {
            if(null != Reader)
            {
                Reader.Close();
                Reader  = null;
            }
        }

        protected C ReadCollection<C, I>(int count, Func<I> reader) where C : IList<I>, new()
        {
            var collection          = new C();

            for(int i= 0; i < count; ++i)
                collection.Add(reader());

            return collection;
        }

        protected string ReadString(int length)
        {
            var data                = Reader.ReadBytes(length);
            var index               = Array.IndexOf(data, (byte)0);
            var value               = index < 0 ? Encoding.GetString(data) : Encoding.GetString(data, 0, index);
          //value                   = index < 0 ? value.Trim('\0', (char)0xFD);

            return value;
        }

        protected GenVector2 ReadVector2()
        {
            var x   = Reader.ReadSingle();
            var y   = Reader.ReadSingle();
            return new GenVector2() { X= x, Y= y };
        }

        protected GenVector3 ReadVector3()
        {
            var x   = Reader.ReadSingle();
            var y   = Reader.ReadSingle();
            var z   = Reader.ReadSingle();
            return new GenVector3() { X= x, Y= y, Z= z };
        }

        protected GenVector4 ReadVector4()
        {
            var x   = Reader.ReadSingle();
            var y   = Reader.ReadSingle();
            var z   = Reader.ReadSingle();
            var w   = Reader.ReadSingle();
            return new GenVector4() { X= x, Y= y, Z= z, W= w };
        }

        protected GenColor3 ReadColor3()
        {
            var r   = Reader.ReadSingle();
            var g   = Reader.ReadSingle();
            var b   = Reader.ReadSingle();
            return new GenColor3() { R= r, G= g, B= b };
        }

        protected GenColor4 ReadColor4()
        {
            var r   = Reader.ReadSingle();
            var g   = Reader.ReadSingle();
            var b   = Reader.ReadSingle();
            var a   = Reader.ReadSingle();
            return new GenColor4() { R= r, G= g, B= b, A= a };
        }
        
        [System.Diagnostics.Conditional("DEBUG")]
        protected void DebugPrintOffset(string title)
        {
            System.Diagnostics.Debug.WriteLine(title + "- Position: " + BaseStream.Position.ToString("X8"));
        }
    }
}
