using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitWars
{
    class Weapon
    {
        private static Random rand = new Random();
        private readonly int min_damage;
        private readonly int max_damage;

        private readonly Damage.DamageType type;
        private readonly int ap = 0;
        private readonly int sp = 0;
        private readonly string name;
        private readonly int presition; 
        public int Ap => ap;
        public int Sp => sp;
        public string Name => name;
        internal Damage.DamageType Type => type;
        public int Min_damage => min_damage;
        public int Max_damage => max_damage;

        public Weapon(int min_damage, int max_damage, Damage.DamageType type, int presition, string name)
        {
            this.min_damage = min_damage;
            this.max_damage = max_damage;
            this.type = type;
            this.presition = presition;
            this.name = name;
        }

        public Weapon(int min_damage, int max_damage, Damage.DamageType type, int presition, string name, int ap, int sp)
            : this(min_damage, max_damage, type, presition, name)
        {
            this.ap = ap;
            this.sp = sp;
        }

        public int GetDamage()
        {
            return rand.Next(min_damage, max_damage);
        }

        public bool Fire(int user_presition)
        {
            return (user_presition > rand.Next(0, 100)) && (presition > rand.Next(0, 100));
        }
    }
}
