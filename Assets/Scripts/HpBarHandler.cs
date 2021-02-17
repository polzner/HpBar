using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarHandler : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Slider _slider;

    private PlayerStatsHandler _stats;

    private void Start()
    {
        _stats = _player.GetComponent<PlayerStatsHandler>();
        _slider.maxValue = _stats._health;
    }

    public void SetSliderValue()
    {
        _slider.value = _stats._health;
    }

}
