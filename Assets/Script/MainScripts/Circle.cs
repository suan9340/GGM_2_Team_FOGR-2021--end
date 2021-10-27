using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Circle : MonoBehaviour
{
    private int score;
    private int spriteIndex;
    private int index = 0;
    private int matarial;
    public float curHp;
    public float sizeHp;
    public float preHp;
    private bool isOver;
    private bool isEndWait;
    [SerializeField] private int[] SPS;
    [SerializeField] private float waitTime;
    [SerializeField] private float curSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float maxHp;
    [SerializeField] private float startHp;
    [SerializeField] private float[] hpLevel;
    [SerializeField] private float[] cameraSize;
    [SerializeField] private Text matarialText;
    [SerializeField] private Text scoreText;
    [SerializeField] private SoundManager sound;
    [SerializeField] private GameObject overPannel;
    [SerializeField] private Transform holdTemp;
    [SerializeField] private SpriteRenderer[] sprites;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Camera camera;
    void Start()
    {
        curSpeed = speed;
        preHp = curHp;
        curHp = startHp;
        sizeHp = curHp;
        StartCoroutine(Wait());
        StartCoroutine(CheckLevel());
        StartCoroutine(AddScore());
        StartCoroutine(LerfSize());
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
            if (isEndWait)
            {
                curHp -= Time.deltaTime * 0.5f;
            }
        }
        else
        {
            GameOver();
        }
        sizeHp = Mathf.Lerp(preHp, curHp, 1f);
        transform.localScale = new Vector3(sizeHp, sizeHp, 0);
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        isEndWait = true;
    }
    public void GameOver()
    {
        if (!isOver)
        {
            isOver = true;
            Time.timeScale = 0;
            overPannel.SetActive(true);
        }
    }
    public void ChangeSpeed(float value)
    {
        curSpeed = value;
    }
    public void Heal(float temp)
    {
        curHp += temp;
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
    }
    public void UpdateUI()
    {
        matarialText.text = string.Format("재료 : {0}",matarial);
    }
    public void GetMaterial(int get)
    {
        matarial += get;
        UpdateUI();
    }
    public void GetBuff()
    {
        int a = Random.Range(0, 3);
        switch(a)
        {
            case 0:
                Debug.Log("1번 버프 온");
                break;
            case 1:
                Debug.Log("2번 버프 온");
                break;
            case 2:
                Debug.Log("3번 버프 온");
                break;
            default:
                Debug.Log("범위 이상");
                break;
        }
    }
    public void ChangeSpeed(int change)
    {
        curSpeed = change;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Item item = collision.gameObject.GetComponent<Item>();
            item.Dead();
        }
        if (collision.gameObject.CompareTag("Material"))
        {
            Item item = collision.gameObject.GetComponent<Item>();
            matarial += item.GetMaterial();
            item.Dead();
            UpdateUI();
        }
        if (collision.gameObject.CompareTag("Alpha"))
        {
            Item item = collision.gameObject.GetComponent<Item>();
            item.Dead();
            Heal(item.GetDamage());
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Item item = collision.gameObject.GetComponent<Item>();
            Heal(-item.GetDamage());
            item.Dead();
        }
    }
    private IEnumerator CheckLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
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
    public IEnumerator LerfSize()
    {
        while (true)
        {
            preHp = curHp;
            yield return new WaitForSeconds(1f);
        }
    }
    public void ChangeSpeed()
    {

    }
}
