using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	static public class VectorExtension {

		/// <summary>
		/// Clamps a Vector component-wise
		/// </summary>
		/// <param name="value">The vector to clamp</param>
		/// <param name="min">The minimum values of each component</param>
		/// <param name="max">The maximum values of each component</param>
		/// <returns></returns>
		static public Vector2 Clamp(this Vector2 value, Vector2 min, Vector2 max) {
			value.x = Mathf.Clamp(value.x, min.x, max.x);
			value.y = Mathf.Clamp(value.y, min.y, max.y);
			return value;
		}
		/// <summary>
		/// Clamps a Vector component-wise
		/// </summary>
		/// <param name="value">The vector to clamp</param>
		/// <param name="min">The minimum values of each component</param>
		/// <param name="max">The maximum values of each component</param>
		/// <returns></returns>
		static public Vector3 Clamp(this Vector3 value, Vector3 min, Vector3 max) {
			value.x = Mathf.Clamp(value.x, min.x, max.x);
			value.y = Mathf.Clamp(value.y, min.y, max.y);
			value.z = Mathf.Clamp(value.z, min.z, max.z);
			return value;
		}

		/// <summary>
		/// Remap a vector from a Range I to a Range O componente-wise
		/// </summary>
		/// <returns>oMin + ( (value-iMin)*(oMax-oMin)/(iMax-iMin) )</returns>
		/// <param name="value">Value to remap</param>
		/// <param name="iMin">Lower bound of the input range</param>
		/// <param name="iMax">Upper bound of the input range</param>
		/// <param name="oMin">Lower bound of the output range</param>
		/// <param name="oMax">Upper bound of the output range</param>
		static public Vector2 Remap(this Vector2 value, Vector2 iMin, Vector2 iMax, Vector2 oMin, Vector2 oMax){
			value.x = FloatExtension.Remap(value.x, iMin.x, iMax.x, oMin.x, oMax.x);
			value.y = FloatExtension.Remap(value.y, iMin.y, iMax.y, oMin.y, oMax.y);
			return value;
		}
		/// <summary>
		/// Remap a vector from a Range I to a Range O componente-wise
		/// </summary>
		/// <returns>oMin + ( (value-iMin)*(oMax-oMin)/(iMax-iMin) )</returns>
		/// <param name="value">Value to remap</param>
		/// <param name="iMin">Lower bound of the input range</param>
		/// <param name="iMax">Upper bound of the input range</param>
		/// <param name="oMin">Lower bound of the output range</param>
		/// <param name="oMax">Upper bound of the output range</param>
		static public Vector3 Remap(this Vector3 value, Vector3 iMin, Vector3 iMax, Vector3 oMin, Vector3 oMax){
			value.x = FloatExtension.Remap(value.x, iMin.x, iMax.x, oMin.x, oMax.x);
			value.y = FloatExtension.Remap(value.y, iMin.y, iMax.y, oMin.y, oMax.y);
			value.z = FloatExtension.Remap(value.z, iMin.z, iMax.z, oMin.z, oMax.z);
			return value;
		}

		/// <summary>
		/// Divides to two Vector2 component-wise
		/// </summary>
		/// <param name="me">The divident</param>
		/// <param name="divider">The divider.</param>
		public static Vector2 Divide(this Vector2 me, Vector2 divider){
			me.x /= divider.x;
			me.y /= divider.y;
			return me;
		}
		/// <summary>
		/// Divides to two Vector3 component-wise
		/// </summary>
		/// <param name="me">The divident</param>
		/// <param name="divider">The divider.</param>
		public static Vector3 Divide(this Vector3 me, Vector3 divider){
			me.x /= divider.x;
			me.y /= divider.y;
			me.z /= divider.z;
			return me;
		}

		/// <summary>
		/// Multiply to two Vector2 component-wise, and return the result. 
		/// Unlike `Vector2.Scale`, it does not modify the vector it was called onto.
		/// </summary>
		/// <returns>The resulting vector</returns>
		public static Vector2 Multiply(this Vector2 me, Vector2 divider){
			me.x *= divider.x;
			me.y *= divider.y;
			return me;
		}
		/// <summary>
		/// Multiply to two Vector3 component-wise
		/// Unlike `Vector3.Scale`, it does not modify the vector it was called onto.
		/// </summary>
		/// <returns>The resulting vector</returns>
		public static Vector3 Multiply(this Vector3 me, Vector3 divider){
			me.x *= divider.x;
			me.y *= divider.y;
			me.z *= divider.z;
			return me;
		}

		/// <summary>
		/// Converts a Vector2 to Vector3 by swapping the Y and Z axes.
		/// </summary>
		public static Vector3 zUp (this Vector2 me)
		{ return new Vector3 (me.x, 0, me.y); }
		/// <summary>
		/// Converts a Vector3 to Vector2 by swappin the Y and Z axes.
		/// </summary>
		public static Vector2 zUp (this Vector3 me) 
		{ return new Vector2 (me.x, me.z);	  }


		public static Vector2 Lerp(Vector2 a, Vector2 b, Vector2 t){
			return new Vector2 (
				Mathf.Lerp (a.x, b.x, t.x),
				Mathf.Lerp (a.y, b.y, t.y)
			);
		}
		public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, Vector2 t){
			return new Vector2 (
				Mathf.LerpUnclamped (a.x, b.x, t.x),
				Mathf.LerpUnclamped (a.y, b.y, t.y)
			);
		}

		public static Vector3 Lerp(Vector3 a, Vector3 b, Vector3 t){
			return new Vector3 (
				Mathf.Lerp (a.x, b.x, t.x),
				Mathf.Lerp (a.y, b.y, t.y),
				Mathf.Lerp (a.z, b.z, t.z)
			);
		}
		public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, Vector3 t){
			return new Vector3 (
				Mathf.LerpUnclamped (a.x, b.x, t.x),
				Mathf.LerpUnclamped (a.y, b.y, t.y),
				Mathf.LerpUnclamped (a.z, b.z, t.z)
			);
		}

		/// <summary>
		/// Rotates this Vector2 by 90° to the right and returns it.
		/// </summary>
		/// <returns>The rotated vector</returns>
		public static Vector2 ClockwisePerpendicular(this Vector2 yAxis){
			return new Vector2 (yAxis.y, -yAxis.x);
		}
		/// <summary>
		/// Rotaotes this Vector2 by 90° to the left and returns it.
		/// </summary>
		/// <returns>The rotated vector</returns>
		public static Vector2 CounterClockwisePerpendicular(this Vector2 xAxis){
			return new Vector2 (-xAxis.y, xAxis.x);
		}

	} // END Extension
} // END Namespace