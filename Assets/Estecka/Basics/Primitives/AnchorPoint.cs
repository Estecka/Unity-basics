using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka {
	[System.Serializable]
	/// <summary>
	/// Represents a position within a GameObject
	/// </summary>
	public struct AnchorPoint {
		public Transform referenceObject;
		public Vector3 localPosition;

		public Vector3 WorldPosition{
			get{
				if (referenceObject == null)
					return localPosition;
				else
					return referenceObject.TransformPoint (localPosition);
			}
			set {
				if (referenceObject == null)
					localPosition = value;
				else
					localPosition = referenceObject.InverseTransformPoint (value);
			}
		}

		public Vector3 Right	{ get { return referenceObject ? referenceObject.right 	: Vector3.right; 	} }
		public Vector3 Up		{ get { return referenceObject ? referenceObject.up 		: Vector3.up; 		} }
		public Vector3 Forward	{ get { return referenceObject ? referenceObject.forward 	: Vector3.forward; 	} }

		/// <summary>
		/// Draws the local space's X, Y and Z vector around this points position in the world.
		/// </summary>
		/// <param name="size">The local length of the drawn vector.</param>
		public void DrawGizmos(float size = 1){
			Gizmos.color = Color.red;	Gizmos.DrawRay ( this.WorldPosition, size*this.Right   );
			Gizmos.color = Color.green;	Gizmos.DrawRay ( this.WorldPosition, size*this.Up      );
			Gizmos.color = Color.blue;	Gizmos.DrawRay ( this.WorldPosition, size*this.Forward );
		}

	} // END Struct
} // END Namespace