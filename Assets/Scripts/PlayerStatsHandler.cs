using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsHandler : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;
    [Range(0, 1)]
    [SerializeField] private float _speed;
    [SerializeField] private float _oneStepValue;

    private HpBarHandler _hpBarHandler;
    public float _health;

    private void Update()
    {
        _hpBarHandler = GetComponent<HpBarHandler>();
    }

    public void Heal()
    {
        StartCoroutine(StartHeal());
    }

    private IEnumerator StartHeal()
    {
        float targetValue = _health + 10;
        while (_health < targetValue && _slider.value != _slider.maxValue)
        {
            _health += _oneStepValue;
            _hpBarHandler.SetSliderValue();
            _text.text = _health.ToString();
            yield return new WaitForSeconds(_speed);
        }
    }

    public void Damage()
    {
        StartCoroutine(StartDamage());
    }

    private IEnumerator StartDamage()
    {
        float targetValue = _slider.value - 10;
        while (_health > targetValue && _slider.value != 0)
        {
            _health -= _oneStepValue;
            _hpBarHandler.SetSliderValue();
            _text.text = _health.ToString();
            yield return new WaitForSeconds(_speed);
        }
    }
}
