using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _09._HTTP_Server
{
    class Program
    {
        private const int PortNumber = 8081;

        public static void Main()
        {
            var listener = new TcpListener(IPAddress.Any, PortNumber);
            listener.Start();
            Console.WriteLine($"Listening on port {PortNumber}...");
            int readBytes;

            while (true)
            {
                using (var stream = listener.AcceptTcpClient().GetStream())
                {
                    var buffer = new byte[4096];
                    readBytes = stream.Read(buffer, 0, buffer.Length);
                    var requestStr = Encoding.UTF8.GetString(buffer);

                    var urlStart = requestStr.IndexOf("/");
                    var urlEnd = requestStr.IndexOf(" ", urlStart);
                    var url = requestStr.Substring(urlStart, urlEnd - urlStart);

                    var resource = string.Empty;
                    var hasError = false;
                    switch (url)
                    {
                        case "/":
                            resource = "../../index.html";
                            break;
                        case "/info":
                            resource = "../../info.html";
                            break;
                        default:
                            hasError = true;
                            resource = "../../error.html";
                            break;
                    }

                    byte[] responseHeader;
                    if (!hasError)
                    {
                        responseHeader =
                            Encoding.UTF8.GetBytes(string.Format("HTTP/1.1 200 OK Content-Type: text/html\r\n\r\n"));
                    }
                    else
                    {
                        responseHeader =
                            Encoding.UTF8.GetBytes(
                                string.Format("HTTP/1.1 404 Not Found Content-Type: text/html\r\n\r\n"));
                    }
                    stream.Write(responseHeader, 0, responseHeader.Length);

                    using (var source = new FileStream(resource, FileMode.OpenOrCreate, FileAccess.Read))
                        while ((readBytes = source.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            stream.Write(buffer, 0, readBytes);
                        }
                }
            }
        }
    }
}
