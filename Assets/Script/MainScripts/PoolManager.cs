using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolManager : MonoBehaviour
{
    #region �ν�����
    [Header("Pool �� ������ ������Ʈ")][SerializeField] private Transform[] instance;
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