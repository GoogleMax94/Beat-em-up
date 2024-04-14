using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadShowMesg : MonoBehaviour
{
    public GameObject Mesg;
    public void Show()
    {
        Mesg.SetActive(true);
    }
}
