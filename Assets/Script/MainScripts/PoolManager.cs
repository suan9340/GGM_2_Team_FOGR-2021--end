using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolManager : MonoBehaviour
{
    #region �ν�����
    [Header("���� Ȱ��ȭ ������Ʈ �θ�")] [SerializeField] private Transform holder;
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