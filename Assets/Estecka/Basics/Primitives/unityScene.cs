using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Estecka {
	[System.Serializable]
	public struct UnityScene {
		#if UNITY_EDITOR
		public UnityEditor.SceneAsset sceneAsset;
		#endif


		public int buildIndex;
		public UnityScene(int buildIndex){
			this.buildIndex = buildIndex;
			#if UNITY_EDITOR
			sceneAsset = null;
			#endif
		}



		public bool isValid { get { return this.buildIndex>-1; } }

	} // END Struct
} // END Namespace