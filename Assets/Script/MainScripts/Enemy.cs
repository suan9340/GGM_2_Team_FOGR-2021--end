using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Item
{
    bool isAttacked;
    [SerializeField] private float maxHp;
    [SerializeField] private float hp;
    [SerializeField] private Vector4[] Color;
    [SerializeField] private SpriteRenderer renderer;
    private void OnEnable()
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
            pos.y = Random.Range(45, 55); ;
            pos.x = Random.Range(-55, 55);
            if (Random.Range(0, 2) == 0)
            {
                pos.y *= -1;
            }
        }
        transform.position = pos;
        base.damage = GameManager.Instance.GetLevel(1);
        base.speed = GameManager.Instance.GetLevel(2);
        hp = GameManager.Instance.GetLevel(0);
        maxHp = GameManager.Instance.GetLevel(0);
    }
    public void GetDamaged(int damage)
    {
        if (!isAttacked)
        {
            hp -= damage;
            if (hp < maxHp * 0.25f)
            {
                renderer.color = Color[3];
            }
            else if (hp < maxHp * 0.5f)
            {
                renderer.color = Color[2];
            }
            else if (hp < maxHp * 0.75f)
            {
                renderer.color = Color[1];
            }
            else
            {
                renderer.color = Color[0];
            }
            if (hp <= 0)
            {
                GameManager.Instance.GetExp(point);
                Dead();
            }
        }
        else return;
    }
}
