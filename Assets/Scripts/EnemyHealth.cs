using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0;
    void Start() {
        currentHitPoints = maxHitPoints;
    }

    
    void OnParticleCollision(GameObject other) {
        print("Ãæµ¹");
        ProcessHit();
    }

    void ProcessHit() {
        currentHitPoints--;
        if(currentHitPoints <= 0) {
            Destroy(gameObject);
        }
    }

}
