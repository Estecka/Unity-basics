#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Estecka.Extensions;

namespace Estecka.EsteckaEditor {
	public class GameStarter : EditorWindow {
		[SerializeField] GUIStyle style;
		bool 
		waitingForPlayMode = true, 
		started = false;
		
		[MenuItem("Estecka/Start Game")]
		public static void StartGame(){
			GameStarter me = EditorWindow.GetWindow (typeof(GameStarter), true, "Starting Game...", true) as GameStarter;
			me.style = new GUIStyle (EditorStyles.boldLabel);
			me.style.alignment = TextAnchor.MiddleCenter;
		}

		void OnGUI(){
			EditorGUILayout.LabelField ("Starting...", style);
			if (!started && EditorApplication.isPlaying) {
				this.Close ();
				return;
			}

			if (!started) {
				EditorApplication.isPlaying = true;
				started = true;
				waitingForPlayMode = true;
			}

			if (waitingForPlayMode && EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode) {
				waitingForPlayMode = false;
				Time.timeScale = 1;
				UnityEngine.SceneManagement.SceneManager.LoadScene (0);
				this.Close ();
			}


		}
		
	} // END Window
} // END Namespace
#endif