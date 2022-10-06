using System;
using System.Linq;
using UniRx;
using Unity.Linq;
using UnityEngine;

public class Unit : AgentMono
{
        public UnitAttributes attributes;
        private MuzzleFlash muzzleFlash;
        private GameObject hitFlash;
        public IObservable<Unit> HasDied => hasDied;
        private readonly Subject<Unit> hasDied = new Subject<Unit>();
        public IAnimator Animator = new AnimationNone();
        private HealthBar healthBar;

        private HealthBar HealthBar
        {
                get
                {
                        if (healthBar == null)
                        {
                                healthBar = Go
                                        .Child("HealthBarCanvas")
                                        .Child("HealthBar")
                                        .GetComponent<HealthBar>();
                        }

                        return healthBar;
                }
        }

        public MuzzleFlash MuzzleFlash
        {
                get
                {
                        if (muzzleFlash == null)
                        {
                                muzzleFlash = Go
                                        .Child("Flash")
                                        .GetComponent<MuzzleFlash>();
                        }

                        return muzzleFlash;
                }
        }

        public GameObject HitFlash
        {
                get
                {
                        if (hitFlash == null)
                        {
                                hitFlash = Go
                                        .Child("HitFlash");
                        }

                        return hitFlash;
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

        protected override void Start()
        {
                base.Start();
                attributes.health = attributes.maxHealth;
                MuzzleFlash.HideFlash();
                HitFlash.gameObject.SetActive(false);
                HealthBar.Init(this);
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
                Debug.Log(Go.name + " Hit by: " + hitBy.name + " for " + damage + " damage" );
                TakeDamage(damage);
        }

        /// <summary>
        /// Used for doing logic based on health level
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(float damage)
        {
                attributes.health -= damage;
                Debug.Log(Go.name + " took: " + damage + " Health left: " + attributes.health);
                HealthBar.SetValue(attributes.health);

                if (attributes.health <= 0)
                {
                        attributes.health = 0;
                        Die();
                }
        }

        public void Die()
        {
                attributes.health = 0;
                hasDied.OnNext(this);
        }
}
