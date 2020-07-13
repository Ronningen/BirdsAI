using System.Windows.Media;
using System.Windows.Shapes;

namespace BirdsAI
{
	public class Wall : CoordinatesHolder
	{
		private Path renderPath;
		public Path RenderPath
		{
			get => renderPath;
			set { renderPath = value; RaisePropertyChanged(); }
		}

		public Wall(Geometry geometry, double x, double y)
		{
			RenderPath = new Path() { Fill = Brushes.DarkGreen, Data = geometry, DataContext = this };
			X = x;
			Y = y;
		}

		protected Wall() { }
	}
}
