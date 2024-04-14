using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Heath _heath;

    private Slider _slider;
    void Start()
    {
        _slider = GetComponent<Slider>();

        _heath.OnChangeHealth.AddListener(SetValue);
    }


    private void SetValue(float value)
    {
        _slider.value = value / _heath.MaxHealth;
    }
}
