using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
namespace Estecka.EsteckaEditor {
	[CustomPropertyDrawer(typeof(ScenePathAttribute))]
	public class ScenePathDrawer : PropertyDrawer{

		static List<string> sceneNames = new List<string>();

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label){
			if (fieldInfo.FieldType != typeof(string))
				return EditorGUI.GetPropertyHeight(property, label);
			else
				return EditorGUIUtility.singleLineHeight;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
			if (fieldInfo.FieldType != typeof(string)){
				Debug.LogErrorFormat("`{0}` is not a string property", fieldInfo.Name);
				EditorGUI.PropertyField(position, property, true);
				return;
			}

			sceneNames.Clear();
			EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
			for (int i=0; i<scenes.Length; i++){
				if (scenes[i].enabled)
					sceneNames.Add(scenes[i].path);
			}
			position = EditorGUI.PrefixLabel(position, label);

			if (sceneNames.IndexOf(property.stringValue) < 0)
				GUI.color = Color.red;
			int index = EditorGUI.Popup(position, sceneNames.IndexOf(property.stringValue), sceneNames.ToArray());
			GUI.color = Color.white;

			if (index >= 0)
				property.stringValue = sceneNames[index];
			else 
				EditorGUI.LabelField(position, property.stringValue);
				
		}

	} // END Drawer
} // END Namespace
#endif

namespace Estecka {
	public class ScenePathAttribute : PropertyAttribute {}
}