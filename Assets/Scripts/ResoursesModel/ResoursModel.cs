using System;
using UnityEngine;
public abstract class ResoursModel
{
    public uint Resours { get; private set; }

    public event Action Changed;
    public event Action FoodShoved;
    public bool NoFood;

    protected ResoursModel(uint resours)
    {
        Resours = resours;
    }

    protected ResoursModel()
    {
        Resours = 0;
    }

    public void Add(uint value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException();

        Resours += value;

        Changed?.Invoke();

        if (Resours == 1)
            FoodShoved?.Invoke();
    }

    public void Spend(uint value)
    {
        if (value <= 0 && value > Resours)
            throw new ArgumentOutOfRangeException();

        Resours -= value;

        Changed?.Invoke();
    }
}
