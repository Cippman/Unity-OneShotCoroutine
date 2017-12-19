using UnityEngine;
using CippSharp;

public class AutoActivate : MonoBehaviour
{
    void Start()
    {
        OneShotCoroutine.PlayDelayedAction(() => gameObject.SetActive(true), new WaitForSeconds(5));
        gameObject.SetActive(false);
    }
}
