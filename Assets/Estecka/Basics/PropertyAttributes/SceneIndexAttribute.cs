using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
namespace Estecka.EsteckaEditor {
	[CustomPropertyDrawer(typeof(SceneIndexAttribute))]
	public class SceneAttributeDrawer : PropertyDrawer{

		static List<string> sceneNames = new List<string>();

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label){
			if (fieldInfo.FieldType != typeof(int))
				return EditorGUI.GetPropertyHeight(property, label);
			else
				return EditorGUIUtility.singleLineHeight;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
			if (fieldInfo.FieldType != typeof(int)){
				Debug.LogWarning("SceneAttribute should only be used on ints.");
				EditorGUI.PropertyField(position, property, true);
			}

			sceneNames.Clear();
			EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
			for (int i=0; i<scenes.Length; i++){
				if (scenes[i].enabled)
					sceneNames.Add(scenes[i].path);
			}
			property.intValue = EditorGUI.Popup(position, label.text, property.intValue, sceneNames.ToArray());
		}

	} // END Drawer
} // END Namespace
#endif

namespace Estecka {
	public class SceneIndexAttribute : PropertyAttribute {}
}