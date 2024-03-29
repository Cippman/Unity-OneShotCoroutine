﻿/*
 *  Author: Alessandro Salani (Cippman)
 */
#if UNITY_EDITOR
using UnityEngine;

namespace CippSharp.Core.OSC.Samples
{
    public class LoopActivation : MonoBehaviour
    {
        [TextArea(1, 5)] public string notes = "";

        [Space(5)]
        //Debug purpose only
        public bool showOneShotCoroutine = false;

        private readonly WaitForSeconds waitOneSecond = new WaitForSeconds(1);

        private void Start()
        {
            ChangeStatus();
        }

        private void ChangeStatus()
        {
            gameObject.SetActive(!gameObject.activeSelf);

            //Debug purpose only
            if (showOneShotCoroutine)
            {
                OneShotCoroutine.useEmptyNames = false;
                OneShotCoroutine.hiddenInHierarchy = false;
            }

            OneShotCoroutine.PlayDelayedAction(ChangeStatus, waitOneSecond);

            //Debug purpose only
            if (showOneShotCoroutine)
            {
                OneShotCoroutine.useEmptyNames = true;
                OneShotCoroutine.hiddenInHierarchy = true;
            }
        }
    }
}
#endif