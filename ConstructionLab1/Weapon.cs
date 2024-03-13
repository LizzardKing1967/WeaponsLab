using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class Weapon
    {
        public Weapon(string weaponName, double weight) 
        {
            Id = Guid.NewGuid();
            this.weaponName = weaponName;
            this.weight = weight;
        }
    
        protected Guid Id;

        protected string weaponName;

        public string WeaponName { get { return weaponName; } } 


        protected double weight;

        public double Weight { get { return weight; } }

        protected double damage;

        public override string ToString ()
        {
            return "Weapon id = " + Id + "Weapon name = " + weaponName + "Weapon weight = " + weight;
        }

        public virtual double GetDamage(double damage)
        {
            return damage;
        }

    }

}
