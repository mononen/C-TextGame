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
            while (RunStat.IsRunning && Inventory.Php > 0)
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
                if (Inventory.FlaskKitchen)
                {
                    Console.WriteLine("There isn't a flask here to take!");
                }
                else
                {
                    Console.WriteLine("you take the flask");
                    Inventory.flask = true;
                    AboveGround.Kitchen();
                }
            }
            else if(Parsed.Equals("east"))
            {
                AboveGround.Bedroom();
            }
            else if(Parsed.Equals("look"))
            {
                Console.WriteLine(Desc.k1);
                Kitchen();
            }
            else if(Parsed.Equals("quit")){
                RunStat.IsRunning = false;
            }
            else if(Parsed.Equals("has been"))
            {
                HasVisit.Print();
                Kitchen();
            }
            else if (Parsed.Equals("inv"))
            {
                Inventory.ItemStatusPrint();
                Kitchen();
            }
            else if(Parsed.Equals("clr"))
            {
                Console.Clear();
                GC.Collect();
                Kitchen();
            }
            else
            {
                Console.WriteLine("You look around confused.");
                Kitchen();
            }
        }
        public static void Bedroom()
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
            String Parsed = Input.Parser(KeyIn);
            if (KeyIn.Equals("take bottle"))
            {
                if (Inventory.FlareGunN1Taken)
                {
                    Console.WriteLine("There isn't a flare gun here to take!");
                }
                else
                {
                    Console.WriteLine("You take the bottle");
                    Inventory.bottle = true;
                    AboveGround.Bedroom();
                }
            }
            else if(KeyIn.Equals("take bag") || KeyIn.Equals("take sack") || KeyIn.Equals("take wool sack"))
            {
                if (Inventory.FlareGunN1Taken)
                {
                    Console.WriteLine("There isn't a flare gun here to take!");
                }
                else
                {
                    Console.WriteLine("You take the wool sack");
                    Inventory.sack = true;
                    AboveGround.Bedroom();
                }
            }
            else if (KeyIn.Equals("go left"))
            {
                Closet();
            }
            else if (Parsed.Equals("look"))
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
            else if (Parsed.Equals("quit")){
                RunStat.IsRunning = false;
            }
            else if (Parsed.Equals("has been"))
            {
                HasVisit.Print();
                Bedroom();
            }
            else if (Parsed.Equals("inv"))
            {
                Inventory.ItemStatusPrint();
                Bedroom();
            }
            else if(Parsed.Equals("back") || Parsed.Equals("west"))
            {
                AboveGround.Kitchen();
                Bedroom();
            }
            else if(KeyIn.Equals("clear"))
            {
                Console.Clear();
                GC.Collect();
                Bedroom();
            }
            else
            {
                Console.WriteLine("You look around confused.");
                Bedroom();
            }
        }
        public static void Closet()
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
            String Parsed = Input.Parser(KeyIn);
            if (KeyIn.Equals("take flashlight") || KeyIn.Equals("flashlight") || KeyIn.Equals("take flash light"))
            {
                if (Inventory.FlareGunN1Taken)
                {
                    Console.WriteLine("There isn't a flare gun here to take!");
                }
                else
                {
                    Console.WriteLine("You take the flashlight");
                    Inventory.flashlight = true;
                    Closet();
                }
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
            else if (Parsed.Equals("quit"))
            {
                RunStat.IsRunning = false;
            }
            else if (Parsed.Equals("has been"))
            {
                HasVisit.Print();
                Closet();
            }
            else if (Parsed.Equals("inv"))
            {
                Inventory.ItemStatusPrint();
                Closet();
            }
            else if (Parsed.Equals("back"))
            {
                Bedroom();
            }
            else if(Parsed.Equals("clr"))
            {
                Console.Clear();
                GC.Collect();
                Closet();
            }
            else
            {
                Console.WriteLine("You look around confused.");
                Closet();
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
            String Parsed = Input.Parser(KeyIn);
            if (KeyIn.Equals("turn on flashlight") || KeyIn.Equals("flashlight"))
            {
                UnderGround.LightBasement();
            }
            else if (Parsed.Equals("quit"))
            {
                RunStat.IsRunning = false;
            }
            else if(Parsed.Equals("has been"))
            {
                HasVisit.Print();
                DarkBasement();
            }
            else if (Parsed.Equals("inv"))
            {
                Inventory.ItemStatusPrint();
                DarkBasement();
            }
            else if(Parsed.Equals("back"))
            {
                Console.WriteLine(Desc.bdt);
                DarkBasement();
            }
            else if(Parsed.Equals("clr"))
            {
                Console.Clear();
                GC.Collect();
                DarkBasement();
            }
            else
            {
                Console.WriteLine("You look around confused");
                DarkBasement();
            }
        }
        public static void LightBasement()
        {
            if (HasVisit.basement)
            {
                Console.WriteLine(Label.BASEMENT);
            }
            else
            {
                Console.WriteLine(Desc.bl1);
            }
            HasVisit.basement = true;
            String KeyIn = Input.getInput();
            String Parsed = Input.Parser(KeyIn);
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
            else if (Parsed.Equals("south"))
            {
                S1();
            }
            else if(Parsed.Equals("north"))
            {
                N1();
            }
            else if(Parsed.Equals("look"))
            {
                if (Inventory.NmmBasementTaken)
                {
                    Console.WriteLine(Desc.bl1Empty);
                }
                else
                {
                    Console.WriteLine(Desc.bl1);
                }
            }
            else if (Parsed.Equals("quit"))
            {
                RunStat.IsRunning = false;
            }
            else if(Parsed.Equals("back"))
            {
                Console.WriteLine(Desc.bdt);
                LightBasement();
            }
            else if(Parsed.Equals("has been"))
            {
                HasVisit.Print();
                LightBasement();
            }
            else if (Parsed.Equals("inv"))
            {
                Inventory.ItemStatusPrint();
                LightBasement();
            }
            else if(Parsed.Equals("clr"))
            {
                Console.Clear();
                GC.Collect();
                LightBasement();
            }
            else
            {
                Console.WriteLine("You look around confused.");
                LightBasement();
            }
        }
        public static void S1()
        {
            if (HasVisit.S1)
            {
                Console.WriteLine(Label.WELL);
            }
            else
            {
                Console.WriteLine(Desc.S1);
            }
            HasVisit.S1 = true;
            String KeyIn = Input.getInput();
            String Parsed = Input.Parser(KeyIn);
            if (KeyIn.Equals("take rope") || KeyIn.Equals("rope"))
            {
                Console.WriteLine("You take the rope.");
                Inventory.rope = true;
            }
            else if (KeyIn.Equals("climb") || KeyIn.Equals("climb rope"))
            {
                if (Inventory.TieRope == false)
                {
                    Console.WriteLine("You fall to your death");
                    Console.WriteLine("game over.");
                    RunStat.IsRunning = false;
                }
            }
            else if (Inventory.rope == true && KeyIn.Equals("tie rope"))
            {
                Console.WriteLine("You tie the rope on the bracket.");
                Inventory.TieRope = true;
            }
            else if (Inventory.TieRope == true && KeyIn.Equals("climb"))
            {
                //temp troubleshooting code
                Console.WriteLine("You go to the bottom of the rope");
                //WellBottom();
            }
            else if (Parsed.Equals("look"))
            {
                Console.WriteLine(Desc.N1Empty);
                S1();
            }
            else if (Parsed.Equals("has visit"))
            {
                HasVisit.Print();
                S1();
            }
            else if (Parsed.Equals("inv"))
            {
                Inventory.ItemStatusPrint();
                S1();
            }
            else if (Parsed.Equals("quit"))
            {
                RunStat.IsRunning = false;
            }
            else if (Parsed.Equals("clr"))
            {
                Console.Clear();
                GC.Collect();
                S1();
            }
            else if (Parsed.Equals("back"))
            {
                LightBasement();
            }
            else
            {
                Console.WriteLine("You look around confused.");
                S1();
            }
        }
        public static void N1()
        {           
            if (HasVisit.N1)
            {
                Console.WriteLine(Label.TUNNEL);
            }
            else
            {
                Console.WriteLine(Desc.N1);
            }
            HasVisit.N1 = true;
            String KeyIn = Input.getInput();
            String Parsed = Input.Parser(KeyIn);
            if (KeyIn.Equals("mining cart") || KeyIn.Equals("cart") || KeyIn.Equals("minecart") || KeyIn.Equals("get in mining cart") || KeyIn.Equals("get in minecart") || KeyIn.Equals("enter cart") || KeyIn.Equals("enter"))
            {
                Cart();
            }
            else if (KeyIn.Equals("take flares") || KeyIn.Equals("flares") || KeyIn.Equals("flare"))
            {
                if (Inventory.flareN1Taken)
                {
                    Console.WriteLine("There are no magazines here to take!");
                }
                else
                {
                    Inventory.flareN1Taken = true;
                    Inventory.Flare = Inventory.Flare + 2;
                    Console.WriteLine("You take two flares.");
                }
            }
            else if (KeyIn.Equals("take flare gun") || KeyIn.Equals("flare gun"))
            {
                if (Inventory.FlareGunN1Taken)
                {
                    Console.WriteLine("There isn't a flare gun here to take!");
                }
                else
                {
                    Inventory.FlareGunN1Taken = true;
                    Inventory.FlareGun = true;
                    Console.WriteLine("You take the flare gun.");
                }
            }
            else if (Parsed.Equals("look"))
            {
                Console.WriteLine(Desc.N1Empty);
                N1();
            }
            else if (Parsed.Equals("has visit"))
            {
                HasVisit.Print();
                N1();
            }
            else if (Parsed.Equals("inv"))
            {
                Inventory.ItemStatusPrint();
                N1();
            }
            else if (Parsed.Equals("quit"))
            {
                RunStat.IsRunning = false;
            }
            else if (Parsed.Equals("clr"))
            {
                Console.Clear();
                GC.Collect();
                N1();
            }
            else if (Parsed.Equals("back"))
            {
                LightBasement();
            }
            else
            {
                Console.WriteLine("You find yourself staring at the mine cart");
                N1();
            }
        }
        public static void Cart()
        {
            //already in the minecart, function only meant for pulling the lever.
            if (HasVisit.cart)
            {
                Console.WriteLine(Label.CART);
            }
            else
            {
                Console.WriteLine(Desc.cart);
            }
            String KeyIn = Input.getInput();
            String Parsed = Input.Parser(KeyIn);
            if(KeyIn.Equals("pull lever") || KeyIn.Equals("lever") || KeyIn.Equals("go"))
            {
                Nymph1();
            }
            else if(KeyIn.Equals("get out") || KeyIn.Equals("exit"))
            {
                N1();
            }
            else if (Parsed.Equals("look"))
            {
                Console.WriteLine(Desc.cartIn);
                Cart();
            }
            else if (Parsed.Equals("has visit"))
            {
                HasVisit.Print();
                Cart();
            }
            else if (Parsed.Equals("inv"))
            {
                Inventory.ItemStatusPrint();
                Cart();
            }
            else if (Parsed.Equals("quit"))
            {
                RunStat.IsRunning = false;
            }
            else if (Parsed.Equals("clr"))
            {
                Console.Clear();
                GC.Collect();
                Cart();
            }
            else if (Parsed.Equals("back"))
            {
                N1();
            }
            else
            {
                Console.WriteLine("You find yourself staring at the red lever");
                Cart();
            }
        }
        public static void Nymph1()
        {
            if (Inventory.Nymph1Alive)
            {
                Console.WriteLine(Desc.river);
                String KeyIn = Input.getInput();
                String Parsed = Input.Parser(KeyIn);
                if (KeyIn.Equals("attack") || KeyIn.Equals("attack with gun") || KeyIn.Equals("attack with lever") || KeyIn.Equals("attack with flare"))
                {
                    FightSet.Fight(Inventory.Nymph1HP, Inventory.Nymph1DMG, "River Nymph", Inventory.Nymph1Alive);
                }
                else if (KeyIn.Equals("run") || KeyIn.Equals("run away"))
                {
                    Console.WriteLine("There is nowhere to run!");
                }
                else
                {
                    Console.WriteLine("You are being stared down by a nymph with a sword in her hand, and you want to do that!");
                }
            }
            else
            {
                Console.WriteLine(Desc.nymph1Dead);
                String KeyIn = Input.getInput();
                String Parsed = Input.Parser(KeyIn);
                if(KeyIn.Equals("take sword"))
                {
                    Inventory.sword = true;
                    Inventory.Nymph1Sword = true;
                    Console.WriteLine("You take the fallen nymph's sword and wipe off your blood");
                }
                else if (Parsed.Equals("forward"))
                {

                }
                else if (Parsed.Equals("look"))
                {
                    Console.WriteLine(Desc.cartIn);
                }
                else if (Parsed.Equals("has visit"))
                {
                    HasVisit.Print();
                }
                else if (Parsed.Equals("inv"))
                {
                    Inventory.ItemStatusPrint();
                }
                else if (Parsed.Equals("quit"))
                {
                    RunStat.IsRunning = false;
                }
                else if (Parsed.Equals("clr"))
                {
                    Console.Clear();
                    GC.Collect();
                }
                else if (Parsed.Equals("back"))
                {
                    N1();
                }
                else
                {
                    Console.WriteLine("You find yourself looking around the room.");
                    Nymph1();
                }
            }
        }
    }
    //fighting system and interface
    class FightSet
    {
        public static void Fight(int TargetHP, int TargetDMG, String TargetName, Boolean TargetAlive)
        {
            if(TargetHP < 0)
            {
                Console.WriteLine("The " + TargetName + " falls over, dead.");
                TargetAlive = false;
            }
            while (TargetHP > 0 && RunStat.IsRunning && Inventory.Php > 0)
            {
                Boolean HasUsedFlare = false;
                int BurnCount = 0;
                Console.WriteLine("Attack with what?");
                String KeyIn = Input.getInput();
                if (KeyIn.Contains("attack with 9mm") || KeyIn.Equals("pistol") || KeyIn.Equals("gun"))
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
                        Console.WriteLine("You don't have one of those!");
                        Inventory.Mistake++;
                    }
                }
                else if (KeyIn.Equals("attack with sword") || KeyIn.Equals("sword"))
                {
                    if (Inventory.sword)
                    {
                        //flare DOT counter
                        if (HasUsedFlare && BurnCount > 0)
                        {
                            TargetHP = TargetHP - Inventory.SwordDmg - Inventory.FlareDOT;
                            BurnCount--;
                        }
                        else
                        {
                            TargetHP = TargetHP - Inventory.SwordDmg;
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
                        Console.WriteLine("You don't have one of those");
                        Inventory.Mistake++;
                    }
                }
                else if (KeyIn.Contains("lever"))
                {
                    if (Inventory.lever)
                    {
                        //flare damage over time calculator
                        if (HasUsedFlare && BurnCount > 0)
                        {
                            TargetHP = TargetHP - Inventory.LeverDmg - Inventory.FlareDOT;
                        }
                        else
                        {
                            TargetHP = TargetHP - Inventory.LeverDmg;
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
                        Console.WriteLine("You don't have one of those!");
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
            GC.Collect();
        }
    }
}