using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class Caliber
    {

        /// <summary>
        /// Поле класса, обозначающее наименование калибра оружия
        /// </summary>
        private string caliberName;

        /// <summary>
        /// Поле класса, обозначающее урон от калибра
        /// </summary>

        private Double caliberDamage;

        /// <summary>
        /// Конструктор класса Caliber
        /// </summary>
        /// <param name="caliberName"></param>
        /// <param name="caliberDamage"></param>
        public Caliber(String caliberName, Double caliberDamage)
        {
            this.caliberName = caliberName;
            this.caliberDamage = caliberDamage;
        }

        /// <summary>
        /// Getter and setter
        /// </summary>
        public String CaliberName
        {
            get { return this.caliberName; }
            set { this.caliberName = value; }
        }

        /// <summary>
        /// Getter and setter
        /// </summary>

        public Double CaliberDamage {
            get { return this.caliberDamage; } 
            set { this.caliberDamage= value; }
        }
    }
}
