using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Poda.Tablets.UI.ViewModels
{
    public class TabletListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TabletViewModel> Tablets { get; set; } = new ObservableCollection<TabletViewModel>();

        public void RefreshList(System.Collections.Generic.IEnumerable<Interfaces.ITablet> tablets)
        {
            Tablets.Clear();

            foreach (var tablet in tablets)
            {
                Tablets.Add(new TabletViewModel(tablet));
            }

            RaisePropertyChanged(nameof(Tablets));
        }

        private void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
