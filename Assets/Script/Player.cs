using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    bool isUsingWappen;
    int wappenIndex = 0;
    float angle;
    Vector2 mousePos;
    Vector2 target;
    [SerializeField] private Text wappenText;
    [SerializeField] private string[] wappenName;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform wappenHold;
    [SerializeField] private GameObject[] wappen;
    void Start()
    {
        
    }
    void Update()
    {
        wappenText.text = string.Format("¹«±â : {0}", wappenName[wappenIndex]);
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mousePos.y - target.y, mousePos.x - target.x) * Mathf.Rad2Deg;
        wappenHold.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        CheckInput();
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isUsingWappen = true;
            wappen[wappenIndex].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isUsingWappen = false;
            wappen[wappenIndex].GetComponent<Collider2D>().enabled = true;
            wappen[wappenIndex].SetActive(false);
            wappen[wappenIndex].GetComponent<Collider2D>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isUsingWappen)
        {
            wappenIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isUsingWappen)
        {
            wappenIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !isUsingWappen)
        {
            wappenIndex = 2;
        }
    }
}
