using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wappen : MonoBehaviour
{
    #region 인스펙터
    [Header("무기의 공격력")] [SerializeField] private int damage = 2;
    [Header("Circle 스크립트")] [SerializeField] private Circle circle;
    #endregion
    public void ChangeDamage(int get)
    {
        damage = get;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            collision.GetComponent<Enemy>().GetDamaged(damage);
        if (collision.CompareTag("Material"))
        {
            Item item = collision.GetComponent<Item>();
            circle.GetMaterial(item.GetMaterial());
            GameManager.Instance.GetMatarial();
            item.Dead();
        }
        if (collision.CompareTag("Alpha"))
        {
            Item item = collision.GetComponent<Item>();
            circle.GetMaterial(item.GetMaterial());
            GameManager.Instance.GetMatarial();
            item.Dead();
        }
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            circle.GetBuff();
            item.Dead();
        }
    }
}