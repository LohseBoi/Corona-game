using UnityEngine;

namespace BehaviourNodes
{
	[RequireComponent(typeof(BoxCollider))]
	public class Despawn : MonoBehaviour
	{
		public Transform Pool;
	
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Human"))
			{
				other.gameObject.transform.parent = Pool;
			}
		}
	}
}