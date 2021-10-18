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
            Instantiate(item_Heal);
        }
    }
    IEnumerator spawn_Matarial()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime[1]);
            Instantiate(item_Matarial);
        }
    }
    IEnumerator spawn_Alpha()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime[2]);
            Instantiate(item_Alpha);
        }
    }
    IEnumerator spawn_Enemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime[3]);
            Instantiate(Enemy);
        }
    }
}
