using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Estecka {
	[System.Serializable]
	public struct UnityScene : ISerializationCallbackReceiver {
		#if UNITY_EDITOR
		public UnityEditor.SceneAsset sceneAsset;
		#endif


		public int buildIndex;
		public string path;

		public void OnBeforeSerialize(){}
		public void OnAfterDeserialize(){
			this.RuntimeValidation();
		}


		public void RuntimeValidation(){
			if (this.buildIndex < 0 && string.IsNullOrEmpty(this.path))
				return;

			int foundIndex = SceneUtility.GetBuildIndexByScenePath(this.path);
			if (foundIndex < 0)
			{
				string foundPath = SceneUtility.GetScenePathByBuildIndex(this.buildIndex);
				if (string.IsNullOrEmpty(foundPath)){
					Debug.LogWarningFormat(
						"No traces of this scene were found. \nPlease reassign this scene in the editor. \n" +
						"Build Index : {0} \nPath : {1}", 
						this.buildIndex, 
						this.path
					);
					this.buildIndex = -1;
					this.path = null;
				} 
				else {
					Debug.LogWarningFormat(
						"A scene path could not be found, its build index was found at a different path. \nMake sure the intended scene is assigned in the Editor. \n" +
						"Build index : {0} \nExpected path : {1} \nActual path : {2}",
						this.buildIndex,
						this.path,
						foundPath
					);
					this.path = foundPath;
				}
			}
			else if (foundIndex != this.buildIndex)
			{
				Debug.LogWarningFormat(
					"A scene was found with a different build index than expected \nMake sure the intended scene is assigned in the Editor \n" +
					"Path : {0} \nExpected index : {1} \nActual index : {2}", 
					this.path, 
					this.buildIndex, 
					foundIndex
				);
				this.buildIndex = foundIndex;
			}
		}


		public bool isValid { get { return this.buildIndex>-1; } }

	} // END Struct
} // END Namespace