using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCircle : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = -speed;
        }
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
