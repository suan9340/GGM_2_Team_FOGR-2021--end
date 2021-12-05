using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolManager : MonoBehaviour
{
    #region 인스펙터
    [Header("현제 활성화 오브젝트 부모")] [SerializeField] private Transform holder;
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
    public void ClearTable()
    {
        //print(holder.childCount);
        for (int i = 0; i < holder.childCount; i++)
        {
            Item item = holder.GetChild(0).GetComponent<Item>();
            item.Dead();
        }
    }
}