using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.Model
{
    public class WeaponRepository 
    {
        private ObservableCollection<Weapon> _weapons;
        public ObservableCollection<Weapon> Weapons
        {
            get { return _weapons; }
            set
            {
                _weapons = value;
                
            }
        }

        public WeaponRepository()
        {
            // Инициализация списка оружия
            Weapons = new ObservableCollection<Weapon>();
        }

        public void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        public void EditWeapon(Weapon oldWeapon, Weapon newWeapon)
        {
            int index = Weapons.IndexOf(oldWeapon);
            if (index != -1)
            {
                Weapons[index] = newWeapon;
            }
        }

        public void RemoveWeapon(Weapon weapon)
        {
            Weapons.Remove(weapon);
        }

        // Дополнительные методы и логика работы с оружием

        public event PropertyChangedEventHandler PropertyChanged;
      
    }
}
