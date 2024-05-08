using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interface
{
    /// <summary>
    /// Реализует интерфейс ICommand для создания команд, которые можно привязать к элементам управления в пользовательском интерфейсе WPF.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Делегат, выполняемый командой.
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// Условие, определяющее, может ли команда выполняться в данный момент.
        /// </summary>
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Инициализирует новый экземпляр класса RelayCommand с указанным делегатом выполнения.
        /// </summary>
        /// <param name="parExecute">Делегат, который будет выполнен при выполнении команды.</param>
        public RelayCommand(Action parExecute) : this(parExecute, null)
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса RelayCommand с указанным делегатом выполнения и условием выполнения.
        /// </summary>
        /// <param name="parExecute">Делегат, который будет выполнен при выполнении команды.</param>
        /// <param name="parCanExecute">Условие, определяющее, может ли команда выполниться в данный момент.</param>
        public RelayCommand(Action parExecute, Func<bool> parCanExecute)
        {
            _execute = parExecute ?? throw new ArgumentNullException(nameof(parExecute));
            _canExecute = parCanExecute;
        }

        /// <summary>
        /// Происходит при изменении условия, определяющего, может ли команда выполниться в данный момент.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Определяет, может ли команда выполниться в данный момент.
        /// </summary>
        /// <param name="parCommand">Параметр команды (не используется в данной реализации).</param>
        /// <returns>True, если команда может выполниться; в противном случае - false.</returns>
        public bool CanExecute(object parCommand)
        {
            return _canExecute == null || _canExecute();
        }

        /// <summary>
        /// Выполняет логику команды.
        /// </summary>
        /// <param name="parCommand">Параметр команды (не используется в данной реализации).</param>
        public void Execute(object parCommand)
        {
            _execute();
        }
    }
} 
    
