using System;
using TMPro;

[Serializable]
public class UnitAttributes
{
    public float moveSpeed = 1f;
    public float maxHealth = 100f;
    public float health = 100f;
    public float damageSoft = 10f;
    public float damageHard = 1f;
    public float range = 5f;
    public bool canMove = true;
    public bool isSoft = true;
}