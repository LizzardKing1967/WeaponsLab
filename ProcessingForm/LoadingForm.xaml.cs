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
    /// Логика взаимодействия для LoadingForm.xaml
    /// </summary>
    public partial class LoadingForm : Window
    {
        public delegate object dAddOject();
        public delegate void dCancel();
        public delegate void dFinish(List<object> parList);

        public event dCancel OnCancel;
        public event dFinish OnFinish;

        private bool _isFinished = false;
        private bool _isCanceled = false;
        private bool _isAutoClosed = false;

        private List<object> _createdObjects = new List<object>();

        private dAddOject addNewObject;

        public List<object> CreatedObjects
        {
            get => _createdObjects;
            set => _createdObjects = value;
        }

        public bool IsFinished
        {
            get { return _isFinished; }
        }

        public bool IsCanceled
        {
            get { return _isCanceled; }
        }

        public LoadingForm(int parPlantsCount, bool parIsAutoClosed, dAddOject parAddObject, dFinish parOnFinish)
        {
            InitializeComponent();
            addNewObject = parAddObject;
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = parPlantsCount;
            _isAutoClosed = parIsAutoClosed;
            Closing += Window_Close;
            OnCancel += SkipDevicesSaving;
            OnFinish += parOnFinish;

            Task.Run(() => PerformGeneration(parPlantsCount));
            Task.Run(UpdateForm);
        }

        private void Window_Close(object sender, CancelEventArgs e)
        {
            if (!_isFinished)
            {
                _isCanceled = true;
                ButtonCancel.IsEnabled = false;
                OnCancel?.Invoke();
            }
        }

        private void SkipDevicesSaving()
        {
            _createdObjects.Clear();
        }

        private async Task PerformGeneration(int parWeaponsCount)
        {
            for (int i = 0; i < parWeaponsCount && !_isCanceled && !_isFinished; i++)
            {
                await Task.Delay(500);
                _createdObjects.Add(await Task.Run(() => addNewObject()));
            }
        }

        private async Task UpdateForm()
        {
            while (!_isFinished && !_isCanceled)
            {
                await Task.Delay(100); // Пауза для уменьшения загрузки CPU
                UpdateProgressBar(CreatedObjects.Count);
            }
        }

        public void UpdateProgressBar(int parNewValue)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    ProgressBar.Value = parNewValue;
                    if (ProgressBar.Value >= ProgressBar.Maximum - 1 && !_isFinished)
                    {
                        ButtonCancel.Content = "Закрыть";
                        LabelProcess.Content = "Генерация случайных записей успешно завершена!";
                        _isFinished = true;
                        if (_isAutoClosed)
                        {
                            OnFinish?.Invoke(CreatedObjects);
                            Close();
                        }
                    }
                });
            }
            catch (Exception)
            {
                OnCancel?.Invoke();
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (!_isFinished)
            {
                _isCanceled = true;
                ButtonCancel.IsEnabled = false;
                OnCancel?.Invoke();
            }
            else
            {
                OnFinish?.Invoke(CreatedObjects);
                Close();
            }
        }
    }
}
