using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAP.Data
{
	[CreateAssetMenu(fileName = "New_Settings", menuName = "SpawnSettings/New Settings")]
	public class SpawnSettings : ScriptableObject
	{
		#region Variables
		[SerializeField] private float _radiusX;
		public float RadiusX => _radiusX;

		[SerializeField] private float _radiusY;
		public float RadiusY => _radiusY;

		[SerializeField] private int _cubesCount;
		public int CubesCount => _cubesCount;

		[SerializeField] private GameObject _cubePrefab;
		public GameObject CubePrefab => _cubePrefab;
		#endregion
	} 

}
