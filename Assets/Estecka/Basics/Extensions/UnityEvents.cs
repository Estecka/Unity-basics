using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.Events {
	[System.Serializable] public class UnityEventBool 	: UnityEvent<bool> 		{}
	[System.Serializable] public class UnityEventInt 	: UnityEvent<int> 		{}
	[System.Serializable] public class UnityEventFloat 	: UnityEvent<float> 	{}
	[System.Serializable] public class UnityEventChar 	: UnityEvent<char> 		{}
	[System.Serializable] public class UnityEventString : UnityEvent<string>	{}

	[System.Serializable] public class UnityEventCollider : UnityEvent<Collider>		{}
	[System.Serializable] public class UnityEventCollision : UnityEvent<Collision>		{}
	[System.Serializable] public class UnityEventCollider2D : UnityEvent<Collision2D>	{}
	[System.Serializable] public class UnityEventCollision2D : UnityEvent<Collider2D>	{}

}
