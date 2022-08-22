using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAP.Core
{
	public class CubesMovement : MonoBehaviour
	{

		#region Variables
		[Header("Settings:")]
		[Range(3, 6)]
		[SerializeField] private float _speedMin;
		[Range(7, 10)]
		[SerializeField] private float _speedMax;

		[HideInInspector] public List<GameObject> SpawnedCubes;
		private bool _active = false;
		#endregion

		private void Update()
		{
			if(Input.GetKeyDown(KeyCode.Space) && !_active)
			{
				StartMovement();
				_active = !_active;
			}
		}

		public void StartMovement()
		{
			foreach (var cube in SpawnedCubes)
			{
				Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();
				float speed = Random.Range(_speedMin, _speedMax);
				Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f) * speed); ;
				cubeRigidbody.AddForce(direction, ForceMode.Impulse);
			}
		}
	} 
}
