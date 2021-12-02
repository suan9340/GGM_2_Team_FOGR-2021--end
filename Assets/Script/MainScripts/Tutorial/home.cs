using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (TutorialManager.Instance.isStory6)
            {
                Debug.Log("원이 작아져");
                Destroy(collision.gameObject);
            }
            else return;
        }

        if (collision.CompareTag("materail"))
        {
            Debug.Log("강화용 재료가 늘어나");
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("trash"))
        {
            Debug.Log("원이 작아져");
            Destroy(collision.gameObject);
        }

    }
}
