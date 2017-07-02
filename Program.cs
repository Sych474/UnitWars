using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitWars
{
    class Program
    {
        static void BattleCicle(Unit unit1, Unit unit2)
        {
            List<Damage.Shot> unit1_shots, unit2_shots;
            List<Damage.ShotResult> unit1_shots_res, unit2_shots_res;
            while (unit1.Hull_points > 0 && unit2.Hull_points > 0)
            {
                Console.WriteLine(unit1.Name + " FIRE:");
                unit1_shots = unit1.Fire(0);

                ConsoleInformer.WriteShotsInfo(unit1_shots);
                unit2_shots_res = unit2.GetShots(unit1_shots);
                ConsoleInformer.WriteShotsResultInfo(unit2_shots_res, unit2.Name);
                ConsoleInformer.WriteUnitState(unit2);

                Console.WriteLine(unit2.Name + " FIRE:");
                unit2_shots = unit2.Fire(0);

                ConsoleInformer.WriteShotsInfo(unit2_shots);
                unit1_shots_res = unit1.GetShots(unit2_shots);
                ConsoleInformer.WriteShotsResultInfo(unit1_shots_res, unit1.Name);
                ConsoleInformer.WriteUnitState(unit1);
            }
        }
        static void Main(string[] args)
        {
            Unit AR_10 = UnitFactory.CreateAR_10();
            Unit Tarantul = UnitFactory.CreateTarantulM2();

            ConsoleInformer.WriteUnitInfo(AR_10);
            ConsoleInformer.WriteUnitInfo(Tarantul);


            BattleCicle(AR_10, Tarantul);

            Console.WriteLine("Done");
            Console.Read();
        }
    }
}
