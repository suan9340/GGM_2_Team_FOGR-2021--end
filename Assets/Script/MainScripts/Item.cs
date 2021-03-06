using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    #region 인스펙터
    [Header("획득가능 재료")] [SerializeField] protected int ingredient;
    [Header("획득가능 HP")] [SerializeField] protected float heal;
    [Header("받을수 있는 데미지")] [SerializeField] protected float damage;
    [Header("죽을시 나오는 파티클")] [SerializeField] protected GameObject particle;
    [Header("풀링받을 오브젝트 주소")] [SerializeField] protected int poolIndex;
    [Header("PoolManager")] [SerializeField] protected PoolManager poolManager;
    //[Header("중력 속도")] [SerializeField] protected float speed = 3.5f;
    #endregion
    #region GetSet 함수
    
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
        if (Random.Range(0, 2) == 0)//x가 멀떄
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
        else//y가 멀때
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