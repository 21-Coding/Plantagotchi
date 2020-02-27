using System;
using System.Collections.Generic;

namespace Grow.Models
{
    public class Plant
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Hydration { get; set; }
        public int Hunger { get; set; }
        public int Sun { get; set; }
        public int Maturity { get; set; }

        
        public Plant()
        {
            Name = "";
            Species = "";
            Hydration = 20;
            Hunger = 20;
            Sun = 20;
            Maturity = 0;
        }

        public void Water()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Your plant got watered!");
            Hydration += 5;
            Maturity +=5;
        }
        public void Feed()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Your plant got some nutrition!");
            Hunger += 5;
            Maturity +=5;
        }
        public void GiveSunshine()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Your plant soaked up some serious sun");
            Sun +=5;
            Maturity +=5;
        }
      
        
        
        public void Disaster()
        {
            Random randNum = new Random();
            int index = randNum.Next(1, 5);
            if (index == 1)
            {
                Windstorm();
            }
            else if (index == 2)
            {
                AphidAttack();
            }
            else if (index == 3) 
            {
                CloudAttack();
            }
            else
            {
                ClearDay();
            }
        }
        private void Windstorm()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("~~~~There was a crazy windstorm! Hydration is lost~~~~");
            Hydration -= 5;
        }
        private void AphidAttack()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("~~~~Aphids attacked! Your plant needs nutrition~~~~~");
            Hunger -= 5;
        }
        private void CloudAttack()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("~~~~Intense PNW clouds, your plant is desperate for sun~~~~~");
            Sun -= 5;
        }
        private void ClearDay()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("~~~~It was a lovely day and your plant was happy~~~~");
        }

        public void DisplayStats()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine(Name + "'s current stats:");
            Console.WriteLine("Water level: " + Hydration);
            Console.WriteLine("Nutrition level: " + Hunger);
            Console.WriteLine("Sun level: " + Sun);
            Console.WriteLine("Maturation level: " + Maturity);
        }

        public static void StartGame()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("Welcome to the Plantagotchi");
            Console.WriteLine("*********************************");
            Console.Write("Please enter a name for your plant: ");
            string name = Console.ReadLine();
            Console.Write("What species is this plant? ");
            string species = Console.ReadLine();
            Plant plant = new Plant();
            plant.Name = name;
            plant.Species = species;
            Console.WriteLine("**********************************");
            plant.DisplayStats();
            Console.WriteLine("**********************************");
            Console.WriteLine("Are you ready to grow? (yes or no)");
            string response = Console.ReadLine();
            if (response == "yes" || response == "Yes")
            {
                plant.RunGame();
            }
            else
            {
                Console.WriteLine("I guess we'll start over...");
                EndGame();
            }
        }

        public void RunGame()
        {
            if (Hydration == 0 || Sun == 0 || Hunger == 0)
            {
                EndGame();
            }
            else if (Maturity >= 25)
            {
                Harvest();
            }
            else 
            {
                Console.WriteLine("**********************************");
                Console.WriteLine("Today is a new day! Let's see what nature has in store for you today. Do you want to do something with your plant? (yes or no)");
                string input = Console.ReadLine();
                if (input == "yes" || input == "Yes")
                {
                    Console.WriteLine("Choose what to give your plant: (water, food or sun)");
                    string choice = Console.ReadLine();
                    if (choice == "water" || choice == "Water")
                    {
                        Water();
                        Disaster();
                        DisplayStats();
                        RunGame();
                    }
                    else if (choice == "food" || choice == "Food")
                    {
                        Feed();
                        Disaster();
                        DisplayStats();
                        RunGame();
                    }
                    else if (choice == "sun" || choice == "Sun")
                    {
                        GiveSunshine();
                        Disaster();
                        DisplayStats();
                        RunGame();

                    }
                }
                else
                {
                        Disaster();
                        DisplayStats();
                        RunGame();
                }
            }
        }

        public static void EndGame()
        {
            Console.WriteLine("Your plant didn't make it.");
        }
        public static void Harvest()
        {
            Console.WriteLine("Your plant has outgrown its pot! Its time to harvest!");
        }
   }
}