using System.Windows.Media;

namespace BirdsAI
{
	public static class GeometryTransformer
	{
		public static Geometry Transform(this Geometry geometry, double dx, double dy)
		{
			return Geometry.Combine(geometry, Geometry.Empty, GeometryCombineMode.Union, new TranslateTransform(dx, dy));
		}
	}
}
