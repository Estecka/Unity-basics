using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Estecka {
	public sealed class PreLoader : MonoBehaviour {
		[SerializeField][SceneIndex] int sceneToLoad;
		
		public UnityEventFloat onLoadingProgress;
		public UnityEvent onLoadingReady;

		AsyncOperation _loading;

		void Start(){
			_loading = SceneManager.LoadSceneAsync(sceneToLoad);
			_loading.allowSceneActivation = false;
		}

		void Update(){
			if (_loading != null){
				onLoadingProgress.Invoke(_loading.progress);
				if (_loading.progress >= 0.9f)
					onLoadingReady.Invoke();
			}
		}
		
		public void LoadAsap(){
			_loading.allowSceneActivation = true;
		}

	} // END Behaviour
} // END Namespace