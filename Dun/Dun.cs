using game_in_console.dun.enemys;
using Game_in_console.data.Npc;
using game_in_console.player;
using System;

namespace Game_in_console.dun
{
    public class Dun
    {
        public Player player;
        public NPCStuff nPCNames;
        public string[] DunRoomMap { get; set; }
        private readonly int DunLevel = 1;

        int Enemylimit = 11;
        int enemyC = 0;
        readonly int min = 0;
        readonly int Max = 8;
        int Rooms = 4;
        int exit = 5;
        /// <summary>
        /// this is the start fun not the start Dun
        /// </summary>
        public void D_Start()
        {
            nPCNames.TheWildSay(0);
            nPCNames.TheWildSay(1);
            int PlayerlevelDun = int.Parse(Console.ReadLine());
            GenDun();
            if (PlayerlevelDun > 7)
            {
                Enemylimit += 2;
                Rooms += 2;
            }
            switch (PlayerlevelDun)
            {
                case 1:
                    Enemylimit = 11;
                    Rooms = 5;
                    Console.WriteLine(nPCNames.TheWild + ": ok level 1 coming op");
                    break;
                case 2:
                    Enemylimit = 16;
                    Rooms = 7;
                    break;
                case 3:
                    Enemylimit = 21;
                    Rooms = 10;
                    break;
                case 4:
                    Enemylimit = 26;
                    Rooms = 14;
                    break;
                case 5:
                    Enemylimit = 31;
                    Rooms = 17;
                    break;
                case 6:
                    Enemylimit = 38;
                    Rooms = 20;
                    break;
                case 7:
                    Enemylimit = 44;
                    Rooms = 22;
                    break;
            }
            Update();
        }
        int GoAway = 4;
        bool DunDone;
        int Playerroom;
        int playerX = 0;
        int playerY = 0;
        public void Update()
        {
            if (Playerroom == DunRoomMap.Length)
            {
                DunDone = true;
            }
            if (DunDone != true)
            {
                if (DunRoomMap[Playerroom][playerX + playerY] == ' ')
                {
                    Console.WriteLine("dead");
                }
                if (DunRoomMap[Playerroom][playerX + playerY] == 'T')
                {
                    Console.WriteLine("you lost 1 HP there is tarp");
                    Console.WriteLine(DunRoomMap[Playerroom][playerX + playerY]);
                    DunRoomMap[Playerroom][playerX + playerY].ToString().Replace('T', 'X');
                    Console.WriteLine(DunRoomMap[Playerroom][playerX + playerY]);
                }
                if (DunRoomMap[Playerroom][playerX + playerY] == 'E')
                {
                    int EE = random.Next(1, 10);
                    if (GoAway == 0 || EE == 9 && EE == 8 && EE == 6 && EE == 1)
                    {
                        Console.WriteLine("attack");
                    }
                    else
                    {
                        Console.WriteLine("you got away form the enemys this time but next time we will see about it");
                        GoAway--;
                        Console.WriteLine("you now have " + GoAway + " times to get away form an enemy");
                    }
                }
                string DunUser = Console.ReadLine();
                Contorls(DunUser);
                if (DunDone == false)
                    Update();
            }
        }
        public void Exit()
        {
            Playerroom++;
            DunRoomMap[Playerroom][playerX + playerY].ToString().Replace('T', '#');
            DunRoomMap[Playerroom][playerX + playerY].ToString().Replace('E', '#');
            DunRoomMap[Playerroom][playerX + playerY].ToString().Replace('Q', '#');
            DunRoomMap[Playerroom][playerX + playerY].ToString().Replace(' ', '#');
        }
        public void Contorls(string DunUser)
        {
            if (DunUser == "help")
            {
                Console.WriteLine("you can see the room you are in by saying (RoomMap) or (RM) \n you can ues (W),(A),(S) and (D)");
            }
            if (DunUser == "RoomMap" || DunUser == "RM")
            {
                RoomMap();
            }
            if (DunUser == "d" || DunUser == "D" && playerX <= 8)
            {
                playerX++;
            }
            if (DunUser == "a" || DunUser == "A" && playerY >= 0)
            {
                playerX--;
            }
            if (DunUser == "w" || DunUser == "W" && playerY <= 8 * 8)
            {
                playerX++;
                playerY -= 8;
            }
            if (DunUser == "s" || DunUser == "S" && playerY >= 0)
            {
                playerX++;
                playerY += 8;
            }
            if (DunUser == "C")
            {
                if (DunRoomMap[Playerroom][playerX + playerY] == 'L')
                {
                    Loot();
                }
                if (DunRoomMap[Playerroom][playerX + playerY] == 'Q' && Playerroom != DunRoomMap.Length)
                {
                    Exit();
                }
            }
        }
        public void Loot()
        {
            Console.WriteLine("There is loot");
            if (player.PTools.torch == false)
            {
                Console.WriteLine("you cant see a chast you say");
                Console.WriteLine("i need a torch to see this");
            }
            else
            {
                L_see();
            }
        }
        public void L_see()
        {
            int EnemyChast = random.Next(0, 10);
            if (EnemyChast < 5)
            {
                Console.WriteLine("no its a mimic");
                Console.WriteLine("you can run but the mimic will follow you (Run) or you cut battle it (attack)");
                string MimicAttack = Console.ReadLine();
                if (MimicAttack == "Run")
                {
                    if (Input.Chance(25 + player.SkillsBase.Agility, 0, 100))
                    {
                        Console.WriteLine("you cut run form it");
                    }
                    else
                    {
                        Console.WriteLine("you get eaten by it");
                    }
                }
                else if (MimicAttack == "attack")
                {
                    Attack("mimic", 1);
                }
            }
            else
            {
                Console.WriteLine("there is no mimic here");
                for (int i = 0; i < 3; i++)
                {
                    if (Input.Chance(10, 0, 100))
                        Console.WriteLine("this empty");
                    if (Input.Chance(25, 0, 100))
                    {
                        Console.WriteLine("you got an item25");
                    }
                    else if (Input.Chance(50, 0, 100))
                    {
                        Console.WriteLine("you got an item50");
                    }
                    else if (Input.Chance(75, 0, 100))
                    {
                        Console.WriteLine("you got an item75");
                    }
                    else if (Input.Chance(100, 0, 100))
                    {
                        Console.WriteLine("you got an item100");
                    }
                }
            }
        }
        int attack = 0;
        int HP = 0;
        int HitChance = 0;
        int dodge = 0;
        bool killed = false;
        public void Attack(string name, int enemycon)
        {
            if (attack == 0 && HP == 0 && HitChance == 0 && dodge == 0)
            {
                attack = Enemy.GetEnemy(name).Dps;
                HP = Enemy.GetEnemy(name).Hp;
                HitChance = Enemy.GetEnemy(name).HitChance;
                dodge = Enemy.GetEnemy(name).dodge;
            }
            Console.WriteLine("you can attack(attack) or check(C)");
            string AttackUser = Console.ReadLine();
            if (AttackUser == "attack")
            {
                //player attack
                if (Input.Chance(player.gear.GetGearData(enums.ArmorTypes.MainHand).HitChance - dodge, 0, 100))
                {
                    //player can attack
                    if (HP > 0)
                    {
                        HP -= player.gear.GetGearData(enums.ArmorTypes.MainHand).DPS;
                        Console.WriteLine("you hit for " + HP + player.gear.GetGearData(enums.ArmorTypes.MainHand).DPS);
                    }
                    if (HP < 0)
                    {
                        Console.WriteLine("you killde the " + name);
                        killed = true;
                    }
                }
                else
                {
                    //enemy dodges
                    Console.WriteLine("the enemy dodge you attack ");
                }
            }
            if(AttackUser == "C")
            {
                Console.WriteLine("this a " + name + " it has " + HP + "HP it can do " + attack + " harts of dam");
            }
            //enemy attack
            if (AttackUser != "C" && Input.Chance(HitChance - player.gear.GetGearData(enums.ArmorTypes.MainHand).BlockChance, 0, 100))
            {
                Console.WriteLine("the " + name + " has attack you for " + attack);
            }
            if (killed != true && enemycon != 0)
                Attack(name, enemycon);
        }
        public void RoomMap()
        {
            if (player.PTools.torch)
            {
                Console.WriteLine("you are on " + playerX + " " + playerY + " on a " + DunRoomMap[Playerroom][playerX + playerY]);
                Console.WriteLine(DunRoomMap[Playerroom]);
            }
            if (player.PTools.torch == false)
            {
                Console.WriteLine("you are on " + playerX + " " + playerY + " on a " + DunRoomMap[Playerroom][playerX + playerY]);
                if (playerY != 0 && playerX != 0)
                    Console.WriteLine(DunRoomMap[Playerroom][playerX - 1 + playerY - 8] + DunRoomMap[Playerroom][playerX + playerY - 8] + DunRoomMap[Playerroom][playerX + 1 + playerY - 8] + "\n" +
                                  DunRoomMap[Playerroom][playerX - 1 + playerY] + DunRoomMap[Playerroom][playerX + playerY] + DunRoomMap[Playerroom][playerX + 1 + playerY] + "\n" +
                                  DunRoomMap[Playerroom][playerX - 1 + playerY + 8] + DunRoomMap[Playerroom][playerX + playerY + 8] + DunRoomMap[Playerroom][playerX + 1 + playerY + 8]);
                if (playerY == 0 && playerX == 0)
                    Console.WriteLine(DunRoomMap[Playerroom][playerX + playerY] + DunRoomMap[Playerroom][playerX + 1 + playerY] + "\n" +
                                  DunRoomMap[Playerroom][playerX + playerY + 8] + DunRoomMap[Playerroom][playerX + 1 + playerY + 8]);
                if (playerY != 0)
                    Console.WriteLine(DunRoomMap[Playerroom][playerX + playerY - 8] + DunRoomMap[Playerroom][playerX + 1 + playerY - 8] + "\n" +
                                  DunRoomMap[Playerroom][playerX + playerY] + DunRoomMap[Playerroom][playerX + 1 + playerY] + "\n" +
                                  DunRoomMap[Playerroom][playerX + playerY + 8] + DunRoomMap[Playerroom][playerX + 1 + playerY + 8]);
                if (playerX != 0)
                    Console.WriteLine(DunRoomMap[Playerroom][playerX - 1 + playerY] + DunRoomMap[Playerroom][playerX + playerY] + DunRoomMap[Playerroom][playerX + 1 + playerY] + "\n" +
                                  DunRoomMap[Playerroom][playerX - 1 + playerY + 8] + DunRoomMap[Playerroom][playerX + playerY + 8] + DunRoomMap[Playerroom][playerX + 1 + playerY + 8]);
            }
        }
        Random random;
        void GenDun()
        {
            DunRoomMap = new string[Rooms];
            random = new Random();
            for (int s = 0; s < Rooms; s++)
            {
                string TempDunRoom = "";
                for (int i = 0; i < 8 * 8; i++)
                {
                    TempDunRoom =
                    random.Next(min, Max).ToString() +
                    TempDunRoom;
                    if (i == 8 || i == 16 || i == 24 || i == 32 || i == 40 || i == 48 || i == 56 || i == 64)
                    {
                        TempDunRoom = "\r\n" + TempDunRoom;
                    }
                }
                //Console.WriteLine(s + " " + TempDunRoom[i]);
                if (TempDunRoom.Contains('2') ||
                    TempDunRoom.Contains('3'))
                {
                    enemyC++;
                }
                if (TempDunRoom.Contains('7') && exit != 0)
                {
                    exit--;
                }
                TempDunRoom = TempDunRoom.Replace('0', ' ');//air
                TempDunRoom = TempDunRoom.Replace('1', '#');//tile
                if (enemyC! < Enemylimit)
                {
                    TempDunRoom = TempDunRoom.Replace('2', 'E');//enemy
                    TempDunRoom = TempDunRoom.Replace('3', 'E');//enemy
                }
                else
                {
                    TempDunRoom = TempDunRoom.Replace('2', 'C');//enemy
                    TempDunRoom = TempDunRoom.Replace('3', 'C');//enemy
                }
                TempDunRoom = TempDunRoom.Replace('4', 'X');//tile
                TempDunRoom = TempDunRoom.Replace('5', 'L');//loot
                TempDunRoom = TempDunRoom.Replace('6', 'T');//tarp
                TempDunRoom = TempDunRoom.Replace('8', 'D');//door
                if (exit != 0)
                {
                    TempDunRoom = TempDunRoom.Replace('7', 'Q');//Exit
                }
                if (exit == 0)
                {
                    TempDunRoom = TempDunRoom.Replace('7', '#');//tile
                }
                DunRoomMap[s] = TempDunRoom;
            }
        }
    }
}
