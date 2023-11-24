using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public enum States
    {
        Invalid = -1,
        Idle = 0,
        Patrol = 1,
        Chase = 2,
    }
}
