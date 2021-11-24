using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : Item
{
    #region 변수
    bool isAttacked;
    #endregion
    #region 인스펙터
    [Header("최대 Hp")] [SerializeField] private float maxHp;
    [Header("진짜 Hp")] [SerializeField] private float hp;
    [Header("색깔 배열(4차원 RGBA)")] [SerializeField] private Vector4[] Color;
    [Header("자신의 SpriteRenderer")] [SerializeField] private SpriteRenderer renderer;
    #endregion

    // 켜질때 세팅 해주는 것
    private void OnEnable() 
    {
        renderer.color = Color[0];
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
        base.damage = GameManager.Instance.GetLevel(1,1);
        base.speed = GameManager.Instance.GetLevel(2,2);
        hp = GameManager.Instance.GetLevel(0,0);
        maxHp = GameManager.Instance.GetLevel(0,0);
    }

    // 데미지 입었을 때 색 바꿔주는 함수
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
                Dead();
            }
        }
        else return;
    }
}
