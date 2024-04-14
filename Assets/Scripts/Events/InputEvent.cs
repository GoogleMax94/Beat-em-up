using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEvent : MonoBehaviour
{

    [Flags]
    public enum KeyCode
    {
        None = 0,
        Left = 1 << 0, // 1
        Right = 1 << 1, // 2
        Up = 1 << 2, // 4
        Down = 1 << 3, // 8
        LeftUp = Left | Up, // 5
        RightUp = Right | Up, // 6
        LeftDown = Left | Down, // 9
        RightDown = Right | Down // 10
    }

    public static event Action<KeyCode> InputKey;

    public KeyCode keyCode;

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(UnityEngine.KeyCode.A) || Input.GetKeyDown(UnityEngine.KeyCode.LeftArrow))
            keyCode = KeyCode.Left;
        else if (Input.GetKeyDown(UnityEngine.KeyCode.D) || Input.GetKeyDown(UnityEngine.KeyCode.RightArrow))
            keyCode = KeyCode.Right;

        if (keyCode != KeyCode.None)
        {
            if (Input.GetKey(UnityEngine.KeyCode.W) || Input.GetKey(UnityEngine.KeyCode.UpArrow))
                keyCode |= KeyCode.Up;
            else if (Input.GetKey(UnityEngine.KeyCode.S) || Input.GetKey(UnityEngine.KeyCode.DownArrow))
                keyCode |= KeyCode.Down;

            InputKey?.Invoke(keyCode);
            keyCode = KeyCode.None;
        }
    }

    private void OnDisable()
    {
    }

    private void Start()
    {
        
    }

}
