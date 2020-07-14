using static System.Math;
using static BirdsAI.SkyParams;

namespace BirdsAI
{
	public class Bird : CoordinatesHolder
	{
		public BirdView view;

		private double direction;
		public double Direction
		{
			get => direction;
			set
			{
				direction = value;
				RaisePropertyChanged();
			}
		}
		public double RadDirection
		{
			get => Direction * PI / 180d;
			set => Direction = value * 180d / PI;
		}

		public Bird(double x, double y)
		{
			X = x;
			Y = y;
		}

		public void Fly()
		{
			X += speed * Cos(RadDirection);
			Y += speed * Sin(RadDirection);
		}
	}
}
