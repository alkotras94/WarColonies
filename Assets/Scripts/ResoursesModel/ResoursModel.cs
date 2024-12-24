using System;
using UnityEngine;
public abstract class ResoursModel
{
    public uint Resours { get; private set; }

    public event Action Changed;

    public void Add(uint value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException();

        Resours += value;

        Changed?.Invoke();
    }

    public void Spend(uint value)
    {
        if (value <= 0 && value > Resours)
            throw new ArgumentOutOfRangeException();

        Resours -= value;

        Changed?.Invoke();
    }
}
