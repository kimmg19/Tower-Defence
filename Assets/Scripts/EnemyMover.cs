using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] float waitTime = 1f;
    void Start() {
        StartCoroutine(PrintWayPoint());
    }

    IEnumerator PrintWayPoint() {
        foreach (WayPoint wayPoint in path) {
            print(wayPoint.name);
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
