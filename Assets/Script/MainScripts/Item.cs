using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    #region 변수
    protected Vector2 pos;
    #endregion
    #region 인스펙터
    [Header("획득가능 점수")] [SerializeField] protected int point;
    [Header("획득가능 재료")] [SerializeField] protected int material;
    [Header("획득가능 HP")] [SerializeField] protected float heal;
    [Header("받을수 있는 데미지")] [SerializeField] protected float damage;
    [Header("죽을시 나오는 파티클")] [SerializeField] protected GameObject particle;
    [Header("풀링받을 오브젝트 주소")] [SerializeField] protected int poolIndex;
    [Header("PoolManager")] [SerializeField] protected PoolManager poolManager;
    [Header("중력 속도")] [SerializeField] protected float speed = 3.5f;
    #endregion
    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
    }
    private void OnEnable()
    {
        if (Random.Range(0, 2) == 0)//x가 멀떄
        {
            pos.x = Random.Range(45, 55);
            pos.y = Random.Range(-55, 55);
            if (Random.Range(0, 2) == 0)
            {
                pos.x *= -1;
            }
        }
        else//y가 멀때
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