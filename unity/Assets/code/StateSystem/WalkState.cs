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
            var player = (Player) unit;
            Vector3 velocity = new Vector3(player.inPutX, 0, player.inPutZ);
            velocity *= unit.Speed;
            unit.Rigidbody.velocity = velocity;

            unit.animator.SetBool("Walk", true);
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