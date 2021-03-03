using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _health;

    public event UnityAction<float> HealthChange;

    public float _oneStepValue;
    private float _maxHealth;

    public float Health => _health;

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
            HealthChange.Invoke(_health);
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
            HealthChange.Invoke(_health);
            yield return new WaitForSeconds(_speed);
        }
    }
}
