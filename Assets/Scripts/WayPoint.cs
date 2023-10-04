using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable = true;

    public bool IsPlaceable {
        get {
            return isPlaceable;
        }
    }

    private void OnMouseDown() {
        if (isPlaceable) {
            bool isPlaced=towerPrefab.CreateTower(towerPrefab,transform.position);
            isPlaceable = !isPlaced;
        }            
    }
}