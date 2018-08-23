#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Estecka;

namespace EsteckaEditor {
	[CustomPropertyDrawer(typeof (jauge))]
	public class JaugeDrawer : PropertyDrawer {
		/*public override float GetPropertyHeight (SerializedProperty property, GUIContent label){
			return EditorGUIUtility.singleLineHeight;
		}*/

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
			SerializedProperty _max 	= property.FindPropertyRelative ("max");
			SerializedProperty _current = property.FindPropertyRelative ("current");

			bool fullEditor = fieldInfo.GetCustomAttributes(typeof(jauge.FullEditorAttribute), false).Length>0;

			// Remove this block is you wish to expose everything even in edit mode.
			if (!Application.isPlaying && !fullEditor) {
				Rect boolPos = position;
				boolPos.width = 54;
				position.width -= boolPos.width;
				boolPos.x += position.width;



				EditorGUI.PropertyField (position, _max, label);
				//_current.floatValue = _max.floatValue;
				bool full = (_current.floatValue/_max.floatValue)!=0;
				full = EditorGUI.ToggleLeft(boolPos, full ? "Full":"Empty", full);
				_current.floatValue = full ? _max.floatValue : 0 ;
				return;
			}


			Rect labelPosition, controlPosition, maxPosition, currentPosition;

			labelPosition = position;
			labelPosition.width = EditorGUIUtility.labelWidth;

			controlPosition = position;
			controlPosition.width -= labelPosition.width;
			controlPosition.x += labelPosition.width;

			maxPosition = controlPosition;
			maxPosition.width *= 1/2f;
			maxPosition.x += maxPosition.width;

			currentPosition = controlPosition;
			currentPosition.width *= 1/2f;;

			EditorGUI.ProgressBar (labelPosition, _current.floatValue/_max.floatValue, string.Empty );
			EditorGUI.LabelField (labelPosition, label);

			EditorGUIUtility.labelWidth = labelPosition.width;
			EditorGUI.PropertyField (currentPosition, _current, GUIContent.none);

			EditorGUIUtility.labelWidth = 30;
			EditorGUI.PropertyField (maxPosition, _max);

			float sliderValue =  GUI.HorizontalSlider (labelPosition, _current.floatValue, 0, _max.floatValue, GUIStyle.none, GUIStyle.none);

			bool outOfBound = false;
			outOfBound |= sliderValue==_max.floatValue && _current.floatValue>_max.floatValue;
			outOfBound |= sliderValue==0 && _current.floatValue<0;
			if (!outOfBound)
				_current.floatValue = sliderValue;

		}
	} // END Drawer
} // END Namespace
#endif