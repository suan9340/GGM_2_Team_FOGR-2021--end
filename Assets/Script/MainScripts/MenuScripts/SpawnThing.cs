using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThing : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void Start() {
        switch (Random.Range(0, 10))
        {
            case 0:
                anim.Play("0");
                break;
            case 1:
                anim.Play("1");
                break;
            case 2:
                anim.Play("2");
                break;
            case 3:
                anim.Play("3");
                break;
            case 4:
                anim.Play("4");
                break;
            case 5:
                anim.Play("5");
                break;
            case 6:
                anim.Play("6");
                break;
            case 7:
                anim.Play("7");
                break;
            case 8:
                anim.Play("8");
                break;
            case 9:
                anim.Play("9");
                break;
        }
    }
}
