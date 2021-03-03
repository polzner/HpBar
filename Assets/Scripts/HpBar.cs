using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = _player.Health;
    }

    private void OnEnable()
    {
        _player.HealthChange += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChange -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        _slider.value = health;
    }
}
