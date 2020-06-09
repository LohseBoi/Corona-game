using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanInfect : MonoBehaviour
{

    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Station"))
        {
            parent.tag = "Human";
        }

        if (col.CompareTag("Infected"))
        {
            parent.tag = col.tag;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Station"))
        {
            parent.tag = "Human";
        }
    }
}
