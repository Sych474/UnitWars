using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitWars
{
    class BaseObject
    {
        private int hull_points;
        private readonly int max_hull_points; 
        private int shield = 0;
        private readonly int max_shild = 0;
        private readonly string name; 
        private Damage.Resist armor_resist;
        private Damage.Resist shild_resist;

        public int Hull_points { get => hull_points; set => hull_points = value; }
        public int Shild { get => shield; set => shield = value; }
        internal Damage.Resist Armor_resist { get => armor_resist; set => armor_resist = value; }
        internal Damage.Resist Shild_resist { get => shild_resist; set => shild_resist = value; }

        public string Name => name;
        public int Max_hull_points => max_hull_points;
        public int Max_shield => max_shild;


        public BaseObject(int hp, int shield = 0, string name = "")
        {
            this.hull_points = hp;
            this.max_hull_points = hp;
            this.shield = shield;
            this.max_shild = shield;
            this.name = name;
            this.armor_resist = new Damage.Resist();
            this.shild_resist = new Damage.Resist();
        }
        public BaseObject(int hp, int shield, string name, Damage.Resist armor_resist)
        {
            this.hull_points = hp;
            this.max_hull_points = hp;
            this.shield = shield;
            this.max_shild = shield;
            this.name = name;
            this.armor_resist = armor_resist;
            this.shild_resist = new Damage.Resist();
        }
        public BaseObject(int hp, int shield, string name, Damage.Resist armor_resist, Damage.Resist shild_resist)
        {
            this.hull_points = hp;
            this.max_hull_points = hp;
            this.shield = shield;
            this.max_shild = shield;
            this.name = name;
            this.armor_resist = armor_resist;
            this.shild_resist = shild_resist;
        }
        public List<Damage.ShotResult> GetShots(List<Damage.Shot> shots)
        {
            var res = new List<Damage.ShotResult>();
            foreach (var item in shots)
            {
                res.Add(GetShot(item));
            }
            return res;
        }
        public Damage.ShotResult GetShot(Damage.Shot shot)
        {
            Damage.ShotResult res = new Damage.ShotResult();
            if (!shot.Is_hit) return res;

            res.Armor_damage = this.hull_points;
            res.Shild_damage = this.shield;
            
            int pirsed_damage = shot.Damage; 
            if (shield > 0)
            {
                pirsed_damage = damage_shield(shot.Damage, shot.Sp, shot.Type);
            }
            if (pirsed_damage > 0)
            {
                damage_armor(pirsed_damage, shot.Ap, shot.Type);
            }
            res.Shild_damage -= this.shield;
            res.Armor_damage -= this.hull_points;

            res.Shild_resist = shot.Damage - res.Shild_damage - pirsed_damage;
            res.Armor_resist = shot.Damage - res.Shild_damage - res.Shild_resist - res.Armor_damage;
            return res;
        }
        private int damage_shield(int damage, int sp, Damage.DamageType type)
        {
            int real_damage = Damage.get_real_damage(damage, sp, shild_resist, type);
            int pirsed_damage = 0;
            if (shield - real_damage < 0)
            {
                pirsed_damage = real_damage - shield;
                shield = 0;
            }
            else
            {
                shield -= real_damage;
            }
            //Console.WriteLine(name + " get damage to shilds: " + (real_damage - pirsed_damage).ToString());
            return pirsed_damage;
        }
        private void damage_armor(int damage, int ap, Damage.DamageType type)
        {
            int real_damage = Damage.get_real_damage(damage, ap, armor_resist, type);
            hull_points -= real_damage;
            //Console.WriteLine(name + " get damage to armor: " + real_damage.ToString());
            if (hull_points <= 0)
            {
                this.destroyed();
            }
        }
        private void destroyed()
        {
            Console.WriteLine(name + " DESTROYED!!!!"); 
        }
    }
}
