using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,0), 10 * Time.deltaTime);
    }
}
