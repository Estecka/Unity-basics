using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka {
	/// <summary>
	/// Utility class for manupulating keycodes and controller buttons.
	/// </summary>
	public static class ControllerButton {
		/// <summary>
		/// Keycode corresponding to the give xBox Controller button
		/// </summary>
		public static readonly KeyCode
		A = KeyCode.JoystickButton0,
		B = KeyCode.JoystickButton1,
		X = KeyCode.JoystickButton2,
		Y = KeyCode.JoystickButton3,

		UpperLeftTrigger	= KeyCode.JoystickButton4,
		UpperRightTrigger	= KeyCode.JoystickButton5,

		Back	= KeyCode.JoystickButton6,
		Start	= KeyCode.JoystickButton7,

		LeftStick	= KeyCode.JoystickButton8,
		RightStick	= KeyCode.JoystickButton9;
		/*
		button10 = KeyCode.JoystickButton10,
		button11 = KeyCode.JoystickButton11,
		button12 = KeyCode.JoystickButton12,
		button13 = KeyCode.JoystickButton13,
		button14 = KeyCode.JoystickButton14,
		button15 = KeyCode.JoystickButton15,
		button16 = KeyCode.JoystickButton16,
		button17 = KeyCode.JoystickButton17,
		button18 = KeyCode.JoystickButton18,
		button19 = KeyCode.JoystickButton19;
		/**/

		/// <summary>
		/// Applies a specific controller to a Joystick Button.
		/// </summary>
		/// <param name="button">Keycode ranging from 'JoystickButton0' to 'JoystickButton19' </param>
		/// <param name="joystickID">Value from 0 to 9. 0 meaning "any joystick"</param>
		public static KeyCode Joystick(this KeyCode button, int joystickID){
			return button+ 20*joystickID;
		}

	} // END Class
} // END Namespace