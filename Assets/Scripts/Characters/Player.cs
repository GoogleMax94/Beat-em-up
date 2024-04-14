using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Character
{
    public class Player : Characters
    {
        Vector3 scale;
        public float damag;
        // Start is called before the first frame update
        void Start()
        {
            InputEvent.InputKey += InputEvent_InputKey;
            scale = transform.localScale;
        }

        private void InputEvent_InputKey(InputEvent.KeyCode obj)
        {

            if (obj == InputEvent.KeyCode.LeftUp || obj == InputEvent.KeyCode.Left || obj == InputEvent.KeyCode.LeftDown)
                scale.x = -Mathf.Abs(scale.x);
            else
                scale.x = Mathf.Abs(scale.x);


            if (obj == InputEvent.KeyCode.LeftUp || obj == InputEvent.KeyCode.RightUp)
                state = State.AttackUp;
            else if (obj == InputEvent.KeyCode.Left || obj == InputEvent.KeyCode.Right)
                state = State.Attack;
            else if (obj == InputEvent.KeyCode.LeftDown || obj == InputEvent.KeyCode.RightDown)
                state = State.AttackDown;


            transform.localScale = scale;
            Fight(transform.position + ((scale.x > 0)?Vector3.right:Vector3.left));


           
        }

        private void OnDisable()
        {
            InputEvent.InputKey -= InputEvent_InputKey;

        }

        public override void Damage(Characters enemy, float damage)
        {
            if (state != State.Dead)
            {

                scale.x = transform.position.x - enemy.transform.position.x>0? -Mathf.Abs(scale.x): Mathf.Abs(scale.x);

                transform.localScale = scale;

                base.Damage(enemy, damage);
            }
        }

        public override void Dead()
        {
            state = State.Dead;
            InputEvent.InputKey -= InputEvent_InputKey;
            tag = "Dead";
            base.Dead();
        }
        void Fight(Vector2 point)
        {
            RaycastHit2D[] physics = Physics2D.CapsuleCastAll(point, Vector2.one, CapsuleDirection2D.Vertical, 0, Vector2.zero);

            foreach (var item in physics)
            {
                if(item.transform.TryGetComponent<Characters>(out var character))
                {
                    character.Damage(this, damag);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
