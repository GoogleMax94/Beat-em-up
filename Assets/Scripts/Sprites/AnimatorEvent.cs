using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{

    public Trigget[] triggers;

    [Serializable]
    public struct Trigget
    {
        public string name;
        public InputEvent.KeyCode keyCode;
    }

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        InputEvent.InputKey += InputEvent_InputKey;
    }

    private void OnDisable()
    {
        InputEvent.InputKey -= InputEvent_InputKey;
    }

    private void InputEvent_InputKey(InputEvent.KeyCode key)
    {
        foreach (var item in triggers)
            if (item.keyCode == key)
                animator.SetTrigger(item.name);
    }
}
