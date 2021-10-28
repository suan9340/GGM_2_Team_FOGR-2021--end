using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    #region ����
    protected Vector2 pos;
    #endregion
    #region �ν�����
    [Header("ȹ�氡�� ����")] [SerializeField] protected int point;
    [Header("ȹ�氡�� ���")] [SerializeField] protected int material;
    [Header("ȹ�氡�� HP")] [SerializeField] protected float heal;
    [Header("������ �ִ� ������")] [SerializeField] protected float damage;
    [Header("������ ������ ��ƼŬ")] [SerializeField] protected GameObject particle;
    [Header("Ǯ������ ������Ʈ �ּ�")] [SerializeField] protected int poolIndex;
    [Header("PoolManager")] [SerializeField] protected PoolManager poolManager;
    [Header("�߷� �ӵ�")] [SerializeField] protected float speed = 3.5f;
    #endregion
    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
    }
    private void OnEnable()
    {
        if (Random.Range(0, 2) == 0)//x�� �֋�
        {
            pos.x = Random.Range(45, 55);
            pos.y = Random.Range(-55, 55);
            if (Random.Range(0, 2) == 0)
            {
                pos.x *= -1;
            }
        }
        else//y�� �ֶ�
        {
            pos.y = Random.Range(45, 55); ;
            pos.x = Random.Range(-55, 55);
            if (Random.Range(0, 2) == 0)
            {
                pos.y *= -1;
            }
        }
        transform.position = pos;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), speed * Time.deltaTime);
    }
    public void Dead()
    {
        GameManager.Instance.GetExp(point);
        Instantiate(particle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        transform.SetParent(poolManager.Instance(poolIndex));
    }
    public float GetHeal()
    {
        return heal;
    }
    public float GetDamage()
    {
        return damage;
    }
    public int GetMaterial()
    {
        return material;
    }
}