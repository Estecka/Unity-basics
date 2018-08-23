using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	public static class VectorExtension  {

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