using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	public static class TransformExtensions {
		/// <summary>
		/// Make the Up axis of this Transform point toward the given Transform.
		/// </summary>
		public static void LookAt2D(this Transform transform, Transform target){
			transform.LookAt (transform.position + Vector3.forward, target.position);
		}

		/// <summary>
		/// Make the Up axis of this Transform point toward the given position.
		/// </summary>
		public static void LookAt2D(this Transform transform, Vector2 position){
			transform.LookAt (transform.position + Vector3.forward, position);
			/* Vector3 rotation = transform.eulerAngles;
			rotation.z = Vector2.SignedAngle (Vector2.up, position - (Vector2)transform.position);
			transform.eulerAngles = rotation; */
		}

		/// <summary>
		/// Get this Transforms position within its topmost parent.
		/// </summary>
		public static Vector3 GetRootPosition(this Transform transform){
			return transform.root.InverseTransformPoint (transform.position);
		}
		/// <summary>
		/// Set this Transform's position within its topmost parent.
		/// </summary>
		public static void SetRootPosition(this Transform transform, Vector3 position){
			transform.position = transform.root.TransformPoint (position);
		}

	} // END Extensions
} // END Namespace