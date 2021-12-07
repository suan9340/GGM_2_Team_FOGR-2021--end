using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoWeapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ingredient")
        {
            collision.gameObject.GetComponent<material>().Attacked();
        }
        if(collision.gameObject.name == "Garbage")
        {
            collision.gameObject.GetComponent<trash>().Attacked();
        }
        if (collision.gameObject.name == "Item")
        {
            collision.gameObject.GetComponent<item>().Attacked();
        }
    }
}
