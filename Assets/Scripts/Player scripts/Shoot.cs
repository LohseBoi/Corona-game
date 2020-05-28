using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet, station;
    bool fire = true;
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
        if (Input.GetMouseButtonDown(1) && fire == true)  //Right
        {
            Instantiate(station, new Vector3(transform.position.x + transform.forward.x * 1.25f, transform.position.y, transform.position.z + transform.forward.z * 1.25f), Quaternion.Euler(0, 0, 0));
            fire = false;
            StartCoroutine(TakeTime());
        }
    }

    IEnumerator TakeTime()
    {
        yield return new WaitForSeconds(10);
        fire = true;
    }
}
