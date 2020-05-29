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
        switch (col.gameObject.tag)
        {
            case "Bat Body":
                Destroy(col.transform.parent.gameObject);
                Destroy(this.gameObject);
                break;
            case "Human":

                break;
            case "Infected":

                break;
            case "Station":

                break;
            case "Finish":
                Destroy(this.gameObject);
                break;
            default:

                break;
        }
        
    }
}
