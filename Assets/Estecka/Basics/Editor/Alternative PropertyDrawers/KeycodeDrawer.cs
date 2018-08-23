using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Estecka.EsteckaEditor {
	[CustomPropertyDrawer(typeof(KeyCode))]
	public class KeycodeDrawer : PropertyDrawer {
		public enum EControllerID : int {
			any = 0,
			Controller1 = 1,
			Controller2 = 2,
			Controller3 = 3,
			Controller4 = 4,
			Controller5 = 5,
			Controller6 = 6,
			Controller7 = 7,
			Controller8 = 8,
		}//

		//#if UNITY_EDITOR_WIN
		public enum EXboxButton : int {
			A = KeyCode.JoystickButton0,
			B = KeyCode.JoystickButton1,
			X = KeyCode.JoystickButton2,
			Y = KeyCode.JoystickButton3,

			UpperLeftTrigger	= KeyCode.JoystickButton4,
			UpperRightTrigger 	= KeyCode.JoystickButton5,

			Back	= KeyCode.JoystickButton6,
			Start 	= KeyCode.JoystickButton7,

			LeftStick	= KeyCode.JoystickButton8,
			RightStick	= KeyCode.JoystickButton9,

			button10 = KeyCode.JoystickButton10,
			button11 = KeyCode.JoystickButton11,
			button12 = KeyCode.JoystickButton12,
			button13 = KeyCode.JoystickButton13,
			button14 = KeyCode.JoystickButton14,
			button15 = KeyCode.JoystickButton15,
			button16 = KeyCode.JoystickButton16,
			button17 = KeyCode.JoystickButton17,
			button18 = KeyCode.JoystickButton18,
			button19 = KeyCode.JoystickButton19,
		}//
		//#endif

		static string[] inspectorOptions = new string[]{"Default", "Controller"};

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
			position = EditorGUI.PrefixLabel (position, label);
			EditorGUI.indentLevel = 0;


			Rect menu = position;
			menu.width = EditorGUIUtility.singleLineHeight;
			position.width -= menu.width;
			menu.x += position.width;

			property.isExpanded = 0 < EditorGUI.Popup(menu, property.isExpanded ? 1:0, inspectorOptions);

			if (!property.isExpanded) 
				property.intValue = (int)(KeyCode)EditorGUI.EnumPopup (position, (KeyCode)property.intValue);
			else{
				
				bool valid = true;
				EXboxButton button = (EXboxButton) 0;
				EControllerID id = (EControllerID) 0;

				id = EControllerID.any;
				int bneh = property.intValue;

				if (bneh < (int)KeyCode.JoystickButton0 || bneh > (int)KeyCode.Joystick8Button9)
					valid = false;
				else {
					bneh -= (int)KeyCode.JoystickButton0;
					while (bneh > 19) {
						bneh -= 20;
						id++;
					}
					button = (EXboxButton)(bneh + (int)KeyCode.JoystickButton0);
				}

				position.width *= 2 /3f;
				button = (EXboxButton)EditorGUI.EnumPopup (position, button);
				if (!valid)
					EditorGUI.LabelField (position, " <not a controller button>");

				position.x += position.width;
				position.width *= 1 /2f;
				id = (EControllerID)EditorGUI.EnumPopup (position, id);

				property.intValue = (int)button + (valid ? (int)id*20 : 0);
			}
		}//


		
	} // END Drawer 
} // END Namespace