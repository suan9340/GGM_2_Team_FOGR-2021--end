using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    SpriteRenderer render;
    Transform target;
    public void Search(Transform trans)
    {
        render = GetComponent<SpriteRenderer>();
        render.material.color = Color.black;
        target = trans;
    }
}