using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Estecka.Extensions;

namespace Estecka.Demo {
	public sealed class EsteckaBasicsDemoScript : MonoBehaviour {
		[Header("Extended PropertyDrawers")]
		public KeyCode keycode;
		public LayerMask layerMask;

		[Header("Estecka's propertyAttributes")]
		[ExposeMask] public int exposeMask;
		[Axis2D] public int Axis2D;
		[ReadOnly] public int Readonly;
		[RuntimeOnly] public int runtimeOnly;
		[RectPivot(0.5f, 0.5f)] public Rect rectPivot;
		[PreviewSprite] public Sprite previewSprite;

		[Header("Estecka's primitives")]
		[jauge.FullEditor] public jauge jaugeFullEditor = new jauge(1);
		public jauge jaugeSimpleEditor = new jauge (1);
		public AnchorPoint anchorPoint;
		public RemoteJauge remoteField = new RemoteJauge();
		public UnityScene scene;
		public Affine affine;

		void OnDrawGizmos(){
			anchorPoint.DrawGizmos ();
			Gizmos.color = Color.red;
			rectPivot.DrawGizmos (this.transform);
		}

	} // END Behaviour
} // END Namespace