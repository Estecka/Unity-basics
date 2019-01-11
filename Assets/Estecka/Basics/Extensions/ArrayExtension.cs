using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	static public class ArrayExtension {
		/// <summary>
		/// Process every items from this array and returns an array of the results.
		/// </summary>
		/// <param name="input">The array to preocess</param>
		/// <param name="conversion">The function that will convert this array's elements</param>
		/// <typeparam name="I">The source array's element type</typeparam>
		/// <typeparam name="O">The destination array's element type</typeparam>
		/// <returns></returns>
		static public O[] Map<I, O>(this I[] input, System.Func<I, O> conversion){
			O[] output = new O[input.Length];
			for (int i=0; i<input.Length; i++)
				output[i] = conversion.Invoke(input[i]);
			return output;
		}

		static public List<T> Filter<T>(this T[] input, System.Func<T, bool> iteratee){
			List<T> output = new List<T>(input.Length);
			for (int i=0; i<input.Length; i++)
				if (iteratee(input[i]))
					output.Add(input[i]);
			return output;
		}

	} // END Extensions
} // END Namespace