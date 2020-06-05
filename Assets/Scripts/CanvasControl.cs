using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Image circle;
    public GameObject control;
    public Camera end;
    public Canvas endC;
    List<Transform> canvas = new List<Transform>();
    float fill = 0f;
    public TextMeshProUGUI time;
    void Start()
    {
        Time.timeScale = 1;

        end.gameObject.SetActive(false);
        endC.gameObject.SetActive(false);
        circle.fillAmount = 0;
        foreach (Transform t in transform)
        {
            if (t.name != "Text (TIME)")
                canvas.Add(t);
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        StartCoroutine(TakeTime(50));
    }

    // Update is called once per frame
    void Update()
    {
        //circle.fillAmount = fill;
        if (Input.GetMouseButtonDown(1) && fill == 0)// && this.GetComponent<Shoot>().placeStation == true)  //Right
        {
            StartCoroutine(Hold());
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0;
            else if (Time.timeScale == 0)
                Time.timeScale = 1;

            Cursor.visible = !Cursor.visible;
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else if (Cursor.lockState == CursorLockMode.None) 
                Cursor.lockState = CursorLockMode.Locked;

            foreach (Transform t in canvas)
            {
                t.gameObject.SetActive(!t.gameObject.activeSelf);
            }
            control.GetComponent<Shoot>().enabled = !control.GetComponent<Shoot>().enabled;
            control.GetComponent<Move>().enabled = !control.GetComponent<Move>().enabled;
        }
    }
    IEnumerator Hold()
    {
        while (fill < 1)
        {
            yield return new WaitForSeconds(0.01f);
            fill += 0.001f;
            circle.fillAmount = fill;
        }
        fill = 0f;
        circle.fillAmount = fill;
    }
    IEnumerator TakeTime(int t)
    {
        if(t==0)
        {
            EndGame();
            StopAllCoroutines();
        }

        time.text = t.ToString();
        yield return new WaitForSeconds(1);
        StartCoroutine(TakeTime(t - 1));
    }
    void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        end.gameObject.SetActive(true);
        endC.gameObject.SetActive(true);
        Destroy(control);
        Destroy(this.gameObject);
    }
}