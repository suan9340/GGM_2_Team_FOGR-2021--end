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
    [Header("진짜 Hp")] [SerializeField] private float curHp;
    [Header("색깔 배열(4차원 RGBA)")] [SerializeField] private Vector4[] Color;
    [Header("자신의 SpriteRenderer")] [SerializeField] private SpriteRenderer renderer;
    #endregion
    private void OnEnable() // 켜질때 세팅 해주는 것
    {
        base.damage = GameManager.Instance.GetLevel(1,1);
        base.speed = GameManager.Instance.GetLevel(2,2);
        curHp = GameManager.Instance.GetLevel(0,0);
        maxHp = GameManager.Instance.GetLevel(0,0);
    }
    public void GetDamaged(int damage) // 데미지 입었을 때 색 바꿔주는 함수
    {
        if (!isAttacked)
        {
            curHp -= damage;
            if (curHp < maxHp * 0.25f)
            {
                renderer.color = Color[3];
            }
            else if (curHp < maxHp * 0.5f)
            {
                renderer.color = Color[2];
            }
            else if (curHp < maxHp * 0.75f)
            {
                renderer.color = Color[1];
            }
            else
            {
                renderer.color = Color[0];
            }
            if (curHp <= 0)
            {
                Dead();
            }
        }
        else return;
    }
}
