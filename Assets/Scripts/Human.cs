using UnityEngine;
using Random = UnityEngine.Random;

public class Human : MonoBehaviour
{
    private const float InfectionRadius = 1f;
    private const float InfectionThreshold = .5f;
    private const float RecoveryTime = 100;
    private const float TickRate = 1000;

    private float _time;

    private bool _infected;
    private ushort _recoveryProgress;
    public GameObject Humans;

    // Start is called before the first frame update
    private void Start()
    {
        if (Humans == null)
            Debug.LogError("No human source list set.");
        
    }

    // Update is called once per frame
    private void Update()
    {
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
        var humans = Humans.GetComponentsInChildren<Human>(false);

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
