using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    #region �ν�����
    #endregion
    [Header("������ ���")] [SerializeField] private Transform target;
    void Update()
    {
        transform.position = target.position;
    }
}