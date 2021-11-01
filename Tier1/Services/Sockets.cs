using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using Tier1.Model;

namespace Tier1.Services
{
    public class Sockets:ISockets
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        public void Connect()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8500);
            socket.Connect(ipEndPoint);
            Console.WriteLine("Connect success!");
        }
        
        public string SendAndReceive(Request request)
        {
            Thread.Sleep(100);
            var json = JsonSerializer.Serialize(request);
            Console.WriteLine("send:" + json);
            byte[] bytes = Encoding.UTF8.GetBytes(json + ";");
            socket.Send(bytes);
            string recv = "";
            byte[] recvBytes = new byte[1024];
            int bytesa;
            bytesa = socket.Receive(recvBytes, recvBytes.Length, 0);
            recv += Encoding.UTF8.GetString(recvBytes, 0, bytesa);
            Console.WriteLine("receive ok " + recv);
            return recv;
        }
        
        public string Register(int id, string name, string mail, string password)
        {
            Request request = new Request()
            {
                Type = RequestTypes.REGISTER.ToString(),
                Args = new Customer {Id = id, Name  = name, Mail = mail, Password = password}
            };
            string recv = SendAndReceive(request);
            Message message = JsonSerializer.Deserialize<Message>(recv);
            return message.ToString();
        }
    }
}