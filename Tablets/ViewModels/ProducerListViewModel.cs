using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Poda.Tablets.UI.ViewModels
{
    public class ProducerListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ProducerViewModel> Producers { get; set; } = new ObservableCollection<ProducerViewModel>();

        public void RefreshList(System.Collections.Generic.IEnumerable<Interfaces.IProducer> producers)
        {
            Producers.Clear();

            foreach (var producer in producers)
            {
                Producers.Add(new ProducerViewModel(producer));
            }

            RaisePropertyChanged(nameof(Producers));
        }

        private void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
