using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionLab1
{
    public class Caliber
    {
        public Caliber(String caliberName, Double caliberDamage)
        {
            this.caliberName = caliberName;
            this.caliberDamage = caliberDamage;
        }

        string caliberName;
        public String CaliberName
        {
            get { return this.caliberName; }
            set { this.caliberName = value; }
        }

        Double caliberDamage;

        public Double CaliberDamage {
            get { return this.caliberDamage; } 
            set { this.caliberDamage= value; }
        }
    }
}
