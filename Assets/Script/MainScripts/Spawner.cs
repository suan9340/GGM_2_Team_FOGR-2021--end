using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region 인스펙터
    [Header("스폰하는 쿨타임")] [SerializeField] private float[] coolTime;
    [Header("적 스폰하는 확률")] [SerializeField] private EnemySpawnPerCent[] spawnPerCent;
    [Header("적 프리팹")] [SerializeField] private GameObject Enemy;
    [Header("아이템 프리팹")] [SerializeField] private GameObject item_Heal;
    [Header("재료 프리팹")] [SerializeField] private GameObject item_Matarial;
    [Header("쓰레기 프리팹")] [SerializeField] private GameObject item_Alpha;
    [Header("스폰한 아이템 모아두는곳")] [SerializeField] private GameObject itemHolder;
    [Header("PoolManager 스크립트")] [SerializeField] private PoolManager poolManager;
    #endregion
    void Start()
    {
        StartCoroutine(spawn_Enemy());
        StartCoroutine(spawn_Heal());
        StartCoroutine(spawn_Matarial());
        StartCoroutine(spawn_Alpha());
    }
    IEnumerator spawn_Heal()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime[0]);
            GameObject obj = poolManager.Get(0);
            if(obj != null)
            {
                obj.transform.SetParent(itemHolder.transform);
                obj.SetActive(true);
            }
            else
            {
                obj = Instantiate(item_Heal);
                obj.transform.SetParent(itemHolder.transform);
            }
        }
    }
    IEnumerator spawn_Matarial()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime[1]);
            GameObject obj = poolManager.Get(1);
            if (obj != null)
            {
                obj.transform.SetParent(itemHolder.transform);
                obj.SetActive(true);
            }
            else
            {
                obj = Instantiate(item_Matarial);
                obj.transform.SetParent(itemHolder.transform);
            }
        }
    }
    IEnumerator spawn_Alpha()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime[2]);
            GameObject obj = poolManager.Get(2);
            if (obj != null)
            {
                obj.transform.SetParent(itemHolder.transform);
                obj.SetActive(true);
            }
            else
            {
                obj = Instantiate(item_Alpha);
                obj.transform.SetParent(itemHolder.transform);
            }
        }
    }
    IEnumerator spawn_Enemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime[3]);
            if(Random.Range(0,100) < spawnPerCent[0].PerCent)
            {
                GameObject obj = poolManager.Get(3);
                if (obj != null)
                {
                    obj.transform.SetParent(itemHolder.transform);
                    obj.SetActive(true);
                }
                else
                {
                    obj = Instantiate(Enemy);
                    obj.transform.SetParent(itemHolder.transform);
                }
            }
            else
            {
                Debug.Log("꽝!");
            }
        }
    }
}
[System.Serializable]
class EnemySpawnPerCent
{
    [Header("100분위 확률")] [SerializeField] private int[] perCent;
    public int PerCent { get { return perCent[GameManager.Instance.CurExpLevel]; } set { perCent[GameManager.Instance.CurExpLevel] = value; } }
}