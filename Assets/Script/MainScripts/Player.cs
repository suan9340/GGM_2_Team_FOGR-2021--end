using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    #region 변수
    bool isUsingWappen;
    int wappenIndex = 0;
    float angle;
    float range;
    Vector2 mousePos;
    Vector2 target;
    GameObject wappenTemp;
    #endregion
    #region 인스펙터
    [Header("무기이름")] [SerializeField] private string[] wappenName;
    [Header("차징 속도")] [SerializeField] private float wappenSpeed;
    [Header("무기위치 잡아주는것")] [SerializeField] private Transform wappenHold;
    [Header("무기이름 반영하는 텍스트")] [SerializeField] private Text wappenText;
    [Header("Circle 스크립트")] [SerializeField] private Circle circle;
    [Header("메인 카메라")] [SerializeField] private Camera mainCam;
    [Header("무기 범위 지시용")] [SerializeField] private GameObject[] wappen;
    [Header("무기 실질 공격용")] [SerializeField] private GameObject[] wappenReal;
    #endregion
    void Start()
    {
        
    }
    void Update()
    {
        wappenText.text = string.Format("무기 : {0}", wappenName[wappenIndex]);
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
            wappenTemp.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            range += Time.deltaTime * 100;
            if(wappenIndex == 0)
            {
                wappenTemp.transform.localScale = new Vector3(range * 0.1f, range, 0) * wappenSpeed;
                wappenReal[wappenIndex].transform.localScale = new Vector3(range * 0.1f, range, 0) * wappenSpeed;
            }
            else
            {
                wappenTemp.transform.localScale = new Vector3(range, range, 0) * wappenSpeed;
                wappenReal[wappenIndex].transform.localScale = new Vector3(range, range, 0) * wappenSpeed;
            }
            isUsingWappen = true;
            Vector2 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
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
            GameManager.Instance.UIManager.ChangeUiWappen(wappenIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isUsingWappen)
        {
            wappenIndex = 1;
            GameManager.Instance.UIManager.ChangeUiWappen(wappenIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !isUsingWappen)
        {
            wappenIndex = 2;
            GameManager.Instance.UIManager.ChangeUiWappen(wappenIndex);
        }
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
