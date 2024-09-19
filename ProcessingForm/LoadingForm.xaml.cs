using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProcessingForm
{
    /// <summary>
    /// Класс LoadingForm представляет окно загрузки с индикатором выполнения.
    /// Используется для создания объектов с возможностью отмены операции и
    /// автоматического завершения.
    /// </summary>
    public partial class LoadingForm : Window
    {
        // Делегат для создания нового объекта
        public delegate object dAddOject();

        // Делегат для обработки отмены
        public delegate void dCancel();

        // Делегат для обработки завершения создания объектов
        public delegate void dFinish(List<object> parList);

        // Событие, возникающее при отмене операции
        public event dCancel OnCancel;

        // Событие, возникающее при завершении операции
        public event dFinish OnFinish;

        // Флаг, указывающий, завершена ли операция
        private bool _isFinished = false;

        // Флаг, указывающий, отменена ли операция
        private bool _isCanceled = false;

        // Флаг, указывающий, нужно ли автоматически закрывать окно после завершения
        private bool _isAutoClosed = false;

        // Список созданных объектов
        private List<object> _createdObjects = new List<object>();

        // Делегат для добавления нового объекта
        private dAddOject addNewObject;

        // Свойство для доступа к созданным объектам
        public List<object> CreatedObjects
        {
            get => _createdObjects;
            set => _createdObjects = value;
        }

        // Свойство, возвращающее, завершена ли операция
        public bool IsFinished
        {
            get { return _isFinished; }
        }

        // Свойство, возвращающее, отменена ли операция
        public bool IsCanceled
        {
            get { return _isCanceled; }
        }

        /// <summary>
        /// Конструктор, инициализирующий окно загрузки.
        /// </summary>
        /// <param name="parWeaaponsCount">Количество создаваемых объектов (например, оружий).</param>
        /// <param name="parIsAutoClosed">Флаг автоматического закрытия окна.</param>
        /// <param name="parAddObject">Делегат для создания нового объекта.</param>
        /// <param name="parOnFinish">Делегат, выполняемый при завершении операции.</param>
        public LoadingForm(int parWeaaponsCount, bool parIsAutoClosed, dAddOject parAddObject, dFinish parOnFinish)
        {
            InitializeComponent();
            addNewObject = parAddObject;
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = parWeaaponsCount;
            _isAutoClosed = parIsAutoClosed;
            Closing += Window_Close;  // Подписка на событие закрытия окна
            OnCancel += SkipDevicesSaving;
            OnFinish += parOnFinish;

            // Запуск асинхронных задач для создания объектов и обновления формы
            Task.Run(() => PerformGeneration(parWeaaponsCount));
            Task.Run(UpdateForm);
        }

        /// <summary>
        /// Обработчик события закрытия окна.
        /// Если операция не завершена, отменяется её выполнение.
        /// </summary>
        private void Window_Close(object sender, CancelEventArgs e)
        {
            if (!_isFinished)
            {
                _isCanceled = true;
                ButtonCancel.IsEnabled = false;
                OnCancel?.Invoke(); // Вызов события отмены
            }
        }

        /// <summary>
        /// Очищает список созданных объектов при отмене операции.
        /// </summary>
        private void SkipDevicesSaving()
        {
            _createdObjects.Clear();
        }

        /// <summary>
        /// Асинхронная задача для создания объектов.
        /// Операция продолжается до завершения или отмены.
        /// </summary>
        private async Task PerformGeneration(int parWeaponsCount)
        {
            for (int i = 0; i < parWeaponsCount && !_isCanceled && !_isFinished; i++)
            {
                _createdObjects.Add(await Task.Run(() => addNewObject()));
            }
        }

        /// <summary>
        /// Асинхронная задача для обновления формы (прогресс-бара) в реальном времени.
        /// </summary>
        private async Task UpdateForm()
        {
            while (!_isFinished && !_isCanceled)
            {
                await Task.Delay(100); // Задержка для снижения нагрузки на процессор
                UpdateProgressBar(CreatedObjects.Count);
            }
        }

        /// <summary>
        /// Обновляет значение прогресс-бара и проверяет, завершена ли операция.
        /// </summary>
        public void UpdateProgressBar(int parNewValue)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    ProgressBar.Value = parNewValue;

                    // Проверка, достиг ли прогресс максимум и завершение операции
                    if (ProgressBar.Value >= ProgressBar.Maximum - 1 && !_isFinished)
                    {
                        ButtonCancel.Content = "Закрыть";
                        LabelProcess.Content = "Генерация случайных записей успешно завершена!";
                        _isFinished = true;

                        if (_isAutoClosed)
                        {
                            OnFinish?.Invoke(CreatedObjects);
                            Close();  // Автоматическое закрытие окна после завершения
                        }
                    }
                });
            }
            catch (Exception)
            {
                OnCancel?.Invoke();  // В случае ошибки вызов отмены
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку отмены/закрытия.
        /// Если операция завершена, окно закрывается, в противном случае операция отменяется.
        /// </summary>
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (!_isFinished)
            {
                _isCanceled = true;
                ButtonCancel.IsEnabled = false;
                OnCancel?.Invoke();  // Вызов события отмены
            }
            else
            {
                OnFinish?.Invoke(CreatedObjects);  // Вызов события завершения
                Close();
            }
        }
    }
}
