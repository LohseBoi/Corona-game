using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject me;
    float speed = 10;

    float rotationH = 5;
    float rotationV = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translationZ = Input.GetAxis("Vertical") * speed;
        float translationX = Input.GetAxis("Horizontal") * speed;
        translationZ *= Time.deltaTime;
        translationX *= Time.deltaTime;
        me.transform.Translate(translationX, 0, translationZ);

        float h = Input.GetAxis("Mouse X") * rotationH;
        float v = Input.GetAxis("Mouse Y") * rotationV;

        me.transform.Rotate(new Vector3(0, h, 0));
        transform.Rotate(new Vector3(v, 0, 0));

    }
}
