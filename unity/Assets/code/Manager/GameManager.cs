using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public void Start()
    {
        GameStart();
    }
    public void GameStart()
    {
        UnitManager.Instance.LoadPlayer();
    }
    
}
