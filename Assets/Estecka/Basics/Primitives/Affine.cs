using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka {
	/// <summary>
	/// representation of a linear function such as f(x)=ax+b
	/// </summary>
	[System.Serializable]
	public struct Affine {
		public float scalar, offset;

		// -- CONSTRUCTORS
		public Affine (float scalar, float offset){
			this.scalar = scalar; this.offset = offset;
		}
		public Affine (Vector2 direction){
			if (direction.x == 0)
				this.scalar = float.PositiveInfinity;
			else
				this.scalar = direction.y / direction.x;
			this.offset = 0;	
		}
		public Affine (Vector2 a, Vector2 b){
			a = b - a;
			if (a.x == 0) {
				this.scalar = float.PositiveInfinity;
				this.offset = 0;
			} else
				this.scalar = a.y / a.x;
			this.offset = b.y - b.x*scalar;
		}

		/// <summary>
		/// Get Y for a given value of X
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		public float Y(float x){
			return x*scalar +offset ;
		}
		/// <summary>
		/// Get X for a given value of Y
		/// </summary>
		/// <param name="y">The y coordinate.</param>
		public float X(float y){
			if (scalar == 0)
				return float.PositiveInfinity;
			else if (float.IsInfinity (scalar))
				return 0;
			else
				return (y - offset) / scalar;
		}

		public Vector2 CompareTo(Vector2 point){
			return new Vector2 (
				point.x - this.X(point.y),
				point.y - this.Y(point.x)
			);
		}

		/// <summary>
		/// Get the angle of the line drawn by this Affine
		/// </summary>
		/// <returns>The angle.</returns>
		public float getAngle(){ return Mathf.Atan (this.scalar); }

		/// <summary>
		/// Returns the length of the line between the X coordinates 0 and 1
		/// </summary>
		/// <returns>The hypothenuse.</returns>
		public float getHypothenuse(){ return Mathf.Sqrt (this.scalar*this.scalar + 1);}

	} // END Class
} // END Namespace