using System.ComponentModel;

namespace AY.Translit.TestApp.Helpers
{
    public abstract class NotificationObject : INotifyPropertyChanged
    {
        protected void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
