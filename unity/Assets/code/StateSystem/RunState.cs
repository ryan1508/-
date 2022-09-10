using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;

public class RunState : IUnitState
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
        Debug.Log("뛰고 있어요~");
    }
    
    public bool isRunning { get; set; }
    public PlayerState State => PlayerState.RUN;
}