using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.Extensions {
	public static class LayerExtensions {

		public static LayerMask GetCollisionMask(this GameObject go){
			int mask = 0;

			for (int i=0; i<32; i++)
				if (!Physics.GetIgnoreLayerCollision (go.layer, i))
					mask |= 1<<i;
			return mask;
		}

		public static LayerMask GetCollisionMask2D(this GameObject go){
			return Physics2D.GetLayerCollisionMask (go.layer);
		}

		/// <summary>
		/// UNTESTED. Determines whether this gameobject is a Prefab template or a live instance.
		/// </summary>
		public static bool IsPrefab(this GameObject go){
			bool 
			noSceneName = (go.scene.name == null),
			noSceneIndex = (go.scene.buildIndex == -1), 
			noSceneRoot = (go.scene.rootCount == 0);

			if (noSceneName != noSceneIndex || noSceneName != noSceneRoot)
				Debug.LogError (
					string.Format ("Help, this GameObject is ambiguous and I can't tell for sure it's a prefab. ;_;" +
						"\n SceneIndex : {0}; SceneName : {1}; RootCount : {2}", go.scene.name, go.scene.buildIndex, go.scene.rootCount), 
					go
				);

			return noSceneName || noSceneIndex || noSceneRoot;
		}

	} // END Extensions
} // END Namespace