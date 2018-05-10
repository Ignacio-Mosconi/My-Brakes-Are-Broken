﻿using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Text distanceText;
    [SerializeField] private Image fuelBar;
    [SerializeField] private Text scoreText;

    void Start()
    {
        ScoreManager.Instance.OnScoreChange.AddListener(RefreshScore);
        RefreshScore();
    }

    void Update()
    {
        if (!LevelManager.Instance.GameOver)
        {
            distanceText.text = playerTransform.position.z.ToString("0") + " m";
            fuelBar.fillAmount = FuelManager.Instance.FuelAmount / FuelManager.Instance.MaxFuel;
        }
        else
            gameObject.SetActive(false);
    }

    private void RefreshScore()
    {
        scoreText.text = ScoreManager.Instance.Score.ToString();
    }
}
