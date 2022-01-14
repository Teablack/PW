using System.Linq;
using System.Windows;

namespace Poda.Tablets.UI
{
    public partial class MainWindow : Window
    {
        public ViewModels.ProducerListViewModel ProducerLVM { get; } = new ViewModels.ProducerListViewModel();
        private ViewModels.ProducerViewModel selectedProducer = null;

        public ViewModels.TabletListViewModel TabletLVM { get; } = new ViewModels.TabletListViewModel();
        private ViewModels.TabletViewModel selectedTablet = null;

        private readonly BL.BLC blc;

        private string selectedDataSource = "TabletsDBMock.dll";

        public MainWindow()
        {
            blc = new();
            blc.LoadLibrary(selectedDataSource);

            ProducerLVM.RefreshList(blc.GetAllProducers());
            TabletLVM.RefreshList(blc.GetAllTablets());

            InitializeComponent();
        }

        private void ApplyNewDataSource(object sender, RoutedEventArgs e) {
            try
            {
                blc.LoadLibrary(datasource.Text);
                ProducerLVM.RefreshList(blc.GetAllProducers());
                TabletLVM.RefreshList(blc.GetAllTablets());
                selectedDataSource = datasource.Text;
            }
            catch {
                MessageBox.Show("Error occurred, check your input values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                blc.LoadLibrary(selectedDataSource);
            }
        }

        private void ApplyTabletSearch(object sender, RoutedEventArgs e)
        {
            if (tabletSearchField.Text == "") {
                TabletLVM.RefreshList(blc.GetAllTablets());
            } else {
                TabletLVM.RefreshList(blc.GetTablet(tabletPriceFilterField.Text));
            }
        }
        private void ApplyProducerSearch(object sender, RoutedEventArgs e)
        {
            if (producerGUIDSearchField.Text == "")
            {
                ProducerLVM.RefreshList(blc.GetAllProducers());
            } else {
                ProducerLVM.RefreshList(blc.GetProducer(producerGUIDSearchField.Text));
            }
        }

        private void ApplyTabletFilter(object sender, RoutedEventArgs e)
        {
            if (tabletPriceFilterField.Text == "")
            {
                TabletLVM.RefreshList(blc.GetAllTablets());
            }
            else {
                try
                {
                    TabletLVM.RefreshList(blc.GetTablets(int.Parse(tabletPriceFilterField.Text)));
                }
                catch
                {
                    MessageBox.Show("Bad filter provided");
                }
            }
        }
        private void ApplyProducerFilter(object sender, RoutedEventArgs e)
        {
            if (producerNameFilterField.Text == "")
            {
                ProducerLVM.RefreshList(blc.GetAllProducers());
            }
            else {
                ProducerLVM.RefreshList(blc.GetProducers(producerNameFilterField.Text));
            }
        }

        private void AddTablet(object sender, RoutedEventArgs e)
        {
            var allProducersNames = blc.GetAllProducerNames();
            TabletDialog tabletInputDialog = new(allProducersNames);

            if (tabletInputDialog.ShowDialog() == true)
            {
                DAO.TabletDBMock tablet;
                try
                {
                    tablet = new DAO.TabletDBMock()
                    {
                        Model = tabletInputDialog.TabletModel,
                        Producer = blc.GetProducers(tabletInputDialog.Producer).First(),
                        Display = tabletInputDialog.TabletDisplay,
                        Price = tabletInputDialog.TabletPrice
                    };
                }
                catch
                {
                    MessageBox.Show("Error occurred, check your input values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                blc.CreateOrReplaceTablet(tablet);
                TabletLVM.RefreshList(blc.GetAllTablets());
            }
        }
        private void AddProducer(object sender, RoutedEventArgs e)
        {
            ProducerDialog producerInputDialog = new();

            if (producerInputDialog.ShowDialog() == true)
            {
                DAO.ProducerDBMock producerDBMock;
                try
                {
                    producerDBMock = new DAO.ProducerDBMock() { Name = producerInputDialog.ProducerName };
                }
                catch
                {
                    MessageBox.Show("Error occurred, check your input values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                blc.CreateOrModifyProducer(producerDBMock);
                ProducerLVM.RefreshList(blc.GetAllProducers());
            }
        }

        private void EditTablet(object sender, RoutedEventArgs e)
        {
            if (selectedTablet != null)
            {
                TabletDialog tabletEditDialog = new(
                    blc.GetAllProducerNames(),
                    blc.GetTablet(selectedTablet.TabletGUID).First()
                );

                if (tabletEditDialog.ShowDialog() == true)
                {
                    blc.CreateOrReplaceTablet(new DAO.TabletDBMock()
                    {
                        GUID = selectedTablet.TabletGUID,
                        Model = tabletEditDialog.TabletModel,
                        Display = tabletEditDialog.TabletDisplay,
                        Producer = blc.GetProducers(tabletEditDialog.Producer).First(),
                        Price = tabletEditDialog.TabletPrice
                    });

                    TabletLVM.RefreshList(blc.GetAllTablets());
                    ChangeSelectedTablet(null);
                }
            }
            else
            {
                MessageBox.Show("Tablet is not selected!");
            }
        }
        private void EditProducer(object sender, RoutedEventArgs e)
        {
            if (selectedProducer != null)
            {
                ProducerDialog producerEditDialog = new(
                    blc.GetProducer(selectedProducer.ProducerGUID).First()
                );

                if (producerEditDialog.ShowDialog() == true)
                {
                    blc.CreateOrModifyProducer(new DAO.ProducerDBMock()
                    {
                        GUID = selectedProducer.ProducerGUID,
                        Name = producerEditDialog.ProducerName
                    });

                    ProducerLVM.RefreshList(blc.GetAllProducers());
                    TabletLVM.RefreshList(blc.GetAllTablets());
                    ChangeSelectedProducer(null);
                }
            }
            else
            {
                MessageBox.Show("Producer is not selected!");
            }
        }

        private void RemoveTablet(object sender, RoutedEventArgs e)
        {
            if (selectedTablet != null)
            {
                blc.RemoveTablet(selectedTablet.TabletGUID);
                TabletLVM.RefreshList(blc.GetAllTablets());
                selectedTablet = null;
            }
            else
            {
                MessageBox.Show("Tablet is not selected!");
            }
        }
        private void RemoveProducer(object sender, RoutedEventArgs e)
        {
            if (selectedProducer != null)
            {
                blc.RemoveProducer(selectedProducer.ProducerGUID);
                ProducerLVM.RefreshList(blc.GetAllProducers());
                ChangeSelectedProducer(null);
                selectedProducer = null;
            }
            else
            {
                MessageBox.Show("Producer is not selected!");
            }
        }

        private void ChangeSelectedTablet(ViewModels.TabletViewModel tabletViewModel)
        {
            selectedTablet = tabletViewModel;
            DataContext = selectedTablet;
        }
        private void ChangeSelectedProducer(ViewModels.ProducerViewModel producerViewModel)
        {
            selectedProducer = producerViewModel;
            DataContext = selectedProducer;
        }

        private void TabletList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                ChangeSelectedTablet((ViewModels.TabletViewModel)e.AddedItems[0]);
            }
        }
        private void ProducerList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                ChangeSelectedProducer((ViewModels.ProducerViewModel)e.AddedItems[0]);
            }
        }

 
    }
}