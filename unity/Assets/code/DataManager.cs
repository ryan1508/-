using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "DataManager",menuName = "ScriptableObject/Manager",order = 1)]
public class DataManager : SingletonScriptableObject<DataManager>
{
    [SerializeField] public PlayerData playerData;
}
