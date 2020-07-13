using System;

namespace BirdsAI
{
	public static class SkyParams
	{
		public static int fps = 30;

		public static int speed = 6;
		public static int cloudSpeed = 10;

		public static int maxBirdsAmount = 7;
		public static int spread = 80;

		public static int squareTouchRadius = 500;
		public static double colonyInfluence = 0.5;

        public static double FOV = Math.PI / 2;
        public static int raysCount = 9;
        public static int observeDistance = 200;

		public static Random r = new Random();
	}
}
