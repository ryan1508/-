using System;
using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;


public class UnitManager : MonoBehaviourSingleton<UnitManager>
{
    [SerializeField] private SerializableDictionary<string, GameObject> unitPool;
    [SerializeField] private Transform trChild;
    public void SpawnPlayer()
    {
        var gm =Instantiate(unitPool["Player"]);
        gm.transform.SetParent(trChild);
        
        var player = gm.GetComponent<BaseUnit>();
        player.Init();
    }
}
