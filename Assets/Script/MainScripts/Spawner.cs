using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float[] coolTime;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject item_Heal;
    [SerializeField] private GameObject item_Matarial;
    [SerializeField] private GameObject item_Alpha;
    [SerializeField] private GameObject itemHolder;
    [SerializeField] private PoolManager poolManager;
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
    }
}
