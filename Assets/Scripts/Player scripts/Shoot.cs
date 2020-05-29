using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet, station;
    public bool placeStation = true;
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
        if (Input.GetMouseButtonDown(1) && placeStation == true)  //Right
        {
            Instantiate(station, new Vector3(transform.position.x + transform.forward.x * 1.25f, transform.position.y, transform.position.z + transform.forward.z * 1.25f), Quaternion.Euler(0, 0, 0));
            StartCoroutine(TakeTime());
        }
    }

    IEnumerator TakeTime()
    {
        placeStation = false;
        yield return new WaitForSeconds(10);
        placeStation = true;
    }
}
