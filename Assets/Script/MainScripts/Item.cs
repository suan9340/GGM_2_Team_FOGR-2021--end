using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    Vector2 pos;
    private int alpha;
    bool isAttacked;
    [SerializeField] private int hp;
    [SerializeField] private int material;
    [SerializeField] private float heal;
    [SerializeField] private float damage;
    [SerializeField] private int point;
    private void Start()
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
            pos.y = Random.Range(45, 55);;
            pos.x = Random.Range(-55, 55);
            if (Random.Range(0, 2) == 0)
            {
                pos.y *= -1;
            }
        }
        transform.position = pos;
        alpha = Random.Range(0, 3);
    }
    private void OnDestroy()
    {
        GameManager.Instance.GetExp(point);
    }
    public void GetDamaged(int damage)
    {
        if (!isAttacked)
        {
            StartCoroutine(Check());
            hp -= damage;
            if (hp <= 0)
            {
                GameManager.Instance.GetExp(point);
                Destroy(gameObject);
            }
        }
        else return;
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
    public int GetSprite()
    {
        return alpha;
    }
    public IEnumerator Check()
    {
        isAttacked = true;
        yield return new WaitForSeconds(1f);
        isAttacked = false;
        //transform.gameObject.transform.gameObject.transform.gameObject.transform.gameObject.GetComponent<Transform>().position = transform.gameObject.transform.position;
    }
}