using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPValue : MonoBehaviour
{
    public Image bpBar;

    public void SetValue(float hp, float maxHp)
    {
        bpBar.fillAmount = hp / maxHp;

    }

}
