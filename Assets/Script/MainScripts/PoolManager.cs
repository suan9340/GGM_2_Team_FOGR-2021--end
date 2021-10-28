using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolManager : MonoBehaviour
{
    #region 인스펙터
    [Header("Pool 을 수행할 오브젝트")][SerializeField] private Transform[] instance;
    #endregion
    public Transform Instance(int type) { return instance[type]; }
    public GameObject Get(int type)
    {
        if (instance[type].childCount > 0)
        {
            return instance[type].GetChild(0).gameObject;
        }
        else
            return null;
    }
}