using System;
using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;

public class AttackState : IUnitState
{
    private PlayerAttackType _attackType;
    private int attackCount;
    public void Stop(BaseUnit unit)
    {
        
    }

    public void Execute(BaseUnit unit)
    {
        if (unit.BaseUnitType == UnitType.Player)
        {
            var p = unit as Player;
            
            if (attackCount >= p.playerData.AttackMaxCombo)
                attackCount = 0;
            
            ChangePlayerAttackCombo(p );
            attackCount++;
            
        }
    }

    public void ChangePlayerAttackCombo(Player unit)
    {
        if (unit.BaseUnitType == UnitType.Player)
        {
            _attackType = (PlayerAttackType) attackCount;
            var player = (Player) unit;
            player.SetBoxCollider(_attackType,true);
            unit.animator.SetBool(_attackType.ToString(), true);
        }

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
    public PlayerState State => PlayerState.ATTAK;
}
