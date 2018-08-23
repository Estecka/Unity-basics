using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	public static class ListExtension {
		/// <summary>
		/// Set the List's count to the given size.
		/// </summary>
		/// <param name="capacity">Capacity.</param>
		/// <param name="defaultValue">If the list is expanded, the value new objects should be initialized with;</param>
		public static void Resize<T>(this List<T> l, int capacity, T defaultValue = default(T)){
			if (l.Count > capacity) {
				l.RemoveRange (capacity, l.Count - capacity);
			} else {
				if (l.Capacity < capacity)
					l.Capacity = capacity;
				while (l.Count < capacity)
					l.Add (defaultValue);
			}
		}//

		/// <summary>
		/// Add objects to the list if it doesn't contain it already.
		/// </summary>
		static public void AddRangeUnique<T> (this List<T> list, IEnumerable<T> collection){
			foreach (T n in collection)
				if (!list.Contains (n))
					list.Add (n);
		}
		/// <summary>
		/// Add an objects to the list if it doesn't contain it already.
		/// </summary>
		static public void AddUnique<T> (this List<T> list, T value){
			if (!list.Contains (value))
				list.Add (value);
		}
		/// <summary>
		/// Remove all object with this exact value from this List
		/// </summary>
		/// <param name="list">List.</param>
		static public void RemoveAll<T> (this List<T> list, T value){
			while (list.Contains (value))
				list.Remove (value);
		}
		/// <summary>
		/// Remove all null entries from this List.
		/// </summary>
		static public void RemoveNull<T> (this List<T> list) where T : class {
			list.RemoveAll (n => n == null);
		}

		
	} // END Extension
} // END Namespace