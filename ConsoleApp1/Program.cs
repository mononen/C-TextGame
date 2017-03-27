using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusStuff;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            while (RunStat.IsRunning)
            {
                //game start
                Console.WriteLine("welcome to the game! I hope you enjoy in some way!");
                Console.WriteLine("Simple Instructions:");
                Console.WriteLine("Type 'quit' at any time to quit.");
                Console.WriteLine("Type 'inventory' at any time to see what items you possess.");
                Console.WriteLine("type 'look around' at any time to see what is around you.");
                Console.WriteLine("Type 'has been' to at any time to see where you have been so far.");
                Console.WriteLine("type 'back' to return to the previous room (if you can)");
                Console.WriteLine("type 'potatoes' to begin");
                String KeyIn = Input.getInput();
                if (KeyIn.Equals("potatoes"))
                {
                    Console.WriteLine("Prepare yourself, this is the best game ever....");
                    AboveGround.Kitchen();
                }
                if (KeyIn.Equals("iwannaskip"))
                {
                    Skip.s();
                }
                else
                {
                    Console.WriteLine("I'll give you the benefit of the doubt, welcome to the best game ever....");
                    AboveGround.Kitchen();
                }
            }
        }
    }
    class AboveGround
    {
        public static void Kitchen()
        {
            while (RunStat.IsRunning)
            {
                if (HasVisit.kitchen)
                {
                    Console.WriteLine(Label.KL);
                }
                else
                {
                    Console.WriteLine(Desc.k1);
                }
                HasVisit.kitchen = true;
                String KeyIn = Input.getInput();
                if(KeyIn.Equals("take flask"))
                {
                    Console.WriteLine("you take the flask");
                    Inventory.flask = true;
                    AboveGround.Kitchen();
                }
                else if(KeyIn.Equals("go east"))
                {
                    AboveGround.Bedroom();
                }
                else if(KeyIn.Equals("look") || KeyIn.Equals("look around"))
                {
                    Console.WriteLine(Desc.k1);
                }
                else if(KeyIn.Equals("quit") || KeyIn.Equals("end")){
                    RunStat.IsRunning = false;
                }
                else if(KeyIn.Equals("has been"))
                {
                    HasVisit.Print();
                }
                else if (KeyIn.Equals("inventory"))
                {
                    Inventory.ItemStatusPrint();
                }
                else
                {
                    Console.WriteLine("You look around confused.");
                    AboveGround.Kitchen();
                }
            }
        }
        public static void Bedroom()
        {
            while (RunStat.IsRunning)
            {
                if (HasVisit.bedroom)
                {
                    Console.WriteLine(Label.BL);
                }
                else
                {
                    Console.WriteLine(Desc.b1);
                }
                HasVisit.bedroom = true;
                String KeyIn = Input.getInput();
                if (KeyIn.Equals("take bottle"))
                {
                    Console.WriteLine("You take the bottle");
                    Inventory.bottle = true;
                    AboveGround.Bedroom();
                }
                else if(KeyIn.Equals("take bag") || KeyIn.Equals("take sack") || KeyIn.Equals("take wool sack"))
                {
                    Console.WriteLine("You take the wool sack");
                    Inventory.sack = true;
                    AboveGround.Bedroom();
                }
                else if (KeyIn.Equals("go left"))
                {
                    AboveGround.Closet();
                }
                else if (KeyIn.Equals("look") || KeyIn.Equals("look around"))
                {
                    if (Inventory.bottle)
                    {
                        Console.WriteLine(Desc.b2);
                    }
                    else if (Inventory.sack)
                    {
                        Console.WriteLine(Desc.b3);
                    }
                    else if (Inventory.sack && Inventory.bottle)
                    {
                        Console.WriteLine(Desc.b4);
                    }
                    else
                    {
                        Console.WriteLine(Desc.b1);
                    }
                }
                else if (KeyIn.Equals("quit") || KeyIn.Equals("end")){
                    RunStat.IsRunning = false;
                }
                else if (KeyIn.Equals("has been"))
                {
                    HasVisit.Print();
                }
                else if (KeyIn.Equals("inventory"))
                {
                    Inventory.ItemStatusPrint();
                }
                else if(KeyIn.Equals("go back") || KeyIn.Equals("back") || KeyIn.Equals("go west"))
                {
                    AboveGround.Kitchen();
                }
                else
                {
                    Console.WriteLine("You look around confused.");
                    AboveGround.Kitchen();
                }
            }
        }
        public static void Closet()
        {
            while (RunStat.IsRunning)
            {
                if (HasVisit.closet)
                {
                    Console.WriteLine(Label.CL);
                }
                else
                {
                    Console.WriteLine(Desc.c1);
                }
                HasVisit.closet = true;
                String KeyIn = Input.getInput();
                if (KeyIn.Equals("take flashlight") || KeyIn.Equals("flashlight") || KeyIn.Equals("take flash light"))
                {
                    Console.WriteLine("You take the flashlight");
                    Inventory.flashlight = true;
                    Closet();
                }
                else if(KeyIn.Equals("take rug"))
                {
                    Console.WriteLine("What do you expect me to do with this?! It's way too big to carry!");
                    Closet();
                }
                else if(KeyIn.Equals("move rug"))
                {
                    Console.WriteLine("You move the rug out of your way, revealing a trapdoor.");
                    HasVisit.trapdoor = true;
                    Closet();
                }
                else if(KeyIn.Equals("enter") && HasVisit.trapdoor)
                {
                    AboveGround.Basement();
                }
                else if(KeyIn.Equals("look") || KeyIn.Equals("look around"))
                {
                    if (Inventory.flashlight)
                    {
                        Console.WriteLine(Desc.c2);
                    }
                    else if (HasVisit.trapdoor)
                    {
                        Console.WriteLine(Desc.c4);
                    }
                    else if (HasVisit.trapdoor && Inventory.flashlight)
                    {
                        Console.WriteLine(Desc.c3);
                    }
                    else
                    {
                        Console.WriteLine(Desc.c1);
                    }
                }
                else if (KeyIn.Equals("quit") || KeyIn.Equals("end"))
                {
                    RunStat.IsRunning = false;
                }
                else if (KeyIn.Equals("has been"))
                {
                    HasVisit.Print();
                }
                else if (KeyIn.Equals("inventory"))
                {
                    Inventory.ItemStatusPrint();
                }
                else if (KeyIn.Equals("go back") || KeyIn.Equals("back") || KeyIn.Equals("go west"))
                {
                    Bedroom();
                }
                else
                {
                    Console.WriteLine("You look around confused.");
                    Closet();
                }
            }
        }
        public static void Basement()
        {
            if (HasVisit.basement)
            {
                Console.WriteLine(Label.BD);
            }
            else
            {
                Console.WriteLine(Desc.bd1);
            }
        }
    }
    
}