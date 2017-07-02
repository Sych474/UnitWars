using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitWars
{
    class Unit : BaseObject
    {
        private List<Weapon> weapons;
        private int presition = 100; 

        public Unit(int hp, int shield = 0, string name = "")
            : base(hp, shield, name)
        {
            this.weapons = new List<Weapon>();
        }
        public Unit(int hp, int shield, string name, Damage.Resist armor_resist, Damage.Resist shield_resist, List<Weapon> weapons, int presition = 100)
            : base(hp, shield, name, armor_resist, shield_resist)
        {
            this.weapons = weapons;
            this.presition = presition;
        }
        public List<Damage.Shot> Fire(int sloznost)
            //TO_DO исправить ужасный транслит
        {
            List<Damage.Shot> res = new List<Damage.Shot>();
            //Тут может быть какая-то другая формула расчета, по хорошему вынести в отдельный класс и вызывать как static метод.
            int curr_presition = presition - sloznost; 
            foreach (Weapon item in weapons)
            {
                if (item.Fire(curr_presition))
                {
                    //Выстрел, который попал
                    res.Add(new Damage.Shot(item.Name, item.GetDamage(), item.Type, item.Ap, item.Sp));
                }
                else
                {
                    //Выстрел с промахом
                    res.Add(new Damage.Shot(item.Name));
                }
            }
            return res; 
        }

        public int Presition { get => presition; set => presition = value; }
        internal List<Weapon> Weapons { get => weapons; set => weapons = value; }
    }
}
