using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
namespace Estecka.EsteckaEditor {
	[CustomPropertyDrawer(typeof(SceneIndexAttribute))]
	public class SceneAttributeDrawer : PropertyDrawer{

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
			
			position = EditorGUI.PrefixLabel(position, label);

			Rect intpos = position, msgpos = position;
			intpos.width *= 1/3f;
			msgpos.width *= 2/3f;
			msgpos.x += intpos.width;

			EditorGUI.PropertyField(intpos, property, GUIContent.none);
			
			int value = property.intValue;
			string msg = null;

			EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
			int trueIndex = -1;
			for (int i=0; i<scenes.Length; i++){
				if (scenes[i].enabled)
					trueIndex++;
				if (trueIndex == value) {
					msg = scenes[i].path;
					break;
				}
			}

			EditorGUI.LabelField(msgpos, msg ?? "Not a valid Scene Index");
		}

	} // END Drawer
} // END Namespace
#endif

namespace Estecka {
	public class SceneIndexAttribute : PropertyAttribute {}
}