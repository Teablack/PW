using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Poda.Tablets.UI
{
    public partial class TabletDialog : Window
	{
		public TabletDialog(System.Collections.Generic.IEnumerable<string> producers)
		{
			InitializeComponent();
			producers.ToList().ForEach(f => producer.Items.Add(f));
			if (producer.Items.Count > 0)
			{
				producer.SelectedIndex = 0;
			}
		}

		public TabletDialog(System.Collections.Generic.IEnumerable<string> producers, Interfaces.ITablet tablet)
		{
			InitializeComponent();
			producers.ToList().ForEach(p => producer.Items.Add(p));
			
			for (int i = 0; i < producers.Count(); i++) {
				if (producers.ElementAt(i).Equals(tablet.Producer.Name)) {
					producer.SelectedIndex = i;
					break;
				}
			}

			tabletModel.Text = tablet.Model;
			tabletDisplay.SelectedIndex = tablet.Display == Core.DisplayType.Retina ? 0 : 1;
			tabletPrice.Text = tablet.Price.ToString();
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			tabletModel.SelectAll();
			tabletModel.Focus();
		}

		public string TabletModel
		{
			get { return tabletModel.Text; }
		}

		public Poda.Tablets.Core.DisplayType TabletDisplay
		{
			get { return tabletDisplay.SelectedIndex == 0 ? Poda.Tablets.Core.DisplayType.Retina : Poda.Tablets.Core.DisplayType.AMOLED; }
		}

		public int TabletPrice
		{
			get {
				return int.Parse(tabletPrice.Text);
			}
		}

		public string Producer
		{
			get
			{
				return producer.Text;
			}
		}

		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}
	}
}