using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    /// <summary>
    /// Фабричный метод для создания фабрик
    /// </summary>

    public abstract class FactoryMethod
    {
        /// <summary>
        /// Создание объекта фабрики
        /// </summary>
        /// <returns>Объект фабрика</returns>
        public abstract IFactory CreateFactory();
        public abstract override string ToString();

    }
}
