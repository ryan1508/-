using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

namespace Project
{
    public abstract class BaseUnit : MonoBehaviour
    {
        [SerializeField] protected Rigidbody rigidbody;
        
        [SerializeField] protected SkeletonMecanim mecanim;
        protected bool IsInitalize { get; set; }
        protected abstract void UnitUpdate();

        protected IUnitState curUnitState;

        protected Dictionary<PlayerState,IUnitState> unitStates;

        protected Dircetion dircetion;
        
        public Animator animator;
        public Rigidbody Rigidbody => rigidbody;
        
        public float Speed;
        
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
                //GetIUnitState(state.State);
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

public enum Dircetion
{
    Left,
    Right,
}

public enum UnitType
{
    Player,
    Boss
}
