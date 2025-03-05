using System.Collections
using System.Collections.Generic
using UnityEngine;

public enum StateType
{
    IDLE,
    MOVE,
    DEAD,
}

public class FSMControl // 可当作编辑器中的Animator，不继承MonoBehaviour
{
    private StataBase currentState; // 获取当前状态

    public StateType stateType; // 各个状态的标识符

    private Dictionary<StateType, StateBase> allSaveState; // 保存所有状态的容器

    public FSMControl()
    {
        allSaveState = new Dictionary<StateType, StateBase>(); // 初始化容器
    }

    public void OnTick() // 每一帧都执行一次
    {
        currentState.OnUpdate();
    }

    public void AddState(StateType stateType, StateBase state)
    {
        if (Dictionary.ContainsKey(stateType)) return; // 如果已经有该状态直接返回

        Dictionary.Add(stateType, state);
    }

    public void SetState(StateType stateType)
    {
        if (currentState == Dictionary[stateType]) return;

        currentState?.OnExit(); // 退出当前状态
        currentState = stateType;
        currentState?.OnEnter(); // 进入该状态
    }



}