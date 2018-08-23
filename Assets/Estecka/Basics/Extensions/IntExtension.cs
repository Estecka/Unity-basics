using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	public static class IntExtension {

		/// <summary>
		/// Wraps value into a minimum (included) and a maximum (excluded).
		/// </summary>
		public static int Wrap (this int value, int min, int max){
			while (value < min)
				value += max-min;
			while (value >= max)
				value -= max-min;
			return value;
		}
		
	} // END Extension
} // END Namespace