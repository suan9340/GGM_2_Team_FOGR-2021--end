using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wappen : MonoBehaviour
{
    [SerializeField] private int damage = 2;
    [SerializeField] private Circle circle;
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
            item.Dead();
        }
        if (collision.CompareTag("Alpha"))
        {
            Item item = collision.GetComponent<Item>();
            circle.GetMaterial(item.GetMaterial());
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