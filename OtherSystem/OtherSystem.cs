using System;
using System.Linq;
using game_in_console.crafting;
using game_in_console.Shoping;
using game_in_console.NPC.Name;
using game_in_console.dun;
using game_in_console.dun.enemys;
using game_in_console.enums;
using game_in_console.player;
using GameEMain;

namespace game_in_console.otherSystem
{
    public class OtherSystem
    {
        public NPCNames NPCNames;
        public Player player;
        public bool HasPickaxe;
        public bool HasBukkit;
        public bool HasAxe;
        readonly Random RNG;
        public OtherSystem()
        {
            RNG = new Random();
        }
        //in M
        public Items[] ItemPoolWood = { Items.Wood, Items.stick, Items.Piece_of_wood };
        public int[] ItemPoolWoodCon = {1, 2, 1 };
        public int[] ItemPoolWoodChance = { 25, 75, 100 };
        public int WalkingDis;
        public int DisTime;
        public int time;
        public void GetLava()
        {
            if (HasBukkit == true)
            {
                int RNGmin = 5;
                int RNGMax = 10;
                int Ca = 1;
                int Cmin = 1;
                int Cmax = 2;
                WalkingDis = RNG.Next(RNGmin, RNGMax);
                int Div = Input.Range(Cmin, Cmax, Ca);
                if (Div != 0)
                    DisTime = WalkingDis / (player.Skills.speed + Div);
                else
                    DisTime = WalkingDis / (player.Skills.speed + 1);
                Console.WriteLine("the walkingDis is " + WalkingDis + "km and it will take " + DisTime + "min do you wont to go?");
                string User = Console.ReadLine();
                if (User == "go")
                {
                    time = DateTime.Now.Minute;
                    Console.WriteLine("ok");
                    TakeTime(time, DisTime);
                }
            }
        }
        Items[] ItemPoolMine = new Items[1];
        int[] ItemPoolMineCon = new int[1];
        int[] ItemPoolMineChance = new int[1];
        public void Mine(Items Pickaxe)
        {
            int Cmax = 0, Cmin = 0, Ca = 0, RNGMax = 0, RNGmin = 0, Cbreak = 0;
            switch (Pickaxe)
            {
                case Items.WoodenPickaxe:
                    ItemPoolMineChance = new int[3];
                    ItemPoolMineCon = new int[3];
                    ItemPoolMine = new Items[3];
                    ItemPoolMine[0] = Items.coal; 
                    ItemPoolMine[1] = Items.stone;
                    ItemPoolMine[2] = Items.flint;
                    ItemPoolMineCon[0] = 1;
                    ItemPoolMineCon[1] = 2;
                    ItemPoolMineCon[2] = 1;
                    ItemPoolMineChance[0] = 25;
                    ItemPoolMineChance[1] = 75;
                    ItemPoolMineChance[2] = 100;
                    RNGmin = 5;
                    RNGMax = 10;
                    Ca = 1;
                    Cmin = 1;
                    Cmax = 2;
                    Cbreak = 75;
                    break;
                case Items.StonePickaxe:
                    ItemPoolMineChance = new int[4];
                    ItemPoolMineCon = new int[4];
                    ItemPoolMine = new Items[4];
                    ItemPoolMine[0] = Items.ironore;
                    ItemPoolMine[1] = Items.coal;
                    ItemPoolMine[2] = Items.stone;
                    ItemPoolMine[3] = Items.flint;
                    ItemPoolMineCon[0] = 1;
                    ItemPoolMineCon[1] = 2;
                    ItemPoolMineCon[2] = 3;
                    ItemPoolMineCon[3] = 2;
                    ItemPoolMineChance[0] = 25;
                    ItemPoolMineChance[1] = 55;
                    ItemPoolMineChance[2] = 75;
                    ItemPoolMineChance[3] = 100;
                    RNGmin = 7;
                    RNGMax = 13;
                    Ca = 5;
                    Cmin = 1;
                    Cmax = 5;
                    Cbreak = 45;
                    break;
                case Items.IronPickaxe:
                    RNGmin = 10;
                    RNGMax = 15;
                    Ca = 7;
                    Cmin = 3;
                    Cmax = 7;
                    Cbreak = 25;
                    ItemPoolMineChance = new int[6];
                    ItemPoolMineCon = new int[6];
                    ItemPoolMine = new Items[6];
                    ItemPoolMine[0] = Items.ironore;
                    ItemPoolMine[1] = Items.copperore;
                    ItemPoolMine[3] = Items.tinore;
                    ItemPoolMine[2] = Items.coal;
                    ItemPoolMine[4] = Items.flint;
                    ItemPoolMine[5] = Items.stone;
                    ItemPoolMineCon[0] = 2;
                    ItemPoolMineCon[1] = 2;
                    ItemPoolMineCon[2] = 4;
                    ItemPoolMineCon[3] = 2;
                    ItemPoolMineCon[4] = 3;
                    ItemPoolMineCon[5] = 6;
                    ItemPoolMineChance[0] = 30;
                    ItemPoolMineChance[1] = 45;
                    ItemPoolMineChance[2] = 55;
                    ItemPoolMineChance[3] = 60;
                    ItemPoolMineChance[4] = 70;
                    ItemPoolMineChance[5] = 80;
                    break;
                case Items.steelPickaxe:
                    RNGmin = 7;
                    RNGMax = 13;
                    Ca = 5;
                    Cmin = 1;
                    Cmax = 5;
                    Cbreak = 1;
                    ItemPoolMineChance = new int[4];
                    ItemPoolMineCon = new int[4];
                    ItemPoolMine = new Items[4];
                    ItemPoolMine[0] = Items.steel;
                    ItemPoolMine[1] = Items.steel;
                    ItemPoolMine[2] = Items.steel;
                    ItemPoolMine[3] = Items.stone;
                    ItemPoolMineCon[0] = 1;
                    ItemPoolMineCon[1] = 1;
                    ItemPoolMineCon[2] = 1;
                    ItemPoolMineCon[3] = 8;
                    ItemPoolMineChance[0] = 10;
                    ItemPoolMineChance[1] = 15;
                    ItemPoolMineChance[2] = 20;
                    ItemPoolMineChance[3] = 100;

                    break;
            }
            WalkingDis = RNG.Next(RNGmin, RNGMax);
            int Div = Input.Range(Cmin, Cmax, Ca);
            if (Div != 0)
                DisTime = WalkingDis / (player.Skills.speed + Div);
            else
                DisTime = WalkingDis / (player.Skills.speed + 1);
            Console.WriteLine("the walkingDis is " + WalkingDis + "km and it will take " + DisTime + "min do you wont to go?");
            string User = Console.ReadLine();
            if (User == "go")
            {
                time = DateTime.Now.Minute;
                Console.WriteLine("ok");
                TakeTime(time, DisTime);
                Result(ItemPoolMine, ItemPoolMineCon, ItemPoolMineChance);
                if (Input.Chance(Cbreak, 1, 100))
                {
                    Console.WriteLine("your axe broke you got 2 pieces of wood");
                    player.PTools.Axe = Items.none;
                    player.UpdatePlayer();
                    switch (Pickaxe)
                    {
                        case Items.WoodenPickaxe:
                            player.GetItem(Items.Piece_of_wood, 2);
                            break;
                        case Items.StonePickaxe:
                            player.GetItem(Items.stick, 2);
                            player.GetItem(Items.stone, 1);
                            break;
                        case Items.IronPickaxe:
                            player.GetItem(Items.stick, 4);
                            player.GetItem(Items.stick, Input.Range(0, 75, 1)* (Input.Range(0, 75, 1)+1));
                            break;
                        case Items.steelPickaxe:
                            player.GetItem(Items.stick, 1);
                            player.GetItem(Items.stick, Input.Range(0,100,1));
                            break;
                    }
                }
            }

        }
        public void Wood(Items axe)
        {
            int Cmax = 0, Cmin = 0, Ca = 0, RNGMax = 0, RNGmin = 0, Cbreak = 0;
            switch (axe)
            {
                case Items.an_old_axe_form_Bolvar:
                    RNGmin = 3;
                    RNGMax = 5;
                    Ca = 10;
                    Cmin = 0;
                    Cmax = 0;
                    Cbreak = 76;
                    ItemPoolWoodChance[0] = 75;
                    ItemPoolWoodChance[1] = 50;
                    break;
                case Items.WoodenAxe:
                    RNGmin = 5;
                    RNGMax = 10;
                    Ca = 1;
                    Cmin = 1;
                    Cmax = 2;
                    Cbreak = 75;
                    break;
                case Items.StoneAxe:
                    RNGmin = 7;
                    RNGMax = 13;
                    Ca = 5;
                    Cmin = 1;
                    Cmax = 5;
                    Cbreak = 50;
                    break;
                case Items.IronAxe:
                    break;
            }
            WalkingDis = RNG.Next(RNGmin, RNGMax);
            int Div = Input.Range(Cmin, Cmax, Ca);
            if (Div != 0)
                DisTime = WalkingDis / (player.Skills.speed + Div);
            else
                DisTime = WalkingDis / (player.Skills.speed + 1);
            Console.WriteLine("the walkingDis is " + WalkingDis + "km and it will take " + DisTime + "min do you wont to go?");
            string User = Console.ReadLine();
            if (User == "go")
            {
                time = DateTime.Now.Minute;
                Console.WriteLine("ok");
                TakeTime(time, DisTime);
                Result(ItemPoolWood,ItemPoolWoodCon,ItemPoolWoodChance);
                if (Input.Chance(Cbreak, 0, 100))
                {
                    Console.WriteLine("your axe broke you got 2 pieces of wood");
                    player.PTools.Axe = Items.none;
                    player.UpdatePlayer();
                    switch (axe)
                    {
                        case Items.an_old_axe_form_Bolvar:
                            break;
                        case Items.WoodenAxe:
                            player.GetItem(Items.Piece_of_wood, 2);
                            break;
                        case Items.StoneAxe:
                            break;
                        case Items.IronAxe:
                            break;
                    }
                }
            }

        }
        int Timer;
        public void TakeTime(int Start_time, int Distime)
        {
            Timer = Start_time + Distime;
            string User = Console.ReadLine();
            if (User == "done")
                Console.WriteLine("here " + Timer + "Minutes");
            if (Timer >= DateTime.Now.Minute)
                TakeTime(Start_time, Distime);
        }
        public void Result(Items[] ItemPool, int[] ItemPoolCon, int[] ItemPoolChance)
        {
            Items Re = Items.none;
            int con = 0;
            int Chance = Input.ChanceOut(0, 100);
            if (Chance < ItemPoolChance[0])
            {
                Re = ItemPool[0];
                con = ItemPoolCon[0];
            }
            else if (Chance < ItemPoolChance[1])
            {
                Re = ItemPool[1];
                con = ItemPoolCon[1];
            }
            else if (Chance < ItemPoolChance[2])
            {
                Re = ItemPool[2];
                con = ItemPoolCon[2];
            }
            if (Re == Items.stone)
                player.SetCraftingStations(1);
            bool Done = false;
            Console.WriteLine("you got " + con + " " + Re);
            for (int i = 0; i < player.InvIndex; i++)
            {
                if (player.Inv[i] == Re && Done != true)
                {
                    player.GetItem(Re, con);
                    Done = true;
                }
                else if (player.Inv[player.InvIndex] == Items.none && Done != true && i == player.InvIndex - 1)
                {
                    player.GetItem(Re, con);
                    Done = true;
                }

            }
        }
    }
}
