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
                Debug.Log("���� �۾���");
                Destroy(collision.gameObject);
            }
            else return;
        }

        if (collision.CompareTag("materail"))
        {
            Debug.Log("��ȭ�� ��ᰡ �þ");
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("trash"))
        {
            Debug.Log("���� �۾���");
            Destroy(collision.gameObject);
        }

    }
}
