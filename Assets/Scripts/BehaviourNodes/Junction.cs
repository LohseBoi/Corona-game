using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BehaviourNodes
{
    [RequireComponent(typeof(BoxCollider))]
    public class Junction : MonoBehaviour
    {
        public Transform[] Targets;

        private void Start()
        {
            if (Targets == null)
                throw new NullReferenceException("The `Targets` field on a `Junction` can not be null.");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Human"))
                other.transform.LookAt(Targets[Random.Range(0, Targets.Length)]);
        }
    }
}
