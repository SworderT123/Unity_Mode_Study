using UnityEngine;

public class InstanceSystem : MoNoBehaviour
{
    private InstanceSystem() { }


    private static readonly object _lock = new object(); // 锁住线程，防止多线程访问

    public static InstanceSystem instance
    {
        get
        {
            if (instance == null)
            {
                // 通过GameObject.FindObjectOfType<InstanceSystem>()来查找场景中是否已经存在InstanceSystem实例
                instance = GameObject.FindObjectOfType<InstanceSystem>();
                lock (_lock)
                {
                    // 如果没有找到InstanceSystem实例，就创建一个新的GameObject，并挂载InstanceSystem组件
                    if (instance == null)
                    {
                        GameObject tool = new GameObject("InstanceSystem");
                        instance = tool.AddComponent<InstanceSystem>();

                        // 保证InstanceSystem实例不会被销毁
                        DontDestroyOnLoad(tool);
                    }
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}