using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    /// <summary>
    /// Класс огнестрельного оружия Firearm, наследник класса Weapon
    /// </summary>
    public class Firearm : Weapon
    {

        /// <summary>
        /// Темп стрельбы оружия
        /// </summary>
        private int _fireRate;

        /// <summary>
        /// Калибр оружия
        /// </summary>
        private Caliber _caliber;

        /// <summary>
        /// Ёмкость магазина оружия
        /// </summary>
        private int _ammoCapacity;

        /// <summary>
        /// Текущее количество боеприпасов в оружии
        /// </summary>
        private int _currentCapacity;

        /// <summary>
        /// Getter и Setter для поля _ammoCapacity
        /// </summary>
        public int AmmoCapacity { 
            get { return this._ammoCapacity; } 
            set { this._ammoCapacity = value;}
        }

        /// <summary>
        /// Getter и Setter для поля _currentCapacity
        /// </summary>
        public int CurentCapacity { 
            get { return this._currentCapacity; } 
            set { this._currentCapacity = value;}
        }



        /// <summary>
        /// Getter и Setter для поля _fireRate
        /// </summary>
        public int FireRate { 
            get { return this._fireRate; } 
            set { this._fireRate = value;}
        }

        /// <summary>
        /// Конструктр для класса FireArm
        /// </summary>
        /// <param name="parWeaponName"></param>
        /// <param name="parWeight"></param>
        /// <param name="parFireRate"></param>
        /// <param name="parCaliber"></param>
        /// <param name="parAmmoCapacity"></param>
        /// <param name="parDegreeOfDanger"></param>
        public Firearm(string parWeaponName, double parWeight, double parDegreeOfDanger, int parFireRate, Caliber parCaliber, int parAmmoCapacity) : base(parWeaponName, parWeight, parDegreeOfDanger)
        {
            this._fireRate = parFireRate;
            this._ammoCapacity = parAmmoCapacity;
            this._currentCapacity = parAmmoCapacity;
            this._caliber = parCaliber;
        }

        /// <summary>
        /// Метод выполения выстрела из оружия
        /// </summary>
        /// <param name="parTarget">Цель для выстрела</param>
        public virtual string Shoot(String parTarget)
        {
            if (this._currentCapacity > 0)
            {
                this._currentCapacity--;
                return $"Shoot to {parTarget}";
            }
            else
            {
                return "No ammo";
            }
        }

        /// <summary>
        /// Метод перезарядки оружия
        /// </summary>
        public void Reload()
        { 
            this._currentCapacity = _ammoCapacity; 
        }

        /// <summary>
        /// Переопределенный метод оценки урона, учитывающий темп стрельбы и калибр оружия
        /// </summary>
        /// <returns></returns>
        public override double GetDamage()
        {
            return base.GetDamage() * _fireRate * _caliber.CaliberDamage;
        }


        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, Caliber: {1}, Fire Rate: {2}, Ammo capacity: {3}, Current capacity: {4}", base.ToString(), _caliber, _fireRate, _ammoCapacity, _currentCapacity);
        }
    }
}
