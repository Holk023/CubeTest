using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace NAP.UI
{
	public class CubesCounter : MonoBehaviour
	{

		#region Variables

		private int _cubeCount;
		[SerializeField] private TextMeshProUGUI _countText;

		#endregion

		public void SetCubeCount(int count)
		{
			_cubeCount = count;
			_countText.text = $"{_cubeCount}";
		}
	}
}