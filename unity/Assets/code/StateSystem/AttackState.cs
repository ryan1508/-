using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;

public class AttackState : IUnitState
{
    public void Stop(BaseUnit unit)
    {
        
    }

    public void Execute(BaseUnit unit)
    {
        //unit.ChangeState(this);
        //unit.animator.SetBool("walk", false);
    }

    public IUnitState GetState()
    {
        return this;
    }

    public void PrintCurrState()
    {
        Debug.Log("공격 중이에요~");
    }
    
    public bool isRunning { get; set; }
    public PlayerState State => PlayerState.ATTAK1;
}
