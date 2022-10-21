using System;
using System.Collections.Generic;
using System.Text;
using game_in_console.Shoping.Class;
using game_in_console.NPC.Name;
using game_in_console.bug;
using game_in_console.enums;
using GameEMain;
using game_in_console.player;
namespace game_in_console.Shoping
{
    public class Shop : ShopDataBase
    {
        private bool FirstIn = true;
        private bool exit = false;
        public void ShopStart()
        {
            exit = false;
            Random random = new Random();
            if (exit == false)
            {
                if (FirstIn == true)
                {
                    for (int i = 0; i < itemsList.Length; i++)
                    {
                        itemsList[i] = new ShopItemsList();

                    }
                    SetupShop(random);
                    FirstIn = false;
                }
                string User = Console.ReadLine();
                switch (converter.UserToShopOp(User))
                {
                    case ShopOp.buy:
                        Buy();
                        break;
                    case ShopOp.help:
                        break;
                    case ShopOp.WCIB:
                        WCIB();
                        break;
                    case ShopOp.GO:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
            if (exit != true)
                ShopStart();
            else
            {
                Bye(random);
            }
        }
        void WCIB()
        {
            Console.WriteLine(S_NPC.ShopKeeperName + ": " + "i have");
            for (int i = 0; i < itemsList.Length; i++)
            {
                Console.WriteLine(itemsList[i].S_Con + " " + itemsList[i].name + " for " + itemsList[i].S_cost + ", ");
            }
            if(itemsList[0] == null)
            {
                Bug.MessBug("01920", Bugs.craft);
            }
        }
        void Buy()
        {
            Console.WriteLine(S_NPC.ShopKeeperName + ": " + "what to buy?");
            Console.WriteLine("to a buy a thing you need to say thecnumber to buy the item " + Con[item1] + " " + ItemTaple[item1] + " for " + Cost[item1]);
            int ItemNum = int.Parse(Console.ReadLine()) - 1;
            if (S_player.Coins >= itemsList[ItemNum].S_cost)
            {
                //geting the items to Player Inv
                S_player.GetItem(itemsList[ItemNum].name, itemsList[ItemNum].S_Con);
                BuyItem(ItemNum, true);
                //sub the coins form the player
                S_player.Coins -= itemsList[ItemNum].S_cost;
                //deleteing the items form the shop
                DeleteingItems(ItemNum);
            }
            else
                BuyItem(ItemNum, false);
        }
    }
}
