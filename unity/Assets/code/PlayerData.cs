using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData",menuName = "ScriptableObject/Data",order = 1)]
public class PlayerData : ScriptableObject
{
    //public static string Name;
    public int AttackMaxCombo;
    public int Speed;
}
