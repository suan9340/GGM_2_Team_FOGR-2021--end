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
    [Header("����Ŵ���")] [SerializeField] private SoundManager sound;
    [Header("�÷��̾ ����ִ� ��")] [SerializeField] private Transform holdTemp;
    [Header("Main ī�޶�")] [SerializeField] private Camera camera;
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
    // ���� ���� ���� �� �پ��� �ð� ��ٸ��� �ڷ�ƾ �Լ�
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        isEndWait = true;
    }

    // ���� �������� �� �Ҹ��� �Լ�
    public void GameOver()
    {
        if (!isOver)
        {
            isOver = true;
            Time.timeScale = 0;
            GameManager.Instance.UIManager.Over();
        }
    }

    // �� �ӵ��� ���׷��̵� ������ �� ȣ��Ǵ� �Լ�
    public void ChangeSpeed(float value)
    {
        curSpeed = value;
    }

    // ���� Ŀ�� �� ȣ��Ǵ� �Լ�
    public void Heal(float temp)
    {
        curHp += temp;
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
    }

    // UI������Ʈ
    public void UpdateUI()
    {
    }

    // ��� ����� �� ȣ��Ǵ� �Լ� 
    public void GetMaterial(int get)
    {
        GameManager.Instance.Matarial += get;
        GameManager.Instance.UIManager.UpdateUI();
    }

    // �������� ���� �� ��� ������ �����ϴ� �Լ�
    public void GetBuff()
    {
        int a = Random.Range(0, 3);
        switch(a)
        {
            case 0:
                Debug.Log("1�� ���� ��");
                break;
            case 1:
                Debug.Log("2�� ���� ��");
                break;
            case 2:
                Debug.Log("3�� ���� ��");
                break;
            default:
                Debug.Log("���� �̻�");
                break;
        }
    }

    // Dummy 
    public void ChangeSpeed(int change)
    {
        curSpeed = change;
    }

    // �浹�ҽ� ����Ǵ°�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))    //�������Ͻ�
        {
            Item item = collision.gameObject.GetComponent<Item>();
            item.Dead();
        }
        if (collision.gameObject.CompareTag("Material"))    //���
        {
            Item item = collision.gameObject.GetComponent<Item>();  
            GameManager.Instance.Matarial += item.GetMaterial();
            UpdateUI();
            item.Dead();
        }
        if (collision.gameObject.CompareTag("Alpha"))   //  ������
        {
            Item item = collision.gameObject.GetComponent<Item>();
            item.Dead();
            Heal(item.GetDamage());
        }
        if (collision.gameObject.CompareTag("Enemy"))   // ��
        {
            Item item = collision.gameObject.GetComponent<Item>();
            Heal(-item.GetDamage());
            item.Dead();
        }
    }

    // ���� �����ҿ� ���� ī�޶� ũ�� ���� �����ִ� �ڷ�ƾ �Լ�
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

    // ���� ����� ���� 1���� hp�� ����ϴ� �Լ�
    public IEnumerator LerfSize()
    {
        while (true)
        {
            preHp = curHp;
            yield return new WaitForSeconds(1f);
        }
    }
}
