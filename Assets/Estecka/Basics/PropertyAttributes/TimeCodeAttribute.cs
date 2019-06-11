using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
namespace Estecka.EsteckaEditor {
	[CustomPropertyDrawer(typeof(TimeCodeAttribute))]
	public class TimeCodeDrawer : PropertyDrawer{
		static Regex regex = new Regex(
			@"^((?<hours>\d\d)?:)?(?<minutes>\d\d):(?<seconds>\d\d):(?<fraction>\d\d+)$",
			RegexOptions.ExplicitCapture | RegexOptions.Singleline | RegexOptions.CultureInvariant
			);

		static public float Parse(string timecode, int? fract = null){
			Match match = regex.Match(timecode);
			string hours    = match.Groups["hours"].Value;
			string minutes  = match.Groups["minutes"].Value;
			string seconds  = match.Groups["seconds"].Value;
			string fraction = match.Groups["fraction"].Value;

			if (fract == null)
				fract = (int)Mathf.Pow(10, fraction.Length-1);

			float result = 0;
			result += (float)int.Parse(fraction) / fract.Value;
			result += int.Parse(seconds);
			result += int.Parse(minutes) * 60;
			if (!string.IsNullOrEmpty(hours))
				result += int.Parse(hours) * 3600;

			return result;
		}

		static public string Unparse(float value, int fract = 10){
			int hours    = (int)(value/3600);
			int minutes  = (int)(value/60) %3600;
			int seconds  = (int)(value) %60;
			int fraction = Mathf.RoundToInt((value*fract) % fract);

			string shours    = hours.ToString("00");
			string sminutes  = minutes.ToString("00");
			string sseconds  = seconds.ToString("00");
			string sfraction = fraction.ToString("00");

			string timecode = $"{shours}:{sminutes}:{sseconds}:{sfraction}";
			return timecode;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
			if (fieldInfo.FieldType != typeof(float)){
				Debug.LogErrorFormat("`{0}` is not a float property", fieldInfo.Name);
				EditorGUI.PropertyField(position, property, true);
				return;
			}

			int? fract = (attribute as TimeCodeAttribute).framerate;
			
			string timecode = Unparse(property.floatValue, fract ?? 100);
			EditorGUI.BeginChangeCheck();
			timecode = EditorGUI.DelayedTextField(position, label, timecode);
			if (EditorGUI.EndChangeCheck()){
				property.floatValue = Parse(timecode, fract);
			}
		}

	} // END Drawer
} // END Namespace
#endif

namespace Estecka {
	public class TimeCodeAttribute : PropertyAttribute {
		public int? framerate;
		public TimeCodeAttribute(int framerate) {
			this.framerate = framerate;
		}
	}
}
