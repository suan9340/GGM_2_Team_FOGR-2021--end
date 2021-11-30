using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    Coroutine runningCoroutine = null;
    [Header("������ų �ڽ���")] [SerializeField] private GameObject child;
    private void OnEnable() // ������ ���� ���ִ� ��
    {
        base.damage = GameManager.Instance.GetLevel(1, 1);
        base.speed = GameManager.Instance.GetLevel(2, 2);
        base.curHp = GameManager.Instance.GetLevel(0, 0);
        base.maxHp = GameManager.Instance.GetLevel(0, 0);
        SetStartPosition();
        runningCoroutine = StartCoroutine(SpawnChild());
    }
    private void OnDisable()
    {
        if (runningCoroutine != null)
        {
            StopCoroutine(runningCoroutine);
        }
    }
    IEnumerator SpawnChild()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            GameObject obj = Instantiate(child, transform.position,Quaternion.identity);
            obj.transform.SetParent(null);
        }
    }
}
