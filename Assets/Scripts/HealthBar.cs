using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void SetHealth(float ratio)
    {
        fillImage.fillAmount = Mathf.Clamp01(ratio);
    }
}
