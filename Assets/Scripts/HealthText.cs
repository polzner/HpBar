using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Text _text; 
    [SerializeField] private Player _stats;

    public void UpdateText()
    {
        _text.text = _stats._health.ToString();
    }
}
