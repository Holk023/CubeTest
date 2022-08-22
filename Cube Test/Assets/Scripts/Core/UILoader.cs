using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NAP.Core
{
	public class UILoader : MonoBehaviour
	{

		#region Variables
		[Header("References:")]
		public string _sceneToLoad;
		#endregion

		private void Awake()
		{
			SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Additive);
		}
	} 
}
