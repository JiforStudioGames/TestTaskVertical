using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI hpTextStatus;
    
    private Enemy _enemy;
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();

        healthSlider.maxValue = _enemy.hp;
        healthSlider.value = _enemy.hp;
        
        hpTextStatus.text = $"Hp: {_enemy.hp}/{_enemy.currentHp}";
    }

    private void OnEnable()
    {
        _enemy.onHpChange += UpdateStatusHp;
    }

    private void OnDisable()
    {
        _enemy.onHpChange -= UpdateStatusHp;
    }

    private void UpdateStatusHp(int newHp)
    {
        healthSlider.value = newHp;
        hpTextStatus.text = $"Hp: {newHp}/{_enemy.hp}";
    }
}
