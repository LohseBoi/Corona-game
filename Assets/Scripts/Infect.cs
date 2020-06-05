using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infect : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Human"))
        {
            col.gameObject.tag = "Infected";
            transform.parent.Rotate(new Vector3(-90, 0, 0), Space.Self);
            StartCoroutine(Hold());
        }
    }
    IEnumerator Hold()
    {
        while(transform.parent.position.y < 4)
        {
            yield return new WaitForEndOfFrame();
        }
        transform.parent.localRotation = Quaternion.Euler(0, transform.parent.rotation.y, transform.parent.rotation.z);
        transform.parent.gameObject.GetComponent<WingFlap>().stopT = false;
        StartCoroutine(transform.parent.gameObject.GetComponent<WingFlap>().Turn());
        StopCoroutine(Hold());
    }
}
