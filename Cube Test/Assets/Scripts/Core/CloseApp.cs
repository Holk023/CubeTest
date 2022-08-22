using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAP.Core
{
	public class CloseApp : MonoBehaviour
	{
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();
		}
	} 
}
