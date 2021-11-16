using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static State CurrentState;

    public enum State
    {
        EndPlatform, Play, Lost, Won
    }
}

