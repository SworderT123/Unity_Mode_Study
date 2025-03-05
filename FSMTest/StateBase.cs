using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase // 用于实现每个动画状态的方法
{
    /// <summary>
    /// 第一次进入该状态时执行
    /// </summary>
    public abstract void OnEnter();
    /// <summary>
    /// 在该状态时执行
    /// </summary>
    public abstract void OnUpdate();
    /// <summary>
    /// 离开该状态时执行
    /// </summary>
    public abstract void OnExit();
}
