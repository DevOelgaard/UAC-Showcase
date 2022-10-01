using System;
using UniRx;
using UnityEngine;

public class Unit : AgentMono
{
        public UnitAttributes attributes;
        private MuzzleFlash muzzleFlash;
        public IObservable<Unit> HasDied => hasDied;
        private readonly Subject<Unit> hasDied = new Subject<Unit>();

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

        /// <summary>
        /// Used for displaying animations and so forth
        /// </summary>
        /// <param name="target"></param>
        public void Attack(Unit target)
        {
                Debug.Log(Go.name + " Attacked: " + target.name);
        }

        /// <summary>
        /// Used for displaying hit animations
        /// </summary>
        /// <param name="hitBy"></param>
        /// <param name="damage"></param>
        public void TakeHit(Unit hitBy, float damage)
        {
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

        /// <summary>
        /// Used for doing logic based on health level
        /// </summary>
        /// <param name="damage"></param>
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
                hasDied.OnNext(this);
        }
}
