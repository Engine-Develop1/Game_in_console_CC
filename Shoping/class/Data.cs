using game_in_console.crafting;
using game_in_console.Shoping;
using game_in_console.NPC.Name;
using game_in_console.dun;
using game_in_console.dun.enemys;
using game_in_console.data.items;
using game_in_console;
using game_in_console.otherSystem;
using game_in_console.enums;
using game_in_console.player;
using System;

namespace game_in_console.Shoping.Class
{
    public class Data
    {
        public Items[] ItemTaple { get; set; }
        public int[] Con { get; set; }
        public int[] Cost { get; set; }
        public int[] Chance { get; set; }
        public int item1 = 0;
        public int item2 = 0;
        public int item3 = 0;
    }
}
