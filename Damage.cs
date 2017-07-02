using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitWars
{
    class Damage
    {
        public enum DamageType
        {
            ENERGY,
            TYPE2,
            TYPE3
        }
        public const int DAMAGE_TYPES_N = 3;

        public class Resist
        {
            private int energy_resist = 0;
            private int type2_resist = 0;
            private int type3_resist = 0;
            public Resist(int energy_resist = 0, int type2_resist = 0, int type3_resist = 0)
            {
                this.energy_resist = energy_resist;
                this.type2_resist = type2_resist;
                this.type3_resist = type3_resist;
            }

            public int Energy_resist { get => energy_resist; set => energy_resist = value; }
            public int Type2_resist { get => type2_resist; set => type2_resist = value; }
            public int Type3_resist { get => type3_resist; set => type3_resist = value; }
        }

        private static int get_real_resist(int pirsing, Resist resist, DamageType type)
        {
            int real_resist = 0; 
            switch (type)
            {
                case DamageType.ENERGY:
                    real_resist = (resist.Energy_resist - pirsing);
                    break;
                case DamageType.TYPE2:
                    real_resist = (resist.Type2_resist - pirsing);
                    break;
                case DamageType.TYPE3:
                    real_resist = (resist.Type3_resist - pirsing);
                    break;
            }
            if (real_resist < 0)
            {
                real_resist = 0;
            }
            return real_resist;
        }
        public static int get_real_damage(int damage, int pirsing, Resist resist, DamageType type)
        {
            int real_resist = get_real_resist(pirsing, resist, type);
            //Console.WriteLine("resisted : " + real_resist.ToString());
            return damage - real_resist;
        }
        
        public class Shot
        {
            private readonly string name;
            private readonly bool is_hit = true; 
            private readonly int damage;
            private readonly DamageType type;
            private readonly int ap;
            private readonly int sp;

            public Shot(string name)
            {
                this.name = name;
                this.is_hit = false;
            }
            public Shot(string name, int damage, DamageType type, int ap = 0, int sp = 0)
            {
                this.name = name;
                this.damage = damage;
                this.type = type;
                this.ap = ap;
                this.sp = sp;
            }

            public int Damage => damage;
            public int Ap => ap;
            public int Sp => sp;

            public bool Is_hit => is_hit;

            public string Name => name;

            internal DamageType Type => type;
        }

        public class ShotResult
        {
            private int armor_damage = 0;
            private int shild_damage = 0;
            private int armor_resist = 0;
            private int shild_resist = 0;

            public ShotResult()
            {

            }
            public ShotResult(int shild_damage, int shild_resist, int armor_damage = 0, int armor_resist = 0)
            {
                this.shild_damage = shild_damage;
                this.shild_resist = shild_resist;
                this.armor_damage = armor_damage;
                this.armor_resist = armor_resist;
            }

            public int Armor_damage { get => armor_damage; set => armor_damage = value; }
            public int Shild_damage { get => shild_damage; set => shild_damage = value; }
            public int Armor_resist { get => armor_resist; set => armor_resist = value; }
            public int Shild_resist { get => shild_resist; set => shild_resist = value; }
        }
    }
}
