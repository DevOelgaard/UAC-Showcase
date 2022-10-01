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

       public static void Attack(Unit attacker, Unit defender)
       {
              var range = Vector3.Distance(attacker.transform.position, defender.transform.position);
              if (range > attacker.attributes.range)
              {
                     Debug.LogError("Unit " + attacker.name + " can't attack! " + defender.name + " is out of range");
                     return;
              }
              attacker.Attack(defender);
              defender.Hit(attacker);
       }
}