using System;

namespace Tier1.Services
{
    public class Client
    {
        private static Client client = new Client();
        private static int checkCode = 0;
    
        ISockets sockets=new Sockets();
    
        private Client()
        {
        }
        public static Client getInstance()
        {
            return client;
        }

        public void Connect()
        {
            if (checkCode==0)
            {
                sockets.Connect();
                checkCode = 1;
            }
            Console.WriteLine("already connect");
        }

        public string RegisterCustomer(int id, string name, string mail, string password)
        {
            string result=sockets.Register(id,name, mail,password);

            return result;
        }
    }
}