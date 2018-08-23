using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomPropertyDrawer(typeof(RuntimeOnly))]
public class RuntimeOnlyDrawer : PropertyDrawer {
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
		return Application.isPlaying ? 
			EditorGUI.GetPropertyHeight (property, label, true) : 0;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		if (Application.isPlaying)
			EditorGUI.PropertyField(position, property, label, true);
	}
}
#endif
public class RuntimeOnly : PropertyAttribute {}
