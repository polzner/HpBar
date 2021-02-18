using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsHandler : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public float _health;
    public float _oneStepValue;
    private float _maxHealth;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void Heal()
    {
        if(_health + _oneStepValue < _maxHealth)
        {
            _health += 10;
        }
    }

    public void Damage()
    {
        if (_health - _oneStepValue > 0)
        {
            _health -= 10;
        }
    }
}
