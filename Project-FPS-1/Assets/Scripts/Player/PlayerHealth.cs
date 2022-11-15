using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health, chipTimer;
    public float maxHealth = 100f, chipSpeed = 2f;
    public Slider frontHealth, backHealth;

    private void Start() {
        health = maxHealth;
        SetSliders();
    }
    private void SetSliders(){
        frontHealth.maxValue = maxHealth;
        backHealth.maxValue = maxHealth;
        frontHealth.value = maxHealth;
        backHealth.value = maxHealth;
    }
    private void Update() {
        health = Mathf.Clamp(health,0,maxHealth);
        UpdateHealthUI();
    }
    private void UpdateHealthUI(){
        //get slider values
        float frontvalue = frontHealth.value;
        float backvalue = backHealth.value;
        //check slider values
        if(backvalue > health){
            frontHealth.value = health;
            backHealth.GetComponentInChildren<Image>().color = Color.red;
            chipTimer += Time.deltaTime;
            float percentComplete = chipTimer/chipSpeed;
            percentComplete *= percentComplete;
            backHealth.value = Mathf.Lerp(backvalue,health,percentComplete);
        }
        else if(frontvalue < health){
            backHealth.value = health;
            backHealth.GetComponentInChildren<Image>().color = Color.green;
            chipTimer += Time.deltaTime;
            float percentComplete = chipTimer/chipSpeed;
            percentComplete *= percentComplete;
            frontHealth.value = Mathf.Lerp(frontvalue,health,percentComplete);
        }
    }
    public void TakeDamage(float value){
        health -= value;
        chipTimer = 0;
    }
    public void RestoreHealth(float value){
        health += value;
        chipTimer = 0;
    }
}
