using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game_in_console.enums;
using game_in_console.dun.enemys;
using GameEMain;
using game_in_console.data.items;
using game_in_console.player.databases;
namespace game_in_console.player
{
    public class Player : PlayerData
    {
        public Player()
        {
            Skills = new Skills();
            SkillsBase = new Skills();
            LevelSkills = new Skills();
            PTools = new Tools();
            Gear = new PlayerGear();
            int SpaceInInv = 50;
            Inv = new Items[SpaceInInv];
            for (int i = 0; i < Inv.Length; i++)
            {
                Inv[i] = Items.none;
            }
            InvCon = new int[SpaceInInv];
        }
        /// <summary>
        /// for the player's armor/tools
        /// </summary>
        public void UpdatePlayer()
        {
            PTools = GetTools();
            Skills.Hp = UpdateArmor(0, gear) + SkillsBase.Hp + LevelSkills.Hp;
            Skills.armor = UpdateArmor(1, gear) + SkillsBase.armor + LevelSkills.armor;
            Skills.Strength = UpdateArmor(2, gear) + SkillsBase.Strength + LevelSkills.Strength;
            Skills.Agility = UpdateArmor(3, gear) + SkillsBase.Agility + LevelSkills.Agility;
            Skills.speed = UpdateArmor(4, gear) + SkillsBase.speed + LevelSkills.speed;
            Skills.dodgeC = UpdateArmor(5, gear) + SkillsBase.dodgeC + LevelSkills.dodgeC;
            if (BronzeCount == 2)
                SetCraftingStations(3);
        }
        public void SetPLayerD()
        {
            Level = 1;
            SkillsBase.Hp = 10;
            SkillsBase.armor = 0;
            SkillsBase.Strength = 0;
            SkillsBase.Agility = 2;
            SkillsBase.speed = 2;
            SkillsBase.dodgeC = 20;
        }
        public void LevelUp(int level)
        {
            if(LevelSkills.Hp <= 300)
                SkillsBase.Hp += 10;
            if(level == 20)
                SkillsBase.armor = 1;
            if (level == 25)
                SkillsBase.Strength = 1;
            if (level == 20)
                SkillsBase.Agility = 3;
            if (level == 20)
                SkillsBase.speed = 3;
            if (level == 20)
                SkillsBase.dodgeC = 40;
        }
        public void GetItem(Items AddItem, int con)
        {
            bool GetIn = false;
            for (int i = 0; i < InvIndex; i++)
            {
                if (Inv[i] == AddItem)
                {
                    InvCon[i] += con;
                    GetIn = true;
                }
                if (Inv[i] == Items.none)
                {
                    Inv[i] = AddItem;
                    InvCon[i] = con;
                    GetIn = true;
                }
            }
            if (GetIn != true)
            {
                Inv[InvIndex] = AddItem;
                InvCon[InvIndex] = con;
                InvIndex++;
            }
        }
        public Tools GetTools()
        {
            Tools re = new Tools();
            for (int i = 0; i < InvIndex; i++)
            {
                switch (Inv[i])
                {
                    case Items.WoodenPickaxe:
                        re.Pickaxe = Inv[i];
                        break;
                    case Items.StonePickaxe:
                        re.Pickaxe = Inv[i];
                        break;
                    case Items.IronPickaxe:
                        re.Pickaxe = Inv[i];
                        break;
                    case Items.an_old_axe_form_Bolvar:
                        re.Axe = Inv[i];
                        break;
                    case Items.WoodenAxe:
                        re.Axe = Inv[i];
                        break;
                    case Items.StoneAxe:
                        re.Axe = Inv[i];
                        break;
                    case Items.IronAxe:
                        re.Axe = Inv[i];
                        break;
                    default:
                        break;
                }
                if (Inv[i] == Items.bukkit)
                    settings.Settings.HasBukkit = true;
                if (Inv[i] == Items.torch)
                    re.torch = true;
            }
            return re;
        }
    }
}
