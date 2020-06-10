using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Human : MonoBehaviour
{
	private const float InfectionRadius = .6f;
	private const float InfectionThreshold = .9f;
	private const float RecoveryTime = 10;
	private const float TickRate = 3;
	private const float Speed = 4;

	private float _time;

	public HumanBat Bat;
	public bool Infected
	{
		get => _infected;
		set
		{
			_infected = value;
			Bat.SetState(value);
		}
	}

	private ushort _recoveryProgress;
	private GameObject _humans;
	private bool _infected;

	// Start is called before the first frame update
	private void Start()
	{
		_humans = GameObject.FindWithTag("Active People");
		if (_humans == null)
			Debug.LogError("No human source list found.");
        
	}

	private void Update()
	{
		transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
        
		_time += Time.deltaTime;
		if (!(_time > TickRate)) return;
        
		_time -= TickRate;
		if (_infected)
		{
			_recoveryProgress += 1;
			InfectionCheck();

			if (_recoveryProgress >= RecoveryTime)
			{
				Infected = false;
				_recoveryProgress = 0;
			}
		}
	}

	private void InfectionCheck()
	{
		var humans = _humans.GetComponentsInChildren<Human>(false);

		foreach (var other in humans)
		{
			if (other == this) continue;
			var distance = other.transform.position - transform.position; 
			if (distance.magnitude > InfectionRadius && Random.value > InfectionThreshold)
			{
				other.Infected = true;
			}
		}
	}
	private void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag("Station"))
		{
			Infected = false;
		}

	}
}