using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	static public class ArrayExtension {
		/// <summary>
		/// Process every items from this array and returns an array of the results.
		/// </summary>
		/// <param name="input">The array to process</param>
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

		/// <summary>
		/// Return an array of all the elements from this array that passed the given test.
		/// </summary>
		/// <param name="input">The array to filter</param>
		/// <param name="test">The method that will test each element of the array</param>
		/// <typeparam name="T">The type of elements in both arrays.</typeparam>
		/// <returns></returns>
		static public List<T> Filter<T>(this T[] input, System.Func<T, bool> test){
			List<T> output = new List<T>(input.Length);
			for (int i=0; i<input.Length; i++)
				if (test(input[i]))
					output.Add(input[i]);
			return output;
		}

	} // END Extensions
} // END Namespace