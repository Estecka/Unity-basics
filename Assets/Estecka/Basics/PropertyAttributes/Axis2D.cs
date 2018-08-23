using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
namespace Estecka.EsteckaEditor{
	[CustomPropertyDrawer(typeof(Axis2D))]
	public class Axis2DPropertyDrawer : PropertyDrawer {

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
			if (fieldInfo.FieldType != typeof(int))
				EditorGUI.PropertyField (position, property, label, true);
			else
				property.intValue = (int)(axis2D)EditorGUI.EnumPopup (position, label, (axis2D)property.intValue);
		}
		
	}// END Drawer
} // END Namespace
#endif

namespace Estecka {
	/// <summary>
	/// Display an int value as an Axis2D eum in the inspector
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Field)]
	public class Axis2D : PropertyAttribute {}
}