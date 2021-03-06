using System;
using UnityEngine;

public abstract class IInputManager : ScriptableObject
{
    public abstract bool GetForword();
    public abstract bool GetBackword();
    public abstract bool GetLeft();
    public abstract bool GetRight();

    public abstract bool PickUpFood();
    public abstract bool CutWood();
    public abstract bool CollectResource();
    public abstract bool PickUpWeapon();
    public abstract bool EatFood();
    public abstract bool Crouch();
    public abstract bool SteelthAttack();
}
