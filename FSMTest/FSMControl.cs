using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 使用接口，避免状态与状态机双向依赖，实现解耦
// 高层模块（状态类）不应依赖底层模块（状态机），两者都应依赖抽象（接口）-- 依赖倒置原则DIP
public interface IStateContext
{
    Animator animator { get; } // 当状态需要得到该组件时可以直接通过接口访问

    void RequestStateChange(StateType newState);
}

public enum StateType
{
    IDLE,
    MOVE,
}

// 有限状态机，可以看成Animator
// 住：所有 MonoBehaviour 的子类不能通过 new 创建
public class FSMControl : IStateContext // 状态机实现该接口
{
    private StateType stateType; // 记录当前状态的标识符

    private StateBase currentState; // 当前状态

    private Dictionary<StateType, StateBase> allSaveState; // 取得当前状态机的所有状态

    public Animator animator { get; private set; } // 获得Animator组件

    public void RequestStateChange(StateType newState)
    {
        SetState(newState);
    }

    public FSMControl(Animator animator)
    {
        allSaveState = new Dictionary<StateType, StateBase>(); // 初始化容器

        this.animator = animator;

        InitializeState();
        // 首次运行进入的状态
        SetInitState(StateType.IDLE);
    }

    private void InitializeState()
    {
        // 实例化添加每个状态
        foreach (StateType type in System.Enum.GetValues(typeof(StateType))) // 寻找到所有状态
        {
            allSaveState.Add(type, StateFactory.CreateFactory(type, this));
        }
    }

    private void SetInitState(StateType initType)
    {
        // 如果容器中 initType 的键
        if (allSaveState.TryGetValue(initType, out StateBase state)) // 根据 initType 获得键值，并存在 state 中
        {
            currentState = state;
            state.OnEnter();
        }
    }

    // 每帧执行
    public void OnTick()
    {
        currentState.OnUpdate();
    }

    // 添加状态
    public void AddState(StateType stateType, StateBase state)
    {
        if (allSaveState.ContainsKey(stateType)) return; // 已经包含该状态了

        allSaveState.Add(stateType, state);
    }

    // 设置状态
    public void SetState(StateType stateType)
    {
        if (allSaveState[stateType] == currentState) return; // 如果是当前状态

        currentState?.OnExit(); // 离开当前状态
        currentState = allSaveState[stateType]; // 设置状态
        currentState?.OnEnter(); // 进入状态
    }




}
