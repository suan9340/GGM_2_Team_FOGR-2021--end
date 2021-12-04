using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    Coroutine runningCoroutine = null;
    private LineRenderer lineRenderer;
    [Header("발사구멍")] [SerializeField] private Transform firePos;
    [Header("발사간격")] [SerializeField] private float delay;
    private void OnEnable() // 켜질때 세팅 해주는 것
    {
        base.damage = GameManager.Instance.GetLevel(1, 1);
        //base.speed = GameManager.Instance.GetLevel(2, 2);
        base.curHp = GameManager.Instance.GetLevel(0, 0);
        base.maxHp = GameManager.Instance.GetLevel(0, 0);
        SetStartPosition();
        if (lineRenderer == null) { lineRenderer = GetComponent<LineRenderer>(); }
        runningCoroutine = StartCoroutine(Attack());
    }
    private void OnDisable()
    {
        if (runningCoroutine != null)
        {
            StopCoroutine(runningCoroutine);
        }
    }
    IEnumerator Attack ()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (pos.x > 0 && pos.x < 1 && pos.y > 0 && pos.y < 1)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(firePos.position, Vector2.zero, 10000);
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, firePos.position);
                if (hit)
                {
                    lineRenderer.SetPosition(1, hit.point);
                    Debug.Log(hit.transform.gameObject.name);
                }
                else
                {
                    Debug.Log("Null!");
                }
            }
            yield return new WaitForSeconds(0.2f);
            lineRenderer.enabled = false;
        }
    }
}