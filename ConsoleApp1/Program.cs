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
            //game start
            Console.WriteLine("welcome to the game! I hope you enjoy in some way!");
            Console.WriteLine("Simple Instructions:");
            Console.WriteLine("Type 'quit' at any time to quit.");
            Console.WriteLine("Type 'inventory' at any time to see what items you possess.");
            Console.WriteLine("type 'look around' at any time to see what is around you.");
            Console.WriteLine("Type 'has been' to at any time to see where you have been so far.");
            Console.WriteLine("type 'back' to return to the previous room (if you can)");
            Console.WriteLine("type 'I'm ready!' to begin");
            String KeyIn = Input.getInput();
            if (KeyIn.Equals("i'm ready!"))
            {
                Console.WriteLine("Prepare yourself, this is the best game ever....");
               // Kitchen.desc();
            }
            if (KeyIn.Equals("iwannaskip"))
            {
                Skip.s();
            }
            else
            {
                Console.WriteLine("I'll give you the benefit of the doubt, welcome to the best game ever....");
                //Kitchen.desc();
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
                else if(KeyIn.Equals("quit") || KeyIn.Equals("end"){
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
    }
}
