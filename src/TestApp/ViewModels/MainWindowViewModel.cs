using System.Diagnostics;
using System.Globalization;
using System.Windows.Input;
using AY.Translit.TestApp.Helpers;

namespace AY.Translit.TestApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel, IMainWindow
    {
        private int _inputLanguageSelectedIndex;
        private string _inputData;
        private string _outputData;

        private CultureInfo GetSelectedCultureInfo()
        {
            switch (InputLanguageSelectedIndex)
            {
                case 0: return new CultureInfo("ru-RU");
                case 1: return new CultureInfo("uk-UA");
                default: return CultureInfo.InvariantCulture;
            }
        }

        private void ClearAllButtonClick()
        {
            InputLanguageSelectedIndex = -1;
            InputData = string.Empty;
            OutputData = string.Empty;
        }

        private void TransliterateButtonClick()
        {
            if (string.IsNullOrWhiteSpace(InputData))
            {
                OutputData = string.Empty;
                return;
            }

            var stopwatch = new Stopwatch();
            var cultureInfo = GetSelectedCultureInfo();

            stopwatch.Start();

            var translit = new Transliterator(cultureInfo);
            var output = translit.Transliterate(InputData);

            stopwatch.Stop();

            OutputData = string.Format(
                "Elapsed milliseconds: {0}\nInput length: {1}\nOutput length: {2}\n\n{3}", 
                stopwatch.ElapsedMilliseconds, InputData.Length, output.Length, output);
        }

        public int InputLanguageSelectedIndex
        {
            get { return _inputLanguageSelectedIndex; }
            set
            {
                _inputLanguageSelectedIndex = value;
                RaisePropertyChanged("InputLanguageSelectedIndex");
            }
        }

        public string InputData
        {
            get { return _inputData; }
            set
            {
                _inputData = value;
                RaisePropertyChanged("InputData");
            }
        }

        public string OutputData
        {
            get { return _outputData; }
            set
            {
                _outputData = value;
                RaisePropertyChanged("OutputData");
            }
        }

        public ICommand ClearAllCommand { get; private set; }

        public ICommand TransliterateCommand { get; private set; }

        public MainWindowViewModel()
        {
            InputLanguageSelectedIndex = -1;
            ClearAllCommand = new RelayCommand(ClearAllButtonClick);
            TransliterateCommand = new RelayCommand(TransliterateButtonClick);
        }
    }
}
