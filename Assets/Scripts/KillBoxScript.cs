using UnityEngine;
using UnityEngine.Events;

public class KillBoxScript : MonoBehaviour
{
    public UnityEvent OnPlayerEnter;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            OnPlayerEnter?.Invoke();
    }
}
