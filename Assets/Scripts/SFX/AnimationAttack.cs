using System.Collections.Generic;
using UnityEngine;

public class AnimationAttack: IAnimator
{
    private readonly Unit attacker;
    private readonly List<Unit> targets;

    public AnimationAttack(Unit attacker, List<Unit> targets)
    {
        this.attacker = attacker;
        this.targets = targets;
    }

    public void StartAnimation()
    {
        attacker.MuzzleFlash.ShowFlash();
        foreach (var target in targets)
        {
            target.HitFlash.gameObject.SetActive(true);
        }
    }

    public void StopAnimation()
    {
        attacker.MuzzleFlash.HideFlash();
        foreach (var target in targets)
        {
            target.HitFlash.gameObject.SetActive(false);
        }
    }
}