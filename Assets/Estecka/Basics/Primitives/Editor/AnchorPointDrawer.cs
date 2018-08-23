#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Estecka.EsteckaEditor {
	[CustomPropertyDrawer(typeof(AnchorPoint))]
		public class AnchorPointDrawer : PropertyDrawer {
		public override float GetPropertyHeight(SerializedProperty p, GUIContent l){
			return 2 * EditorGUIUtility.singleLineHeight;
		}

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			Rect obj, vec;
			obj = position;
			obj.height *= 0.5f;

			vec = obj;
			vec.y += vec.height;
			vec.x += EditorGUIUtility.labelWidth;
			vec.width -= EditorGUIUtility.labelWidth;

			EditorGUI.PropertyField (obj, property.FindPropertyRelative("referenceObject"), label);
			EditorGUI.PropertyField (vec, property.FindPropertyRelative ("localPosition"), GUIContent.none);
		}
		
	} // END Drawer
} // END Namespace
#endif