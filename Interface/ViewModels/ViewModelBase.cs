using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interface
{
    /// <summary>
    /// Базовый класс для ViewModel, реализующий интерфейсы INotifyPropertyChanged и IDisposable.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        private bool _actionCompleted;

        /// <summary>
        /// Инициализирует новый экземпляр класса ViewModelBase.
        /// </summary>
        protected ViewModelBase()
        {

        }

        /// <summary>
        /// Событие, возникающее при изменении значения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged для указанного свойства.
        /// </summary>
        /// <param name="parPropertyName">Имя свойства, для которого произошло изменение.</param>
        public virtual void OnPropertyChanged(string parPropertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(parPropertyName));
            }
        }

        /// <summary>
        /// Освобождает ресурсы, используемые объектом.
        /// </summary>
        public void Dispose()
        {
            this.OnDispose();
        }

        /// <summary>
        /// Метод, вызываемый при освобождении ресурсов.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

        /// <summary>
        /// Указывает, было ли успешно выполнено действие.
        /// </summary>
        public bool ActionCompleted
        {
            get { return _actionCompleted; }
            set
            {
                _actionCompleted = value;
                OnPropertyChanged(nameof(ActionCompleted));
            }
        }
    }
}
