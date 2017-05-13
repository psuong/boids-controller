using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Boid {
    
    public class BoidController : MonoBehaviour {
        [Header("Flock Properties")]
        [Tooltip("How fast does each boid move?")]
        public float speed = 10f;
        [Tooltip("How fast does each boid turn?")]
        public float angularSpeed = 120f;
        [Tooltip("What is the size of the flock?")]
        public uint flockSize = 10;

        [Header("Boid Rules")]
        [Tooltip("What is the likelihood for the boids to have to same orientation?")]
        public float alignmentWeight = 0.4f;
        [Tooltip("What is the likelihood for the boids to move to a common goal?")]
        public float cohesionWeight = 0.5f;
        [Tooltip("What is the likelihood for the agents to be further apart?")]
        public float separationWeight = 0.6f;
        
        private NavMeshAgent[] boids;
        private Transform[] transforms;

        private void Start() {
            // Initialize the agents and the transforms
            boids = new NavMeshAgent[flockSize];
            transforms = new Transform[flockSize];

        }

        private void Update() {
        }

        private void Spawn() {
        }
    }
}