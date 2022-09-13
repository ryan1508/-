using System;
using System.Collections;
using System.Collections.Generic;
using Project;
using SKUnityToolkit.SerializableDictionary;
using UnityEngine;


public class UnitManager : MonoBehaviourSingleton<UnitManager>
{
    [SerializeField] private SerializableDictionary<UnitType, GameObject> unitPool;
    [SerializeField] private Transform trChild;
    public void LoadPlayer()
    {
        var gm =Instantiate(unitPool[UnitType.Player]);
        gm.transform.SetParent(trChild);
        
        var player = gm.GetComponent<BaseUnit>();
        player.Init();
    }
}
