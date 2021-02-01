// AForge Math Library
//
// Copyright � Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

namespace AForge.Math
{
	using System;

	/// <summary>
	/// RangeD - represents a double range with min and max values
	/// </summary>
	public struct RangeD
	{
		private double min, max;

		// Min property
		public double Min
		{
			get { return min; }
			set { min = value; }
		}
		// Max property
		public double Max
		{
			get { return max; }
			set { max = value; }
		}

		// Constructor
		public RangeD(double min, double max)
		{
			this.min = min;
			this.max = max;
		}
	}
}
