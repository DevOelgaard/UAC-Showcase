using System;
using TMPro;
using UnityEngine;

[Serializable]
public class UnitAttributes
{
    public float moveSpeed = 1f;
    public float maxHealth = 100f;
    public float health = 100f;
    public float damageSoft = 10f;
    public float damageHard = 1f;
    public float range = 5f;
    public float optimalDistanceToTarget = 3f;
    public float RangeSpan => range - optimalDistanceToTarget;
    [Range(0.1f,1f)]
    public float effectPercentAtMinimumRange = 0.3f;
    public bool canMove = true;
    public bool isSoft = true;
}