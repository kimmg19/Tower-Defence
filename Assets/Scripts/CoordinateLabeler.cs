using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour {

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint wayPoint;

    void Awake() {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DiaplayCoordinates();
        wayPoint = GetComponentInParent<WayPoint>();
    }

    void Update() {
        if (!Application.isPlaying) {
            DiaplayCoordinates();
            UpdateObjectName();
        }
        ColorCoordinates();
        ToggleLables();
    }

    private void ToggleLables() {
        if(Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.IsActive(); 
        }
    }

    void ColorCoordinates() {
        if (wayPoint.IsPlaceable) {
            label.color = defaultColor;
        } else {
            label.color = blockedColor;
        }
        

    }

    void DiaplayCoordinates() {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + ", " + coordinates.y;
    }
    void UpdateObjectName() {
        transform.parent.name = coordinates.ToString();
    }
}
