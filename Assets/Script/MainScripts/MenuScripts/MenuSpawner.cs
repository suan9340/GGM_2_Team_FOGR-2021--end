using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] menuSpawnThing;
    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 5));
            GameObject obj = Instantiate(menuSpawnThing[Random.Range(0,menuSpawnThing.Length)],transform.position,Quaternion.identity);
        }
    }
}
