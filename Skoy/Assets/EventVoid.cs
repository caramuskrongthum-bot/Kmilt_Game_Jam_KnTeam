using UnityEngine;
using UnityEngine.Events;

public class EventVoid : MonoBehaviour
{
    public UnityEvent UnityEvent;
    public UnityEvent UnityEvent2;
    public UnityEvent UnityEvent3;

    public void DoEvent()
    {
        UnityEvent.Invoke();
    }
    public void DoEvent2()
    {
        UnityEvent2.Invoke();
    }
    public void DoEvent3()
    {
        UnityEvent3.Invoke();
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
