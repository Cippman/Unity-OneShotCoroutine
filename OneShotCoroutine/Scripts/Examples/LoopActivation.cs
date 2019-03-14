using UnityEngine;
using CippSharp;

public class LoopActivation : MonoBehaviour
{

    WaitForSeconds oneSecondWait = new WaitForSeconds(1);

    void Start()
    {
        ChangeStatus();
    }

    void ChangeStatus()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        OneShotCoroutine.PlayDelayedAction(() => ChangeStatus(), oneSecondWait);
    }

}
