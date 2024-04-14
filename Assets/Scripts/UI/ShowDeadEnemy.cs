using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowDeadEnemy : MonoBehaviour
{
    public UnityEvent<string> DeadCount;
    int Count = 0;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.IsDeadEnemy += () => DeadCount?.Invoke((++Count).ToString());
    }

}
