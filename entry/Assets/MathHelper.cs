using System;

public class MathHelper {
	public static double ToDegrees( double rad ) {
		return rad * 180 / Math.PI;
	}

	public static float ToDegrees( float rad ) {
		return rad * 180 / (float) Math.PI;
	}
}
