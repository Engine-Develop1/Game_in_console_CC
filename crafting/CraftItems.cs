using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game_in_console.bug;
using game_in_console.enums;
using game_in_console.player;
using GameEMain;
namespace game_in_console.crafting
{
    public class CraftItems
    {
        bool Dev;
        public Player C_Player;
        public CraftingStations stations;
        public void Craft(string Item)
        {
            Dev = settings.Settings.Dev;
            //make a crafting system 
            if(Dev)
                Console.WriteLine("system: finding item form database ");
            switch (stations)
            {
                case CraftingStations.WoodWork:
                    if ("Wooden pickaxe" == Item || "WP" == Item || "wp" == Item)
                        Craft2I(Items.Wood, 3, Items.stick, 2, Items.WoodenPickaxe, 1);
                    else if ("wooden axe" == Item || "Wooden axe" == Item || "WA" == Item || "wa" == Item)
                        Craft2I(Items.Wood, 3, Items.stick, 2, Items.WoodenAxe, 1);
                    else if ("wooden sword" == Item || "Wooden sword" == Item || "WS" == Item || "ws" == Item)
                        Craft2I(Items.Wood, 3, Items.stick, 2, Items.WoodenAxe, 1);
                    else if ("Sticks" == Item || "sticks" == Item)
                        Craft1I(Items.Wood, 4, Items.stick, 32);
                    else if ("Wood" == Item || "wood" == Item)
                        Craft1I(Items.stick, 8, Items.Wood, 1);
                    break;
                case CraftingStations.StoneWorkshop:
                    if ("Stone pickaxe" == Item || "SP" == Item || "sp" == Item)
                        Craft2I(Items.stone, 3, Items.stick, 2, Items.StonePickaxe, 1);
                    else if ("furnace" == Item || "furn" == Item || "Furn" == Item)
                        Craft1IStation(Items.stone, 8, CraftingStations.SmeltingStation);
                    else if ("Anvil" == Item || "anvil" == Item)
                        Craft2IStation(Items.ironIngot, 4, Items.iron_block, 3, CraftingStations.Anvil);
                    break;
                case CraftingStations.SmeltingStation:
                    if ("iron" == Item || "Iron" == Item)
                        Craft2I(Items.ironore, 2, Items.coal, 1, Items.ironIngot, 1);
                    if ("ironblock" == Item || "IronBlock" == Item || "IB" == Item || "ib" == Item)
                        Craft1I(Items.ironIngot, 8, Items.iron_block, 1);
                    else if ("iron2" == Item || "Iron2" == Item)
                        Craft2I(Items.ironore, 4, Items.coal, 2, Items.ironIngot, 2);
                    break;
                case CraftingStations.AlloySmelt:
                    if ("steel" == Item || "Steel" == Item || "SB" == Item || "sb" == Item)
                        Craft3I(Items.ironore, 2, Items.coal, 4, Items.lava_bukkit, 1, Items.steel, 1);
                    break;
                case CraftingStations.Anvil:
                    if ("Iron pickaxe" == Item || "IP" == Item || "ip" == Item)
                        Craft2I(Items.ironIngot, 3, Items.stick, 2, Items.IronPickaxe, 1);
                    break;
            }
        }
        public void Craft1I(Items items1, int Item1Con, Items Re, int ReCon)
        {
            for (int s = 0; s < C_Player.InvIndex; s++)
            {
                if (C_Player.Inv[s] == items1)
                {
                    int F = 0;
                    if (C_Player.InvCon[s] >= Item1Con)
                    {
                        if (C_Player.InvCon[s] == Item1Con)
                        {
                            C_Player.InvCon[s] = 0;
                            C_Player.Inv[s] = Items.none;
                        }
                        else
                            C_Player.InvCon[s] = C_Player.InvCon[s] - Item1Con;
                        F++;
                    }
                    if (F == 1)
                    {
                        bool Done = false;
                        for (int i = 0; i < C_Player.InvIndex; i++)
                        {
                            if (C_Player.Inv[i] == Re && Done != true)
                            {
                                C_Player.GetItem(Re, ReCon);
                                Done = true;
                            }
                            else if (C_Player.Inv[C_Player.InvIndex] == Items.none && Done != true && i == C_Player.InvIndex - 1)
                            {
                                C_Player.GetItem(Re, ReCon);
                                Done = true;
                            }
                        }
                    }
                }

            }
        }
        public void Craft1IStation(Items items1, int Item1Con, CraftingStations Re)
        {
            for (int s = 0; s < C_Player.InvIndex; s++)
            {
                if (C_Player.Inv[s] == items1)
                {
                    int F = 0;
                    if (C_Player.InvCon[s] >= Item1Con)
                    {
                        if (C_Player.InvCon[s] == Item1Con)
                        {
                            C_Player.InvCon[s] = 0;
                            C_Player.Inv[s] = Items.none;
                        }
                        else
                            C_Player.InvCon[s] = C_Player.InvCon[s] - Item1Con;
                        F++;
                    }
                    if (F == 1)
                    {
                        for (int i = 0; i < C_Player.InvIndex; i++)
                        {
                            switch (Re)
                            {
                                case CraftingStations.WoodWork:
                                    break;
                                case CraftingStations.StoneWorkshop:
                                    break;
                                case CraftingStations.SmeltingStation:
                                    C_Player.SetCraftingStations(2);
                                    break;
                                case CraftingStations.AlloySmelt:
                                    break;
                                case CraftingStations.Anvil:
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

            }
        }
        public void Craft2I(Items items1, int Item1Con, Items items2, int Item2Con, Items Re, int ReCon)
        {
            for (int s = 0; s < C_Player.InvIndex; s++)
            {
                for (int a = 0; a < C_Player.InvIndex; a++)
                {
                    if (C_Player.Inv[s] == items1 && C_Player.Inv[a] == items2)
                    {
                        int F = 0;
                        if (C_Player.InvCon[s] >= Item1Con)
                        {
                            if (C_Player.InvCon[s] == Item1Con)
                            {
                                C_Player.InvCon[s] = 0;
                                C_Player.Inv[s] = Items.none;
                            }
                            else
                                C_Player.InvCon[s] = C_Player.InvCon[s] - Item1Con;
                            F++;
                        }
                        if (C_Player.InvCon[a] >= Item2Con)
                        {
                            if (C_Player.InvCon[a] == Item2Con)
                            {
                                C_Player.InvCon[a] = 0;
                                C_Player.Inv[a] = Items.none;
                            }
                            else
                                C_Player.InvCon[a] -= Item2Con;
                            F++;
                        }
                        if (F == 2)
                        {
                            if (Re == Items.bronze)
                                C_Player.BronzeCount++;
                            bool Done = false;
                            for (int i = 0; i < C_Player.InvIndex; i++)
                            {
                                if (C_Player.Inv[i] == Re && Done != true)
                                {
                                    C_Player.GetItem(Re, ReCon);
                                    Done = true;
                                }
                                else if(C_Player.Inv[C_Player.InvIndex] == Items.none && Done != true && i == C_Player.InvIndex)
                                {
                                    C_Player.GetItem(Re, ReCon);
                                }
                            }
                        }
                    }
                }
            }
        }
        public void Craft2IStation(Items items1, int Item1Con, Items items2, int Item2Con, CraftingStations Re)
        {
            for (int s = 0; s < C_Player.InvIndex; s++)
            {
                for (int a = 0; a < C_Player.InvIndex; a++)
                {
                    if (C_Player.Inv[s] == items1 && C_Player.Inv[a] == items2)
                    {
                        int F = 0;
                        if (C_Player.InvCon[s] >= Item1Con)
                        {
                            if (C_Player.InvCon[s] == Item1Con)
                            {
                                C_Player.InvCon[s] = 0;
                                C_Player.Inv[s] = Items.none;
                            }
                            else
                                C_Player.InvCon[s] = C_Player.InvCon[s] - Item1Con;
                            F++;
                        }
                        if (C_Player.InvCon[a] >= Item2Con)
                        {
                            if (C_Player.InvCon[a] == Item2Con)
                            {
                                C_Player.InvCon[a] = 0;
                                C_Player.Inv[a] = Items.none;
                            }
                            else
                                C_Player.InvCon[a] -= Item2Con;
                            F++;
                        }
                        if (F == 2)
                        {
                            switch (Re)
                            {
                                case CraftingStations.WoodWork:
                                    break;
                                case CraftingStations.StoneWorkshop:
                                    break;
                                case CraftingStations.SmeltingStation:
                                    C_Player.SetCraftingStations(2);
                                    break;
                                case CraftingStations.AlloySmelt:
                                    break;
                                case CraftingStations.Anvil:
                                    C_Player.SetCraftingStations(4);
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                }

            }
        }
        public void Craft3I(Items items1, int Item1Con, Items items2, int Item2Con, Items items3, int Item3Con, Items Re, int ReCon)
        {
            for (int s = 0; s < C_Player.InvIndex; s++)
            {
                for (int a = 0; a < C_Player.InvIndex; a++)
                {
                    for (int d = 0; d < C_Player.InvIndex; d++)
                    {
                        if (C_Player.Inv[s] == items1 && C_Player.Inv[a] == items2 && C_Player.Inv[d] == items3)
                        {
                            int F = 0;
                            if (C_Player.InvCon[s] >= Item1Con)
                            {
                                if (C_Player.InvCon[s] == Item1Con)
                                {
                                    C_Player.InvCon[s] = 0;
                                    C_Player.Inv[s] = Items.none;
                                }
                                else
                                    C_Player.InvCon[s] = C_Player.InvCon[s] - Item1Con;
                                F++;
                            }
                            if (C_Player.InvCon[a] >= Item2Con)
                            {
                                if (C_Player.InvCon[a] == Item2Con)
                                {
                                    C_Player.InvCon[a] = 0;
                                    C_Player.Inv[a] = Items.none;
                                }
                                else
                                    C_Player.InvCon[a] -= Item2Con;
                                F++;
                            }
                            if (C_Player.InvCon[d] >= Item3Con)
                            {
                                if (C_Player.InvCon[d] == Item3Con)
                                {
                                    C_Player.InvCon[d] = 0;
                                    C_Player.Inv[d] = Items.none;
                                }
                                else
                                    C_Player.InvCon[d] = C_Player.InvCon[d] - Item3Con;
                                F++;
                            }
                            if (F == 3)
                            {
                                bool Done = false;
                                for (int i = 0; i < C_Player.InvIndex; i++)
                                {
                                    if (C_Player.Inv[i] == Re && Done != true)
                                    {
                                        C_Player.GetItem(Re, ReCon);
                                        Done = true;
                                    }
                                    else if (C_Player.Inv[C_Player.InvIndex] == Items.none && Done != true && i == C_Player.InvIndex)
                                    {
                                        C_Player.GetItem(Re, ReCon);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
