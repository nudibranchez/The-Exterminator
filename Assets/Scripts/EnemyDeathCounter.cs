using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDeathCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextModif;
    int DeathCount = 0;

    public void AddToTotal()
    {
        DeathCount ++;
        TextModif.text = DeathCount.ToString();
    }

}
