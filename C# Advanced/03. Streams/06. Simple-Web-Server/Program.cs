using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _06._Simple_Web_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var tcpListener = new TcpListener(IPAddress.Any, 4000);
            tcpListener.Start();
            Console.WriteLine("Listening on port {0}...", 4000);

            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    byte[] request = new byte[4096];
                    stream.Read(request, 0, 4096);
                    Console.WriteLine(Encoding.UTF8.GetString(request));

                    string html = string.Format("{0}{1}{2}{3} - {4}{2}{1}{0}",
                        "<html>", "<body>", "<h1>", "Welcome to my awesome site!", DateTime.Now);
                    byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                    stream.Write(htmlBytes, 0, htmlBytes.Length);
                }
            }

        }
    }
}
