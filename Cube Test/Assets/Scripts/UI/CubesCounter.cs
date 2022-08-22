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
		[Header("References:")]
		[SerializeField] private TextMeshProUGUI _countText;

		private int _cubeCount;
		#endregion

		public void SetCubeCount(int count)
		{
			_cubeCount = count;
			_countText.text = $"{_cubeCount}";
		}
	}
}