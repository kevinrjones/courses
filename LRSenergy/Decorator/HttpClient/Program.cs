using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("started");
            WebRequest request = WebRequest.Create("http://localhost:8888/decorator");
            WebResponse response = request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            int bytesRead = ReadResponse(new BandwidthStream(responseStream));
            Console.WriteLine("bytes read: " + bytesRead);
            Console.WriteLine("ended");
        }

        private static int ReadResponse(Stream resposeStream)
        {
            int total = 0;
            byte[] buffer = new byte[1024];
            int read = 0;
            while ((read = resposeStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                total += read;
            }

            return total;
        }
    }
}
