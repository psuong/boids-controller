using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Boid {

    public class BoidController : MonoBehaviour {
        
        // Accessors
        public NavMeshAgent[] Boids { get { return boids; } }
        public Transform[] Transforms { get { return transforms; } }

        [Header("Spawning Properties")]
        public GameObject boidPrefab;
        public Vector3 spawnPosition;
        public Transform parent;
        public bool isBoidParented;

        [Header("Flock Properties")]
        [Tooltip("How fast does each boid move?")]
        public float speed = 10f;
        [Tooltip("How fast does each boid turn?")]
        public float angularSpeed = 120f;
        [Tooltip("What is the minimum distance for a boid to be an adjacent neighbor?")]
        public float neighborDistance = 50f;
        public float lookAheadDistance = 5f;
        [Tooltip("What is the size of the flock?")]
        public uint flockSize = 10;

        [Header("Boid Rules")]
        [Tooltip("What is the likelihood for the boids to have to same orientation?")]
        public float alignmentWeight = 0.4f;
        [Tooltip("What is the likelihood for the boids to move to a common goal?")]
        public float cohesionWeight = 0.5f;
        [Tooltip("What is the likelihood for the agents to be further apart?")]
        public float separationWeight = 0.6f;

#if UNITY_EDITOR
        [Header("Debug Options")]
        public Color destinationColor = new Color(1f, 0f, 0f, 0.25f);
        public Color desiredVelocityColor = new Color(0f, 0f, 1f, 0.25f);
#endif

        private NavMeshAgent[] boids; // A private array containing references to all of the boids
        private Transform[] transforms; // A private aray referencing the Transform information of the boids

        private void Start() {
            // Initialize the agents and the transforms
            boids = new NavMeshAgent[flockSize];
            transforms = new Transform[flockSize];
            
            for (int i = 0; i < flockSize; i++) {
                Vector3 position = new Vector3(Random.Range(-spawnPosition.x, spawnPosition.x), Random.Range(-spawnPosition.y, spawnPosition.y), Random.Range(-spawnPosition.z, spawnPosition.z));
                GameObject boid = (isBoidParented) ? Instantiate(boidPrefab, position, Quaternion.identity, parent) as GameObject: Instantiate(boidPrefab, position, Quaternion.identity) as GameObject;
                boids[i] = boid.GetComponent<NavMeshAgent>();
                transforms[i] = boid.transform;
            }
        }

        private void Update() {
            for (int i = 0; i < boids.Length; ++i) {
                // The rules are essentially Vector3 components
                Vector3 alignment, cohesion, separation;
                // Set the flock parameters
                SetFlockParameters(i, out alignment, out cohesion, out separation);

                Vector3 velocity = alignment * alignmentWeight + cohesion * cohesionWeight + separation * separationWeight;
                Vector3 destination = transforms[i].position + velocity * lookAheadDistance;
                if (!CanSetDestination(i, destination)) {
                    velocity *= -1;
                    CanSetDestination(i, destination);
                }
            }
        }

        private void SetFlockParameters(int index, out Vector3 alignment, out Vector3 cohesion, out Vector3 separation) {
            alignment = cohesion = separation = Vector3.zero;
            int neighborCount = 0;
            var boidTransform = transforms[index];

            for (int i = 0; i < boids.Length; ++i) {
                if (i != index) {
                    if (Vector3.Magnitude(transforms[i].position - boidTransform.position) < neighborDistance) {
                        alignment += boids[i].velocity;
                        cohesion += transforms[i].position;
                        separation += transforms[i].position - boidTransform.position;
                        neighborCount++;
                    }
                }
            }

            if (neighborCount == 0) { return; }
            // Normalize the vector components
            alignment = (alignment / neighborCount).normalized;
            cohesion = ((cohesion / neighborCount) - boidTransform.position).normalized;
            separation = ((separation / neighborCount) * -1).normalized;
        }

        private bool CanSetDestination(int index, Vector3 target) {
            if (boids[index].destination == target) {
                return true;
            }
            return boids[index].SetDestination(target);
        }
    }
}