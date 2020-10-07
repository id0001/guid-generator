using System.Windows;

namespace GuidGen
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			// Create the window
			MainWindow wnd = new MainWindow();
			
			// Set the viemodel
			wnd.DataContext = new GuidGeneratorViewModel();

			// Show the window
			wnd.Show();
		}
	}
}
