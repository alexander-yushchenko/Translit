using System.Windows.Input;

namespace AY.Translit.TestApp
{
    public interface IMainWindow
    {
        int InputLanguageSelectedIndex { set; get; }
        string InputData { set; get; }
        string OutputData { set; get; }
        ICommand ClearAllCommand { get; }
        ICommand TransliterateCommand { get; }
    }
}