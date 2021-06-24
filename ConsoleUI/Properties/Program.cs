using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Welcome to the Mac Raffle");
            GetUserInfo();
            PrintGuestsName();
            GetRaffleNumber(guests);
            PrintWinner();
        }
        //Start writing your code here
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();
        private static int winningNumber;

        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            message = Console.ReadLine();
            return message = message.ToLower();
        }

        private static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private static void GetUserInfo()
        {
            string name = "";
            while (name != "yes")

            {
                name = GetUserInput("Please enter a name for the raffle.");
                raffleNumber = GenerateRandomNumber(min, max);

                if (guests.ContainsValue(name) == true)
                {
                    while (guests.ContainsValue(name) == true)
                    {
                        name = GetUserInput("Name is already entered. Please enter another guest.");
                    }
                }
                else if (guests.ContainsKey(raffleNumber) == true)
                {
                    while (guests.ContainsKey(raffleNumber) == true)
                    {
                        raffleNumber = GenerateRandomNumber(min, max);
                    }
                }
                if (name != "yes")
                {
                    AddGuestsInRaffle(raffleNumber, name);
                }
            }
        }
        //writing out the guest name
        private static void PrintGuestsName()
        {
            foreach (KeyValuePair<int, string> guest in guests)
                Console.WriteLine(guest);
        }

        private static void GetRaffleNumber(Dictionary<int, string> givenDict)
        {
            Random raffleRandom = new Random();
            List<int> raffleNum = new List<int> { };
            int num = raffleRandom.Next();
            foreach (KeyValuePair<int, string> guest in guests)
            {
                raffleNum.Add(guest.Key);
            }
            for (int n = 0; n < 1; n++)
            {
                num = raffleRandom.Next(raffleNum.Count);
            }
            winningNumber = raffleNum[num];
        }
        //choosing the winner
        private static void PrintWinner()
        {
            Console.WriteLine($"The winner of the new Mac is...{guests[winningNumber]} with raffle number: {winningNumber}.");
        }

        //adding guests to raffle
        private static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            guest.Add (raffleNumber, guest);
        }


        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
