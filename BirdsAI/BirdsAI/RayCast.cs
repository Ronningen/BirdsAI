using System.Windows;
using System.Collections;
using System.Windows.Media;
using static System.Math;
using static BirdsAI.SkyParams;

namespace BirdsAI
{
	public class RayCast : IEnumerable
	{
		private double Direction { get; set; }

		public RayCast(Bird bird)
		{
			Direction = bird.RadDirection;
		}

		public IEnumerator GetEnumerator()
		{
			for (double angle = Direction - FOV / 2; angle <= Direction + FOV / 2; angle += FOV / (raysCount - 1))
			{
				Point end = new Point(observeDistance * Cos(angle), observeDistance * Sin(angle));
				yield return new Ray()
				{
					Direction = angle,
					Line = new PathGeometry(
						new PathFigure[]
						{
							new PathFigure(new Point(0,0),
							new PathSegment[]
							{
								new LineSegment(end, false),
								new LineSegment(new Point(end.X, end.Y + 1), false),
								new LineSegment(new Point(Cos(angle + PI / 2), Sin(angle + PI / 2)), false)
							}, true)
						})
				};
			}
		}
	}
}
