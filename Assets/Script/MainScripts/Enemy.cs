using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : Item
{
    #region ����
    bool isAttacked;
    private SpriteRenderer renderer;
    protected float curHp;
    #endregion
    #region �ν�����
    [Header("������ ǥ�ÿ� �ؽ�Ʈ")] [SerializeField] private GameObject damageText;
    [Header("���° ������ ǥ�ÿ�")] [SerializeField] private int enemyIndex;
    [Header("���� ����ġ")] [SerializeField] protected Vector3 angle_fix;
    [Header("�ִ� Hp")] [SerializeField] protected float maxHp;
    [Header("����")] [SerializeField] private Color[] ColorArr;
    #endregion
    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.green;
    }
    private void OnEnable() // ������ ���� ���ִ� ��
    {
        base.damage = GameManager.Instance.GetLevel(enemyIndex,1);
        //base.speed = GameManager.Instance.GetLevel(enemyIndex,2);
        curHp = GameManager.Instance.GetLevel(enemyIndex,0);
        maxHp = GameManager.Instance.GetLevel(enemyIndex,0);
        if(renderer != null)
        {
            renderer.color = Color.green;
        }
        SetStartPosition();
    }
    void Update()
    {
        //MoveToZero();
        float angle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0,angle) + angle_fix;
    }
    public void GetDamaged(int damage) // ������ �Ծ��� �� �� �ٲ��ִ� �Լ�
    {
        if (!isAttacked)
        {
            GameObject obj = Instantiate(damageText, new Vector3(transform.position.x,transform.position.y + 3,transform.position.z), Quaternion.identity);
            obj.transform.GetChild(0).GetComponent<TextMesh>().text = string.Format("-{0}", damage);
            curHp -= damage;
            if (curHp < maxHp * 0.25f)
            {
                renderer.color = ColorArr[3];
            }
            else if (curHp < maxHp * 0.5f)
            {
                renderer.color = ColorArr[2];
            }
            else if (curHp < maxHp * 0.75f)
            {
                renderer.color = ColorArr[1];
            }
            else
            {
                renderer.color = ColorArr[0];
            }
            if (curHp <= 0)
            {
                Dead();
            }
        }
        else return;
    }
}