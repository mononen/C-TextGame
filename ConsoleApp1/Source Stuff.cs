using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace StatusStuff
{
    class Inventory
    {
        //player hit points
        public static int Php = 100;
        //item or tool status
        //all start with false (b/c you don't spawn with anything)
        public static Boolean flask = false;
        public static Boolean sack = false;
        public static Boolean bottle = false;
        public static Boolean flashlight = false;
        public static Boolean rug = false;
        //if you have taken the item from the location
        public static Boolean FlaskKitchen = false;
        public static Boolean SackBedroom = false;
        public static Boolean BottleBedroom = false;
        public static Boolean FlashlightCloset = true;
        public static Boolean RugCloset = true;

        //nmm is the 9mm hand gun
        public static Boolean Nmm = false;
        //gun dmg
        public static int NmmDmg = 10;
        //count of bullets
        public static int NmmR = 0;
        //posession of flare gun
        public static Boolean FlareGun = false;
        //flare damage over time
        public static int FlareDOT = 8;
        //count of flares
        public static int Flare = 0;
        //if you have taken the objects from these locations
        public static Boolean flareN1Taken = false;
        public static Boolean FlareGunN1Taken = false;
        public static Boolean NmmBasementTaken = false;
        public static Boolean NmmRBasementTaken = false;

        //enemy health
        public static int Nymph1HP = 35;
        //enemy damage
        public static int Nymph1DMG = 10;
        public static void ItemStatusPrint()
        {
            Console.WriteLine("You have:");
            if (flask)
            {
                Console.WriteLine("a flask,");
            }
            if (sack)
            {
                Console.WriteLine("a sack,");
            }
            if (bottle)
            {
                Console.WriteLine("a bottle,");
            }
            if (flashlight)
            {
                Console.WriteLine("a flashlight,");
            }
            if(rug)
            {
                Console.WriteLine("a rug,");
            }
            if (Nmm)
            {
                Console.WriteLine("a 9mm pistol,");
            }
            if(NmmR > 0)
            {
                Console.WriteLine(NmmR + " rounds");
            }
            if (FlareGun)
            {
                Console.WriteLine("a flare gun,");
            }
            if(Flare > 0)
            {
                Console.WriteLine(Flare + " flares");
            }
        }
    }
    class Desc
    {
        public static String k1 = "You enter an old dilapidated kitchen, there is a flask on the countertop. There is a door to your east";
        public static String k2 = "You are still in the old dilapated kitchen. There is a door to your east.";
        //b1 - b4 are all different variants of the bedroom description text
        public static String b1 = "You enter a dark and nearly empty bedroom with a table in the middle and a bed pushed to the side. There is a small closed door to the left. On the table in the center of the room is a bottle and a wool sack.";
        public static String b2 = "You are in a dark and nearly empty bedroom with a table in the middle and a bed pushed to the side. There is a small closed door to the left. On the table in the center of the room is a wool sack.";
        public static String b3 = "You are in a dark and nearly empty bedroom with a table in the middle and a bed pushed to the side. There is a small closed door to the left. On the table in the center of the room is a flask.";
        public static String b4 = "You enter a dark and nearly empty bedroom with a table in the middle and a bed pushed to the side. There is a small closed door to the left.";
        //c1 - c2 are all different variants of the closet description text
        public static String c1 = "You are in a small closet, there is a flashlight, and a small rug on the floor.";
        public static String c2 = "You are in a small closet, there is a small rug on the floor.";
        public static String c3 = "You are in a small closet, there is a rug moved out of the way, revealing a trapdoor.";
        public static String c4 = "You are in a small closet, there is a flashilight and there is a rug moved out of the way, revealing a trapdoor.";
        public static String bd1 = "You are in the basement. It is very dark";
        public static String bdt = "You attempt to open the trapdoor, but it is too heavy to push open.";
        public static String bl1 = "You finally see the basement clearly. There is a passage to the South and a passage to the North, you feel a slight breeze coming from the one to the North. The whole region is built out of raw concrete, and it looks very industrial. A gun lies on the desk to your left. Two magazines lie next to it.";
        public static String bl1Empty = "You finally see the basement clearly. There is a passage  to the South and a passage to the North, you feel a slight breeze coming from the one to the North. The whole region is built out of raw concrete and it looks very industrial.";
        public static String N1 = "The tunnel streatches beofore you. There is a old mining cart sitting on some abandoned tracks. Next to the tracks it says: Death to all who enter. A package of flares lie next to an open hole with spikes at the bottom. You see a skeleton hanging limply on one of the spikes. A flare gun lies on the ground just outside of the pit.";
        public static String N1Empty = "The tunnel streatches beofore you. There is a old mining cart sitting on some abandoned tracks. Next to the tracks it says: Death to all who enter. There is an open hole with spikes at the bottom. You see a skeleton hanging limply on one of the spikes.";
        public static String cart = "You clamor into the cart with a bang. There is a red lever to your right.";
        public static String cartIn = "You are in a old rusted mine cart. There is a red lever to your right.";
        public static String river = "It gradually picks up speed, you try and slow down by pushing the lever back into the position it was in before but it snaps off in your hand. The cart is now out of control. Out of the gloom a river appeares, it seems to have washed a portion of the tracks away. The cart splashes into the watter and starts to sink. You see dark shadows move below you. In a panic, you leap from the cart, landing on the shore. You think that you are safe, but unfortunatly you land in front of a river nymph, who is holding a sword.";
        public static String nymph1Dead = "You can finally relax and take a look around the room, the dead nymph's sword is glowing on the floor, covered in your blood. There is a tunnel leading in front, and behind you. ";
    }
    class HasVisit
    {
        public static Boolean kitchen = false;
        public static Boolean bedroom = false;
        public static Boolean trapdoor = false;
        public static Boolean basement = false;
        public static Boolean closet = false;
        public static Boolean Lbasement = false;
        public static Boolean N1 = false;
        public static Boolean S1 = false;
        public static Boolean cart = false;
        public static Boolean nymph1 = false;
        public static Boolean river = false;
        public static void Print()
        {
            Console.WriteLine("You have visited:");
            if (kitchen)
            {
                Console.WriteLine("the kitchen,");
            }
            if (bedroom)
            {
                Console.WriteLine("the bedroom,");
            }
            if (closet)
            {
                Console.WriteLine("the closet,");
            }
            if (trapdoor)
            {
                Console.WriteLine("the trapdoor,");
            }
            if (basement)
            {
                Console.WriteLine("the basement,");
            }
            if(N1 || S1)
            {
                Console.WriteLine("the tunnels");
            }
        }
    }
    class RunStat
    {
        public static Boolean IsRunning = true;
    }
    class Skip
    {
        public static void s()
        {
            String KeyIn = Input.getInput();

            if (KeyIn.Equals("idarkbasement"))
            {
                Inventory.flask = true;
                Inventory.sack = true;
                Inventory.bottle = true;
                Inventory.flashlight = true;
                Inventory.rug = true;
                UnderGround.DarkBasement();
            }
            if (KeyIn.Equals("ilightbasement"))
            {
                Inventory.flask = true;
                Inventory.sack = true;
                Inventory.bottle = true;
                Inventory.flashlight = true;
                Inventory.rug = true;
                UnderGround.LightBasement();
            }
            if (KeyIn.Equals("in1"))
            {
                Inventory.flask = true;
                Inventory.sack = true;
                Inventory.bottle = true;
                Inventory.flashlight = true;
                Inventory.rug = true;
                //UnderGround.N1();

            }
            if (KeyIn.Equals("inymph1"))
            {
                Inventory.flashlight = true;
                Inventory.flask = true;
                Inventory.sack = true;
                Inventory.bottle = true;
                Inventory.rug = true;
                Inventory.Nmm = true;
                Inventory.NmmR = 16;
                Inventory.NmmRBasementTaken = true;
                Inventory.FlareGun = true;
                Inventory.Flare = 2;
                Inventory.flareN1Taken = true;
                FightSet.Fight(Inventory.Nymph1HP, Inventory.Nymph1DMG, "Nymph");
            }
            else
            {
                Console.WriteLine("I don't understand");
                s();
            }
        }
    }
    class Input
    {
        public static string getInput()
        {
            //prints cursor
            Console.Write("> ");
            string SysIn = Console.ReadLine();
            String Input = SysIn;
            String Parsed = Input.ToLower();
            return Parsed;
        }
        //general parsing
        //not to process anything specific
        public static String Parser(String KeyIn)
        {
            if (KeyIn.Contains("south"))
            {
                return "south";
            }
            else if (KeyIn.Contains("east"))
            {
                return "east";
            }
            else if (KeyIn.Contains("north"))
            {
                return "north";
            }
            else if (KeyIn.Contains("west"))
            {
                return "west";
            }
            else if (KeyIn.Contains("look"))
            {
                return "look";
            }
            else if (KeyIn.Contains("quit") || KeyIn.Equals("end"))
            {
                return "quit";
            }
            else if (KeyIn.Contains("been"))
            {
                return "has been";
            }
            else if (KeyIn.Contains("inventory") || KeyIn.Contains("inv"))
            {
                return "inv";
            }
            else if (KeyIn.Contains("clear") || KeyIn.Equals("clr"))
            {
                return "clr";
            }
            else if (KeyIn.Contains("back"))
            {
                return "back";
            }
            else
            {
                return null;
            }
        }

    }
    class Label
    {
        public static String BL = "BEDROOM";
        public static String KL = "KITCHEN";
        public static String TD = "TRAPDOOR";
        public static String CL = "CLOSET";
        public static String BASEMENT = "BASEMENT";
        public static String TUNNEL = "TUNNEL";
        public static String CART = "CART";
        public static String RIVER = "RIVER";
    }
}
