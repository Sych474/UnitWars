using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitWars
{
    class UnitFactory
    {
        /*
         *AR-10
         * light battle mech 
         * HP - 100, Shield - 20
         * Wargear:
         * 2 Light Lazers 
         * 1 Light Misile Louncher 
        */
        public static Unit CreateAR_10()
        {
            int hp = 100;
            int shild = 20;
            string name = "AR-10";
            Damage.Resist armor_resist = new Damage.Resist(2, 2, 2);
            Damage.Resist shield_resist = new Damage.Resist();
            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(WeaponFacory.CreateLightLazer());
            weapons.Add(WeaponFacory.CreateLightLazer());
            weapons.Add(WeaponFacory.CreateLightMisileLouncher());
            int presition = 90;
  
            return new Unit(hp, shild, name, armor_resist, shield_resist, weapons, presition);
        }

        /*
        *Tarantul M2
        * light battle mech with good shields
        * HP - 40, Shield - 70
        * Wargear:
            1 Autocanon 
            1 MisileLouncher
        */
        public static Unit CreateTarantulM2()
        {
            int hp = 40;
            int shild = 70;
            string name = "Tarantul M2";
            Damage.Resist armor_resist = new Damage.Resist(0, 2, 0);
            Damage.Resist shield_resist = new Damage.Resist(5, 5, 5);
            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(WeaponFacory.CreateAutocanon());
            weapons.Add(WeaponFacory.CreateMisileLouncher());
            int presition = 85;

            return new Unit(hp, shild, name, armor_resist, shield_resist, weapons, presition);
        }
    }
}
