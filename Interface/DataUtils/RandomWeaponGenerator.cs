using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.DataUtils
{
    public static class RandomWeaponGenerator
    {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Алфавит генерируемых имен
        /// </summary>
        private const string ALPHABET = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        /// <summary>
        /// Минимальная длинна названия
        /// </summary>
        private const int ALPHABET_MIN_LEANGH = 3;

        /// <summary>
        /// Максимальная длинна названия
        /// </summary>
        private const int ALPHABET_MAX_LEANGH = 15;

        /// <summary>
        /// Массив функций создания оружия
        /// </summary>
        private static Func<Weapon>[] _weaponCreator =
        {
          () => new Pistol(),
          () => new Rifle(),
          () => new Sword(),
          () => new Axe(),
        };

        /// <summary>
        /// Создание случайного оружия
        /// </summary>
        /// <returns>Случайное оружие</returns>
        public static Weapon CreateRandomWeapon()
        {
            Weapon result = _weaponCreator[_random.Next(_weaponCreator.Length)]();

            result.WeaponName = GetRandomName();
            result.Weight = Math.Round(_random.NextDouble() * 100, 2);
            result.DegreeOfDanger = Math.Round(_random.NextDouble() * 100, 2);
            return result;
        }

        /// <summary>
        /// Генератор случайных названий
        /// </summary>
        /// <returns>Случайное название</returns>
        private static string GetRandomName()
        {
            StringBuilder result = new StringBuilder();

            int length = _random.Next(ALPHABET_MIN_LEANGH, ALPHABET_MAX_LEANGH + 1);

            for (int i = 0; i < length; i++)
                result.Append(ALPHABET[_random.Next(ALPHABET.Length)]);

            return result.ToString();
        }
    }
}



