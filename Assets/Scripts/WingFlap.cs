using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingFlap : MonoBehaviour
{
    
    List<Transform> wings = new List<Transform>();
    // Start is called before the first frame update
    float speed = 1.2f;
    void Start()
    {
        wings.AddRange(gameObject.GetComponentsInChildren<Transform>());
        for (int i = 0; i < wings.Count; i++)
        {
            if (wings[i].name != "Left wing" && wings[i].name != "Right wing")
            {
                wings.RemoveAt(i);
                i--;
            }
        }


        StartCoroutine(FlapPrep());
        StartCoroutine(Flap());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Debug.Log(transform.forward);
        Debug.Log(transform.rotation);
        Debug.Log("JA");
        //Turning. Perhaps in 8's?
    }
    IEnumerator FlapPrep()
    {
        for (int i = 0; i < 20; i++)
        {
            wings[0].RotateAround(wings[0].parent.localPosition, new Vector3(0, 0, 1), 2);
            wings[1].RotateAround(wings[0].parent.localPosition, new Vector3(0, 0, -1), 2);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Flap()
    {
        for (int i = 0; i < 40; i++)
        {
            wings[0].RotateAround(wings[0].parent.localPosition, new Vector3(0, 0, -1), 2);
            wings[1].RotateAround(wings[0].parent.localPosition, new Vector3(0, 0, 1), 2);
            yield return new WaitForEndOfFrame();
        }
        for (int i = 0; i < 40; i++)
        {
            wings[0].RotateAround(wings[0].parent.localPosition, new Vector3(0, 0, 1), 2);
            wings[1].RotateAround(wings[0].parent.localPosition, new Vector3(0, 0, -1), 2);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Flap());
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Human"))
        { 
            transform.LookAt(col.gameObject.transform);
        }
    }
}
