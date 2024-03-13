using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class SteelArm : Weapon
    {
        public SteelArm(string weaponName, double weight, double strikeRate, double degreeOfSharpening) : base(weaponName, weight)
        {
            this.strikeRate = strikeRate;
            this.degreeOfSharpening = degreeOfSharpening;

        }
        double strikeRate;
        public double StrikeRate { get { return this.strikeRate;} }

        double degreeOfSharpening;
        public double DegreeOfSharpening { get { return this.degreeOfSharpening; } }

        public virtual void Strike(String target)
        {
            if (this.degreeOfSharpening > 0)
            {
                Console.Write("Strike to" + target);
                this.degreeOfSharpening--;
            }
            else
            {
                Console.Write("Your weapon is dull, sharp it!");
            }
        }

        public virtual void Sharpening()
        {
            this.degreeOfSharpening ++;
        }

        public override string ToString()
        {
            return base.ToString() + "Strike rate" + strikeRate + "Degree of sharpening" + degreeOfSharpening;
        }




    }
}
