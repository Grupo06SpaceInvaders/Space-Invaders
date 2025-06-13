using TMPro;
using UnityEngine;

public class PlayerHealthListner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healtText;

    private void OnEnable()
    {
        PlayerHealth.OnLifeChanged += LifeChanged;
    }

    private void OnDisable()
    {
        PlayerHealth.OnLifeChanged -= LifeChanged;
    }

    private void LifeChanged(int value)
    {
        healtText.text = $"Life : {value}";
    }
}