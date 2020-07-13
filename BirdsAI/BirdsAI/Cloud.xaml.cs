using System;
using System.Windows;
using System.Windows.Controls;
using static BirdsAI.SkyParams;

namespace BirdsAI
{
	public partial class Cloud : UserControl
	{
		public Cloud()
		{
			InitializeComponent();
			rectangle.Width = r.Next(250, 500);
			animater.Duration = TimeSpan.FromSeconds(r.Next(15, 40));
			animater.BeginTime = TimeSpan.FromSeconds(r.Next(5));
			animater.To = new Thickness(-rectangle.Width, 0, 0, 0);
		}
	}
}
