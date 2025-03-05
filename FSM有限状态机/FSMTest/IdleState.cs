using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateBase
{
    private IStateContext _context;
    private float _deltaTime = 5f;

    public IdleState(IStateContext context) // 依赖注入，只需要知道接口
    {
        _context = context;
    }

    public override void OnEnter()
    {
        Debug.Log("我要无聊啦~!");
    }

    public override void OnUpdate()
    {
        _context.animator.Play("Idle");
        if (_deltaTime > 0)
        {
            _deltaTime -= Time.deltaTime;
            if (_deltaTime <= 0)
            {
                Debug.Log("我好无聊！");
                _context.RequestStateChange(StateType.MOVE); // 使用接口切换状态
            }
        }

    }

    public override void OnExit()
    {
        Debug.Log("我不要无聊啦！");
    }
}
