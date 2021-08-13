/*
 *  Author: Alessandro Salani (Cippman)
 */

#if UNITY_EDITOR
using System.Collections;
using UnityEngine;

namespace CippSharp.Core.OSC.Samples
{
    public class AnnoyingLog : MonoBehaviour
    {
        [TextArea(1, 7)] public string notes = "";

        [Space(5)] public KeyCode stopCoroutineInput = KeyCode.Space;

        private OneShotCoroutine annoyingLogCoroutine;

        private void Start()
        {
            annoyingLogCoroutine = OneShotCoroutine.PlayCoroutine(AnnoyingLogCoroutine());
        }

        private IEnumerator AnnoyingLogCoroutine()
        {
            WaitForSeconds waitTwoSeconds = new WaitForSeconds(2.0f);

            while (true)
            {
                yield return waitTwoSeconds;
                Debug.Log(gameObject.name + " I'm printed every 2.0 seconds!", this);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(stopCoroutineInput))
            {
                if (annoyingLogCoroutine != null)
                {
                    annoyingLogCoroutine.Stop();
                    Debug.Log(gameObject.name + " Annoying Log Coroutine Stopped.", this);
                }

                annoyingLogCoroutine = null;
            }
        }
    }
}
#endif
