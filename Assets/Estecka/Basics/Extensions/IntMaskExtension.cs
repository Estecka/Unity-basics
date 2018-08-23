using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	public static class IntMaskExtension {
		/// <summary>
		/// Inverses the mask.
		/// </summary>
		/// <returns>~mask</returns>
		public static int InverseMask (this int mask)
		{ return ~mask; }

		/// <summary>
		/// Add flags to a mask
		/// </summary>
		/// <returns><c>mask | flags<<c>/returns>
		public static int AddMask (this int mask, int flags)
		{ return mask | flags; }

		/// <summary>
		/// Removes the given flags from a mask.
		/// </summary>
		/// <returns>mask & ~flags</returns>
		public static int RemoveMask (this int mask, int flags)
		{ return mask & ~flags; }

		/// <summary>
		/// Check whether a mask contains all the given flags 
		/// </summary>
		/// <returns><c>(mask & flags) == flags</c></returns>
		public static bool ContainsMask (this int mask, int flags)
		{ return (mask & flags) == flags; }

		/// <summary>
		/// Check whether a mask contains any one of the given flags.
		/// </summary>
		/// <returns><c>(mask & flags) != 0</c></returns>
		public static bool ContainsAnyMask (this int mask, int flags)
		{ return (mask & flags) != 0; }
		
	} // END Extension
} // END Namespace