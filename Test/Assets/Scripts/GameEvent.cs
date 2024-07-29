using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static event Action OnRolled;

    public static void Rolled()
    {
        if (OnRolled != null)
        {
            OnRolled();
        }
    }
}
