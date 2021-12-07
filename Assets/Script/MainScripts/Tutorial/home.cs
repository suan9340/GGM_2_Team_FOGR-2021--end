using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform hold;
    [SerializeField] Transform weaponHold;
    [SerializeField] float angle;
    [SerializeField] Vector2 mousePos, chargeSpeed;
    [SerializeField] GameObject weapon,weaponReal;
    GameObject weaponTemp;
    bool isUsingWeapon;
    float range;
    void Update()
    {
        CheckInput();
        ChangeAngle();
    }
    public void ChangeAngle()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mousePos.y - weaponHold.position.y, mousePos.x - weaponHold.position.x) * Mathf.Rad2Deg;
        weaponHold.eulerAngles = new Vector3(0, 0, angle - 90);
        float temp = weaponHold.localEulerAngles.z;
        if (temp <= 360 && temp >= 110 + 180 - 110)
        {
            if (temp < 360 - 110)
            {
                temp = 360 - 110;
            }
        }
        else
        {
            if (temp > 110)
            {
                temp = 110;
            }
        }
        weaponHold.localEulerAngles = new Vector3(0, 0, temp);
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weaponTemp = Instantiate(weapon, weaponHold);
            weaponTemp.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            range += Time.deltaTime * 100;
            weaponTemp.transform.localScale = new Vector3(range * chargeSpeed.x, range * chargeSpeed.y, 0);
            weaponReal.transform.localScale = new Vector3(range * chargeSpeed.x, range * chargeSpeed.y, 0);
            isUsingWeapon = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Destroy(weaponTemp);
            isUsingWeapon = false;
            weapon.SetActive(false);
            StartCoroutine(Attack());
            range = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed *= -1;
        }
        hold.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
    IEnumerator Attack()
    {
        GameObject temp = Instantiate(weaponReal, weaponHold);
        temp.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Destroy(temp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (TutorialManager.Instance.isStory6)
            {
                Debug.Log("원이 작아져");
                TutorialManager.Instance.isSamll();
                Destroy(collision.gameObject);
            }
            else return;
        }

        if (collision.CompareTag("materail"))
        {
            Debug.Log("강화용 재료가 늘어나");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("trash"))
        {
            Debug.Log("원이 작아져");
            TutorialManager.Instance.isSamll();
            Destroy(collision.gameObject);
        }
    }
}
