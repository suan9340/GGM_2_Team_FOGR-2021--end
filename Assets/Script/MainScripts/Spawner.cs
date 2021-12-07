using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region 인스펙터
    [Header("스폰하는 쿨타임")] [SerializeField] private float[] coolTime;
    [Header("쓰래기 스폰하는 확률")] [SerializeField] private GarbageSpawnPerCent[] garbageSpawnPerCent;
    [Header("재료 스폰하는 확률")] [SerializeField] private IngreDientSpawnPerCent[] ingredientSpawnPercent;
    [Header("적 스폰하는 확률")] [SerializeField] private EnemySpawnPerCent[] spawnPerCent;
    [Header("적 프리팹")] [SerializeField] private GameObject[] Enemy;
    [Header("재료 프리팹")] [SerializeField] private GameObject[] ingredient;
    [Header("쓰레기 프리팹")] [SerializeField] private GameObject[] garbage;
    [Header("아이템 프리팹")] [SerializeField] private GameObject item;
    [Header("스폰한 아이템 모아두는곳")] [SerializeField] private GameObject itemHolder;
    [Header("PoolManager 스크립트")] [SerializeField] private PoolManager poolManager;
    #endregion
    void Start()
    {
        StartCoroutine(spawn_Enemy());
        StartCoroutine(spawn_Item());
        StartCoroutine(spawn_Ingredient());
        StartCoroutine(spawn_Garbage());
    }
    IEnumerator spawn_Item()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            yield return new WaitForSeconds(coolTime[0]);
            GameObject obj = poolManager.Get(1);
            if(Random.Range(0,100) < 50)
            {
                if (obj != null)
                {
                    obj.transform.SetParent(itemHolder.transform);
                    obj.SetActive(true);
                }
                else
                {
                    obj = Instantiate(item);
                    obj.transform.SetParent(itemHolder.transform);
                }
            }
        }
    }
    IEnumerator spawn_Ingredient()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            yield return new WaitForSeconds(coolTime[1]);
            bool isSpawn = false;
            int temp = Random.Range(0, 100);
            int cur = 0;
            int i;
            for (i = 0; i < ingredientSpawnPercent.Length; i++)
            {
                cur += ingredientSpawnPercent[i].PerCent;
                if (temp < cur)
                {
                    isSpawn = true;
                    break;
                }
            }
            if (isSpawn)
            {
                GameObject obj = poolManager.Get(i + 12);
                //Debug.Log(i + 3);
                if (obj != null)
                {
                    obj.transform.SetParent(itemHolder.transform);
                    obj.SetActive(true);
                }
                else
                {
                    obj = Instantiate(ingredient[i]);
                    obj.transform.SetParent(itemHolder.transform);
                }
            }
        }
    }
    IEnumerator spawn_Garbage()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            yield return new WaitForSeconds(coolTime[2]);
            bool isSpawn = false;
            int temp = Random.Range(0, 100);
            int cur = 0;
            int i;
            for (i = 0; i < garbageSpawnPerCent.Length; i++)
            {
                cur += garbageSpawnPerCent[i].PerCent;
                if (temp < cur)
                {
                    isSpawn = true;
                    break;
                }
            }
            if (isSpawn)
            {
                GameObject obj = poolManager.Get(i + 7);
                if (obj != null)
                {
                    obj.transform.SetParent(itemHolder.transform);
                    obj.SetActive(true);
                }
                else
                {
                    obj = Instantiate(garbage[i]);
                    obj.transform.SetParent(itemHolder.transform);
                }
            }
        }
    }
    IEnumerator spawn_Enemy()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            yield return new WaitForSeconds(coolTime[3]);
            bool isSpawn = false;
            int temp = Random.Range(0,100);
            int cur = 0;
            int i;
            for (i = 0; i < spawnPerCent.Length; i++)
            {
                cur += spawnPerCent[i].PerCent;
                if (temp < cur)
                {
                    isSpawn = true;
                    break;
                }
            }
            if (isSpawn)
            {
                GameObject obj = poolManager.Get(i + 2);
                if (obj != null)
                {
                    obj.transform.SetParent(itemHolder.transform);
                    obj.SetActive(true);
                }
                else
                {
                    obj = Instantiate(Enemy[i]);
                    obj.transform.SetParent(itemHolder.transform);
                }
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
[System.Serializable]
class IngreDientSpawnPerCent
{
    [Header("100분위 확률")] [SerializeField] private int[] perCent;
    public int PerCent { get { return perCent[GameManager.Instance.CurExpLevel]; } set { perCent[GameManager.Instance.CurExpLevel] = value; } }
}
[System.Serializable]
class GarbageSpawnPerCent
{
    [Header("100분위 확률")] [SerializeField] private int[] perCent;
    public int PerCent { get { return perCent[GameManager.Instance.CurExpLevel]; } set { perCent[GameManager.Instance.CurExpLevel] = value; } }
}