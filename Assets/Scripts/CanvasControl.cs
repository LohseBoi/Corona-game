using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Image circle;
    float fill = 0f;
    void Start()
    {
        circle.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //circle.fillAmount = fill;
        if (Input.GetMouseButtonDown(1) && fill == 0)// && this.GetComponent<Shoot>().placeStation == true)  //Right
        {
            StartCoroutine(Hold());
        }
    }

    IEnumerator Hold()
    {
        while (fill < 1)
        {
            yield return new WaitForSeconds(0.01f);
            fill += 0.001f;
            circle.fillAmount = fill;
            Debug.Log(fill);
        }
        fill = 0f;
        circle.fillAmount = fill;
        StopAllCoroutines();
    }
}
