using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka {
	[System.Serializable]
	/// <summary>
	/// Wrapper for defining both a value and a maximum value, coming with a nice PropertyDrawer.
	/// Can be used to represent a healthbar, timer, cooldown...
	/// </summary>
	public struct jauge {
		// -- FIELDS -- 
		/// <summary>
		/// The theorical top value of the jauge's content.
		/// </summary>
		public float max;

		/// <summary>
		/// The unclamped jauge's content. 
		/// </summary>
		public float current;

		/// <summary>
		/// Created a full jauge with the given capacity.
		/// </summary>
		public jauge (float max=1){
			this.max = max;
			this.current = max;
		}
		/// <summary>
		/// Create a jauge with the given capacity and content.
		/// </summary>
		public jauge (float max, float content ){
			this.max = max;
			this.current = content;
		}



		// -- PROPERTIES -- 
		/// <summary>
		/// The unclamped normalized content of the jauge.
		/// </summary>
		public float fill {
			get {
				if (max == 0)
					return current * float.PositiveInfinity;
				else
					return current /max;
			}
			set {
				if (max != 0)
					current = value *max;
			}
		}

		public bool isFull { get { return current >= max; }}
		public bool isEmpty{ get { return current <= 0;   }}

		/// <summary>
		/// The jauge's content, clamped between Zero and the jauge's max.
		/// Setting this property will clamp the jauge's content.
		/// </summary>
		public float clampedCurrent { 
			get { return Mathf.Clamp(current, 0, max); }
			set { current = Mathf.Clamp(value, 0, max); }
		}
		/// <summary>
		/// The normalized content of the jauge, clamped between 0 and 1.
		/// Setting this property will clamp the jauge's content.
		/// </summary>
		public float clampedFill	{ 
			get { return Mathf.Clamp01(fill); } 
			set { current = Mathf.Clamp01(value) * max; }
		}


		// -- METHODS -- 
		/// <summary>
		/// Multiply both the jauge's capacity and content by the given factor.
		/// </summary>
		public void Scale (float multiplier){
			current *= multiplier;
			max *= multiplier;
		}
		/// <summary>
		/// Scales both the jauge's capacity so as to reach the given capacity.
		/// </summary>
		public void Remap(float capacity){
			current *= capacity / max;
			max = capacity;
		}
		/// <summary>
		/// Offsets both the jauge's capacity and content by the given amount.
		/// </summary>
		public void Nudge(float amount){
			max += amount;
			current += amount;
		}

		/// <summary>
		/// Clamps the jauge's content between Zero and the jauge's capacity.
		/// </summary>
		public void Clamp() { current = Mathf.Clamp(current, 0, max); }
		/// <summary>
		/// Sets the jauge's content to its capacity, unless it already overflows.
		/// </summary>
		public void Refill(){ if (current<max) current = max; }
		/// <summary>
		/// Sets the jauge's content to its capacity. Clears overflow.
		/// </summary>
		public void Reset() { current = max; }
		/// <summary>
		/// Sets the jauge's content to 0, unless its content is negative.
		/// </summary>
		public void Empty() { if (current>0) current = 0; }

		public void CountDown() 	 { this.current -= Time.deltaTime; }
		public void FixedCountDown() { this.current -= Time.fixedDeltaTime; }

		public override string ToString () {
			return string.Format ("{0}/{1}", current, max);
		}

		[System.AttributeUsage(System.AttributeTargets.Field)]
		public sealed class FullEditorAttribute : System.Attribute{}
		
	} // END Class
} // END Namespace