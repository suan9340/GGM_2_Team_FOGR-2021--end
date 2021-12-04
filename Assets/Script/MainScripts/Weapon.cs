using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region 인스펙터
    [Header("무기의 공격력")] [SerializeField] private int damage;
    [Header("Circle 스크립트")] [SerializeField] private Circle circle;
    #endregion
    public void ChangeDamage(int get)
    {
        damage = get;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().GetDamaged((int)(damage * GameManager.Instance.DamageBuffAmount * GameManager.Instance.DamageUpgradeAmount));
        }
        if (collision.CompareTag("Ingredient"))
        {
            Item item = collision.GetComponent<Item>();
            circle.Heal(item.GetHeal());
            GameManager.Instance.GetIngredient();
            item.Dead();
        }
        if (collision.CompareTag("Garbage"))
        {
            Item item = collision.GetComponent<Item>();
            circle.Heal(item.GetHeal());
            GameManager.Instance.GetIngredient();
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