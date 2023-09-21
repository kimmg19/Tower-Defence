using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable = true;

    private void OnMouseDown() {
        if (isPlaceable)
            Instantiate(towerPrefab, gameObject.transform.position, Quaternion.identity);
        isPlaceable = false;
    }
}