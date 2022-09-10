using Project;
using UnityEngine;

public interface IUnitState
{
    void Stop(BaseUnit unit);
    void Execute(BaseUnit unit);
    IUnitState GetState();
    void PrintCurrState();
    bool isRunning { get; set; }
    PlayerState State { get; }
    //BossState _bossState { get; }
}
