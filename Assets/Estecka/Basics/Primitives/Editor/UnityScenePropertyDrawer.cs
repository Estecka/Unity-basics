#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Estecka.EsteckaEditor {
	[CustomPropertyDrawer(typeof(UnityScene))]
	public class UnityScenePropertyDrawer : PropertyDrawer{

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) { 
			if(property.FindPropertyRelative("sceneAsset").objectReferenceValue == null)
				return 16;
			else if (property.FindPropertyRelative ("buildIndex").intValue < 0)
				return 60;
			else
				return 32;
		}

		public static float ratio;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
			SerializedProperty _sceneAsset = property.FindPropertyRelative ("sceneAsset");
			SerializedProperty _buildIndex = property.FindPropertyRelative ("buildIndex");

			position.height = 16;

			position = EditorGUI.PrefixLabel (position, label);
			EditorGUI.PropertyField (position, _sceneAsset, new GUIContent());

			int originalBuildIndex = _buildIndex.intValue;
			_buildIndex.intValue = -1;

			SceneAsset asset = _sceneAsset.objectReferenceValue as SceneAsset;
		    if (asset != null)
		    {
		        string message, path;
		        MessageType mType;
		        path = AssetDatabase.GetAssetPath(asset);

				for (int i=0, j=-1; i<EditorBuildSettings.scenes.Length; i++){
					bool enabled = EditorBuildSettings.scenes [i].enabled;
					if (enabled)
						j++;
					if (EditorBuildSettings.scenes [i].path == path) {
						_buildIndex.intValue = enabled ? j : -1;
						break;
					}
		        }
		 	   if (_buildIndex.intValue >= 0) {
					mType = MessageType.None;
					message = "BuildIndex : " + _buildIndex.intValue;
				}
			    else {
					position.height = 44;
					mType = MessageType.Warning;
					message = "This scene is not included in the Build Settings";
				}
				position.y += 16;
				position.width -= 18;
				EditorGUI.HelpBox (position, message, mType);

				if (originalBuildIndex != _buildIndex.intValue) {
					if (_buildIndex.intValue == -1)
						Debug.LogWarning ("Referenced scene was removed from the Build Settings", asset);
					else
						Debug.Log ("Referenced scene's build index was updated.", asset);
				}
			}
		}

		/// <summary>
		/// Verify the coherence of a given scene's data, and try to correct them if necessary. 
		/// If a sceneAsset is assigned, it will be used as a guide, otherwise, the assigned path will be used.
		/// </summary>
		/// <param name="scene">The scene to verify</param>
		/// <returns>The corrected scene, or the same scene if no correction was made.</returns>
		static public UnityScene Validate(UnityScene scene){
			if (scene.sceneAsset == null) 
			{
				SceneAsset foundAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(scene.path);
				if (foundAsset == null){
					scene.buildIndex = -1;
					scene.path = null;
				} else{
					scene.sceneAsset = foundAsset;
					scene.buildIndex = SceneUtility.GetBuildIndexByScenePath(scene.path);
				}
				return scene;
			}
			else //if (scene.sceneAsset != null)
			{
				scene.path = AssetDatabase.GetAssetPath(scene.sceneAsset);
				scene.buildIndex = SceneUtility.GetBuildIndexByScenePath(scene.path);
				return scene;
			}
		}

	} // END PropertyDrawer
} // END Namespace
#endif