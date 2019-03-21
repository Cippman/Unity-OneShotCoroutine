/*
 *  Author: Alessandro Salani (Cippman)
 */

using System.Collections;
using UnityEngine;
using CippSharp;

public class AutoActivate : MonoBehaviour
{
    [TextArea(1, 5)] public string notes = "";
    
    private void Start()
    {
        gameObject.SetActive(false);
        OneShotCoroutine.PlayCoroutine(SelfActivate());
    }

    private IEnumerator SelfActivate()
    {
        yield return new WaitForSeconds(5.0f);
        gameObject.SetActive(true);
    }
}
