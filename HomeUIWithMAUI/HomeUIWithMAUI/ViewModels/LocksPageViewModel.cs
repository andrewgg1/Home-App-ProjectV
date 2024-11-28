using HomeUIWithMAUI.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeUIWithMAUI.ViewModels
{
    public class LocksPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SmartLock> Locks { get; set; }

        public LocksPageViewModel()
        {
            Locks = new ObservableCollection<SmartLock>
            {
                new SmartLock(1, State.On, true) { Name = "Front Door" },
                new SmartLock(2, State.Off, false) { Name = "Garage" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
