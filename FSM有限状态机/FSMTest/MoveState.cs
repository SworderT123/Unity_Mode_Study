using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : StateBase
{
    private IStateContext _contetx;

    public MoveState(IStateContext context)
    {
        _contetx = context;
    }

    public override void OnEnter()
    {
        Debug.Log("我要走啦！");
    }

    public override void OnUpdate()
    {
        _contetx.animator.Play("Move");

        Debug.Log("我走了哦~");
    }

    public override void OnExit()
    {
        Debug.Log("我不走啦！");
    }
}
