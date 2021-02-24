using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;
    [SerializeField] private UnityEvent SomeEvent;

    public float _health;
    public float _oneStepValue;
    private float _maxHealth;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void Heal()
    {
        StartCoroutine(StartHeal());
    }

    private IEnumerator StartHeal()
    {
        float targetValue = _health + 10;
        while (_health < targetValue && _health != _maxHealth)
        {
            _health += _oneStepValue;
            SomeEvent.Invoke();
            yield return new WaitForSeconds(_speed);
        }
    }

    public void Damage()
    {
        StartCoroutine(StartDamage());
    }

    private IEnumerator StartDamage()
    {
        float targetValue = _health - 10;
        while (_health > targetValue && _health != 0)
        {
            _health -= _oneStepValue;
            SomeEvent.Invoke();
            yield return new WaitForSeconds(_speed);
        }
    }
}
