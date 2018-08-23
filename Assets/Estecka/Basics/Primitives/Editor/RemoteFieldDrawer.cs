#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using Estecka;

namespace EsteckaEditor {
	public abstract class RemoteFieldDrawer<T> : PropertyDrawer {

		static Dictionary<System.Type, string[]> cachedNames = new Dictionary<System.Type, string[]>();
		static string[] FindNames(System.Type type){
			if (!cachedNames.ContainsKey (type)) {
				List<string> list = new List<string> (1);
				list.Add ("<nothing>");
				foreach (FieldInfo f in type.GetFields(BindingFlags.Public | BindingFlags.Instance)) {
					if (f.FieldType == typeof(T) || f.FieldType.IsSubclassOf(typeof(T)))
						list.Add (f.Name);
				}
				foreach (PropertyInfo p in type.GetProperties()) {
					if (p.PropertyType == typeof(T) || p.PropertyType.IsSubclassOf(typeof(T)))
						list.Add (p.Name);
				}
				cachedNames [type] = list.ToArray ();
			}
			return cachedNames[type];
		}//

		RemoteField<T> remoteValue = new RemoteField<T> ();


		public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
			return 2 * EditorGUIUtility.singleLineHeight;
		}//

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
			EditorGUI.LabelField(position, GUIContent.none, EditorStyles.helpBox);

			position.height *= 0.5f;
			position = EditorGUI.PrefixLabel (position, label);

			property.Next (true);
			EditorGUI.PropertyField (position, property, GUIContent.none);

			position.y += position.height;
			if (property.objectReferenceValue == null)
				EditorGUI.LabelField (position, "No Object selected");
			else {
				position.width *= 2/3f;
				System.Type type = property.objectReferenceValue.GetType ();
				remoteValue.TargetObject = property.objectReferenceValue;

				property.Next (false);
				int index = System.Array.IndexOf (FindNames(type), property.stringValue);
				index = index<0 ? 0 : index;
				index = EditorGUI.Popup (position, index, FindNames (type));
				property.stringValue = index==0 ? string.Empty : FindNames(type)[index];
				remoteValue.SetFieldName (property.stringValue, true);


				position.x += position.width;
				position.width *= 1/2f;
				if (remoteValue.HasValue)
					DrawValueLabel (position, remoteValue.value);
			}
		}//

		public virtual void DrawValueLabel (Rect position, T value){ EditorGUI.LabelField (position, value.ToString ()); }

	} // END Drawer

	[CustomPropertyDrawer(typeof(RemoteBool))] 	  public sealed class RemoteBoolDrawer 	  : RemoteFieldDrawer<bool> {}
	[CustomPropertyDrawer(typeof(RemoteInt))] 	  public sealed class RemoteIntDrawer 	  : RemoteFieldDrawer<int> {}
	[CustomPropertyDrawer(typeof(RemoteFloat))]   public sealed class RemoteFloatDrawer	  : RemoteFieldDrawer<float> {}
	[CustomPropertyDrawer(typeof(RemoteString))]  public sealed class RemoteStringDrawer  : RemoteFieldDrawer<string> {}

	[CustomPropertyDrawer(typeof(RemoteJauge))]   public sealed class RemoteJaugeDrawer	  : RemoteFieldDrawer<jauge> {}
	[CustomPropertyDrawer(typeof(RemoteVector2))] public sealed class RemoteVector2Drawer : RemoteFieldDrawer<Vector2> {}
	[CustomPropertyDrawer(typeof(RemoteVector3))] public sealed class RemoteVector3Drawer : RemoteFieldDrawer<Vector3> {}
	[CustomPropertyDrawer(typeof(RemoteUnityObject))]  public sealed class RemoteUnityObjectDrawer  : RemoteFieldDrawer<Object>  {}
} // END Namespace
#endif