using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DictionnaryExtension {
	
	public static V TryGetOrDefault<K,V>(this Dictionary<K, V> dict, K key, V fallback){
		dict.TryGetValue (key, out fallback);
		return fallback;
	}

} // END Extension
