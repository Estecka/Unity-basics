using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

namespace Estecka.EsteckaEditor {
	[CustomPropertyDrawer(typeof(ReadOnly))]
	public class ReadonlyDrawer : PropertyDrawer {
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			return EditorGUI.GetPropertyHeight(property, label, true);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			GUI.enabled = false;
			EditorGUI.PropertyField(position, property, label, true);
			GUI.enabled = true;
		}
	}
}
#endif

namespace Estecka {
	/// <summary>
	/// Renders the field not editable in the inspector
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Field)]
	public class ReadOnly : PropertyAttribute {}
}