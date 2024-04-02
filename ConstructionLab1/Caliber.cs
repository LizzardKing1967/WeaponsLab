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
        /// Наименование калибра оружия
        /// </summary>
        private string _caliberName;

        /// <summary>
        /// Урон от калибра
        /// </summary>
        private double _caliberDamage;

        /// <summary>
        /// Конструктор класса Caliber
        /// </summary>
        /// <param name="parCaliberName"></param>
        /// <param name="parCaliberDamage"></param>
        public Caliber(string parCaliberName, double parCaliberDamage)
        {
            this._caliberName = parCaliberName;
            this._caliberDamage = parCaliberDamage;
        }

        /// <summary>
        /// Getter and setter
        /// </summary>
        public string CaliberName
        {
            get { return this._caliberName; }
            set { this._caliberName = value; }
        }

        /// <summary>
        /// Getter and setter
        /// </summary>
        public double CaliberDamage {
            get { return this._caliberDamage; } 
            set { this._caliberDamage= value; }
        }
    }
}
