using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.ViewModel
{
    public static class OperationModeTranslator
    {
        /// <summary>
        /// Получение названия режима операции для кнопки
        /// </summary>
        /// <param name="parOperationMode">Режим работы</param>
        /// <returns>Название режима работы</returns>
        public static string GetNameOperationModeForButton(this OperationMode parOperationMode)
        {
            return parOperationMode switch
            {
                OperationMode.Add => "Добавить",
                OperationMode.Delete => "Удалить",
                OperationMode.Edit => "Изменить",
                _ => "",
            };
        }

        /// <summary>
        /// Получение названия режима операции для заголовка формы
        /// </summary>
        /// <param name="parOperationMode">Режим работы</param>
        /// <returns>Название режима работы</returns>
        public static string GetNameOperationModeForTitle(this OperationMode parOperationMode)
        {
            return parOperationMode switch
            {
                OperationMode.Add => "Добавление",
                OperationMode.Delete => "Удаление",
                OperationMode.Edit => "Изменение",
                _ => "",
            };
        }
    }

}
