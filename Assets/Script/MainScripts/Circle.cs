using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Circle : MonoBehaviour
{
    #region ����
    private int index = 0;
    private float curSpeed;
    private float curHp;
    private float sizeHp;
    private float preHp;
    private bool isOver;
    private bool isEndWait; 
    #endregion
    #region �ν�����
    [Header("�� �پ��� �����ϴ� �ð�")] [SerializeField] private float waitTime;
    [Header("���� ���ư��� �ӵ�")] [SerializeField] private float speed;
    [Header("���� �ִ� hp")] [SerializeField] private float maxHp;
    [Header("�⺻ hp(������ ��)")] [SerializeField] private float startHp;
    [Header("hp �ܰ�(ī�޶� ũ�� ���� ���Ѱ�)")] [SerializeField] private float[] hpLevel;
    [Header("hp �ܰ迡 ���� �����ϴ� ī�޶� ������")] [SerializeField] private float[] cameraSize;
    [Header("����Ŵ���")] [SerializeField] private SoundManager soundManager;
    [Header("�÷��̾ ����ִ� ��")] [SerializeField] private Transform holdTemp;
    [Header("Main ī�޶�")] [SerializeField] private Camera mainCamera;
    [Header("���� ǥ���� ��������Ʈ �迭")] [SerializeField] private Sprite[] buffSprites;
    [Header("���� Ȱ��ȭ �ð�")] [SerializeField] private float[] buffTimes;
    [Header("ũ��� ��� �ʴ����� �迭")] [SerializeField] private int[] expPerSecond;
    #endregion
    void Start()
    {
        GameSetUP();
    }
    void Update()
    {
        CheckInput();
    }
    private void OnCollisionEnter2D(Collision2D collision) // �浹�ҽ� ����Ǵ°�
    {
        if (collision.gameObject.CompareTag("Item"))    //�������Ͻ�
        {
            Item item = collision.gameObject.GetComponent<Item>();
            item.Dead();
        }
        else if (collision.gameObject.CompareTag("Ingredient"))    //���
        {
            Item item = collision.gameObject.GetComponent<Item>();
            GameManager.Instance.Ingredient += item.GetIngredient();
            GameManager.Instance.GetIngredient();
            item.Dead();
        }
        else if (collision.gameObject.CompareTag("Garbage"))   //  ������
        {
            Item item = collision.gameObject.GetComponent<Item>();
            GetDamage(item.GetDamage());
            item.Dead();
        }
        else if (collision.gameObject.CompareTag("Enemy"))   // ��
        {
            Item item = collision.gameObject.GetComponent<Item>();
            item.Dead();
        }
    }
    void GetDamage(float _damage)
    {
        curHp -= _damage;
        GameManager.Instance.CameraManager.ShakeCamera();
    }
    public IEnumerator LerfSize() // ���� ����� ���� 1���� hp�� ����ϴ� �Լ�
    {
        while (true)
        {
            preHp = curHp;
            yield return new WaitForSeconds(1f);
        }
    }
    private IEnumerator CheckLevel() // ���� �����ҿ� ���� ī�޶� ũ�� ���� �����ִ� �ڷ�ƾ �Լ�
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
    public IEnumerator Wait() // ���� ���� ���� �� �پ��� �ð� ��ٸ��� �ڷ�ƾ �Լ�
    {
        yield return new WaitForSeconds(waitTime);
        isEndWait = true;
    }
    public IEnumerator GetScroe()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameManager.Instance.GetExp(expPerSecond[index]);
        }
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
        StartCoroutine(GetScroe());
    }
    private void CheckInput()
    {
        holdTemp.Rotate(Vector3.forward * Time.deltaTime * curSpeed * GameManager.Instance.SpeedUpgradeAmount * GameManager.Instance.SpeedBuffAmount);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            soundManager.Turn();
            curSpeed *= -1;
        }
        if (curHp > 0)
        {
            if (isEndWait)
            {
                curHp -= Time.deltaTime * 1.5f;
            }
        }
        else
        {
            GameOver();
        }
        sizeHp = Mathf.Lerp(preHp, curHp, 1f);
        transform.localScale = new Vector3(sizeHp, sizeHp, 0);
    }
    public void GameOver() // ���� �������� �� �Ҹ��� �Լ�
    {
        if (!isOver)
        {
            isOver = true;
            Time.timeScale = 0;
            GameManager.Instance.UIManager.Over();
        }
    }
    /*public void ChangeSpeed(float value) // �� �ӵ��� ���׷��̵� ������ �� ȣ��Ǵ� �Լ�
    {
        curSpeed = value;
    }*/
    public void Heal(float temp) // ���� Ŀ�� �� ȣ��Ǵ� �Լ�
    {
        curHp += temp;
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
    }
    public void GetIngredient(int get) // ��� ����� �� ȣ��Ǵ� �Լ� 
    {
        GameManager.Instance.Ingredient += get;
        GameManager.Instance.UIManager.UpdateUI();
    }
    public void GetBuff() // �������� ���� �� ��� ������ �����ϴ� �Լ�
    {
        int a = Random.Range(0, 3);
        switch(a)
        {
            case 0:
                GameManager.Instance.UIManager.BuffOn(buffTimes[a], buffSprites[a]);
                break;
            case 1:
                GameManager.Instance.UIManager.BuffOn(buffTimes[a], buffSprites[a]);
                break;
            case 2:
                GameManager.Instance.UIManager.BuffOn(buffTimes[a], buffSprites[a]);
                break;
            default:
                Debug.Log("���� �̻�");
                break;
        }
    }
    public void ChangeSize()
    {
        mainCamera.orthographicSize = cameraSize[index];
    }
}
