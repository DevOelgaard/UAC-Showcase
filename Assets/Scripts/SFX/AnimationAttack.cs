using System;
using System.Collections.Generic;

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
        if (attacker != null)
        {
            attacker.MuzzleFlash.ShowFlash();
        }
        foreach (var target in targets)
        {
            if (target != null)
            {
                target.HitFlash.gameObject.SetActive(true);
            }
        }
    }

    public void StopAnimation()
    {
        if (attacker != null)
        {
            attacker.MuzzleFlash.HideFlash();
        }
        
        foreach (var target in targets)
        {
            if (target != null)
            {
                target.HitFlash.gameObject.SetActive(false);
            }
        }
    }
}