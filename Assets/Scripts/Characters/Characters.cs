using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public abstract class Characters : MonoBehaviour
    {
        public float MaxHp = 100;
        float HP = 100;

        public float speed;

        public UnityEvent<State> changeState;

        public UnityEvent<float, float> changeHP;

        public UnityEvent<bool> isDead;

        public State _state;

        public State state
        {
            get { return _state; }
            set
            {
                _state = value;
                changeState?.Invoke(_state);
            }
        }

        [Serializable]
        public enum State
        {
            Ide,
            Walk,
            AttackRand,
            AttackUp,
            Attack,
            AttackDown,
            Hit,
            Dead,
        }

        private void OnDisable()
        {
            changeState.RemoveAllListeners();
            changeHP.RemoveAllListeners();
            isDead.RemoveAllListeners();

        }

        public virtual void Damage(Characters enemy, float damage)
        {
            HP -= damage;
            changeHP?.Invoke(HP, MaxHp);
            if (HP <= 0)
                Dead();
            else
                state = State.Hit;

        }

        public virtual void Dead()
        {
            state = State.Dead;
            isDead?.Invoke(true);
        }

        public virtual void Hit()
        {

        }


    }
}