using UnityEngine;

// 实现单例模式基类，可以通过继承这个类来实现单例模式，而不用每次都写一大堆代码
public class SinglePatternBase<T> : MonoBehaviour where T : MonoBehaviour
{
    protected SinglePatternBase() { }

    private static readonly object _lock = new object();
    private static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                // _instance = FindObjectsByType<T>();
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        GameObject singleton = new GameObject(typeof(T).name);
                        _instance = singleton.AddComponent<T>();
                        singleton.name = typeof(T).ToString();
                        DontDestroyOnLoad(singleton);
                    }
                }
            }
        }
        return _instance;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

// 使用方法
// 这个类继承了SinglePatternBase<InstanceSystem>，所以InstanceSystem类就是一个单例模式的类(已继承了instance属性)
public class InstanceSystem : SinglePatternBase<InstanceSystem>
{
    // 避免该类被实例化
    private InstanceSystem() { }

    // ...
}