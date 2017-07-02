using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitWars
{
    class WeaponFacory
    {
        public static Weapon CreateLightLazer()
        {
            int min_damage = 7;
            int max_damage = 10;
            Damage.DamageType type = Damage.DamageType.ENERGY;
            int presition = 95;
            string name = "Light Lazer";
            int ap = 1;
            int sp = 3;
            return new Weapon(min_damage, max_damage, type, presition, name, ap, sp);
        }

        public static Weapon CreateLazer()
        {
            int min_damage = 10;
            int max_damage = 15;
            Damage.DamageType type = Damage.DamageType.ENERGY;
            int presition = 95;
            string name = "Lazer";
            int ap = 2;
            int sp = 5;
            return new Weapon(min_damage, max_damage, type, presition, name, ap, sp);
        }

        public static Weapon CreateAutocanon()
        {
            int min_damage = 15;
            int max_damage = 25;
            Damage.DamageType type = Damage.DamageType.TYPE2;
            int presition = 90;
            string name = "Autocanon";
            int ap = 5;
            int sp = 0;
            return new Weapon(min_damage, max_damage, type, presition, name, ap, sp);
        }

        public static Weapon CreateLightMisileLouncher()
        {
            int min_damage = 5;
            int max_damage = 15;
            Damage.DamageType type = Damage.DamageType.TYPE3;
            int presition = 90;
            string name = "Light Misile Louncher";
            int ap = 4;
            int sp = 0;
            return new Weapon(min_damage, max_damage, type, presition, name, ap, sp);
        }

        public static Weapon CreateMisileLouncher()
        {
            int min_damage = 10;
            int max_damage = 30;
            Damage.DamageType type = Damage.DamageType.TYPE3;
            int presition = 90;
            string name = "Misile Louncher";
            int ap = 5;
            int sp = 0;
            return new Weapon(min_damage, max_damage, type, presition, name, ap, sp);
        }
    }
}
