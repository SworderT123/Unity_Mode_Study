using UnityEngine;


public class IdleState : StateBase
{
    // 假设当前动作需要Animator组件，但是又没有继承MonoBehaviour
    private Animator animator;
    private float deltaTime = 5f;
    private FSMControl fsm; // 获得一个状态机
    // 当实例获得Animator
    public IdleState(Animator animator, FSMControl fsm)
    {
        this.animator = animator;
        this.fsm = fsm;
    }

    // 实现抽象类
    public override void OnEnter()
    {
        // ...
    }

    public override void OnUpdate()
    {
        // ...

        if (deltaTime > 0)
        {
            deltaTime -= Time.deltaTime;

            if (deltaTime <= 0)
            {
                fsm.SetState(StateType.MOVE); // 转移状态
            }
        }
    }

    public override void OnExit()
    {
        // ... 
    }
}