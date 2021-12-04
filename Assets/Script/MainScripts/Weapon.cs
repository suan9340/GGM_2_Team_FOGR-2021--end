using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region �ν�����
    [Header("������ ���ݷ�")] [SerializeField] private int damage;
    [Header("Circle ��ũ��Ʈ")] [SerializeField] private Circle circle;
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