using UnityEngine;
using Random = UnityEngine.Random;

public class Human : MonoBehaviour
{
    private const float InfectionRadius = 1f;
    private const float InfectionThreshold = .5f;
    private const float RecoveryTime = 100;
    private const float TickRate = 1;
    private const float Speed = 4;

    private float _time;

    private bool _infected;
    private ushort _recoveryProgress;
    private GameObject _humans;

    // Start is called before the first frame update
    private void Start()
    {
        _humans = GameObject.FindWithTag("Active Humans");
        if (_humans == null)
            Debug.LogError("No human source list found.");
        
    }

    private void Update()
    {
        transform.Translate(transform.forward * (Time.deltaTime * Speed));
        
        _time += Time.deltaTime;
        if (!(_time > TickRate)) return;
        
        _time -= TickRate;
        if (_infected)
        {
            _recoveryProgress += 1;
            InfectionCheck();

            if (_recoveryProgress >= RecoveryTime)
            {
                _infected = false;
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
                other._infected = true;
            }
        }
    }
}
