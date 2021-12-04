using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    #region �ν�����
    [Header("ȹ�氡�� ���")] [SerializeField] protected int ingredient;
    [Header("ȹ�氡�� HP")] [SerializeField] protected float heal;
    [Header("������ �ִ� ������")] [SerializeField] protected float damage;
    [Header("������ ������ ��ƼŬ")] [SerializeField] protected GameObject particle;
    [Header("Ǯ������ ������Ʈ �ּ�")] [SerializeField] protected int poolIndex;
    [Header("PoolManager")] [SerializeField] protected PoolManager poolManager;
    //[Header("�߷� �ӵ�")] [SerializeField] protected float speed = 3.5f;
    #endregion
    #region GetSet �Լ�
    
    #endregion
    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
    }
    private void OnEnable()
    {
        SetStartPosition();
    }
    void Update()
    {
        //MoveToZero();
    }
    protected void MoveToZero()
    {
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), speed * Time.deltaTime);
    }
    protected void SetStartPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (Random.Range(0, 2) == 0)//x�� �֋�
        {
            int temp = Random.Range(0, 2);
            if(temp == 0)
            {
                pos.x = 0;
            }
            else
            {
                pos.x = 1;
            }
        }
        else//y�� �ֶ�
        {
            int temp = Random.Range(0, 2);
            if (temp == 0)
            {
                pos.y = 0;
            }
            else
            {
                pos.y = 1;
            }
        }
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        float angle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0,angle - 90);
    }
    public void SetPositionByCall(Vector3 pos)
    {
        transform.position = pos;
    }
    public void Dead()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        transform.SetParent(poolManager.Instance(poolIndex));
    }
    public float GetHeal() { return heal; }
    public float GetDamage() { return damage; }
    public int GetIngredient() { return ingredient; }
}