using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,0), speed * Time.deltaTime);
    }
}
