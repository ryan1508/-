using System.Collections;
using System.Collections.Generic;
using Project;
using SKUnityToolkit.SerializableDictionary;
using UnityEngine;

public class Player : BaseUnit
{
    public override UnitType BaseUnitType => UnitType.Player;
    public float inPutX { get; set; }
    public float inPutZ { get; set; }
    //공격 중인 상태 
    public bool IsAttack { get; set; }
    public PlayerData playerData => DataManager.Instance.playerData;
    
    [SerializeField] private SerializableDictionary<PlayerAttackType, BoxCollider> attackBoxColl;
    
    public override void Init()
    {
        base.Init();
        unitStates = new Dictionary<PlayerState, IUnitState>();
        
        unitStates.Add(PlayerState.IDLE,new IdleState());
        unitStates.Add(PlayerState.ATTAK,new AttackState());
        unitStates.Add(PlayerState.RUN,new RunState());
        unitStates.Add(PlayerState.WALK,new IWalkState());
        
        curUnitState = unitStates[PlayerState.IDLE];
    }

    protected override void UnitUpdate()
    {
        // -1 ~ 1
        UpdateHorizonAndVerticalInput();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(PlayerState.ATTAK);
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

    public BoxCollider GetAttackBoxCollider(PlayerAttackType attType)
    {
        if (attackBoxColl.ContainsKey(attType) == false)
        {
            Debug.LogError($"{attType} 콜라이더 없음.");
        }

        return attackBoxColl[attType];
    }

    public void SetBoxCollider(PlayerAttackType attType,bool isEnable)
    {
        foreach (var t in attackBoxColl.Keys)
        {
            if (t != attType)
            {
                attackBoxColl[t].enabled = false;
            }
            else
            {
                attackBoxColl[t].enabled = isEnable;
            }
        }
    }
}
