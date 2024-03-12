using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionLab1
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
        protected string weaponName { get; set; }

        protected double weight { get; set; }

        protected double damage { get; set; }

        public override string ToString ()
        {
            return "Weapon id = " + Id + "Weapon name = " + weaponName + "Weapon weight = " + weight;
        }

        protected virtual double getDamage(double damage)
        {
            return damage;
        }

    }

}
