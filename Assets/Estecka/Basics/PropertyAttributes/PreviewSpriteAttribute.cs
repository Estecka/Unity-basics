using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Estecka.Extensions;

#if UNITY_EDITOR
using UnityEditor;
namespace Estecka.EsteckaEditor {
	[CustomPropertyDrawer(typeof(PreviewSpriteAttribute))]
	public class SpritePreviewDrawer : PropertyDrawer {
		static readonly float spriteSize = 4*16;

		public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
			return (property.objectReferenceValue is Sprite) ? 
				spriteSize : 
				EditorGUI.GetPropertyHeight (property, label) ;
		}

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
			if (!(property.objectReferenceValue is Sprite))
				EditorGUI.PropertyField (position, property);
			
			else {
				Sprite sprite = property.objectReferenceValue as Sprite;
				float aspectRatio = sprite ? Mathf.Clamp(sprite.rect.width /sprite.rect.height, 0.5f, 2) : 1;

				Rect fieldPos 	= position, 
					 previewPos = position;

				fieldPos.width -= spriteSize * aspectRatio;
				fieldPos.height = EditorGUIUtility.singleLineHeight;

				previewPos.width = spriteSize * aspectRatio;
				previewPos.x += fieldPos.width;

				EditorGUI.PropertyField (fieldPos, property);

				EditorGUI.ObjectField(previewPos, property, typeof(Sprite), GUIContent.none);

			}	
		}//
	} // END Drawer
} // END Namespace
#endif

namespace Estecka {
	/// <summary>
	/// Show a preview of the sprite in the inspector
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Field)]
	public class PreviewSpriteAttribute : PropertyAttribute {}
}