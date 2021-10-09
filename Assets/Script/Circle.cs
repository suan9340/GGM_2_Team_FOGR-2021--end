using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private float curHp;
    [SerializeField] private float maxHp;
    void Start()
    {
        curHp = maxHp;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 50);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * 50);
        }
        if (curHp > 0)
        {
            curHp -= Time.deltaTime;
        }
        transform.localScale = new Vector3(curHp, curHp, 1);
    }
    private void Heal(float temp)
    {
        curHp += temp;
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Heal(collision.gameObject.GetComponent<Item>().GetHeal());
            Destroy(collision.gameObject);
        }
    }
}
