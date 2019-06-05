using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5_c_sharp
{
    using System;

    namespace Class
    {
        interface IBasics
        {
            string Name { get; set; }
            string Creator { get; set; }
        }

        public class Organization : IBasics
        {
            string name;
            string creator;

            public string Name { get => name; set => name = value; }
            public string Creator { get => creator; set => creator = value; }

            public Organization(string name, string creator)
            {
                this.Name = name;
                this.Creator = creator;
            }

            public void PrintBasic()
            {
                Console.WriteLine("Name:    " + this.Name + "\nManufacturer:   " + this.Creator);
            }
        }

        public class Insurance_Company : Organization
        {
            public int Work_Time;
            public Insurance_Company(string name, string creator, int work_time)
                : base(name, creator)
            {
                this.Work_Time = work_time;
            }
            public void PrintTime()
            {
                Console.WriteLine("Work time:    " + this.Work_Time);
            }
        }

        public class Oil_Company : Insurance_Company
        {
            public int Price;
            public Oil_Company(string name, string creator, int work_time, int price)
                : base(name, creator, work_time)
            {
                this.Price = price;
            }
            public void PrintPrice()
            {
                Console.WriteLine("Price:    " + this.Price);
            }
        }

        public class Factory : Oil_Company
        {
            public int product_amount;
            public Factory(string name, string creator, int work_time, int price, int product_amount)
                : base(name, creator, work_time, price)
            {
                this.product_amount = product_amount;
            }
            public void PrintAmount()
            {
                Console.WriteLine("Manufactured in this week:    " + this.product_amount);
            }
        }

        class Program
        {
            delegate void Output();
            static void Main(string[] args)
            {
                Organization organization = new Organization("AllSecurity", "Boriss Elcin");
                Insurance_Company insurance_company = new Insurance_Company("BeSecure", "Andrey Kapushko", 5);
                Oil_Company Oil_Company = new Oil_Company("BlackGold", "Satana Ivanovich", 23, 200000);
                Factory factory = new Factory("Kapitoshka", "Tom Edison", 71, 70760340, 500000);
                Output output;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1.Info about organization\n2.Info about insurance company\n3.Info about Oil Company\n4.Info about factory");
                    int selection = 0;
                    try
                    {
                        selection = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Unknown command");
                        Console.ReadKey();
                        continue;
                    }
                    switch (selection)
                    {
                        case 1:
                            output = organization.PrintBasic;
                            output();
                            Console.ReadKey();
                            break;
                        case 2:
                            output = insurance_company.PrintBasic;
                            output += insurance_company.PrintTime;
                            output();
                            Console.ReadKey();
                            break;
                        case 3:
                            output = Oil_Company.PrintBasic;
                            output += Oil_Company.PrintTime;
                            output += Oil_Company.PrintPrice;
                            output();
                            Console.ReadKey();
                            break;
                        case 4:
                            output = factory.PrintBasic;
                            output += factory.PrintTime;
                            output += factory.PrintPrice;
                            output += factory.PrintAmount;
                            output();
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Unknown command");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }
    }
}
