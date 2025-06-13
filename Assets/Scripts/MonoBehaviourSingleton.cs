using UnityEngine;

public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
{
    public static T Instance { get; private set; }
    public static bool HasIntance => Instance != null;

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = (T)this;
    }

}
