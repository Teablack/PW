using System.ComponentModel;

namespace Poda.Tablets.UI.ViewModels
{
    public class ProducerViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private Interfaces.IProducer producer;

        public ProducerViewModel(Interfaces.IProducer _producer)
        {
            producer = _producer;
        }

        public string ProducerGUID
        {
            get => producer.GUID;
            set
            {
                producer.GUID = value;
                RaisePropertyChanged(nameof(ProducerGUID));
            }
        }

        public string ProducerName
        {
            get => producer.Name;
            set
            {
                producer.Name = value;
                RaisePropertyChanged(nameof(ProducerName));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
