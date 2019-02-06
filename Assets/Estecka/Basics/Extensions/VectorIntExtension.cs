using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	static public class VectorIntExtension {
		/// <summary>
		/// Rotates this Vector by 90° to the right and returns it.
		/// </summary>
		/// <returns>The rotated vector</returns>
		public static Vector2Int Clockwise(this Vector2Int vector){
			return new Vector2Int (vector.y, -vector.x);
		}
		/// <summary>
		/// Rotates this Vector by 90° to the left and returns it.
		/// </summary>
		/// <returns>The rotated vector</returns>
		public static Vector2Int CounterClockwise(this Vector2Int vector){
			return new Vector2Int (-vector.y, vector.x);
		}
		/// <summary>
		/// Rotates this Vector by 180° and returns it.
		/// </summary>
		/// <returns>The rotated vector</returns>
		public static Vector2Int Opposed(this Vector2Int vector){
			return new Vector2Int (-vector.x, -vector.y);
		}

		public static IEnumerable<Vector2Int> Adjacent(this Vector2Int position){
			yield return position + Vector2Int.up;
			yield return position + Vector2Int.right;
			yield return position + Vector2Int.down;
			yield return position + Vector2Int.left;
		}

	} // END Extensions
} // END Namespace