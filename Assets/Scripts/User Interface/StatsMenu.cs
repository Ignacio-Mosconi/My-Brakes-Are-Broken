using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsMenu : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI distanceTraveled;
    [SerializeField] TextMeshProUGUI coinsCollected;

    void Start()
    {
        distanceTraveled.text = GameManager.Instance.DistanceTraveled.ToString("0") + " km";
        coinsCollected.text = GameManager.Instance.CoinsCollected.ToString();
    }
}
