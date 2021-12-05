using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    #region 변수
    bool isUsingWappen;
    int weaponIndex = 0;
    public float angle;
    public float angle2;
    public Vector2 temp;
    public Vector2 FixTemp;
    float range;
    Vector2 mousePos;
    Vector2 target;
    GameObject wappenTemp;
    #endregion
    #region 인스펙터
    [Header("무기 차징속도")] [SerializeField] private Vector2[] waeponChargeSpeedArr;
    [Header("무기이름")] [SerializeField] private string[] wappenName;
    [Header("차징 속도")] [SerializeField] private float wappenSpeed;
    [Header("무기위치 잡아주는것")] [SerializeField] private Transform wappenHold;
    [Header("무기이름 반영하는 텍스트")] [SerializeField] private Text wappenText;
    [Header("Circle 스크립트")] [SerializeField] private Circle circle;
    [Header("메인 카메라")] [SerializeField] private Camera mainCam;
    [Header("무기 범위 장판")] [SerializeField] private GameObject[] wappen;
    [Header("무기 공격 장판")] [SerializeField] private GameObject[] wappenReal;
    [Header("무기공격 각도 제한 배열")] [SerializeField] private float[] attackAngle;
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
        angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        angle2 = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;

        if (angle2 - attackAngle[weaponIndex] < -180)
        {
            FixTemp.x = 180;
        }
        else
        {
            FixTemp.x = 0;
        }
        if(angle2 + attackAngle[weaponIndex] > 180)
        {
            FixTemp.y = -180;
        }
        else
        {
            FixTemp.y = 0;
        }
        if (angle2 - attackAngle[weaponIndex] + FixTemp.x < angle2 + attackAngle[weaponIndex] + FixTemp.y)
        {
            angle = Mathf.Clamp(angle, angle2 - attackAngle[weaponIndex] + FixTemp.x, angle2 + attackAngle[weaponIndex] + FixTemp.y);
        }
        else
        {
            angle = Mathf.Clamp(angle, angle2 + attackAngle[weaponIndex] + FixTemp.y, angle2 - attackAngle[weaponIndex] + FixTemp.x);
        }
        wappenHold.eulerAngles = new Vector3(0, 0, angle - 90);
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
            range += Time.deltaTime * 100 * GameManager.Instance.WaeponSpeedBuffAmount * GameManager.Instance.WaeponSpeedUpgradeAmount;
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
            wappenText.text = string.Format("무기 : {0}", wappenName[weaponIndex]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isUsingWappen)
        {
            weaponIndex = 1;
            GameManager.Instance.UIManager.ChangeUiWappen(weaponIndex);
            wappenText.text = string.Format("무기 : {0}", wappenName[weaponIndex]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !isUsingWappen)
        {
            weaponIndex = 2;
            GameManager.Instance.UIManager.ChangeUiWappen(weaponIndex);
            wappenText.text = string.Format("무기 : {0}", wappenName[weaponIndex]);
        }
    }
    public void ChangeWappenSpeed(float change)
    {
        wappenSpeed = change;
    }
}
