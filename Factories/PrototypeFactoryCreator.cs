using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeaponsLib;

namespace Factories
{
    public class PrototypeFactoryCreator : FactoryMethod
    {
        /// <summary>
        /// Словарь со всеми классами для редактирования и удаления объектов типа Weapon
        /// </summary>
        private readonly Dictionary<Type, WeaponViewGetter> _editors = new Dictionary<Type, WeaponViewGetter>();
        public override IFactory CreateFactory()
        {
            Pistol pistol = new Pistol();
            Axe axe = new Axe();
            return new PrototypeFactory(pistol, axe);
        }

        private void InitializeFirstPrototype(Axe parAxe)
        {
            
        }


        public override string ToString()
        {
            return "Фабрика прототипов";
        }
    }
}

