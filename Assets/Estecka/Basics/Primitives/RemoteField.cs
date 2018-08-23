using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Estecka {
	public class RemoteField<T> : ISerializationCallbackReceiver {

		public RemoteField (){
			this._targetObject = null;
			this._fieldName = string.Empty;
		}
		public RemoteField(Object target, string name){
			this._targetObject = target;
			this._fieldName = name;
			this.Refresh ();
		}

		// ---- INSPECTOR FIELDS ----
		[SerializeField] Object _targetObject;
		[SerializeField] string _fieldName;

		public Object TargetObject{
			get { return _targetObject; }
			set {
				if (_targetObject!=null && _targetObject.GetType()==value.GetType ())
					_targetObject = value;
				else {
					_targetObject = value;
					this.Refresh ();
				}
			}
		}//
		public bool SetFieldName(string name, bool forceIfNotFound = false){
			string prevName = _fieldName;
			_fieldName = name;
			Refresh ();

			if (this.HasValue)
				return true;
			else {
				if (!forceIfNotFound) {
					_fieldName = prevName;
					Refresh ();
				}
				return false;
			}
		}//


		// ---- PROPERTIES ----
		public bool HasValue {
			get { return field!=null || property!=null; }
		}//

		public bool IsWriteable {
			get { return field!=null || (property!=null && property.GetSetMethod()!=null); }
		}//


		public T value {
			get {
				if (field != null)
					return (T)field.GetValue (_targetObject);
				else if (property != null)
					return (T)property.GetValue (_targetObject, null);
				else
					throw new System.InvalidOperationException ();
				
			}//
			set {
				if (field != null)
					field.SetValue (_targetObject, value);
				else if (property != null)
					property.SetValue (_targetObject, value, null);
				else
					throw new System.InvalidOperationException ();
			}//
		}//



		// ---- INTERNAL MECHANICS ----
		private System.Reflection.PropertyInfo property;
		private System.Reflection.FieldInfo field;

		public void Refresh(){
			if (!_targetObject) {
				field = null;
				property = null;
			}
			else {
				field = this._targetObject.GetType ().GetField 	 (this._fieldName);
				if ( field!=null && (field.FieldType!=typeof(T) || field.FieldType.IsSubclassOf(typeof(T))))
					field = null;

				property = this._targetObject.GetType ().GetProperty (this._fieldName);
				if ( property!=null && (property.PropertyType!=typeof(T) || property.PropertyType.IsSubclassOf(typeof(T))) )
					property = null;
			}
		}//

		public void OnBeforeSerialize() {}
		public void OnAfterDeserialize() { this.Refresh (); }


	} // END Struct

	[System.Serializable] public sealed class RemoteBool 	: RemoteField<bool> 	{}//
	[System.Serializable] public sealed class RemoteInt 	: RemoteField<int> 		{}//
	[System.Serializable] public sealed class RemoteFloat 	: RemoteField<float> 	{}//
	[System.Serializable] public sealed class RemoteString 	: RemoteField<string> 	{}//

	[System.Serializable] public sealed class RemoteJauge 	: RemoteField<jauge> 	{}//
	[System.Serializable] public sealed class RemoteVector2 : RemoteField<Vector2> 	{}//
	[System.Serializable] public sealed class RemoteVector3 : RemoteField<Vector3> 	{}//
	[System.Serializable] public sealed class RemoteUnityObject  : RemoteField<Object> 	{}//

} // END Namespace