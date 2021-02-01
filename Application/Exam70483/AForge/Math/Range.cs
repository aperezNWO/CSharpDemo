// AForge Math Library
//
// Copyright � Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

namespace AForge.Math
{
	using System;

	/// <summary>
	/// Range - represents an integer range with min and max values
	/// </summary>
	public struct Range
	{
		private int min, max;

		// Min property
		public int Min
		{
			get { return min; }
			set { min = value; }
		}
		// Max property
		public int Max
		{
			get { return max; }
			set { max = value; }
		}

		// Constructor
		public Range(int min, int max)
		{
			this.min = min;
			this.max = max;
		}
	}
}
