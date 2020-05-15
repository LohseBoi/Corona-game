using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bat")
            Destroy(col.transform.parent.gameObject);
            
        else if (col.gameObject.tag == "Human")
        {
            //Do sumtin
        }


        Destroy(this.gameObject);
    }
}
