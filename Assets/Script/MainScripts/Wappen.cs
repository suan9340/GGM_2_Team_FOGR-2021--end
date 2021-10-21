using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wappen : MonoBehaviour
{
    private int damage = 5;
    public void ChangeDamage(int get)
    {
        damage = get;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("A");
        if (collision.CompareTag("Enemy"))
            collision.GetComponent<Item>().GetDamaged(damage);
    }
}