using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    #region 인스펙터
    #endregion
    [Header("추적할 대상")] [SerializeField] private Transform target;
    void Update()
    {
        transform.position = target.position;
    }
}