/*
 *  Author: Alessandro Salani (Cippman)
 */

using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

namespace CippSharp
{
    #pragma warning disable 0429
    /// <summary>
    /// One Shot Coroutine. 
    /// Is a simple script that allows to launch coroutine as "one shot" as for audio sources. 
    /// </summary>
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class OneShotCoroutine : MonoBehaviour
    {
        #region Debug

        public static bool useEmptyNames = true;
        public static bool hiddenInHierarchy = true;
        
        #endregion
        
#if UNITY_EDITOR
        private const HideFlags underTheHoodFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
#endif
        
        #region Coroutines

        /// <summary>
        /// Start a coroutine on a new gameObject
        /// </summary>
        /// <returns></returns>
        /// <param name="coroutine"></param>
        public static OneShotCoroutine PlayCoroutine(IEnumerator coroutine)
        {
#if NET_4_6
            string coroutineName = (useEmptyNames) ? string.Empty : $"Coroutine: {coroutine.ToString()}";
#else
            string coroutineName = (useEmptyNames) ? string.Empty : string.Format("Coro: {0}", coroutine.ToString());
#endif
            GameObject coroutinePlayer = new GameObject(coroutineName);
#if UNITY_EDITOR
            if (hiddenInHierarchy)
            {
                coroutinePlayer.hideFlags = underTheHoodFlags;
            }
#endif
            OneShotCoroutine oneShotCoroutineComponent = coroutinePlayer.AddComponent<OneShotCoroutine>();
            oneShotCoroutineComponent.LaunchCoroutine(coroutine);
            return oneShotCoroutineComponent;
        }
        
        /// <summary>
        /// Launch the passed coroutine in a coroutine.
        /// </summary>
        /// <param name="coroutine"></param>
        public void LaunchCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(CoroutinePlayer(coroutine));
        }
        
        private IEnumerator CoroutinePlayer(IEnumerator coroutine)
        {
            yield return StartCoroutine(coroutine);

            Destroy(this.gameObject);
            
            yield break;
        }
        
        #endregion

        #region Delayed Action (Type 0)

        /// <summary>
        /// Invokes an action after the specified time with a coroutine on a new GameObject.
        /// </summary>
        /// <returns></returns>
        /// <param name="action"></param>
        /// <param name="delay"></param>
        public static OneShotCoroutine PlayDelayedAction(Action action, WaitForSeconds delay)
        {
#if NET_4_6
            string actionName = (useEmptyNames) ? string.Empty : $"Action: {action.ToString()}";
#else
            string actionName = (useEmptyNames) ? string.Empty : string.Format("Action: {0}", action.ToString());
#endif
            GameObject coroutinePlayer = new GameObject(actionName);
#if UNITY_EDITOR
            if (hiddenInHierarchy)
            {
                coroutinePlayer.hideFlags = underTheHoodFlags;
            }
#endif
            OneShotCoroutine oneShotCoroutineComponent = coroutinePlayer.AddComponent<OneShotCoroutine>();
            oneShotCoroutineComponent.LaunchDelayedAction(action, delay);
           
            return oneShotCoroutineComponent;
        }
        
        /// <summary>
        /// Starts a coroutine that invokes an action after the specified time
        /// </summary>
        /// <param name="action"></param>
        /// <param name="delay"></param>
        public void LaunchDelayedAction(Action action, WaitForSeconds delay)
        {
            StartCoroutine(DelayedActionCoroutine(action, delay));
        }

        private IEnumerator DelayedActionCoroutine(Action action, WaitForSeconds delay)
        {
            yield return delay;
            if (action != null)
            {
                action();
            }

            Destroy(this.gameObject);
        }

        #endregion
        
        #region Delayed Action (Type 1)
     
        /// <summary>
        /// Invokes an action after the specified time with a coroutine on a new GameObject.
        /// </summary>
        /// <returns></returns>
        /// <param name="reference">a reference.</param>
        /// <param name="action"></param>
        /// <param name="delay"></param>
        /// <typeparam name="T"></typeparam>
        public static OneShotCoroutine PlayDelayedAction<T>(T reference, Action<T> action, WaitForSeconds delay) where T : Object
        {
#if NET_4_6
            string actionName = (useEmptyNames) ? string.Empty : $"Action: {action.ToString()}";
#else
            string actionName = (useEmptyNames) ? string.Empty : string.Format("Action: {0}", action.ToString());
#endif
            
            GameObject coroutinePlayer = new GameObject(actionName);
#if UNITY_EDITOR
            if (hiddenInHierarchy)
            {
                coroutinePlayer.hideFlags = underTheHoodFlags;
            }
#endif
            OneShotCoroutine oneShotCoroutineComponent = coroutinePlayer.AddComponent<OneShotCoroutine>();
            oneShotCoroutineComponent.LaunchDelayedAction<T>(reference, action, delay);

            return oneShotCoroutineComponent;
        }

        /// <summary>
        /// Starts a coroutine that invokes an action after the specified time with the passed reference.
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="action"></param>
        /// <param name="delay"></param>
        public void LaunchDelayedAction<T>(T reference, Action<T> action, WaitForSeconds delay) where T : Object
        {
            StartCoroutine(DelayedActionCoroutine<T>(reference, action, delay));
        }

        private IEnumerator DelayedActionCoroutine<T>(T reference, Action<T> action, WaitForSeconds delay) where T : Object
        {
            yield return delay;
            if (action != null)
            {
                action(reference);
            }

            Destroy(this.gameObject);
        }

        #endregion

        /// <summary>
        /// Stop this OneShotCoroutine.
        /// </summary>
        public void Stop()
        {
            Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
    #pragma warning restore 0429
}
