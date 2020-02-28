using System;
using System.Collections.Generic;
using System.Threading;

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
            TypeLineFast("💧💧💧💧" + Environment.NewLine);
            TypeLine("Your plant got watered!" + Environment.NewLine);
            Hydration += 5;
            Maturity +=5;
        }
        public void Feed()
        {
            TypeLineFast("🥄🥄🥄🥄" + Environment.NewLine);
            TypeLine("Your plant got some nutrition!" + Environment.NewLine);
            Hunger += 5;
            Maturity +=5;
        }
        public void GiveSunshine()
        {
            TypeLineFast("🌞 🌞 🌞 🌞" + Environment.NewLine);
            TypeLine("Your plant soaked up some serious sun" + Environment.NewLine);
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
            TypeLineFast("🌪️🌪️🌪️🌪️" + Environment.NewLine);
            TypeLine("~~~~There was a crazy windstorm! Hydration is lost~~~~" + Environment.NewLine);
            Hydration -= 5;
        }
        private void AphidAttack()
        {
            TypeLineFast("🦗🦗🦗🦗" + Environment.NewLine);
            TypeLine("~~~~Aphids attacked! Your plant needs nutrition~~~~~" + Environment.NewLine);
            Hunger -= 5;
        }
        private void CloudAttack()
        {
            TypeLineFast("⛈️⛈️⛈️⛈️" + Environment.NewLine);
            TypeLine("~~~~Intense PNW clouds, your plant is desperate for sun~~~~~" + Environment.NewLine);
            Sun -= 5;
        }
        private void ClearDay()
        {
            TypeLineFast("    🤗    " + Environment.NewLine);
            TypeLine("~~~~It was a lovely day and your plant was happy~~~~" + Environment.NewLine);
        }

        public void DisplayStats()
        {
            TypeLineFast("👇   📈   👇" + Environment.NewLine);
            TypeLineFast("      " + Environment.NewLine);
            TypeLineFast(Name + "'s current stats:" + Environment.NewLine);
            TypeLineFast("Water level: " + Hydration + Environment.NewLine);
            TypeLineFast("Nutrition level: " + Hunger + Environment.NewLine);
            TypeLineFast("Sun level: " + Sun + Environment.NewLine);
            TypeLineFast("Maturation level: " + Maturity + Environment.NewLine);
            TypeLineFast("      " + Environment.NewLine);
            TypeLineFast("☝️   📈   ☝️" + Environment.NewLine);
        }

        public static void StartGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            TypeLineFast("🌱🌱🌱🌱🌱🌱🌱🌱🌱🌱🌱🌱🌱" + Environment.NewLine);
            TypeLine("Welcome to Plantagotchi" + Environment.NewLine);
            TypeLineFast("🌱🌱🌱🌱🌱🌱🌱🌱🌱🌱🌱🌱🌱" + Environment.NewLine);
            TypeLine("✏️  Please enter a name for your plant: " + Environment.NewLine);
            string name = Console.ReadLine();
            TypeLine("🌿  What species is this plant? " + Environment.NewLine);
            string species = Console.ReadLine();
            Plant plant = new Plant();
            plant.Name = name;
            plant.Species = species;
            TypeLineFast("▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️" + Environment.NewLine);
            plant.DisplayStats();
            TypeLineFast("▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️▫️" + Environment.NewLine);
            TypeLine("Raise your plant to level 20 maturity to harvest, and make sure it doesn't run out of sun 🌞, food 🥄 or water 💧 !" + Environment.NewLine);
            TypeLine("Are you ready to grow? (yes or no)" + Environment.NewLine);
            string response = Console.ReadLine();
            if (response == "yes" || response == "Yes")
            {
                plant.RunGame();
            }
            else
            {
                TypeLine("I guess we'll start over..." + Environment.NewLine);
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
                
                Console.Clear();
                TypeLineFast("             🌞            " + Environment.NewLine);
                RandColor();
                TypeLine("Today is a new day! Let's see what nature has in store for you. Do you want to tend to your plant? (yes or no)" + Environment.NewLine);
                string input = Console.ReadLine();
                if (input == "yes" || input == "Yes")
                {
                    TypeLine("Choose what to give your plant: (💧 water, 🥄 food or 🌞 sun)" + Environment.NewLine);
                    string choice = Console.ReadLine();
                    if (choice == "water" || choice == "Water")
                    {
                        Water();
                        Disaster();
                        DisplayStats();
                        System.Threading.Thread.Sleep(5000);
                        RunGame();
                    }
                    else if (choice == "food" || choice == "Food")
                    {
                        Feed();
                        Disaster();
                        DisplayStats();
                        System.Threading.Thread.Sleep(5000);
                        RunGame();
                    }
                    else if (choice == "sun" || choice == "Sun")
                    {
                        GiveSunshine();
                        Disaster();
                        DisplayStats();
                        System.Threading.Thread.Sleep(5000);
                        RunGame();

                    }
                }
                else
                {
                        Disaster();
                        DisplayStats();
                        System.Threading.Thread.Sleep(5000);
                        RunGame();
                }
            }
        }

        public static void EndGame()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            TypeLine("⚰️  Your plant didn't make it. GAME OVER!  ⚰️" + Environment.NewLine);
        }
        public static void Harvest()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            TypeLine("Your plant is ripe! Its time to harvest!" + Environment.NewLine);
        }
        public static void RandColor()
        {
            Random randNum = new Random();
            int index = randNum.Next(1, 6);
            
            if (index == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            } 
            else if (index == 2)
            {
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (index == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (index == 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (index == 5)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
        static void TypeLine(string line) 
        {
            for (int i = 0; i < line.Length; i++) 
            {
                Console.Write(line[i]);
                System.Threading.Thread.Sleep(50);
            }
        }
        
        static void TypeLineFast(string line) 
        {
            for (int i = 0; i < line.Length; i++) 
            {
                Console.Write(line[i]);
                System.Threading.Thread.Sleep(10);
            }
        }
   }
}