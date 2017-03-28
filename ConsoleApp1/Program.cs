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
                Console.WriteLine("Type 'look around' at any time to see what is around you.");
                Console.WriteLine("Type 'has been' to at any time to see where you have been so far.");
                Console.WriteLine("Type 'back' to return to the previous room (if you can)");
                Console.WriteLine("Type 'clear' to clear the console.");
                Console.WriteLine("Type 'potatoes' to begin");
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
                String Parsed = Input.Parser(KeyIn);
                if(KeyIn.Equals("take flask"))
                {
                    Console.WriteLine("you take the flask");
                    Inventory.flask = true;
                    AboveGround.Kitchen();
                }
                else if(Parsed.Equals("east"))
                {
                    AboveGround.Bedroom();
                }
                else if(Parsed.Equals("look"))
                {
                    Console.WriteLine(Desc.k1);
                }
                else if(Parsed.Equals("quit"){
                    RunStat.IsRunning = false;
                }
                else if(Parsed.Equals("has been"))
                {
                    HasVisit.Print();
                }
                else if (Parsed.Equals("inv")
                {
                    Inventory.ItemStatusPrint();
                }
                else if(Parsed.Equals("clr"))
                {
                    Console.Clear();
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
                else if(KeyIn.Equals("clear"))
                {
                    Console.Clear();
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
                    UnderGround.DarkBasement();
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
                else if(KeyIn.Equals("clear"))
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("You look around confused.");
                    Closet();
                }
            }
        }
    }
    class UnderGround
    {
        public static void DarkBasement()
        {
            if (HasVisit.basement)
            {
                Console.WriteLine(Label.BASEMENT);
            }
            else
            {
                Console.WriteLine(Desc.bd1);
            }
            String KeyIn = Input.getInput();
            if (KeyIn.Equals("turn on flashlight") || KeyIn.Equals("flashlight"))
            {
                UnderGround.LightBasement();
            }
            else if (KeyIn.Equals("quit"))
            {
                RunStat.IsRunning = false;
            }
            else if(KeyIn.Equals("has been"))
            {
                HasVisit.Print();
            }
            else if (KeyIn.Equals("inventory") || KeyIn.Equals("inv"))
            {
                Inventory.ItemStatusPrint();
            }
            else if(KeyIn.Equals("go back") || KeyIn.Equals("back"))
            {
                Console.WriteLine(Desc.bdt);
            }
            else if(KeyIn.Equals("clear"))
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You look around confused");
                DarkBasement();
            }
        }
        public static void LightBasement()
        {
            while(RunStat.IsRunning){
                if (HasVisit.basement)
                {
                    Console.WriteLine(Label.BASEMENT);
                }
                else
                {
                    Console.WriteLine(Desc.bl1);
                }
                String KeyIn = Input.getInput();
                if (KeyIn.Equals("take gun") || KeyIn.Equals("take pistol") || KeyIn.Equals("gun"))
                {
                    Inventory.Nmm = true;
                    Console.WriteLine("You pick up a 9mm handgun");
                    LightBasement();
                }
                else if (KeyIn.Equals("take magazines") || KeyIn.Equals("magazines") || KeyIn.Equals("magazine") || KeyIn.Equals("take magazine") || KeyIn.Equals("take ammo") || KeyIn.Equals("ammo") || KeyIn.Equals("take mags") || KeyIn.Equals("mags"))
                {
                    if (Inventory.NmmRBasementTaken)
                    {
                        Console.WriteLine("There are no magazines here to take!");
                    }
                    else
                    {
                        Inventory.NmmRBasementTaken = true;
                        Inventory.NmmR = Inventory.NmmR + 16;
                        Console.WriteLine("You take 2 magazines that each contain 8 bullets.");
                    }
                    LightBasement();
                }
                else if (KeyIn.Equals("go south") || KeyIn.Equals("south"))
                {
                    //S1();
                }else if(KeyIn.Equals("go north") || KeyIn.Equals("north"))
                {
                    //N1();
                }
                else if(KeyIn.Equals("look") || KeyIn.Equals("look around"))
                {
                    if (Inventory.NmmBasementTaken)
                    {
                        Console.WriteLine(Desc.bl1Empty);
                    }
                    else
                    {
                        Console.WriteLine(Desc.bl1);
                    }
                    LightBasement();
                }
                else if (KeyIn.Equals("quit") || KeyIn.Equals("end"))
                {
                    RunStat.IsRunning = false;
                }
                else if(KeyIn.Equals("go back") || KeyIn.Equals("back"))
                {
                    Console.WriteLine(Desc.bdt);
                }
                else if(KeyIn.Equals("has been"))
                {
                    HasVisit.Print();
                }
                else if (KeyIn.Equals("inventory"))
                {
                    Inventory.ItemStatusPrint();
                    LightBasement();
                }
                else if(KeyIn.Equals("clear"))
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("You look around confused");
                    LightBasement();
                }
            }
        }
        public static void N1()
        {
            while(RunStat.IsRunning)
            {
                if (HasVisit.N1)
                {
                    Console.WriteLine(Label.TUNNEL);
                }
                else
                {
                    if (Inventory.flareN1Taken)
                    {
                        Console.WriteLine(Desc.N1Empty);
                    }
                    Console.WriteLine(Desc.N1);
                }
                HasVisit.N1 = true;
                String KeyIn = Input.getInput();

            }
        }
    }
    //fighting system and interface
    class FightSet
    {
        public static Boolean Fight(int TargetHP, int TargetDMG, String TargetName)
        {
            if(TargetHP < 0)
            {
                Console.WriteLine("The " + TargetName + " falls over, dead.");
            }
            while (TargetHP > 0 && RunStat.IsRunning && Inventory.Php > 0)
            {
                Boolean HasUsedFlare = false;
                int BurnCount = 0;
                Console.WriteLine("Attack with what?");
                String KeyIn = Input.getInput();
                if (KeyIn.Equals("attack with 9mm") || KeyIn.Equals("9mm") || KeyIn.Equals("pistol") || KeyIn.Equals("gun"))
                {
                    if (Inventory.Nmm)
                    {
                        if (Inventory.NmmR > 0)
                        {
                            //takes away ammo
                            Inventory.NmmR = Inventory.NmmR - 1;
                            //flare DOT counter
                            if (HasUsedFlare && BurnCount > 0)
                            {
                                TargetHP = TargetHP - Inventory.NmmDmg - Inventory.FlareDOT;
                                BurnCount--;
                            }
                            else
                            {
                                TargetHP = TargetHP - Inventory.NmmDmg;
                            }
                            //tells you that the target attacked
                            Console.WriteLine("the " + TargetName + " retaliates to your blow!");
                            //subtracts your hp
                            Inventory.Php = Inventory.Php - TargetDMG;
                            //tells you your hp
                            Console.WriteLine("You have " + Inventory.Php + " hp left.");
                            //tells you the target's hp
                            Console.WriteLine("The " + TargetName + " has " + TargetHP + "hp left");
                        }
                        else
                        {
                            Console.WriteLine("The gun clicks uselessly!");
                            Console.WriteLine("You don't have any more bullets!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have one of those!");
                    }
                }
                else if (KeyIn.Equals("attack with flare gun") || KeyIn.Equals("attack with flare") || KeyIn.Equals("flare") || KeyIn.Equals("flare gun"))
                {
                    //checks if you have a flare gun
                    if (Inventory.FlareGun)
                    {
                        if (Inventory.Flare > 0)
                        {
                            //takes away ammo
                            Inventory.Flare = Inventory.Flare - 1;
                            //resets the burn timer
                            BurnCount = 2;
                            HasUsedFlare = true;
                            //subtracts the target's hp
                            TargetHP = TargetHP - Inventory.FlareDOT;
                            //tells you that the target attacked
                            Console.WriteLine("the " + TargetName + " retaliates to your blow!");
                            //subtracts your hp
                            Inventory.Php = Inventory.Php - TargetDMG;
                            //tells you your hp
                            Console.WriteLine("You have " + Inventory.Php + " hp left.");
                            //tells you the target's hp
                            Console.WriteLine("The " + TargetName + " has " + TargetHP + "hp left");
                        }
                        else
                        {
                            Console.WriteLine("The gun clicks uselessly!");
                            Console.WriteLine("You don't have any more flares!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have one of those");
                    }
                }
                else if (KeyIn.Equals("quit") || KeyIn.Equals("end"))
                {
                    RunStat.IsRunning = false;
                }
                else
                {
                    Console.WriteLine("You stand distracted, and nearly get hit!");
                }
            }
            return true;
        }
    }
}