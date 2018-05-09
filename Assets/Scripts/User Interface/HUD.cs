using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] private Text distanceText;
    [SerializeField] private Image fuelBar;

    void Update()
    {
        if (!LevelManager.Instance.GameOver)
        {
            distanceText.text = playerTrans.position.z.ToString("0") + " m";
            fuelBar.fillAmount = FuelManager.Instance.FuelAmount / FuelManager.Instance.MaxFuel;
        }
        else
            gameObject.SetActive(false);
    }
}
