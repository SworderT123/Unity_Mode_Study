using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 对状态机的功能进行测试
public class FSMTest : MonoBehaviour
{
    private FSMControl fsm;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        fsm = new FSMControl(animator); // 实例化 FSMControl
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnTick(); // 调用该状态机的Tick，每帧都播放当前动画
    }
}
