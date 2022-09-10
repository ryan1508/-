using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;

public class IdleState : IUnitState
{
    public PlayerState State => PlayerState.IDLE;
    
    public void Stop(BaseUnit unit)
    {
        //unit.animator.SetBool("walk", false);
    }

    public void Execute(BaseUnit unit)
    {
        if (unit.BaseUnitType == UnitType.Player)
        {
            unit.animator.SetBool("Walk", false);
            //unit.ChangeState(this);
        }
    }

    public IUnitState GetState()
    {
        return this;
    }

    public void PrintCurrState()
    {
        Debug.Log("IDLE");
    }
    public bool isRunning { get; set; }
}
