using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public abstract class BaseUnit : MonoBehaviour
    {
        [SerializeField] protected float Speed;

        [SerializeField] protected Rigidbody rigidbody;
        protected bool IsInitalize { get; set; }
        protected abstract void UnitUpdate();

        protected IUnitState curUnitState;

        protected Dictionary<PlayerState,IUnitState> unitStates;
        
        public Animator animator;

        public virtual UnitType BaseUnitType { get; set; }
        //public Dictionary<PlayerState,IUnitState> UnitStates => unitStates;
        public bool isMoveing { get; set; }
        public virtual void Init()
        {
            IsInitalize = true;
        }
        public void Update()
        {
            if(IsInitalize)
                UnitUpdate();
        }

        public IUnitState GetIUnitState(PlayerState playerState)
        {
            if (unitStates.ContainsKey(playerState) == false)
            {
                Debug.LogError($"{playerState}가 등록 되어있지 않습니다.");
            }

            return unitStates[playerState];
        }

        public void ChangeState(IUnitState state)
        {
            if (BaseUnitType == UnitType.Player)
            {
                GetIUnitState(state.State);
            }
            else
            {
                
            }

            curUnitState = state;
        }
    }
}

public enum PlayerState
{
    IDLE,
    WALK,
    ATTAK1,
    ATTAK2,
    ATTAK3,
    RUN,
}

public enum BossState
{
            
}

public enum UnitType
{
    Player,
    Boss
}
