using System.ComponentModel;

namespace Poda.Tablets.UI.ViewModels
{
    public class TabletViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private Interfaces.ITablet tablet;

        public TabletViewModel(Interfaces.ITablet _tablet)
        {
            tablet = _tablet;
        }

        public string TabletGUID
        {
            get => tablet.GUID;
            set
            {
                tablet.GUID = value;
                RaisePropertyChanged(nameof(TabletGUID));
            }
        }

        public string TabletModel
        {
            get => tablet.Model;
            set
            {
                tablet.Model = value;
                RaisePropertyChanged(nameof(TabletModel));
            }
        }

        public int TabletPrice
        {
            get => tablet.Price;
            set
            {
                tablet.Price = value;
                RaisePropertyChanged(nameof(TabletPrice));
            }
        }

        public string TabletProducer
        {
            get => tablet.Producer.Name;
            set
            {
                tablet.Producer.Name = value;
                RaisePropertyChanged(nameof(TabletProducer));
            }
        }

        public Poda.Tablets.Core.DisplayType TabletDisplay
        {
            get => tablet.Display;
            set
            {
                tablet.Display = value;
                RaisePropertyChanged(nameof(TabletDisplay));
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
