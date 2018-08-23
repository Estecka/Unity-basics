using UnityEngine;
using System.Collections;

namespace Estecka.Extensions {
	static public class TypeExtension {

		/// <summary>
		/// Determines whether this Type is or inherits from another Type.
		/// </summary>
		/// <returns><c>true</c> if sub is or inherits ancestor; otherwise, <c>false</c>.</returns>
		/// <param name="sub">Sub.</param>
		/// <param name="ancestor">Ancestor.</param>
		static public bool Is(this System.Type sub, System.Type ancestor){
			return (sub == ancestor || sub.IsSubclassOf (ancestor));
		}

		/// <summary>
		/// Determines whether this Type s or inherits from another Type.
		/// </summary>
		/// <returns><c>true</c> if sub is or inherits T; otherwise, <c>false</c>.</returns>
		/// <param name="sub">Sub.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		static public bool Is<T>(this System.Type sub){
			return (sub == typeof(T) || sub.IsSubclassOf (typeof(T)));
		}
		
	} // END Extension
} // END Namespace