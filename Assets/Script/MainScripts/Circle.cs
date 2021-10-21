using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Circle : MonoBehaviour
{
    [SerializeField] private float curSpeed;
    float preHp;
    float nowHp;
    private int score;
    private int spriteIndex;
    private int index = 0;
    private float curHp;
    private float sizeHp;
    private int matarial;
    [SerializeField] private Text scoreText;
    [SerializeField] private int[] SPS;
    [SerializeField] private Transform holdTemp;
    [SerializeField] private SpriteRenderer[] sprites;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Camera camera;
    [SerializeField] private Text matarialText;
    [SerializeField] private float speed;
    [SerializeField] private float maxHp;
    [SerializeField] private float startHp;
    [SerializeField] private float[] hpLevel;
    [SerializeField] private float[] cameraSize;
    [SerializeField] private SoundManager sound;
    void Start()
    {
        curSpeed = speed;
        preHp = curHp;
        curHp = startHp;
        sizeHp = curHp;
        StartCoroutine(CheckLevel());
        StartCoroutine(AddScore());
    }
    void Update()
    {
        holdTemp.Rotate(Vector3.forward * Time.deltaTime * curSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sound.Turn();
            curSpeed *= -1;
        }
        if (curHp > 0)
        {
            curHp -= Time.deltaTime * 0.5f;
        }
        sizeHp = Mathf.Lerp(preHp, curHp, 1f);
        transform.localScale = new Vector3(sizeHp, sizeHp, 1);
    }
    public void ChangeSpeed(float value)
    {
        curSpeed = value;
    }
    public void Heal(float temp)
    {
        preHp = curHp;
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
    public void ChangeSpeed(int change)
    {
        curSpeed = change;
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
    private IEnumerator AddScore()
    {
        while (true)
        {
            score += SPS[index];
            scoreText.text = string.Format("Score : {0}", score);
            yield return new WaitForSeconds(1f);
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
    public void ChangeSpeed()
    {

    }
}
