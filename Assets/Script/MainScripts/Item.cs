using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    Vector2 pos;
    private int alpha;
    [SerializeField] private int material;
    [SerializeField] private float heal;
    [SerializeField] private float damage;
    [SerializeField] private int point;
    private void Start()
    {
        if (Random.Range(0, 2) == 0)//x가 멀떄
        {
            pos.x = Random.Range(45, 55);
            pos.y = Random.Range(-55, 55);
            if (Random.Range(0, 2) == 0)
            {
                pos.x *= -1;
            }
        }
        else//y가 멀때
        {
            pos.y = Random.Range(45, 55);;
            pos.x = Random.Range(-55, 55);
            if (Random.Range(0, 2) == 0)
            {
                pos.y *= -1;
            }
        }
        transform.position = pos;
        alpha = Random.Range(0, 3);
    }
    private void OnDestroy()
    {
        GameManager.Instance.GetExp(point);
    }
    public float GetHeal()
    {
        return heal;
    }
    public float GetDamage()
    {
        return damage;
    }
    public int GetMaterial()
    {
        return material;
    }
    public int GetSprite()
    {
        return alpha;
    }
}