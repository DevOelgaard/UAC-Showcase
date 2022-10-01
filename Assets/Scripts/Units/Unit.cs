using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
        public UnitAttributes attributes;
        private MuzzleFlash muzzleFlash;

        public MuzzleFlash MuzzleFlash
        {
                get
                {
                        if (muzzleFlash == null)
                        {
                                muzzleFlash = Go.transform.Find("Flash").GetComponent<MuzzleFlash>();
                        }

                        return muzzleFlash;
                }
        }
        public Vector3 MovementVector => new Vector3(1, 0, 0) * attributes.moveSpeed;
        private GameObject go;
        private GameObject Go
        {
                get
                {
                        if (go == null)
                        {
                                go = gameObject;
                        }

                        return go;
                }
        }

        private void Start()
        {
                attributes.health = attributes.maxHealth;
                muzzleFlash.HideFlash();
        }

        public void Move(Vector3 newPosition)
        {
                Go.transform.position = newPosition;
        }

        public void Attack(Unit target)
        {
                Debug.Log(Go.name + " Attacked: " + target.name);
        }

        public void Hit(Unit hitBy)
        {
                var damage = 0f;
                if (attributes.isSoft)
                {
                        damage = hitBy.attributes.damageSoft;
                }
                else
                {
                        damage = hitBy.attributes.damageHard;
                }
                Debug.Log(Go.name + " Hit by: " + hitBy.name + " for " + damage + " damage");
                TakeDamage(damage);
        }

        public void TakeDamage(float damage)
        {
                attributes.health -= damage;

                if (attributes.health <= 0)
                {
                        attributes.health = 0;
                }
        }

        public void Die()
        {
                attributes.health = 0;
                gameObject.SetActive(false);
        }
}
