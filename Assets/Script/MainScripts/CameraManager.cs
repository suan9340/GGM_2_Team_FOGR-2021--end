using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    bool isRunning;
    bool isEnd;
    Vector3 originalPos;
    [Header("Èçµé¸®´Â Èû")] [SerializeField] private float ShakeForce;
    [Header("Èçµé¸®´Â ½Ã°£")] [SerializeField] private float ShakeTime;
    public void Start()
    {
        originalPos = transform.position;
    }
    public void ShakeCamera(float force , float time)
    {
        StartCoroutine(Shake(force , time));
    }
    IEnumerator Shake(float force, float time)
    {
        isEnd = false;
        isRunning = true;
        yield return new WaitForSeconds(time);
        isRunning = false;
    }
    public void Update()
    {
        if (isRunning)
        {
            transform.position = Random.insideUnitSphere * ShakeForce + originalPos;
        }
        else if(!isEnd)
        {
            transform.position = originalPos;
            isEnd = true;
        }
    }
}