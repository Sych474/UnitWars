using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitWars
{
    class ConsoleInformer
    {
        public static void WriteShotInfo(Damage.Shot shot)
        {
            if (shot.Is_hit)
            {
                Console.WriteLine(shot.Name + " HIT with damage: " + shot.Damage.ToString());
            }
            else
            {
                Console.WriteLine(shot.Name + " missed");
            }
        }
        public static void WriteShotsInfo(List<Damage.Shot> shots)
        {
            foreach (var item in shots)
            {
                WriteShotInfo(item);
            }
        }

        public static void WriteUnitState(Unit unit)
        {
            Console.WriteLine("---------------");
            Console.WriteLine(unit.Name + " state: ");
            Console.WriteLine("XP: " + unit.Hull_points.ToString() + "/" + unit.Max_hull_points.ToString());
            Console.WriteLine("Shild: " + unit.Shild.ToString() + "/" + unit.Max_shield.ToString());
            Console.WriteLine("---------------");
        }

        public static void WriteWeaponInfo(Weapon item)
        {
            Console.WriteLine(item.Name);
            Console.Write("Damage: " + item.Min_damage.ToString() + " - " + item.Max_damage.ToString());
            switch (item.Type)
            {
                case Damage.DamageType.ENERGY:
                    Console.Write(" Damage type: ENERGY ");
                    break;
                case Damage.DamageType.TYPE2:
                    Console.Write(" Damage type: TYPE2 ");
                    break;
                case Damage.DamageType.TYPE3:
                    Console.Write(" Damage type: TYPE3 ");
                    break;
            }
            Console.Write("AP: " + item.Ap.ToString() + " SP " + item.Sp.ToString() + "\n");
            Console.WriteLine();
        }

        public static void WriteResistInfo(Damage.Resist resist, string resist_name = "")
        {
            Console.Write(resist_name + "E: " + resist.Energy_resist.ToString());
            Console.Write(" T2: " + resist.Type2_resist.ToString());
            Console.Write(" T3: " + resist.Type3_resist.ToString());
            Console.WriteLine();
        }
        public static void WriteUnitInfo(Unit unit)
        {
            Console.WriteLine("---------------");
            Console.WriteLine(unit.Name);
            Console.WriteLine("XP: " + unit.Hull_points.ToString() + "/" + unit.Max_hull_points.ToString());
            Console.WriteLine("SHIELD: " + unit.Shild.ToString() + "/" + unit.Max_shield.ToString());
            Console.WriteLine("WARGEAR:");
            foreach (var item in unit.Weapons)
            {
                WriteWeaponInfo(item);
            }
            Console.WriteLine("Presition: " + unit.Presition.ToString());
            WriteResistInfo(unit.Armor_resist, "Armor resists:");
            WriteResistInfo(unit.Shild_resist, "Shild resists:");
            Console.WriteLine("---------------");
        }

        public static void WriteShotResultInfo(Damage.ShotResult res, string unit_name)
        {
            if (res.Shild_damage == 0 && res.Shild_resist == 0 && res.Armor_damage == 0 && res.Armor_resist == 0) return;

                Console.Write(unit_name + ": ");
            if (res.Shild_damage != 0 || res.Shild_resist != 0)
            {
                Console.Write("Shild damaged: " + res.Shild_damage.ToString());
                Console.Write(" Shild resist: " + res.Shild_resist.ToString());
            }
            if (res.Armor_damage != 0 || res.Armor_resist != 0)
            {
            Console.Write(" Armor damaged: " + res.Armor_damage.ToString());
            Console.Write(" Armor resist: " + res.Armor_resist.ToString());
            }
            Console.WriteLine();
            if (res.Armor_damage != 0 && res.Shild_damage != 0)
            {
                Console.WriteLine(unit_name + " Shild FAILED!");
            }
        }

        public static void WriteShotsResultInfo(List<Damage.ShotResult> res, string unit_nane)
        {
            Console.WriteLine("---------------------");
            foreach (var item in res)
            {
                WriteShotResultInfo(item, unit_nane);
            }
            Console.WriteLine("---------------------");
        }
    }
}
