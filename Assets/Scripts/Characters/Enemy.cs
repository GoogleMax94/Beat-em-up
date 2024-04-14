using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.EventSystems.EventTrigger;

namespace Character
{

    public class Enemy : Characters
    {

        public static event Action IsDeadEnemy;

        public float damage;

        public float FightСooldown;

        public bool isFight;

       
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Fight());
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Damage(Characters enemy, float damage)
        {
            if (state != State.Dead)
            {
                transform.position += new Vector3(1.5f * transform.position.x - enemy.transform.position.normalized.x, 0);
                base.Damage(enemy, damage);
            }
        }

        public override void Dead()
        {
            tag = "Dead";
            IsDeadEnemy?.Invoke();
            StartCoroutine(TimerDestroy());
            //Destroy(gameObject);
            base.Dead();

        }

        IEnumerator TimerDestroy()
        {
            yield return new WaitForSecondsRealtime(1);
            Destroy(gameObject);
        }

        IEnumerator Fight()
        {
            while (state != State.Dead)
            {
                if (collision != null)
                {
                    state = State.AttackRand;
                    collision.GetComponent<Characters>().Damage(this, damage);
                    yield return new WaitForSecondsRealtime(FightСooldown);
                }
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }

        private void FixedUpdate()
        {
            if (!InContact)
                collision = null;

            InContact = false;
        }
        public bool InContact = false;
        Collider2D collision;
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                this.collision = collision;
                InContact = true;
            }
        }

    } 
}
