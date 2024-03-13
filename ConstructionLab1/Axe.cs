using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class Axe : SteelArm
    {
        private int handleLength;

        public Axe(string weaponName, double weight, double strikeRate, double degreeOfSharpening, int handleLength)
            : base(weaponName, weight, strikeRate, degreeOfSharpening)
        {
            this.handleLength = handleLength;
        }

        public void ExtendHandle(int length)
        {
            this.handleLength += length;
            Console.WriteLine("Handle extended by " + length + " cm.");
        }

        public override string ToString()
        {
            return base.ToString() + "Handle Length: " + handleLength + " cm";
        }

        public override double GetDamage(double damage)
        {
            return base.GetDamage(damage) * (this.handleLength/100);
        }
    }
}
