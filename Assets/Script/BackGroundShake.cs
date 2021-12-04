using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundShake : MonoBehaviour
{
    Vector2 mousePos;
    Vector3 originalPos;
    [SerializeField] private float shakeForce;
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x * shakeForce, mousePos.y * shakeForce, 10);
    }
}
