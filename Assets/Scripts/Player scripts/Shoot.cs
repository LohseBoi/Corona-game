using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
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
            Instantiate(bullet, transform.position + (transform.forward * 1.5f), transform.rotation);
        }
        if (Input.GetMouseButtonDown(1))  //Right
        {

        }
    }
}
