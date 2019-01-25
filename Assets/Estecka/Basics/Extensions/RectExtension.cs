using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	public static class RectExtension {

		/// <summary>
		/// Flips the rect horizontally while preserving the covered area.
		/// </summary>
		public static Rect FlipX(this Rect rect){
			rect.x += rect.width;
			rect.width *= -1;
			return rect;
		}
		/// <summary>
		/// Flips the rect vertically while preserving the covered area.
		/// </summary>
		public static Rect FlipY(this Rect rect){
			rect.y += rect.height;
			rect.height *= -1;
			return rect;
		}
		/// <summary>
		/// If the rect has a negative size, set it upright while preserving the covered area.
		/// </summary>
		public static Rect Unflip(this Rect rect){
			if (rect.xMax < rect.xMin) rect.FlipX ();
			if (rect.yMax < rect.yMin) rect.FlipY ();
			return rect;
		}

		public static Rect Lerp(Rect a, Rect b, float t){
			return new Rect (
				Mathf.Lerp(a.x, b.x, t),
				Mathf.Lerp(a.y, b.y, t),
				Mathf.Lerp(a.width, b.width, t),
				Mathf.Lerp(a.height, b.height, t)
			);
		}
		public static Rect LerpUnclamped(Rect a, Rect b, float t){
			return new Rect (
				Mathf.LerpUnclamped(a.x, b.x, t),
				Mathf.LerpUnclamped(a.y, b.y, t),
				Mathf.LerpUnclamped(a.width, b.width, t),
				Mathf.LerpUnclamped(a.height, b.height, t)
			);
		}
		public static Rect Lerp(Rect a, Rect b, Vector2 t){
			return new Rect (
				Mathf.Lerp(a.x, b.x, t.x),
				Mathf.Lerp(a.y, b.y, t.y),
				Mathf.Lerp(a.width, b.width, t.x),
				Mathf.Lerp(a.height, b.height, t.y)
			);
		}
		public static Rect LerpUnclamped(Rect a, Rect b, Vector2 t){
			return new Rect (
				Mathf.LerpUnclamped(a.x, b.x, t.x),
				Mathf.LerpUnclamped(a.y, b.y, t.y),
				Mathf.LerpUnclamped(a.width, b.width, t.x),
				Mathf.LerpUnclamped(a.height, b.height, t.y)
			);
		}

		/// <summary>
		/// Checks whether this fully covers another rect
		/// </summary>
		/// <param name="me">The container rect</param>
		/// <param name="rect">The rect to contain</param>
		public static bool Contains(this Rect me, Rect rect){
			return me.xMax >= rect.xMax
				&& me.xMax >= rect.xMin
				&& me.xMin <= rect.xMin
				&& me.xMin <= rect.xMax
				&& me.yMax >= rect.yMax
				&& me.yMax >= rect.yMin
				&& me.yMin <= rect.yMin
				&& me.yMin <= rect.yMax ;
		}

		/// <summary>
		/// Draw a wireframe square representing this Rect.
		/// </summary>
		/// <param name="rect">The rect to draw.</param>
		/// <param name="referenceSpace">The space the rect will be drawn into.</param>
		/// <param name="useXZ">Should the rect be drawn onto the traditional 2D XY plan (false) or onto the horizontal XZ plan ?</param>
		public static void DrawGizmos(this Rect rect, Transform referenceSpace = null, bool useXZ = false){
			bool backface = (rect.width<0 | rect.height<0);
			Vector3
				m00 = rect.min,
				m01 = new Vector3 (rect.xMax, rect.yMin, 0),
				m10 = new Vector3 (rect.xMin, rect.yMax, 0),
				m11 = rect.max;
				
			if (useXZ){
				m00 = m00.zUp();
				m01 = m01.zUp();
				m10 = m10.zUp();
				m11 = m11.zUp();
			}

			if (referenceSpace) {
				m00 = referenceSpace.TransformPoint (m00);
				m01 = referenceSpace.TransformPoint (m01);
				m10 = referenceSpace.TransformPoint (m10);
				m11 = referenceSpace.TransformPoint (m11);
			}

			Gizmos.DrawLine (m00, m01);
			Gizmos.DrawLine (m00, m10);
			Gizmos.DrawLine (m11, m10);
			Gizmos.DrawLine (m11, m01);


			if (backface) {
				Gizmos.DrawLine (m00, m11);
				Gizmos.DrawLine (m10, m01);
			}

		}
			
		public static Vector3 ClampPoint (this Rect rect,  Vector3 position){
			position.x = Mathf.Clamp (position.x, rect.xMin, rect.xMax);
			position.y = Mathf.Clamp (position.y, rect.yMin, rect.yMax);
			return position;
		}
		public static Vector3 WrapPoint (this Rect rect, Vector3 position){
			while (position.x < rect.xMin)
				position.x += rect.width;
			while (position.x > rect.xMax)
				position.x -= rect.width;

			while (position.y < rect.yMin)
				position.y += rect.height;
			while (position.y > rect.yMax)
				position.y -= rect.height;

			return position;
		}

		/// <summary>
		/// Draws a wireframe cube representing the Bounds.
		/// </summary>
		/// <param name="b">The bounds to draw</param>
		/// <param name="referenceSpace">The space the bounds will be drawn into</param>
		public static void DrawGizmos(this Bounds b, Transform referenceSpace = null){
			Vector3
			m000 = b.min,
			m001 = new Vector3 (b.min.x, b.min.y, b.max.z), 
			m010 = new Vector3 (b.min.x, b.max.y, b.min.z), 
			m011 = new Vector3 (b.min.x, b.max.y, b.max.z), 
			m100 = new Vector3 (b.max.x, b.min.y, b.min.z), 
			m101 = new Vector3 (b.max.x, b.min.y, b.max.z), 
			m110 = new Vector3 (b.max.x, b.max.y, b.min.z), 
			m111 = b.max;

			if (referenceSpace) {
				m000 = referenceSpace.TransformPoint (m000);
				m001 = referenceSpace.TransformPoint (m001);
				m010 = referenceSpace.TransformPoint (m010);
				m011 = referenceSpace.TransformPoint (m011);
				m100 = referenceSpace.TransformPoint (m100);
				m101 = referenceSpace.TransformPoint (m101);
				m110 = referenceSpace.TransformPoint (m110);
				m111 = referenceSpace.TransformPoint (m111);
			}

			Gizmos.DrawLine (m000, m001);
			Gizmos.DrawLine (m000, m010);
			Gizmos.DrawLine (m000, m100);

			Gizmos.DrawLine (m001, m011);
			Gizmos.DrawLine (m001, m101);

			Gizmos.DrawLine (m010, m011);
			Gizmos.DrawLine (m010, m110);

			Gizmos.DrawLine (m100, m101);
			Gizmos.DrawLine (m100, m110);

			Gizmos.DrawLine (m111, m110);
			Gizmos.DrawLine (m111, m101);
			Gizmos.DrawLine (m111, m011);
		}

		public static Rect TransformRect(this Rect r, Component from, Component to){
			return r
				.RectToWorld (from ? from.transform : null)
				.WorldToRect (to ? to.transform : null);
		}
		public static Bounds RectToWorld (this Rect r, Transform from){
			Bounds b = default(Bounds);
			b.min = r.min;
			b.max = r.max;
			if (from) {
				b.min = from.TransformPoint  (b.min);
				b.max = from.TransformPoint  (b.max);
			}
			return b;
		}
		public static Rect WorldToRect (this Bounds b, Transform to){
			if (to) {
				b.min = to.InverseTransformPoint  (b.min);
				b.max = to.InverseTransformPoint  (b.max);
			}
			Rect r = default(Rect);
			r.min = b.min;
			r.max = b.max;
			return r;
		}

		/// <summary>
		/// Get the position of the world's origin within the Rect.
		/// (0,0) is the lower-left corner, (1,1) is the upper-right corner.
		/// </summary>
		public static Vector2 NormalizedPivot(this Rect me){
			return new Vector2 (
				-me.x / me.width,
				-me.y / me.height
			);
		}
		
	} // END Extension
} // END Namespace