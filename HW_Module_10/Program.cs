using System.Collections.Generic;
using System.Net.Http.Headers;

namespace HW_Module_10
{
    internal class Program
    {

        /**/



        class Corporation
        {
            public Dictionary<string, string> employersbase;

            public Corporation()
            {
                employersbase = new Dictionary<string, string>();
            }
            public Corporation(Dictionary<string, string> employersbase)
            {
                this.employersbase = employersbase;
            }
            public void AddNewEmployer(string Name, string Pass)
            {
                employersbase.Add(Name, Pass);
            }
            public void AddNewEmployer()
            {
                int temp = 0;
                do
                {
                    Console.WriteLine("Enter a Name : ");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Enter a pass :");
                    string Pass = Console.ReadLine();
                    if (Name.Length != 0 && Pass.Length != 0)
                    {
                        employersbase.Add(Name, Pass);
                        temp++;
                    }
                    else { temp = 0; Console.WriteLine("Incorrect data!"); };
                } while (temp == 0);

            }
            public void DeleteEmployer()
            {
                Console.WriteLine("Choose an Employer or push 0 for Exit");
                OutputEmployers();
                int choice = int.Parse(Console.ReadLine());
                if (choice > 0 && choice <= employersbase.Count)
                    employersbase.Remove(employersbase.ElementAt(choice - 1).Key);
                else Console.WriteLine("Incorrect choice!");
                OutputEmployers();

            }
            public void OutputEmployers()
            {
                if (employersbase.Count == 0) Console.WriteLine("Empty Baze!");
                int count = 0;
                foreach (var el in employersbase)
                    Console.WriteLine(++count + " " + el.Key);


            }

            public void ChangeEmployerInfo()
            {
                if (employersbase.Count == 0) { Console.WriteLine("Empty Baze!"); return; }
                Console.WriteLine("Choose an employer : ");
                OutputEmployers();
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter a Pass : ");
                string Pass = Console.ReadLine();
                if (employersbase.ElementAt(choice - 1).Value == Pass)
                {

                    if (choice > 0 && choice <= employersbase.Count)
                        employersbase.Remove(employersbase.ElementAt(choice - 1).Key);
                    else
                        Console.WriteLine("Incorrect choice!");
                    Console.WriteLine("Enter a new name : ");
                    string NewName = Console.ReadLine();
                    Console.WriteLine("Enter a new pass : ");
                    Pass = Console.ReadLine();
                    employersbase.Add(NewName, Pass);
                }
                else Console.WriteLine("Incorrect data!!");

            }
            public void TakeInfoAboutPass()
            {

                OutputEmployers();
                if (employersbase.Count == 0) { Console.WriteLine("Empty Baze!"); return; }
                Console.WriteLine("Choose an employer : ");
                OutputEmployers();
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine(employersbase.ElementAt(choice - 1).Key + "   :   " + employersbase.ElementAt(choice - 1).Value);

            }
        }



        class InterfaceClient
        {
            public Corporation corporation;
            public InterfaceClient(Corporation corporation) { this.corporation = corporation; }
            void Menu()
            {
                int choice;
                do
                {
                    Console.WriteLine("Choose an action : " +
                        "\n1:Add a new Employer : " +
                        "\n2:Delete an employer : " +
                        "\n3:Change Employer info : " +
                        "\n4:Get Info about Employer pass :" +
                        "\n5:Output Employers : "+
                        "\n0 : Exit");

                    choice = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            {
                                corporation.AddNewEmployer();
                                corporation.OutputEmployers();
                                Console.WriteLine();
                            }
                            break;
                        case 2:
                            {
                                corporation.DeleteEmployer();
                                corporation.OutputEmployers();
                                Console.WriteLine();
                            }
                            break;
                        case 3:
                            {
                                Console.Clear();
                                corporation.ChangeEmployerInfo();
                                corporation.OutputEmployers();
                                Console.WriteLine();
                            }
                            break;
                        case 4:
                            {
                                Console.Clear();
                                corporation.TakeInfoAboutPass();
                                Console.WriteLine();
                            }
                            
                            break;
                            case 5:
                            {
                                corporation.OutputEmployers();
                                Console.WriteLine();
                            }
                            break;
                        case 0: return;
                        default: choice = -1; break;
                    }
                } while (choice > 0);


            }
            static void Main(string[] args)
            {
                Dictionary<string, string> MyFirm = new Dictionary<string, string>();
                MyFirm.Add("Sergii", "1111");
                MyFirm.Add("Oleg", "2222");
                MyFirm.Add("Victor", "3333");
                MyFirm.Add("San9", "4444");
                InterfaceClient corporation = new InterfaceClient(new Corporation(MyFirm));
                corporation.Menu();


            }
        }
    }
}