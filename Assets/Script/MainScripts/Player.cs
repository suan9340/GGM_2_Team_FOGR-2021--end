using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    #region ����
    bool isUsingWappen;
    int wappenIndex = 0;
    float angle;
    float range;
    Vector2 mousePos;
    Vector2 target;
    GameObject wappenTemp;
    #endregion
    #region �ν�����
    [Header("�����̸�")] [SerializeField] private string[] wappenName;
    [Header("��¡ �ӵ�")] [SerializeField] private float wappenSpeed;
    [Header("������ġ ����ִ°�")] [SerializeField] private Transform wappenHold;
    [Header("�����̸� �ݿ��ϴ� �ؽ�Ʈ")] [SerializeField] private Text wappenText;
    [Header("Circle ��ũ��Ʈ")] [SerializeField] private Circle circle;
    [Header("���� ī�޶�")] [SerializeField] private Camera mainCam;
    [Header("���� ���� ���ÿ�")] [SerializeField] private GameObject[] wappen;
    [Header("���� ���� ���ݿ�")] [SerializeField] private GameObject[] wappenReal;
    #endregion
    void Start()
    {
        
    }
    void Update()
    {
        wappenText.text = string.Format("���� : {0}", wappenName[wappenIndex]);
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
