using System;
using UnityEngine;
public abstract class ResoursModel
{
    public int Resours { get; private set; }

    public event Action Changed;

    public void Add(int value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException();

        Resours += value;

        Changed?.Invoke();
    }

    public void Spend(int value)
    {
        if (value <= 0 && value > Resours)
            throw new ArgumentOutOfRangeException();

        Resours -= value;

        Changed?.Invoke();
    }
}
