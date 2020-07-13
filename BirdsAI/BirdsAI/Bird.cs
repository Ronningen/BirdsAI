using static System.Math;
using static BirdsAI.SkyParams;

namespace BirdsAI
{
	public class Bird : CoordinatesHolder
	{
		public BirdView view;
		public RayCast rayCast;

		private double direction;
		public double Direction
		{
			get => direction;
			set
			{
				direction = value % 360;
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
			rayCast = new RayCast(this);
		}

		public void Fly()
		{
			X += speed * Cos(RadDirection);
			Y += speed * Sin(RadDirection);
		}
	}
}
