using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;

public class WalkState : IUnitState
{
    public void Stop(BaseUnit unit)
    {
        
    }

    public void Execute(BaseUnit unit)
    {
        if (unit.BaseUnitType == UnitType.Player)
        {
            unit.animator.SetBool("Walk", true);
            //unit.ChangeState(this);
        }
    }

    public IUnitState GetState()
    {
        return this;
    }

    public void PrintCurrState()
    {
        Debug.Log("걷고 있는 중이에요~");
    }
    
    public bool isRunning { get; set; }
    public PlayerState State => PlayerState.WALK;
}