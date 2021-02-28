using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Slider _slider;

    private Player _stats;

    private void Start()
    {
        _stats = _player.GetComponent<Player>();
        _slider.maxValue = _stats._health;
    }

    public void SetSliderValue()
    {
        _slider.value = _stats._health;
    }
}
