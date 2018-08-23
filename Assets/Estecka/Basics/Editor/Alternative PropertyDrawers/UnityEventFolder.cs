using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Events;

namespace Estecka.EsteckaEditor {
	[CustomPropertyDrawer(typeof(UnityEvent))]
	[CustomPropertyDrawer(typeof(UnityEventBool))]
	[CustomPropertyDrawer(typeof(UnityEventInt))]
	[CustomPropertyDrawer(typeof(UnityEventFloat))]
	[CustomPropertyDrawer(typeof(UnityEventChar))]
	[CustomPropertyDrawer(typeof(UnityEventString))]
	[CustomPropertyDrawer(typeof(UnityEventCollider))]
	[CustomPropertyDrawer(typeof(UnityEventCollision))]
	[CustomPropertyDrawer(typeof(UnityEventCollider2D))]
	[CustomPropertyDrawer(typeof(UnityEventCollision2D))]
	public class UnityEventFolder : UnityEventDrawer {

		public override float GetPropertyHeight (SerializedProperty property, GUIContent label)	{
			return property.isExpanded ? base.GetPropertyHeight (property, label) : EditorGUIUtility.singleLineHeight;
		}

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)	{
			property.isExpanded = EditorGUI.Foldout (position, property.isExpanded, GUIContent.none);

			if (property.isExpanded)
				base.OnGUI (position, property, label);
			else{
				label.text += " ()";
				EditorGUI.LabelField (position, label, EditorStyles.toolbarDropDown);
				//base.DrawEventHeader (position);
			}
		}


	} // END Drawer
} // END Namespac)e