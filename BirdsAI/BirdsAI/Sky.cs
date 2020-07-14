using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Collections.Generic;
using static System.Math;
using static BirdsAI.SkyParams;

namespace BirdsAI
{
	class Sky
	{
		public List<Bird> Birds { get; set; }
		public List<Wall> Walls { get; set; }

		public Sky() : this(new List<Bird>(), new List<Wall>()) { }

		public Sky(List<Bird> birds, List<Wall> walls)
		{
			Birds = birds;
			Walls = walls;

			DispatcherTimer clock = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000 / fps) };
			clock.Tick += new EventHandler(NextFrame);
			clock.Start();
		}

		public void NextFrame(object sender, EventArgs e)
		{
			foreach (Bird bird in Birds)
			{
				OrientBird(bird);
				bird.Fly();
			}
		}

		private void OrientBird(Bird bird)
		{
			double direction = 2 * PI, maxDistance = 0;
			foreach (Ray ray in RayCast.Get(bird))
			{
				IEnumerable<double> w = Walls.Select((wall) =>
				{
					Geometry intersection = Geometry.Combine(
						wall.RenderPath.Data.Transform(wall.X - bird.X, wall.Y - bird.Y),
						ray.Line, GeometryCombineMode.Intersect, null, 0.001, ToleranceType.Absolute);
					if (intersection.IsEmpty())
						return observeDistance + 1;
					double d = Sqrt(Pow(intersection.Bounds.X, 2) + Pow(intersection.Bounds.Y, 2));
					return d;
				});
				if (w.Count() <= 0)
					return;
				double distance = w.Min();
				if (distance > maxDistance)
				{
					maxDistance = distance;
					direction = ray.Direction;
				}
			}
			if (maxDistance > rotateTriggerDistance)
				bird.RadDirection = direction;
			else
				bird.Direction += 5;
		}
	}
}
