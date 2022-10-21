using System;
using game_in_console.crafting;
using game_in_console.Shoping;
using game_in_console.NPC.Name;
using game_in_console.dun;
using game_in_console.dun.enemys;
using GameEMain;
using game_in_console.otherSystem;
using game_in_console.enums;

namespace game_in_console
{
    public class Converter
    {
        public ShopOp UserToShopOp(string user)
        {
            ShopOp Re = ShopOp.none;
            switch (user)
            {
                case "WCIB":
                    Re = ShopOp.WCIB;
                    break;
                case "GO":
                    Re = ShopOp.GO;
                    break;
                case "buy":
                    Re = ShopOp.buy;
                    break;
                case "help":
                    Re = ShopOp.help;
                    break;
            }
            return Re;
        }
        public StartOp UserToStartOp(string user)
        {
            StartOp Re = StartOp.none;
            switch (user)
            {
                case "Save":
                    Re = StartOp.save;
                    break;
                case "save":
                    Re = StartOp.save;
                    break;
                case "End":
                    Re = StartOp.end;
                    break;
                case "end":
                    Re = StartOp.end;
                    break;
                case "stop":
                    Re = StartOp.end;
                    break;
                case "Stop":
                    Re = StartOp.end;
                    break;
                case "info":
                    Re = StartOp.info;
                    break;
                case "Info":
                    Re = StartOp.info;
                    break;
                case "Help":
                    Re = StartOp.help;
                    break;
                case "help":
                    Re = StartOp.help;
                    break;
                case "StartDun":
                    Re = StartOp.StartDun;
                    break;
                case "Run":
                    Re = StartOp.Run;
                    break;
                case "How many coins go i have":
                    Re = StartOp.How_many_coins_go_i_have;
                    break;
                case "hmcgih":
                    Re = StartOp.How_many_coins_go_i_have;
                    break;
                case "coins":
                    Re = StartOp.How_many_coins_go_i_have;
                    break;
                case "Shop":
                    Re = StartOp.Shop;
                    break;
                case "shop":
                    Re = StartOp.Shop;
                    break;
                case "Inv":
                    Re = StartOp.Inv;
                    break;
                case "inv":
                    Re = StartOp.Inv;
                    break;
                case "mine":
                    Re = StartOp.mine;
                    break;
                case "wood":
                    Re = StartOp.wood;
                    break;
                case "Craft":
                    Re = StartOp.Craft;
                    break;
                case "craft":
                    Re = StartOp.Craft;
                    break;
                case "WorldMap":
                    Re = StartOp.WorldMap;
                    break;
                case "TownMap":
                    Re = StartOp.TownMap;
                    break;
                case "WM":
                    Re = StartOp.WorldMap;
                    break;
                case "TM":
                    Re = StartOp.TownMap;
                    break;
                case "wm":
                    Re = StartOp.WorldMap;
                    break;
                case "tm":
                    Re = StartOp.TownMap;
                    break;
                case "speed":
                    Re = StartOp.speed;
                    break;
            }
            return Re;
        }
        public CraftOp UserToCraftOp(string user)
        {
            CraftOp Re = CraftOp.none;
            switch (user)
            {
                case "Help":
                    Re = CraftOp.help;
                    break;
                case "help":
                    Re = CraftOp.help;
                    break;
                case "what can i craft":
                    Re = CraftOp.wcic;
                    break;
                case "wcic":
                    Re = CraftOp.wcic;
                    break;
                case "WCIC":
                    Re = CraftOp.wcic;
                    break;
                case "goout":
                    Re = CraftOp.GO;
                    break;
                case "GoOut":
                    Re = CraftOp.GO;
                    break;
                case "GO":
                    Re = CraftOp.GO;
                    break;
                case "Craft":
                    Re = CraftOp.craft;
                    break;
                case "craft":
                    Re = CraftOp.craft;
                    break;
            }
            return Re;
        }
        public CraftHelpOp UserToHelpCraft(string user)
        {
            CraftHelpOp helpOp = CraftHelpOp.none;
            switch (user)
            {
                case"system":
                    helpOp = CraftHelpOp.systemHelp;
                    break;
                case "craft":
                    helpOp = CraftHelpOp.craftHelp;
                    break;
            }
            return helpOp;
        }
    }
}
