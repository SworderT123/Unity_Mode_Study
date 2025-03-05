using UnityEngine;

public class FSMTest : MonoBehaviour // 当前脚本需要挂载对象
{
    public FSMControl fsm;
    public Animator animator;

    private void Awake()
    {
        fsm = new FSMControl(); // 初始化容器

        animator = GetComponentInChildren<Animator>();

        fsm.AddState(StateType.IDLE, new IdleState(animator, this.fsm)); // 添加状态
        fsm.AddState(StateType.MOVE, new MoveState());

        // 执行初始状态
        fsm.SetState(StateType.IDLE);
    }

    private void Update()
    {
        fsm.OnTick();
    }
}
