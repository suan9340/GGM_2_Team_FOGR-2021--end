using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundShake : MonoBehaviour
{
    Vector2 mousePos;
    Vector3 originalPos;
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x * 0.1f, mousePos.y * 0.1f, 10);
    }
}
