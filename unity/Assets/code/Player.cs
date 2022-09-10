using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;

public class Player : BaseUnit
{
    public override UnitType BaseUnitType => UnitType.Player;
    public override void Init()
    {
        base.Init();
        unitStates = new Dictionary<PlayerState, IUnitState>();
        
        unitStates.Add(PlayerState.IDLE,new IdleState());
        unitStates.Add(PlayerState.ATTAK1,new AttackState());
        unitStates.Add(PlayerState.RUN,new RunState());
        unitStates.Add(PlayerState.WALK,new WalkState());
        
        curUnitState = unitStates[PlayerState.IDLE];
    }

    protected override void UnitUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        // -1 ~ 1
        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= Speed;
        rigidbody.velocity = velocity;
        
        if(inputX == 0 && inputZ == 0)
            Idle();
        else
            Move();
        
        curUnitState.Execute(this);
    }
    
    private void UpdateKeyInput()
    {
        
    }

    private void Move()
    {
        var walkState = unitStates[PlayerState.WALK];
        ChangeState(walkState);
    }

    private void Idle()
    {
        var walkState = unitStates[PlayerState.IDLE];
        ChangeState(walkState);
    }

    private void Attack()
    {
        
    }

    private void Run()
    {
        
    }
}
