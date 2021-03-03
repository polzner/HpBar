using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Text _text; 
    [SerializeField] private Player _player;

    private void Start()
    {
        _text.text = _player.Health.ToString();
    }

    private void OnEnable()
    {
        _player.HealthChange += UpdateText;
    }

    private void OnDisable()
    {
        _player.HealthChange += UpdateText;
    }

    public void UpdateText(float health)
    {
        _text.text = health.ToString();
    }
}
