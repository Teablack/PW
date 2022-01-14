using System;
using System.Windows;

namespace Poda.Tablets.UI
{
    public partial class ProducerDialog : Window
	{
		public ProducerDialog()
		{
			InitializeComponent();
		}

		public ProducerDialog(Interfaces.IProducer producer)
		{
			InitializeComponent();
			producerName.Text = producer.Name;
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			producerName.SelectAll();
			producerName.Focus();
		}

		public string ProducerName
		{
			get { return producerName.Text; }
		}
	}
}