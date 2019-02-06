#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
			SerializedProperty _sceneAsset = property.FindPropertyRelative ("sceneAsset");
			SerializedProperty _buildIndex = property.FindPropertyRelative ("buildIndex");
			SerializedProperty _path = property.FindPropertyRelative ("path");

			position.height = 16;

			position = EditorGUI.PrefixLabel (position, label);
			EditorGUI.BeginChangeCheck();
			EditorGUI.PropertyField (position, _sceneAsset, GUIContent.none);
			if (EditorGUI.EndChangeCheck())
			{
				_path.stringValue = AssetDatabase.GetAssetPath(_sceneAsset.objectReferenceValue);
				_buildIndex.intValue = SceneUtility.GetBuildIndexByScenePath(_path.stringValue);
			}
			else 
			{
				UnityScene scene = new UnityScene(){
					sceneAsset = _sceneAsset.objectReferenceValue as SceneAsset,
					buildIndex = _buildIndex.intValue,
					path = _path.stringValue
				};
				UnityScene foundScene = Validate(scene);
				if (scene != foundScene){
					if (scene.sceneAsset == null)
					{

					}
					else
					{

					}

					_sceneAsset.objectReferenceValue = foundScene.sceneAsset;
					_buildIndex.intValue = foundScene.buildIndex;
					_path.stringValue = foundScene.path;
				}
			}

		    if (_sceneAsset.objectReferenceValue != null)
		    {
		        string message;
		        MessageType mType;
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