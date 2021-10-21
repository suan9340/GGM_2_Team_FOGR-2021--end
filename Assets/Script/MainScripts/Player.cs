using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    GameObject wappenTemp;
    float range;
    bool isUsingWappen;
    int wappenIndex = 0;
    float angle;
    Vector2 mousePos;
    Vector2 target;
    [SerializeField] private float wappenSpeed;
    [SerializeField] private Circle circle;
    [SerializeField] private Camera camera;
    [SerializeField] private Text wappenText;
    [SerializeField] private GameObject[] wappenUI;
    [SerializeField] private string[] wappenName;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform wappenHold;
    [SerializeField] private GameObject[] wappen;
    [SerializeField] private GameObject[] wappenReal;
    void Start()
    {
        
    }
    void Update()
    {
        wappenText.text = string.Format("¹«±â : {0}", wappenName[wappenIndex]);
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        wappenHold.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        CheckInput();
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            wappenTemp = Instantiate(wappen[wappenIndex], wappenHold);
            wappenUI[wappenIndex].SetActive(true);
            wappenTemp.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            range += Time.deltaTime * 8;
            if(wappenIndex == 0)
            {
                wappenTemp.transform.localScale = new Vector3(range, range * 0.1f, 0) * wappenSpeed;
                wappenReal[wappenIndex].transform.localScale = new Vector3(range, range * 0.1f, 0) * wappenSpeed;
            }
            else
            {
                wappenTemp.transform.localScale = new Vector3(range, range, 0) * wappenSpeed;
                wappenReal[wappenIndex].transform.localScale = new Vector3(range, range, 0) * wappenSpeed;
            }
            isUsingWappen = true;
            Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, 100);
            if (hit)
            {
                if (hit.transform.CompareTag("Material") || hit.transform.CompareTag("Alpha"))
                {
                    circle.Heal(hit.transform.GetComponent<Item>().GetHeal());
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Destroy(wappenTemp);
            isUsingWappen = false;
            wappen[wappenIndex].SetActive(false);
            StartCoroutine(Attack());
            range = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isUsingWappen)
        {
            wappenIndex = 0;
            ChangeUiWappen();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isUsingWappen)
        {
            wappenIndex = 1;
            ChangeUiWappen();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !isUsingWappen)
        {
            wappenIndex = 2;
            ChangeUiWappen();
        }
    }
    void ChangeUiWappen()
    {
        for(int i = 0; i < 3; i++)
        {
            wappenUI[i].SetActive(false);
        }
        wappenUI[wappenIndex].SetActive(true);
    }
    public void ChangeWappenSpeed(float change)
    {
        wappenSpeed = change;
    }
    IEnumerator Attack()
    {
        GameObject temp = Instantiate(wappenReal[wappenIndex],wappenHold);
        temp.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Destroy(temp);
    }
}
