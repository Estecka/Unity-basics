using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	static public class RectTransformExtension {
		
		/// <summary>
		/// Converts a world position to a local position normalizerd by this transform's rect.
		/// For overlay canvases, this can be used to convert pixel coordinates from the pointer's position.
		/// </summary>
		/// <returns>(0,0) if the pointer is in the lower-left corner, (1,1) in the upper-right corner.</returns>
		static public Vector2 NormalizedPosition(this RectTransform transform, Vector2 position){
			position = transform.InverseTransformPoint(position);
			position -= transform.rect.position;
			position = position.Divide(transform.rect.size);
			return position;
		}

	} // END Extension
} // END Namespace