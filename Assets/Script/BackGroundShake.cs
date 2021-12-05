using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundShake : MonoBehaviour
{
    Vector2 mousePos;
    Vector3 originalPos;
    [SerializeField] private float zPos = 10;
    [SerializeField] private float shakeForce;
    private void Start()
    {
        originalPos = transform.position;
    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x * shakeForce + originalPos.x, mousePos.y * shakeForce + originalPos.y, zPos);
    }
}
