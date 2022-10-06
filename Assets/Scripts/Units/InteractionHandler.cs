using System.Collections.Generic;
using UnityEngine;

public static class InteractionHandler
{
       public static void Move(Unit unit, GameMap gameMap)
       {
              if (!unit.attributes.canMove)
              {
                     Debug.LogError("Unit " + unit.name + " can't move, and shouldn't try to");
                     return;
              }
              var currentPosition = unit.transform.position;
              var desiredPosition = currentPosition + unit.MovementVector;
              if (desiredPosition.x > gameMap.RightUnitBoundary)
              {
                     desiredPosition.x = gameMap.RightUnitBoundary;
              } 
              unit.Move(desiredPosition);
       }

       public static void Attack(Unit attacker, List<Unit> defenders)
       {
              foreach (var defender in defenders)
              {
                     var distanceToTarget = GetDistance(attacker,defender);
                     if (distanceToTarget > attacker.attributes.range)
                     {
                            Debug.LogError("Unit " + attacker.name + " can't attack! " + defender.name + " is out of range");
                            return;
                     }

                     var damage = GetDamage(attacker, defender, distanceToTarget);
                     attacker.Attack(defender);
                     defender.TakeHit(attacker,damage);
              }

              attacker.Animator = new AnimationAttack(attacker, defenders);
       }

       public static float GetDistance(Unit attacker, Unit defender)
       {
              return Vector3.Distance(attacker.transform.position, defender.transform.position);
       }

       public static float GetDamage(Unit attacker, Unit defender, float distanceToTarget = -1f)
       {
              if (distanceToTarget < 0)
              {
                     distanceToTarget = GetDistance(attacker,defender);
              }

              var damageDistanceModifier = -1f;

              var distanceToTargetAboveOptimal = distanceToTarget - attacker.attributes.optimalDistanceToTarget;

              if (distanceToTargetAboveOptimal <= 0)
              {
                     damageDistanceModifier = 1f;
              }
              else // Distance is > optimalRange
              {
                     var effectPercentageSpan = (1 - attacker.attributes.effectPercentAtMinimumRange)/attacker.attributes.RangeSpan;
                     var percentageOfMaximumSpan = distanceToTargetAboveOptimal / attacker.attributes.RangeSpan * 100;


                     damageDistanceModifier = attacker.attributes.effectPercentAtMinimumRange +
                                      (100 - percentageOfMaximumSpan) * effectPercentageSpan;
              }

              damageDistanceModifier = Mathf.Clamp(damageDistanceModifier, 0f,1f);

              var baseDamage = defender.attributes.isSoft
                     ? attacker.attributes.damageSoft
                     : attacker.attributes.damageHard;

              var damage = baseDamage * damageDistanceModifier;
              Debug.Log("Damage calculated for A: " + attacker.name + " D: " + defender.name + ". Distance: " +
                        distanceToTarget + ", BaseDamage: " + baseDamage + " DamageDistanceModifier: " +
                        damageDistanceModifier + ", Damage: " + damage);

              return damage;
       }
}