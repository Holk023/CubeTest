using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAP.Data;

namespace NAP.Core
{
	public class CubeSpawner : MonoBehaviour
	{

		#region Variables
		[Header("References:")]
		[SerializeField] private Camera _mainCamera;
		[SerializeField] private Transform _centerPoint;
		[SerializeField] private SpawnSettings _spawnSettings;
		[SerializeField] private CubesMovement _cubesMovement;
		#endregion

		void Start()
		{
			SpawnCubes();
			_mainCamera.orthographicSize = _spawnSettings.RadiusY + _spawnSettings.RadiusX;
		}

		private void SpawnCubes()
		{
			for (int i = 0; i < _spawnSettings.CubesCount; i++)
			{
				int angle = 360 / _spawnSettings.CubesCount * i;
				Vector3 position = CalculatePosition(_centerPoint.position, _spawnSettings.RadiusX, _spawnSettings.RadiusY, angle);
				GameObject newSpawnedCube = Instantiate(_spawnSettings.CubePrefab, position, 
					Quaternion.Euler(0, 360 / _spawnSettings.CubesCount * i, 0), _centerPoint);
				_cubesMovement.SpawnedCubes.Add(newSpawnedCube);
			}
		}

		private Vector3 CalculatePosition(Vector3 centerPos, float radiusX, float radiusY, float angle)
		{
			Vector3 position;
			position.x = centerPos.x + radiusX * Mathf.Sin(angle * Mathf.Deg2Rad);
			position.z = centerPos.z + radiusY * Mathf.Cos(angle * Mathf.Deg2Rad);
			position.y = centerPos.y;
			return position;
		}
	} 
}
