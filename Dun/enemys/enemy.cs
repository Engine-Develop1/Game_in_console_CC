using System;
using System.Collections.Generic;
using System.Text;

namespace game_in_console.dun.enemys
{
    public class Data
    {
        public string name;
        public int Hp;
        public int Dps;
        /// <summary>
        /// the level the enemy is at
        /// </summary>
        public int StartLevel;
        public int dodge;
    }
    public class EnemyData : Data
    {
        /// <summary>
        /// what the hit chance is to hit the player
        /// </summary>
        public int HitChance;
        /// <summary>
        /// what dun level the enemy can appear in
        /// </summary>
        public int DunLevel;
    }
    public class BossData : Data
    {
        public int DunLevel;
    }
    public class EnemyCom
    {
        public BossData[] BossData = new BossData[100];
        public EnemyData[] Data = new EnemyData[100];
        int enemyIndex = 0;
        int BossDataIndex = 0;
        public void Addenemy(string name, int Hp, int Dps, int chance, int DunLevel, int Level, int dodge)
        {
            Data[enemyIndex].name = name;
            Data[enemyIndex].Hp = Hp;
            Data[enemyIndex].Dps = Dps;
            Data[enemyIndex].HitChance = chance;
            Data[enemyIndex].DunLevel = DunLevel;
            Data[enemyIndex].StartLevel = Level;
            Data[enemyIndex].dodge = dodge;
            enemyIndex++;
        }
        public void AddBoss(string name, int Hp, int Dps, int DunLevel)
        {
            BossData[BossDataIndex].name = name;
            BossData[BossDataIndex].Hp = Hp;
            BossData[BossDataIndex].Dps = Dps;
            BossData[BossDataIndex].DunLevel = DunLevel;
            BossDataIndex++;
        }
    }
    public class Enemy
    {
        static readonly EnemyCom data = new EnemyCom();
        Enemy()
        {
            data.Addenemy("Rat", 10, 1, 25, 1, 1, 50);
            data.Addenemy("Skeleton", 25, 2, 50, 2, 1,25);
            data.Addenemy("Mimic", 50, 3, 75, -1, 2,25);
        }
        public static EnemyData GetEnemy(string name)
        {
            EnemyData Re = new EnemyData();
            for (int i = 0; i < data.Data.Length; i++)
            {
                if(data.Data[i].name == name)
                {
                    Re.name = data.Data[i].name;
                    Re.Hp = data.Data[i].Hp;
                    Re.Dps = data.Data[i].Dps;
                    Re.HitChance = data.Data[i].HitChance;
                    Re.DunLevel = data.Data[i].DunLevel;
                    Re.StartLevel = data.Data[i].StartLevel;
                    Re.dodge = data.Data[i].dodge;
                }
            }
            return Re;
        }
    }
}
