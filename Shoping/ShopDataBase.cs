using game_in_console.crafting;
using game_in_console.Shoping;
using game_in_console.NPC.Name;
using game_in_console.dun;
using game_in_console.data.items;
using game_in_console;
using game_in_console.otherSystem;
using game_in_console.enums;
using game_in_console.player;
using System;
using game_in_console.Shoping.Class;

namespace game_in_console.Shoping
{
    public class ShopDataBase : Data
    {
        private const int itemslistL = 3;
        public bool GetInFrist = true;
        public bool _exit = false;
        public NPCNames S_NPC;
        public Player S_player;
        public Converter converter;
        int index = 0;
        /// <summary>
        /// a taple for all the items you can get!
        /// </summary>
        public ShopItemsList[] itemsList = new ShopItemsList[itemslistL];
        public int ItemsListIndex;
        public void SetShopSettings()
        {
            switch (S_player.WhatCraftingStations())
            {
                case CraftingStations.WoodWork:
                    index = 5;
                    ItemTaple = new Items[index];
                    ItemTaple[0] = Items.stick;
                    ItemTaple[1] = Items.Wood;
                    ItemTaple[2] = Items.WoodenAxe;
                    ItemTaple[3] = Items.WoodenSword;
                    ItemTaple[4] = Items.an_old_axe_form_Bolvar;
                    Con = new int[index];
                    Con[0] = 2;
                    Con[1] = 3;
                    Con[2] = 1;
                    Con[3] = 1;
                    Con[4] = 1;
                    Cost = new int[index];
                    Cost[0] = 10;
                    Cost[1] = 15;
                    Cost[2] = 25;
                    Cost[3] = 20;
                    Cost[4] = 150;
                    Chance = new int[index];
                    Chance[0] = 50;
                    Chance[1] = 50;
                    Chance[2] = 25;
                    Chance[3] = 10;
                    Chance[4] = 1;
                    break;
                case CraftingStations.StoneWorkshop:
                    break;
                case CraftingStations.SmeltingStation:
                    break;
                case CraftingStations.AlloySmelt:
                    break;
                case CraftingStations.Anvil:
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// gets the item in numbers
        /// </summary>
        /// <param name="RNG"></param>
        public void SetNumber(Random RNG)
        {
            item1 = RNG.Next(0, index);
            item2 = RNG.Next(0, index);
            item3 = RNG.Next(0, index);
        }
        /// <summary>
        /// sets all items to there item index in the array
        /// </summary>
        /// <param name="Index"></param>
        public void SetAllItems(int Index)
        {
            itemsList[ItemsListIndex].name = ItemTaple[Index];
            itemsList[ItemsListIndex].S_Con = Con[Index];
            itemsList[ItemsListIndex].S_cost = Cost[Index];
        }

        public void SetupShop(Random RNG)
        {
            if(GetInFrist == true)
            {
                SetShopSettings();
                Console.WriteLine(S_NPC.ShopKeeperName + ": " + S_NPC.Dia_ShopKeeperIn[RNG.Next(0, S_NPC.Dia_ShopKeeperIn.Length)]);
                SetNumber(RNG);
                SetAllItems(item1);
                ItemsListIndex++;
                SetAllItems(item2);
                ItemsListIndex++;
                SetAllItems(item3);
            }
        }
        public void BuyItem(int Index, bool buy)
        {
            int NeedCoins = S_player.Coins - itemsList[Index].S_cost;
            switch (buy)
            {
                case true:
                    Console.WriteLine(S_NPC.ShopKeeperName + ": " + "thank you for purchaseing " + itemsList[Index].S_Con + " " + itemsList[Index].name + " for " + itemsList[Index].S_cost);
                    break;
                case false:
                    Console.WriteLine(S_NPC.ShopKeeperName + ": " + "Sorry but you do not have enough coins you need " + itemsList[Index].S_cost + " coins and you have " + S_player.Coins + " coins you need " + NeedCoins + " coins");
                    break;
            }
        }
        public void GetPlayerShopItems()
        {
            const int L = 0;
            if (S_player.GetCraftingStations(1) == CraftingStations.StoneWorkshop)
            {
                ItemTaple = new Items[L];
                for (int i = 0; i < L; i++)
                {
                    ItemTaple[i] = Items.stone;
                    ItemTaple[i] = Items.stick;
                    ItemTaple[i] = Items.Wood;
                    ItemTaple[i] = Items.coal;
                    ItemTaple[i] = Items.StonePickaxe;
                }
            }
            if (S_player.GetCraftingStations(2) == CraftingStations.SmeltingStation)
            {

            }
            if (S_player.GetCraftingStations(3) == CraftingStations.AlloySmelt)
            {
            }
            if (S_player.GetCraftingStations(4) == CraftingStations.Anvil)
            {

            }
        }
        public void DeleteingItems(int Index)
        {
            itemsList[Index].name = Items.none;
            itemsList[Index].S_Con = 0;
            itemsList[Index].S_cost = 0;
        }
        public void Bye(Random RNG)
        {
            Console.WriteLine(S_NPC.ShopKeeperName + ": " + S_NPC.Dia_ShopKeeperOut[RNG.Next(0, S_NPC.Dia_ShopKeeperOut.Length)]);
        }
    }
}
