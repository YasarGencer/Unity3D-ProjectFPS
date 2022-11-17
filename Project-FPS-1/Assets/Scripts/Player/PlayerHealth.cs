using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float _health, _chipTimer;
    [SerializeField] private float _maxHealth = 100f, _chipSpeed = 2f;
    [SerializeField] private Slider _backHealth, _frontHealth;

    private void Start() {
        _health = _maxHealth;
        SetSliders();
    }
    private void SetSliders(){
        _frontHealth.maxValue = _maxHealth;
        _backHealth.maxValue = _maxHealth;
        _frontHealth.value = _maxHealth;
        _backHealth.value = _maxHealth;
    }
    private void Update() {
        _health = Mathf.Clamp(_health,0,_maxHealth);
        UpdateHealthUI();
    }
    private void UpdateHealthUI(){
        //get slider values
        float frontvalue = _frontHealth.value;
        float backvalue = _backHealth.value;
        //check slider values
        if(backvalue > _health){
            _frontHealth.value = _health;
            _backHealth.GetComponentInChildren<Image>().color = Color.red;
            _chipTimer += Time.deltaTime;
            float percentComplete = _chipTimer/_chipSpeed;
            percentComplete *= percentComplete;
            _backHealth.value = Mathf.Lerp(backvalue,_health,percentComplete);
        }
        else if(frontvalue < _health){
            _backHealth.value = _health;
            _backHealth.GetComponentInChildren<Image>().color = Color.green;
            _chipTimer += Time.deltaTime;
            float percentComplete = _chipTimer/_chipSpeed;
            percentComplete *= percentComplete;
            _frontHealth.value = Mathf.Lerp(frontvalue,_health,percentComplete);
        }
    }
    public void TakeDamage(float value){
        _health -= value;
        _chipTimer = 0;
    }
    public void RestoreHealth(float value){
        _health += value;
        _chipTimer = 0;
    }
}
