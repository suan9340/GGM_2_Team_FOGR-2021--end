using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    int alpha;
    int hp;
    bool isAttacked;
    Vector2 pos;
    [SerializeField] private int maxHp;
    [SerializeField] private int point;
    [SerializeField] private int material;
    [SerializeField] private float heal;
    [SerializeField] private float damage;
    [SerializeField] private bool isEnemy;
    [SerializeField] private Vector4[] Color;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private GameObject particle;
    private void Start()
    {
        hp = maxHp;
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
    public void Dead()
    {
        GameManager.Instance.GetExp(point);
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void GetDamaged(int damage)
    {
        if (!isAttacked)
        {
            StartCoroutine(Check());
            hp -= damage;
            if (isEnemy)
            {
                if(hp < maxHp * 0.25f)
                {
                    renderer.color = Color[3];
                }
                else if(hp < maxHp * 0.5f)
                {
                    renderer.color = Color[2];
                }
                else if(hp < maxHp * 0.75f)
                {
                    renderer.color = Color[1];
                }
                else
                {
                    renderer.color = Color[0];
                }
            }
            if (hp <= 0)
            {
                GameManager.Instance.GetExp(point);
                Dead();
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
    }
}