using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Character.Characters;

namespace Sprites
{
    [RequireComponent(typeof(Animator))]
    public class Animations : MonoBehaviour
    {
        
        public Animator animator;

        public AnimationTriggers[] triggers;
        [Serializable]
        public struct AnimationTriggers
        {
            public State state;
            public string[] triggers;

        }

        

        public void StartAnim(State state)
        {
            foreach (var item in triggers)
            {
                if(item.state == state)
                {
                    int num = UnityEngine.Random.Range(0, item.triggers.Length - 1);
                    animator.SetTrigger(item.triggers[num]);
                    break;
                }
            }
            
        }

    }
}
