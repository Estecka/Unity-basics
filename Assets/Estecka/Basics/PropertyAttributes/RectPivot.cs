using UnityEngine;
using Estecka.Extensions;
#if UNITY_EDITOR
using UnityEditor;

namespace Estecka.EsteckaEditor {
[CustomPropertyDrawer(typeof(Rect))]
	public class RectDrawer : PropertyDrawer {
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			return EditorGUI.GetPropertyHeight(property, label, true);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

			object[] attributes = fieldInfo.GetCustomAttributes (typeof(RectPivotAttribute), true);
			
			if (attributes.Length == 0)
				EditorGUI.PropertyField (position, property, label);
			else {
				Rect value = property.rectValue;
				Vector2 pivot = ((RectPivotAttribute)attributes[0]).pivot;

				value.position += Vector2.Scale(pivot, value.size);
				EditorGUI.BeginChangeCheck ();
				value = EditorGUI.RectField(position, label, value);
				value.position -= Vector2.Scale(pivot, value.size);
				if (EditorGUI.EndChangeCheck ())
					property.rectValue = value;
			}
		}//


	} // END Drawer
} // END Namespace
#endif

namespace Estecka {
	/// <summary>
	/// In the inspector, edit the position of the rect using the given pivot instead of the lower-left corner.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Field)]
	public class RectPivotAttribute : System.Attribute {
		public Vector2 pivot;
		public RectPivotAttribute(float x, float y){
			this.pivot.x = Mathf.Clamp01 (x);
			this.pivot.y = Mathf.Clamp01 (y);
		} // END Namespace
	} // END Attribute
}