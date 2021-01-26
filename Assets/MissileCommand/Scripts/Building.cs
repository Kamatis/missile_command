using UnityEngine;
using UnityEngine.Events;

public abstract class Building : MonoBehaviour
{
    public OnDeath onDeath;
    public abstract bool IsAlive();

    [System.Serializable]
    public class OnDeath : UnityEvent { }
}
