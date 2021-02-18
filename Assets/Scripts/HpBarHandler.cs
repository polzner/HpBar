using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpBarHandler : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;
    [SerializeField] private Text _text;

    private PlayerStatsHandler _stats;

    private void Start()
    {
        _stats = _player.GetComponent<PlayerStatsHandler>();
        _slider.maxValue = _stats._health;
        _text.text = _slider.value.ToString();
    }

    public void SetSliderValue()
    {
        _slider.value = _stats._health;
        Mathf.MoveTowards(_slider.value, _stats._health, 0.01f);
    }

    public void Heal()
    {
        StartCoroutine(StartHeal());
    }

    private IEnumerator StartHeal()
    {
        float targetValue = _stats._health;
        float oneStepValue = _stats._oneStepValue;
        while (_slider.value < targetValue && _slider.value != _slider.maxValue)
        {
            _slider.value += oneStepValue;
            _text.text = _slider.value.ToString();
            yield return new WaitForSeconds(_speed);
        }
    }

    public void Damage()
    {
        StartCoroutine(StartDamage());
    }

    private IEnumerator StartDamage()
    {
        float targetValue = _stats._health;
        float oneStepValue = _stats._oneStepValue;
        while (_slider.value > targetValue && _slider.value != 0)
        {
            _slider.value -= oneStepValue;
            _text.text = _slider.value.ToString();
            yield return new WaitForSeconds(_speed);
        }
    }

}
