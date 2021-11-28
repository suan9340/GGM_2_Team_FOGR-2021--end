using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Info", menuName = "Enemy")]
public class EnemyInfo : ScriptableObject
{
    public string name = "Default";
    public string desc = "This is Default Enemy";
    public Sprite sprite;
}
