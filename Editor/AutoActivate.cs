/*
 *  Author: Alessandro Salani (Cippman)
 */

using System.Collections;
using UnityEngine;

namespace CippSharp.Core.OSC.Editor.Examples
{
    public class AutoActivate : MonoBehaviour
    {
        [TextArea(1, 7)] public string notes = "";

        [Space(5)] [Tooltip("The delay before activation.")]
        public float delay = 5.0f;

        private void Start()
        {
            gameObject.SetActive(false);
            OneShotCoroutine.PlayCoroutine(SelfActivate(delay));
        }

        private IEnumerator SelfActivate(float value)
        {
            yield return new WaitForSeconds(value);
            gameObject.SetActive(true);
        }
    }
}
