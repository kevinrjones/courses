using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient
{
    public class StreamDecorator : Stream
    {
        private readonly Stream _stream;

        public StreamDecorator(Stream stream)
        {
            _stream = stream;
        }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }

        public override bool CanRead
        {
            get { return _stream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _stream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _stream.CanWrite; }
        }

        public override long Length
        {
            get { return _stream.Length; }
        }

        public override long Position
        {
            get { return _stream.Position; }
            set { _stream.Position = value; }
        }
    }

    public class BandwidthStream : StreamDecorator
    {
        private Stopwatch sw;
        private int totalBytesRead;

        public BandwidthStream(Stream stream) : base(stream)
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (sw == null)
            {
                sw = Stopwatch.StartNew();
            }
            int bytesRead = base.Read(buffer, offset, count);
            totalBytesRead += bytesRead;

            double bandwidth = ((double) totalBytesRead/1000)/(sw.ElapsedMilliseconds/1000);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Bandwidth {0} kb/sec", bandwidth);

            return bytesRead;
        }

        public override void Close()
        {
            sw.Stop();
            base.Close();
        }
    }
}
