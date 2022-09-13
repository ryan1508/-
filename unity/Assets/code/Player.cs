using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;

public class Player : BaseUnit
{
    public override UnitType BaseUnitType => UnitType.Player;

    public float inPutX { get; set; }

    public float inPutZ { get; set; }
    
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
        // -1 ~ 1
        UpdateHorizonAndVerticalInput();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(PlayerState.ATTAK1);
        }
        
        
        curUnitState.Execute(this);
    }
    
    private void UpdateHorizonAndVerticalInput()
    {
        inPutX = Input.GetAxisRaw("Horizontal");
        inPutZ = Input.GetAxisRaw("Vertical");

        if (inPutX == 0 && inPutZ == 0)
        {
            ChangeState(PlayerState.IDLE);
        }
        else
        {
            ChangeState(PlayerState.WALK);
            SetFlipX();
        }
    }

    private void SetFlipX()
    {
        var x = inPutX > 0 ? 1 : -1;
        mecanim.Skeleton.ScaleX = x;
    }
    private void ChangeState(PlayerState playerState)
    {
        var unitState = unitStates[playerState];
        ChangeState(unitState);
    }
}
