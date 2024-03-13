using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class Sword : SteelArm
    {
        private bool isEnchanted;

        public Sword(string weaponName, double weight, double strikeRate, double degreeOfSharpening, bool isEnchanted)
            : base(weaponName, weight, strikeRate, degreeOfSharpening)
        {
            this.isEnchanted = isEnchanted;
        }

        public void Enchant()
        {
            isEnchanted = true;
            Console.WriteLine("Sword is enchanted!");
        }

        public override string ToString()
        {
            return base.ToString() + "Is Enchanted: " + isEnchanted;
        }

        public override double GetDamage(double damage)
        {
            double newDamage = base.GetDamage(damage);
            if (isEnchanted) { 
                newDamage = damage * 1.2;
            }
            return newDamage;
        }
    }
}
