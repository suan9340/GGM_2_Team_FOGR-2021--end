using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wappen : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && collision.CompareTag("Enemy"))
            Destroy(collision.gameObject);
    }
}