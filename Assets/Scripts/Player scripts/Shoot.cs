using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    /*      random color for gameobject
    Renderer rend = gameObject.GetComponent<Renderer>();
    int n = Random.Range(1, 3);
    if (n == 1) rend.sharedMaterial.color = new Color(255, 0, 0);
    if (n == 2) rend.sharedMaterial.color = new Color(0, 255, 0);
    if (n == 3) rend.sharedMaterial.color = new Color(0, 0, 255);
    */

    // Start is called before the first frame update
    public GameObject bullet;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //left
        {
            Instantiate(bullet, transform.position + (transform.forward * 1.5f), transform.rotation);  //Shoot bullet
        }
        if (Input.GetMouseButtonDown(1))  //Right
        {
            //Do sumtin
        }
    }
}
