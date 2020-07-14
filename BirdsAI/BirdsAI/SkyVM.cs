using System.Linq;
using System.Windows.Controls;
using static BirdsAI.SkyParams;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace BirdsAI
{
	class SkyVM
	{
		public CommonCommand AddBirdCommand { get; }
		public CommonCommand RemoveBirdCommand { get; }

		public SkyVM(Canvas field)
		{
			List<Bird> birds = new List<Bird>();
			List<Wall> walls = new List<Wall>();
			foreach(var o in field.Children)
			{
				if (o is Bird bird)
					birds.Add(bird);
				if (o is Path wall)
					walls.Add(new Wall(wall.Data, Canvas.GetLeft(wall), Canvas.GetTop(wall)));
			}
			Sky sky = new Sky(birds, walls);

			AddBirdCommand = new CommonCommand(
				(o) =>
				{
					Bird newbie = new Bird(70, 70);

					field.Children.Add(new BirdView(newbie));
					sky.Birds.Add(newbie);
				},
				(o) => sky.Birds.Count <= maxBirdsAmount);
			RemoveBirdCommand = new CommonCommand(
				(o) =>
				{
					field.Children.Remove(sky.Birds.First().view);
					sky.Birds.RemoveAt(0);
				},
				(o) => sky.Birds.Count > 0);
		}
	}
}
