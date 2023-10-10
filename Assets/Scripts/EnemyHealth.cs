using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] int maxHitPoints = 5;          //적 최대 체력
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;      //적 현재 체력

    Enemy enemy;
    void OnEnable() {
        currentHitPoints = maxHitPoints;
    }
    void Start() {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    void ProcessHit() {
        currentHitPoints--;
        if (currentHitPoints <= 0) {
            maxHitPoints += difficultyRamp;
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }

}
