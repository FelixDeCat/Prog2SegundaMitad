using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
    Dictionary<string, Action> events = new Dictionary<string, Action>();

    public void Subscribe(string key, Action callback)
    {
        if (!events.ContainsKey(key))
        {
            events.Add(key, callback);
        }
    }


    public void ON_EVENT(string ev)
    {
        if (events.ContainsKey(ev))
        {
            events[ev].Invoke();
        }
    }
}
