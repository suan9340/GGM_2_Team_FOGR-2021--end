using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    #region 인스펙터
    [Header("중력 속도")] [SerializeField] private float speed;
    #endregion
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,0), speed * Time.deltaTime);
    }
}
