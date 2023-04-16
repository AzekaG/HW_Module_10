using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static task3_queue.Program;

namespace task3_queue
{


    internal class Program
    {
 


        class ClientInCafe
        {
            public string Name { set; get; }
            public double Time { set; get; }

            public ClientInCafe()
            {
                Name = string.Empty;
                Time = 0;
            }
            public ClientInCafe(string Name, double time)
            {
                this.Name = Name;
                this.Time = time;
            }
            public void IncludeClient()
            {
                int choice;
                Console.WriteLine("Enter a name of client : ");
                this.Name = Console.ReadLine();
                Console.WriteLine("do you wanna to make reserve? 1-yes , 2 - no");
                choice = int.Parse(Console.ReadLine());
                if (choice == 2) { Time = 23.59; return; }

                Console.WriteLine("Enter the time in format   h.mm   12.30.");
                string tempTime = Console.ReadLine();
                string[] temp = tempTime.Split('.');

                this.Time = double.Parse(temp[0])%24+ (double.Parse(temp[1])%60/100);
                
            }
            public void OutputInfoClient()
            {
                Console.WriteLine(Name + " " + Time);
            }





        }


        class IClientInCafe
        {
            
            List <ClientInCafe> clientInCafe;
            ClientInCafe Client;
            Queue <ClientInCafe> queueReserve;
            public IClientInCafe() 
            {
                clientInCafe = new List <ClientInCafe>();
                queueReserve = new Queue <ClientInCafe>(2);
            }

            public void IncludeClient() 
            {
                int choice;
                Console.WriteLine("lets make List of client for Today : ");
                Console.WriteLine("in this menu you can add client without Reserve , or make client Reserve.Lets start : ");
                do
                {
                    Client = new ClientInCafe();
                    Console.WriteLine("Enter an information of client : ");
                    Client.IncludeClient();
                    Client.OutputInfoClient();
                    Console.WriteLine("Do you want to add a client ?  yes-1 , no - 2");
                    choice = int.Parse(Console.ReadLine()); 
                    clientInCafe.Add(Client);
                    if (choice == 2) { break; }
                    choice = 1;
                   
                } while (choice ==1);
                MakeQueue();
            }
            public void MakeQueue()
            {
                
               var makeQueue = from clients in clientInCafe
                               orderby clients.Time
                               select clients;
                
                foreach (var client in makeQueue)
                {
                    
                    queueReserve.Enqueue(client);
                }
               
            }


            public void WorkingDay()
            {
                Console.WriteLine("Now is working day. Now clients will go to us in this queue : ");
               while(queueReserve.Count > 0)
                {
                    Console.WriteLine(queueReserve.Dequeue().Name);   
                }
            }
           
        }
        static void Main(string[] args)
        {

           
            IClientInCafe clientInCafe = new IClientInCafe();
            clientInCafe.IncludeClient();
            clientInCafe.WorkingDay();

        }
    }
}
