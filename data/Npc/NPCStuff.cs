using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_in_console.data.Npc
{
    public class NPCStuff
    {
        public string _1NPCName = "Bolvar";
        public string ShopKeeperName = "TheShopKeeper";
        public string PlayerHelperName = "elf";
        public string TheWild = "TheWild";
        public string PlayerName;
        public string[] Dia_ShopKeeperIn = { "hello what can i do for you?", "it's it not a good day", "The Shop has all the items you need :D" };
        public string[] Dia_ShopKeeperOut = { "thanks you and bye", "bye", "farewell hero" };
        public string[] sayYes = { "yes", "Yes", "Y", "y" };
        public string[] sayWM = { "WorldMap", "worldmap", "wm", "WM" };
        public void TO()
        {
            {
                Console.WriteLine("Hello " + PlayerName);
                PlayerSay("where am i? and who are you?");
                BolvarSay("i am " + _1NPCName + " and you are in Strombard");
                PlayerSay("you said where?");
                BolvarSay("do you have a map?");
                Console.WriteLine("say no to lie or say yes to not lie");
                if (Input.GetLine(sayYes))
                {
                    PlayerSay("yes i have a map");
                    BolvarSay("yes yes can you open it");
                }
                else
                {
                    PlayerSay("no i do not have a map");
                    BolvarSay("ok here take this map and open it");
                }
            }
            
            {
                Console.WriteLine(@"say ""WorldMap"" to open your map");
                if (Input.GetLine(sayWM))
                    Console.WriteLine(WorldMap);
                PlayerSay("What is Firestorm and IronMake and what is the wild?");
                BolvarSay("Firestromb is a friend and the wild is a place where no one has gone to in over 1000 years");
                PlayerSay("but what is IronMake? ");
                BolvarSay("IronMake yes... it's an enemy we have try to destroy them but there are still here ");
                BolvarSay("if you want to go there you need to train for it");
                BolvarSay("get better gear by getting materials and crafting them into something");
                BolvarSay("here is my old axe, try to get some wood in the forest");
                Console.WriteLine(@"say ""shop"" to go to the shop");
            }
        }
        public void TheWildDiaLog()
        {

        }
        public void BolvarSay(string mess)
        {
            Console.WriteLine(_1NPCName + ": " + mess);
        }
        public void ShopKeeeperSay(string mess)
        {
            Console.WriteLine(ShopKeeperName + ": " + mess);
        }
        public void ElfSay(string mess)
        {
            Console.WriteLine(PlayerHelperName + ": " + mess);
        }
        public void TheWildSay(string mess)
        {
            Console.WriteLine(TheWild + ": " + mess);
        }
        public void PlayerSay(string mess)
        {
            Console.WriteLine("You: " + mess);
        }
        public void UnknwonSay(string mess)
        {
            Console.WriteLine("Unknown One: " + mess);
        }

    }
}