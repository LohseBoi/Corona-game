using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject Pool;
	public GameObject Active;
	public GameObject Prefab;
	public Transform Target;

	private float _lastSpawnTime;
	private const float SpawnRate = 10;
	private const uint MinPoolSize = 20;

	private void Start()
	{
		while (Pool.transform.childCount < MinPoolSize)
			Instantiate(Prefab, Pool.transform, true);
	}

	private void Update()
	{
		_lastSpawnTime += Time.deltaTime;
		if (_lastSpawnTime > SpawnRate)
		{
			_lastSpawnTime = 0;
			if (Pool.transform.childCount > 0)
			{
				var child = Pool.transform.GetChild(0);
				child.parent = Active.transform;
				
				var localPosition = transform.localPosition;
				child.position = localPosition;
				var rotation = Quaternion.FromToRotation(child.transform.forward, Target.localPosition - localPosition);
				rotation.x = 0;
				rotation.z = 0;
				child.rotation = rotation;
			}
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponent<Human>() != null)
			other.gameObject.transform.parent = Pool.transform;
	}
}