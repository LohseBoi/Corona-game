using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingFlap : MonoBehaviour
{
    
    List<Transform> wings = new List<Transform>();
    // Start is called before the first frame update
    readonly float speed = 1.2f;
    public bool stopT = false;
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
        StartCoroutine(Turn());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    IEnumerator FlapPrep()
    {
        for (int i = 0; i < 20; i++)
        {
            wings[0].RotateAround(wings[0].parent.localPosition, transform.forward, -2);
            wings[1].RotateAround(wings[1].parent.localPosition, transform.forward, 2);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Flap());
    }
    IEnumerator Flap()
    {
        for (int i = 0; i < 40; i++)
        {
            //wings[0].RotateAround(wings[0].parent.localPosition, new Vector3(0, 0, -1), 2);
            //wings[1].RotateAround(wings[1].parent.localPosition, new Vector3(0, 0, 1), 2);
            wings[0].RotateAround(wings[0].parent.localPosition, transform.forward, 2);
            wings[1].RotateAround(wings[1].parent.localPosition, transform.forward, -2);
            yield return new WaitForEndOfFrame();
        }
        for (int i = 0; i < 40; i++)
        {
            // wings[0].RotateAround(wings[0].parent.localPosition, new Vector3(0, 0, 1), 2);
            // wings[1].RotateAround(wings[1].parent.localPosition, new Vector3(0, 0, -1), 2);
            wings[0].RotateAround(wings[0].parent.localPosition, transform.forward, -2);
            wings[1].RotateAround(wings[1].parent.localPosition, transform.forward, 2);
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(Flap());
    }

    public IEnumerator Turn()
    {
        Debug.Log("Turn");
        int i = 0;
        while (i<360)
        {
            if (stopT)
                break;
            //rotate right
            transform.Rotate(0, 1, 0);
            //yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(0.05f);
            i++;
        }
        
        while (i>0)
        {
            if (stopT)
                break;
            //rotate left
            transform.Rotate(0, -1, 0);
            //yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(0.05f);
            i--;
        }

        if (!stopT)
            StartCoroutine(Turn());
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Human"))
        {
            stopT = true;
            Debug.Log("Stopped");
            transform.LookAt(col.gameObject.transform);
        }
    }
    private void OnTriggerStay(Collider col)
    {
        /*
           float dis = Vector3.Distance(transform.position, col.transform.position);
           Debug.Log(dis);
           if (dis <= 3)// && col.gameObject.CompareTag("Human"))
           {
               col.gameObject.tag = "Infected";
               Debug.Log("HIT");
               transform.Rotate(new Vector3(90, 0, 0), Space.Self);

               while(true) //Wait
               {
                   if (transform.position.y >= 4)
                       break;
                   else
                       Debug.Log("Under");
               }

               transform.localRotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
               stopT = false;
               StartCoroutine(Turn());

           }
           */
    }
}
