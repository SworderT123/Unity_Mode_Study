using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 使用工厂模式统一管理所有状态的实例化逻辑
public static class StateFactory
{
    // 返回实例化的状态类
    public static StateBase CreateFactory(StateType stateType, IStateContext context)
    {
        return stateType switch
        {
            StateType.IDLE => new IdleState(context),
            StateType.MOVE => new MoveState(context),
            // ...
            _ => throw new System.ArgumentException("Invalid state type.")
        };
    }
}
