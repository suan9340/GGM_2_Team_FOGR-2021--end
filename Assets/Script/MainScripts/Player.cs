using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    #region ����
    bool isUsingWappen;
    int weaponIndex = 0;
    float angle;
    float angle2;
    float range;
    Vector2 mousePos;
    Vector2 target;
    GameObject wappenTemp;
    #endregion
    #region �ν�����
    [Header("���� ��¡�ӵ�")] [SerializeField] private Vector2[] waeponChargeSpeedArr;
    [Header("�����̸�")] [SerializeField] private string[] wappenName;
    [Header("��¡ �ӵ�")] [SerializeField] private float wappenSpeed;
    [Header("������ġ ����ִ°�")] [SerializeField] private Transform wappenHold;
    [Header("�����̸� �ݿ��ϴ� �ؽ�Ʈ")] [SerializeField] private Text wappenText;
    [Header("Circle ��ũ��Ʈ")] [SerializeField] private Circle circle;
    [Header("���� ī�޶�")] [SerializeField] private Camera mainCam;
    [Header("���� ���� ����")] [SerializeField] private GameObject[] wappen;
    [Header("���� ���� ����")] [SerializeField] private GameObject[] wappenReal;
    [Header("������� ���� ���� �迭")] [SerializeField] private float[] attackAngle;
    #endregion
    void Start()
    {

    }
    void Update()
    {
        ChangeWeaponAngle();
        CheckInput();
        ChangeAngle();
    }
    void ChangeAngle()
    {
        float angle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle- 90);
    }
    IEnumerator Attack()
    {
        GameObject temp = Instantiate(wappenReal[weaponIndex], wappenHold);
        temp.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Destroy(temp);
    }
    void ChangeWeaponAngle()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        angle2 = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
        angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;

        angle = Mathf.Clamp(angle, -attackAngle[weaponIndex] + angle2, attackAngle[weaponIndex] + angle2);
        wappenHold.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            wappenTemp = Instantiate(wappen[weaponIndex], wappenHold);
            wappenTemp.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            range += Time.deltaTime * 100;
            wappenTemp.transform.localScale = new Vector3(range * waeponChargeSpeedArr[weaponIndex].x, range * waeponChargeSpeedArr[weaponIndex].y, 0) * wappenSpeed * GameManager.Instance.WaeponSpeedBuffAmount * GameManager.Instance.WaeponSpeedUpgradeAmount;
            wappenReal[weaponIndex].transform.localScale = new Vector3(range * waeponChargeSpeedArr[weaponIndex].x, range * waeponChargeSpeedArr[weaponIndex].y, 0) * wappenSpeed * GameManager.Instance.WaeponSpeedBuffAmount * GameManager.Instance.WaeponSpeedUpgradeAmount;
            isUsingWappen = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Destroy(wappenTemp);
            isUsingWappen = false;
            wappen[weaponIndex].SetActive(false);
            StartCoroutine(Attack());
            range = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isUsingWappen)
        {
            weaponIndex = 0;
            GameManager.Instance.UIManager.ChangeUiWappen(weaponIndex);
            wappenText.text = string.Format("���� : {0}", wappenName[weaponIndex]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isUsingWappen)
        {
            weaponIndex = 1;
            GameManager.Instance.UIManager.ChangeUiWappen(weaponIndex);
            wappenText.text = string.Format("���� : {0}", wappenName[weaponIndex]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !isUsingWappen)
        {
            weaponIndex = 2;
            GameManager.Instance.UIManager.ChangeUiWappen(weaponIndex);
            wappenText.text = string.Format("���� : {0}", wappenName[weaponIndex]);
        }
    }
    public void ChangeWappenSpeed(float change)
    {
        wappenSpeed = change;
    }
}
