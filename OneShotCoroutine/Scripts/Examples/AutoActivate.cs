/*
 *  Author: Alessandro Salani (Cippman)
 */

using System.Collections;
using UnityEngine;
using CippSharp;

public class AutoActivate : MonoBehaviour
{
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
