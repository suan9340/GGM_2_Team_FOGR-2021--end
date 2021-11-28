using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : Item
{
    #region ����
    bool isAttacked;
    #endregion
    #region �ν�����
    [Header("�ִ� Hp")] [SerializeField] private float maxHp;
    [Header("��¥ Hp")] [SerializeField] private float curHp;
    [Header("���� �迭(4���� RGBA)")] [SerializeField] private Vector4[] Color;
    [Header("�ڽ��� SpriteRenderer")] [SerializeField] private SpriteRenderer renderer;
    #endregion
    private void OnEnable() // ������ ���� ���ִ� ��
    {
        base.damage = GameManager.Instance.GetLevel(1,1);
        base.speed = GameManager.Instance.GetLevel(2,2);
        curHp = GameManager.Instance.GetLevel(0,0);
        maxHp = GameManager.Instance.GetLevel(0,0);
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
