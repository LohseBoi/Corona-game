using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBat : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject bats;
    MeshRenderer col;
    Material yellow;
    public Material purple;
    void Start()
    {
        bats = gameObject.transform.GetChild(0).gameObject;
        bats.SetActive(false);
        StartCoroutine(Rot());
        col = transform.parent.GetComponent<MeshRenderer>();
        yellow = col.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.gameObject.CompareTag("Infected"))
        {
            bats.SetActive(true);
            col.material = purple;
        }
        else
        {
            bats.SetActive(false);
            col.material = yellow;
        }
    }

    IEnumerator Rot()
    {
        bats.transform.Rotate(0, -0.3f, 0);
        yield return new WaitForEndOfFrame();
        StartCoroutine(Rot());
    }
}
