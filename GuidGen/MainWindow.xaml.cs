using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuidGen
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void GenerateButton_Click(object sender, RoutedEventArgs e)
		{
			var guid = Guid.NewGuid();
			GenerateButton.Content = guid;
			History.Items.Insert(0, guid);
			Clipboard.SetText(guid.ToString());
		}

		private void History_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var guid = (Guid)History.SelectedItem;
			Clipboard.SetText(guid.ToString());
		}
	}
}
