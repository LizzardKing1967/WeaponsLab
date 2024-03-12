using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionLab1
{
    internal class SteelArm : Weapon
    {
        public SteelArm(string weaponName, double weight, double strikeRate, double degreeOfSharpening) : base(weaponName, weight)
        {
            this.strikeRate = strikeRate;
            this.degreeOfSharpening = degreeOfSharpening;

        }
        double strikeRate {  get; set; }
        double degreeOfSharpening { get; set; }

        protected virtual void Strike(String target)
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

        protected virtual void Sharpening()
        {
            this.degreeOfSharpening ++;
        }

        public override string ToString()
        {
            return base.ToString() + "Strike rate" + strikeRate + "Degree of sharpening" + degreeOfSharpening;
        }




    }
}
