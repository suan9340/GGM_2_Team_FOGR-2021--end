using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float heal;
    public float GetHeal()
    {
        return heal;
    }
}
