using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Vector3 originalPos;
    float _shakeForce;
    [Header("��鸮�� ��")] [SerializeField] private float shakeForce;
    [Header("��鸮�� �ð�")] [SerializeField] private float shakeTime;
    public void Start()
    {
        originalPos = transform.position;
    }
    public void ShakeCamera()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        _shakeForce = shakeForce;
        yield return new WaitForSeconds(shakeTime);
        _shakeForce = 0;
        transform.position = originalPos;
    }
    public void Update()
    {
        if(_shakeForce != 0)
        {
            transform.position = Random.insideUnitSphere * shakeForce + originalPos;
        }
    }
}