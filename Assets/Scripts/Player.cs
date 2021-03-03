using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;

    public event UnityAction<float> HealthChange;

    public float _oneStepValue;
    private float _maxHealth;

    public float Health => _health;

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(Damage);
        _healButton.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(Damage);
        _healButton.onClick.RemoveListener(Heal);
    }

    private void Start()
    {
        _maxHealth = _health;
    }

    private void Heal()
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

    private void Damage()
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
