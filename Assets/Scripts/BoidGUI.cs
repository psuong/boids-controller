using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boid;
using TMPro;
using System.Linq;

public class BoidGUI : MonoBehaviour {

    public delegate void InitHandler();
    public static event InitHandler OnInitEvent;

    public BoidController BoidController { get { return boidController; } }

    public TMP_InputField separation;
    public TMP_InputField cohesion;
    public TMP_InputField alignment;
    public TMP_InputField flockSize;
    public TMP_InputField neighborDistance;
    public TMP_InputField viewDistance;

    private BoidController boidController;

    private void Start() {
        boidController = FindObjectOfType<BoidController>();

        separation.text = boidController.separationWeight.ToString();
        cohesion.text = boidController.cohesionWeight.ToString();
        alignment.text = boidController.alignmentWeight.ToString();

        flockSize.text = boidController.flockSize.ToString();
        neighborDistance.text = boidController.neighborDistance.ToString();
        viewDistance.text = boidController.lookAheadDistance.ToString();
    }
    
    private bool IsAllNumeric(string text) {
        return !text.Any(x => char.IsLetter(x));
    }

    private float? GetParamValue(string text) {
        if (IsAllNumeric(text)) {
            return float.Parse(text);
        }
        return null;
    }

    private float SetValue(string text) {
        float? value = GetParamValue(text);
        return (value != null) ? (float)value : 0f;
    }

    public void SetAlignment(string text) {
        BoidController.alignmentWeight = SetValue(text);
    }

    public void SetCohesion(string text) {
        BoidController.cohesionWeight = SetValue(text);
    }

    public void SetSeparation(string text) {
        BoidController.separationWeight = SetValue(text);
    }

    public void StartDemo() {
        if (OnInitEvent != null) {
            OnInitEvent();
        }
    }
}
