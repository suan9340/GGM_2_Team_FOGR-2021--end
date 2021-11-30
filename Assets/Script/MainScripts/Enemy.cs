using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : Item
{
    #region 변수
    bool isAttacked;
    private SpriteRenderer renderer;
    protected float curHp;
    #endregion
    #region 인스펙터
    [Header("최대 Hp")] [SerializeField] protected float maxHp;
    [Header("색깔")] [SerializeField] private Color[] Color;
    #endregion
    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
        renderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable() // 켜질때 세팅 해주는 것
    {
        base.damage = GameManager.Instance.GetLevel(1,1);
        base.speed = GameManager.Instance.GetLevel(2,2);
        curHp = GameManager.Instance.GetLevel(0,0);
        maxHp = GameManager.Instance.GetLevel(0,0);
        SetStartPosition();
    }
    void Update()
    {
        MoveToZero();
        float angle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0,angle - 90);
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