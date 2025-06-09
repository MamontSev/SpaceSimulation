using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceSimulation.SceneControl
{
	public class SceneControlService:MonoBehaviour, ISceneControlService
	{
		public void LoadGamePlay()
		{
			LoadScene("GamePlay");
		}


		public void LoadMenu()
		{
			LoadScene("Menu");
		}
		public void LoadRestart()
		{
			LoadScene("Restart");
		}

		private void LoadScene( string name )
		{
			AsyncOperation sceneAO;
			StartCoroutine(LoadingSceneLevelRealProgress());
			IEnumerator LoadingSceneLevelRealProgress()
			{
				sceneAO = SceneManager.LoadSceneAsync(name , LoadSceneMode.Single);
				sceneAO.allowSceneActivation = false;

				while( !sceneAO.isDone )
				{
					if( sceneAO.progress >= 0.9f )
					{
						sceneAO.allowSceneActivation = true;
					}
					yield return null;
				}
			}
		}
	}
}
