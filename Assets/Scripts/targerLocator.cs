using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targerLocator : MonoBehaviour {
    Transform target;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    [SerializeField] Transform weapon;
    void Start() {
        target = FindObjectOfType<Enemy>().transform;
    }

    void Update() {
        FIndClosestTarget();
        AimWeapon();
    }

    private void FIndClosestTarget() {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float maxDistance = Mathf.Infinity;
        Transform closestTarget = null;
        foreach (Enemy enemy in enemies) {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance) {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon() {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        if (targetDistance < range) Attack(true);
        else Attack(false);
        weapon.LookAt(target);
    }

    private void Attack(bool isActive) {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
