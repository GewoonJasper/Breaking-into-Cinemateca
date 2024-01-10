using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public enum States
    {
        Invalid = -1,
        Idle = 0,
        Catch = 1,
        Patrol = 2,
        Chase = 3,
    }
}
