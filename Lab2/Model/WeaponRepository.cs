using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Client.Model
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

        // Дополнительные методы и логика работы с оружием

        public event PropertyChangedEventHandler PropertyChanged;
      
    }
}
