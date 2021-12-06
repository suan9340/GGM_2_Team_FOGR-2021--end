using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    Coroutine runningCoroutine = null;
    [Header("스폰시킬 자식적")] [SerializeField] private GameObject child;
    [SerializeField] AudioSource audio;
    private void OnEnable() // 켜질때 세팅 해주는 것
    {
        base.damage = GameManager.Instance.GetLevel(1, 1);
        //base.speed = GameManager.Instance.GetLevel(2, 2);
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
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(0));
        }
    }
    IEnumerator SpawnChild()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (pos.x > 0 && pos.x < 1 && pos.y > 0 && pos.y < 1)
            {
                audio.Play();
                GameObject obj = Instantiate(child, transform.position, Quaternion.identity);
                yield return new WaitForEndOfFrame();
                obj.GetComponent<Item>().SetPositionByCall(transform.position);
            }
        }
    }
}