using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	public static class FloatExtension{
		/// <summary>
		/// Remap a value from a Range I to a Range O.
		/// </summary>
		/// <returns>oMax + ( (value-iMin)*(oMax-oMin)/(iMax-iMin) )</returns>
		/// <param name="value">Value to remap</param>
		/// <param name="iMin">Lower bound of the input range</param>
		/// <param name="iMax">Upper bound of the input range</param>
		/// <param name="oMin">Lower bound of the output range</param>
		/// <param name="oMax">Upper bound of the output range</param>
		public static float Remap(this float value, float iMin, float iMax, float oMin, float oMax){
			value -= iMin;
			value *= (oMax-oMin) / (iMax-iMin);
			value += oMin;
			return value;
		}

		/// <summary>
		/// Set the sign of this float.
		/// </summary>
		/// <param name="me">Me</param>
		/// <param name="sign">the sign applied to the float. 0 is considered Positive</param>
		static public float SetSign (this float me, float sign){
			return Mathf.Abs (me) * Mathf.Sign (sign);
		}//


		public static float AntiLerpA(float b, float t, float lerp){
			return (lerp - b*t) / (1-t);
		}
		public static float AntiLerpB(float a, float t, float lerp){
			return (lerp - a*(1-t)) / t;
		}

	} // END Extension
} // END Namespace