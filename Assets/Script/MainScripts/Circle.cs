using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Circle : MonoBehaviour
{
    private int spriteIndex;
    private int index = 0;
    private float curHp;
    private int matarial;
    [SerializeField] private SpriteRenderer[] sprites;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Camera camera;
    [SerializeField] private Text matarialText;
    [SerializeField] private float maxHp;
    [SerializeField] private float startHp;
    [SerializeField] private float[] hpLevel;
    [SerializeField] private float[] cameraSize;
    void Start()
    {
        curHp = startHp;
        StartCoroutine(CheckLevel());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 50);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * 50);
        }
        if (curHp > 0)
        {
            curHp -= Time.deltaTime;
        }
        transform.localScale = new Vector3(curHp, curHp, 1);
    }
    private void Heal(float temp)
    {
        curHp += temp;
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
    }
    public void UpdateUI()
    {
        matarialText.text = string.Format("Àç·á : {0}",matarial);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Heal(collision.gameObject.GetComponent<Item>().GetHeal());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Material"))
        {
            UpdateUI();
            matarial += collision.gameObject.GetComponent<Item>().GetMaterial();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Alpha"))
        {
            UpdateUI();
            ChangeSprite(collision.gameObject.GetComponent<Item>().GetSprite());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            UpdateUI();
            Heal(-collision.gameObject.GetComponent<Item>().GetDamage());
            Destroy(collision.gameObject);
        }
    }
    private IEnumerator CheckLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (hpLevel[index] < curHp)
            {
                index++;
                ChangeSize();
            }
            if (hpLevel[index] > curHp && index > 1)
            {
                index--;
                ChangeSize();
            }
        }
    }
    public void ChangeSize()
    {
        camera.orthographicSize = cameraSize[index];
    }
    public void ChangeSprite(int beta)
    {
        if(spriteIndex < 4)
        {
            sprites[spriteIndex].sprite = sprite[beta];
            spriteIndex++;
        }
        else
        {
            return;
        }
    }
}
