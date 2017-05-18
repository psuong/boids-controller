using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using Boid;

[CustomEditor(typeof(BoidController))]
public class BoidInspector : Editor {

    private BoidController boidController;

    private void OnEnable() {
        boidController = (BoidController)target;
    }

    private void OnDisable() {
        
    }

    private void OnSceneGUI() {
        DrawDestination();
    }

    private void DrawDestination() {
        NavMeshAgent[] boids = boidController.Boids;
        // Transform[] transforms = boidController.Transforms;

        try {
            foreach (var boid in boids) {
                // Get the desired velocity
                Vector3 desiredVelocity = boid.transform.position + boid.desiredVelocity;

                Handles.color = boidController.destinationColor;
                Handles.DrawLine(boid.transform.position, boid.destination);
                Handles.color = boidController.desiredVelocityColor;
                Handles.DrawDottedLine(boid.transform.position, desiredVelocity, 10f);
            }
        } catch (System.NullReferenceException) {
            return;
        }
    }
}
