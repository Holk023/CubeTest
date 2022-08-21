using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NAP.UI;

namespace NAP.Core
{
	public class CalculateCollision : MonoBehaviour
	{

		#region Variables
		[SerializeField] private CubesMovement _cubesMovement;
		[SerializeField] private Transform _centerPoint;

		[SerializeField] private float _radius;
		public float Radius => _radius;

		[SerializeField] private CubesCounter _cubesCounter;
		#endregion

		private void Start()
		{
			_cubesCounter = FindObjectOfType<CubesCounter>();
			if (_cubesCounter == null)
				return;
			_cubesCounter.SetCubeCount(_cubesMovement.SpawnedCubes.Count);
		}

		private void FixedUpdate()
		{
			for (int i = _cubesMovement.SpawnedCubes.Count - 1; i >= 0; i--)
			{
				for (int j = _cubesMovement.SpawnedCubes.Count - 1; j >= 0; j--)
				{
					if (i == j || _cubesMovement.SpawnedCubes[i] == null || _cubesMovement.SpawnedCubes[j] == null)
						continue;

					float distanceToCube = Vector3.Distance(_cubesMovement.SpawnedCubes[i].transform.position,
						_cubesMovement.SpawnedCubes[j].transform.position);

					if (distanceToCube < _radius)
					{
						GameObject cube1 = _cubesMovement.SpawnedCubes[i];
						GameObject cube2 = _cubesMovement.SpawnedCubes[j];
						_cubesMovement.SpawnedCubes.Remove(_cubesMovement.SpawnedCubes[i]);
						_cubesMovement.SpawnedCubes.Remove(_cubesMovement.SpawnedCubes[j]);
						Destroy(cube1);
						Destroy(cube2);
						_cubesCounter.SetCubeCount(_cubesMovement.SpawnedCubes.Count);
					}
				}

				if (Mathf.Abs(_cubesMovement.SpawnedCubes[i].transform.position.z) > Camera.main.orthographicSize * 1.1f ||
					(Mathf.Abs(_cubesMovement.SpawnedCubes[i].transform.position.x) > Camera.main.orthographicSize * 1.8f) && _cubesMovement.SpawnedCubes[i] != null)
				{
					GameObject cube1 = _cubesMovement.SpawnedCubes[i];
					_cubesMovement.SpawnedCubes.Remove(_cubesMovement.SpawnedCubes[i]);
					Destroy(cube1);
					_cubesCounter.SetCubeCount(_cubesMovement.SpawnedCubes.Count);
				}
			}
		}
		private void DrawSphere()
		{
#if UNITY_EDITOR
			for (int i = _cubesMovement.SpawnedCubes.Count - 1; i >= 0 ; i--)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(_cubesMovement.SpawnedCubes[i].transform.position, _radius);

				float distanceFromCenterPoint = Vector3.Distance(_cubesMovement.SpawnedCubes[i].transform.position,
				_centerPoint.position);

				Handles.color = Color.green;
				Handles.Label(Vector3.Lerp(_centerPoint.position, _cubesMovement.SpawnedCubes[i].transform.position, 0.5f),
					$"{distanceFromCenterPoint}");
#endif
			}
		}
		private void OnDrawGizmos()
		{
			DrawSphere();
		}
	} 
}
