using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EventBus
{
    // Stores event type -> list of listeners
    private static Dictionary<Type, List<Delegate>> _subscribers = new();

    /// <summary>
    /// Subscribe to an event of type T.
    /// </summary>
    public static void Subscribe<T>(Action<T> callback)
    {
        var eventType = typeof(T);

        if (!_subscribers.ContainsKey(eventType))
        {
            _subscribers[eventType] = new List<Delegate>();
        }

        // Only add if not already subscribed
        if (!_subscribers[eventType].Contains(callback))
        {
            _subscribers[eventType].Add(callback);
#if UNITY_EDITOR
            Debug.Log($"[EventBus] Subscribed to event: {eventType}");
#endif
        }
    }

    /// <summary>
    /// Unsubscribe from an event of type T.
    /// </summary>
    public static void Unsubscribe<T>(Action<T> callback)
    {
        var eventType = typeof(T);

        if (_subscribers.ContainsKey(eventType))
        {
            _subscribers[eventType].Remove(callback);
#if UNITY_EDITOR
            Debug.Log($"[EventBus] Unsubscribed from event: {eventType}");
#endif
        }
    }

    /// <summary>
    /// Raise an event of type T, optionally with event data.
    /// </summary>
    public static void Raise<T>(T eventData)
    {
        var eventType = typeof(T);

        if (_subscribers.ContainsKey(eventType))
        {
            // Create a copy of the list to avoid issues if
            // listeners subscribe/unsubscribe during iteration
            var subscribersCopy = new List<Delegate>(_subscribers[eventType]);

            foreach (var callback in subscribersCopy.Select(t => t as Action<T>))
            {
                try
                {
// #if UNITY_EDITOR
//                     Debug.Log($"[EventBus] Raising event: {eventType}");
// #endif
                    callback?.Invoke(eventData);
                }
                catch (Exception e)
                {
                    Debug.LogError($"[EventBus] Error invoking event {eventType}: {e}");
                }
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogWarning($"[EventBus] No listeners for event type {eventType}");
#endif
        }
    }
}
