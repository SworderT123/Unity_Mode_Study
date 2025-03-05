using UnityEngine;

// 处于每个状态时，需要执行的函数
public abstract class StateBase
{
    /// <summary>
    /// 进入当前状态的第一帧播放的方法（第一次进入状态）
    /// </summary>
    public abstract void OnEnter()
    /// <summary>
    /// 在当前状态的每一帧播放的方法
    /// </summary>
    public abstract void OnUpdate()
    /// <summary>
    /// 离开当前状态的最后一帧播放的方法
    /// </summary>
    public abstract void OnExit()
}