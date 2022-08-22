using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NAP.UI
{
	public class FadeAnimation : MonoBehaviour
	{

		#region Variables
		[SerializeField] private float _animationSpeed;
		[SerializeField] private TextMeshProUGUI _myTextMesh;
		[SerializeField] private Color _startColor;
		[SerializeField] private Color _endColor;

		private float _animationProgress;
		#endregion


		void Update()
		{
			_animationProgress = Mathf.InverseLerp(-1f, 1f, Mathf.Sin(Time.time * _animationSpeed));
			_myTextMesh.color = Color.Lerp(_startColor, _endColor, _animationProgress);

			if (Input.GetKeyDown(KeyCode.Space))
				gameObject.SetActive(!gameObject.activeSelf);
		}
	} 
}
