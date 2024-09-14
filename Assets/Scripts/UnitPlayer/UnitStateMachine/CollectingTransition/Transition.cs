using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    public abstract void Enter(Hit hitData);
    public abstract void Exit();
}



