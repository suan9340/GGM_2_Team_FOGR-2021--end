using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Circle : MonoBehaviour
{
    #region 변수
    private int index = 0;
    private float curSpeed;
    private float curHp;
    private float sizeHp;
    private float preHp;
    private bool isOver;
    private bool isEndWait; 
    #endregion
    #region 인스펙터
    [Header("원 줄어들기 시작하는 시간")] [SerializeField] private float waitTime;
    [Header("원이 돌아가는 속도")] [SerializeField] private float speed;
    [Header("원의 최대 hp")] [SerializeField] private float maxHp;
    [Header("기본 hp(시작할 때)")] [SerializeField] private float startHp;
    [Header("hp 단계(카메라 크기 조정 위한것)")] [SerializeField] private float[] hpLevel;
    [Header("hp 단계에 따라서 대응하는 카메라 사이즈")] [SerializeField] private float[] cameraSize;
    [Header("사운드매니저")] [SerializeField] private SoundManager sound;
    [Header("플레이어를 잡아주는 것")] [SerializeField] private Transform holdTemp;
    [Header("Main 카메라")] [SerializeField] private Camera camera;
    #endregion
    void Start()
    {
        GameSetUP();
    }
    void Update()
    {
        KeyInPut();
    }

    private void GameSetUP()
    {
        curSpeed = speed;
        preHp = curHp;
        curHp = startHp;
        sizeHp = curHp;
        StartCoroutine(Wait());
        StartCoroutine(CheckLevel());
        StartCoroutine(LerfSize());
    }

    private void KeyInPut()
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
    // 게임 시작 전에 원 줄어드는 시간 기다리는 코루틴 함수
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        isEndWait = true;
    }

    // 게임 오버됬을 때 불리는 함수
    public void GameOver()
    {
        if (!isOver)
        {
            isOver = true;
            Time.timeScale = 0;
            GameManager.Instance.UIManager.Over();
        }
    }

    // 원 속도를 업그레이드 해줬을 때 호출되는 함수
    public void ChangeSpeed(float value)
    {
        curSpeed = value;
    }

    // 원이 커질 때 호출되는 함수
    public void Heal(float temp)
    {
        curHp += temp;
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
    }

    // UI업데이트
    public void UpdateUI()
    {
    }

    // 재료 얻었을 때 호출되는 함수 
    public void GetMaterial(int get)
    {
        GameManager.Instance.Matarial += get;
        GameManager.Instance.UIManager.UpdateUI();
    }

    // 아이템을 공격 시 얻는 버프를 실행하는 함수
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

    // Dummy 
    public void ChangeSpeed(int change)
    {
        curSpeed = change;
    }

    // 충돌할시 실행되는것
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))    //아이템일시
        {
            Item item = collision.gameObject.GetComponent<Item>();
            item.Dead();
        }
        if (collision.gameObject.CompareTag("Material"))    //재료
        {
            Item item = collision.gameObject.GetComponent<Item>();  
            GameManager.Instance.Matarial += item.GetMaterial();
            UpdateUI();
            item.Dead();
        }
        if (collision.gameObject.CompareTag("Alpha"))   //  쓰레기
        {
            Item item = collision.gameObject.GetComponent<Item>();
            item.Dead();
            Heal(item.GetDamage());
        }
        if (collision.gameObject.CompareTag("Enemy"))   // 적
        {
            Item item = collision.gameObject.GetComponent<Item>();
            Heal(-item.GetDamage());
            item.Dead();
        }
    }

    // 원의 증감소에 따라 카메라 크기 비율 맞춰주는 코루틴 함수
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

    public void ChangeSize()
    {
        camera.orthographicSize = cameraSize[index];
    }

    // 러프 사이즈를 위해 1초전 hp를 기억하는 함수
    public IEnumerator LerfSize()
    {
        while (true)
        {
            preHp = curHp;
            yield return new WaitForSeconds(1f);
        }
    }
}
