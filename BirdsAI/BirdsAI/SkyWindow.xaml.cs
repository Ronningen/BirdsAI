using System.Windows;

namespace BirdsAI
{
	public partial class SkyWindow : Window
	{
		public SkyWindow()
		{
			InitializeComponent();
			DataContext = new SkyVM(field);
		}
	}
}
