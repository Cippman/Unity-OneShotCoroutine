/// <summary>
/// One shot coroutine.
/// 
/// Is a simple script that allows to launch coroutine as "one shot" as for audio sources :) 
/// 
///
/// </summary>
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

using Object = UnityEngine.Object;

namespace CippSharp
{
    #pragma warning disable 0429
    [AddComponentMenu("")]
    public class OneShotCoroutine : MonoBehaviour
    {
        //it generates garbage collection if setted to false
        const bool dontUsePrettyNames = true;

        //just for debug of if feel better if these are shown in hierarchy and inspector even for few seconds
        #if UNITY_EDITOR
        const bool hidden = true;
        const HideFlags underTheHoodFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
        #endif

        public void LaunchCoro(IEnumerator coro)
        {
            StartCoroutine(Coro(coro));
        }

        IEnumerator Coro(IEnumerator coro)
        {
            yield return StartCoroutine(coro);

            Destroy(this.gameObject);
        }


        public void LaunchDelayedAction(UnityAction action, WaitForSeconds delay)
        {
            StartCoroutine(DelayedAction_Coro(action, delay));
        }

        IEnumerator DelayedAction_Coro(UnityAction action, WaitForSeconds delay)
        {
            yield return delay;
            if (action != null)
            {
                action();
            }

            Destroy(this.gameObject);
        }

        public void LaunchDelayedAction<T>(T reference, UnityAction<T> action, WaitForSeconds delay) where T : Object
        {
            StartCoroutine(DelayedAction_Coro<T>(reference, action, delay));
        }

        IEnumerator DelayedAction_Coro<T>(T reference, UnityAction<T> action, WaitForSeconds delay) where T : Object
        {
            yield return delay;
            if (action != null)
            {
                action(reference);
            }

            Destroy(this.gameObject);
        }


        void OnDestroy()
        {
            StopAllCoroutines();
        }


        /// <summary>
        /// It allows you to launch a coroutine
        /// </summary>
        /// <returns>The coro.</returns>
        /// <param name="coro">Coro.</param>
        public static OneShotCoroutine PlayCoro(IEnumerator coro)
        {

            var coroName = (dontUsePrettyNames) ? string.Empty : string.Format("Coro: {0}", coro.ToString());
            var coroGameObject = new GameObject(coroName);
            #if UNITY_EDITOR
            if (hidden)
            {
                coroGameObject.hideFlags = underTheHoodFlags;
            }
            #endif
           
            var coroComponent = coroGameObject.AddComponent<OneShotCoroutine>();
            coroComponent.LaunchCoro(coro);
           
            return coroComponent;
        }

        /// <summary>
        /// It allows you to launch a delayed action.
        /// </summary>
        /// <returns>The delayed action.</returns>
        /// <param name="action">Action.</param>
        /// <param name="delay">Delay.</param>
        public static OneShotCoroutine PlayDelayedAction(UnityAction action, WaitForSeconds delay)
        {

            var coroName = (dontUsePrettyNames) ? string.Empty : string.Format("Coro: {0}", action.ToString());
            var coroGameObject = new GameObject(coroName);
            #if UNITY_EDITOR
            if (hidden)
            {
                coroGameObject.hideFlags = underTheHoodFlags;
            }
            #endif
           
            var coroComponent = coroGameObject.AddComponent<OneShotCoroutine>();
            coroComponent.LaunchDelayedAction(action, delay);
           
            return coroComponent;
        }


        /// <summary>
        /// It allows you to launch a delayed action with ''reference''.
        /// </summary>
        /// <returns>The delayed action.</returns>
        /// <param name="reference">Reference.</param>
        /// <param name="action">Action.</param>
        /// <param name="delay">Delay.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static OneShotCoroutine PlayDelayedAction<T>(T reference, UnityAction<T> action, WaitForSeconds delay) where T : Object
        {

            var coroName = (dontUsePrettyNames) ? string.Empty : string.Format("Coro: {0}:{1}", reference.name.ToString(), action.ToString());
            var coroGameObject = new GameObject(coroName);
            #if UNITY_EDITOR
            if (hidden)
            {
                coroGameObject.hideFlags = underTheHoodFlags;
            }
            #endif
            var coroComponent = coroGameObject.AddComponent<OneShotCoroutine>();
            coroComponent.LaunchDelayedAction<T>(reference, action, delay);

            return coroComponent;
        }
    }
    #pragma warning restore 0429
}