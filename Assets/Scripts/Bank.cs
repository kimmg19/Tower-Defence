using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Bank : MonoBehaviour
{
    [SerializeField] int startngBalance = 150;
    [SerializeField]int currentBalance;
    [SerializeField] TextMeshProUGUI diaplayBalance;
    public int CurrentBalance {
        get {
            return currentBalance;
        }
        
    }

    void Awake() {
        currentBalance = startngBalance;
        UpdateDisplay();
    }
    public void Deposit(int amount) {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();

    }

    public void Withdraw(int amount) {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        if (currentBalance< 0) {
            ReloadScene();
        }
    }
    void UpdateDisplay() {
        diaplayBalance.text = "Gold: " + currentBalance;
    }

    private void ReloadScene() {
        Scene currentScene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
