using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionLab1
{
    internal class Sword : SteelArm
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

        protected override double getDamage(double damage)
        {
            double newDamage = base.getDamage(damage);
            if (isEnchanted) { 
                newDamage = damage * 1.2;
            }
            return newDamage;
        }
    }
}
