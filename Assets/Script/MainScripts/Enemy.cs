using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : Item
{
    #region ����
    bool isAttacked;
    private SpriteRenderer renderer;
    protected float curHp;
    #endregion
    #region �ν�����
    [Header("�ִ� Hp")] [SerializeField] protected float maxHp;
    [Header("����")] [SerializeField] private Color[] Color;
    #endregion
    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
        renderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable() // ������ ���� ���ִ� ��
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
    public void GetDamaged(int damage) // ������ �Ծ��� �� �� �ٲ��ִ� �Լ�
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