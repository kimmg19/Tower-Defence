using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targerLocator : MonoBehaviour
{
    Transform target;
    [SerializeField] Transform weapon;
    void Start()
    {
        target=FindObjectOfType<EnemyMover>().transform;
    }

    void Update()
    {
        AimWeapon();
    }

    private void AimWeapon() {
        weapon.LookAt(target);
    }
}
