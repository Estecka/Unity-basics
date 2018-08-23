using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Estecka.Extensions;

#if UNITY_EDITOR
using UnityEditor;
namespace Estecka.EsteckaEditor{
	[CustomPropertyDrawer(typeof(ExposeMask))]
	public class ExposeMaskDrawer : PropertyDrawer {

		public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
			return 5 * EditorGUIUtility.singleLineHeight;
		} // 

		GUIStyle labelstyle;


		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
			position.height *= 1/5f;
			EditorGUI.PropertyField (position, property);

			int value = 0;
			GUIStyle buttonstyle = EditorStyles.miniButtonMid;

			position.y += position.height;
			position.width *= 1/8f;
			Vector2 anchor = position.position;
			int row=0, line=0;

			for (int i=0; i<32; i++){
				bool lbl = property.intValue.ContainsMask(1<<i);

				position.x = anchor.x + row* position.width;
				position.y = anchor.y + line* position.height;

				switch (row) {
				case 0: case 4: 	buttonstyle = EditorStyles.miniButtonLeft;	break;
				case 7: case 3: 	buttonstyle = EditorStyles.miniButtonRight;	break;
				default: 	buttonstyle = EditorStyles.miniButtonMid;	break;
				}


				labelstyle = new GUIStyle (GUI.skin.label);
				labelstyle.alignment = TextAnchor.MiddleCenter;
				if (EditorGUI.Toggle (position, lbl, buttonstyle))
					value = value.AddMask(1<<i);
				EditorGUI.LabelField (position, lbl ? "1" : "0", labelstyle);

				row++;
				if (row >= 8) {
					row = 0;
					line++;
				}
			}
			property.intValue = value;
		} //

	} // END Drawer
} // END Namespace
#endif

namespace Estecka {
	/// <summary>
	/// Exposes the bitwise mask of an int value in the inspector
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Field)]
	public class ExposeMask : PropertyAttribute {}
}

