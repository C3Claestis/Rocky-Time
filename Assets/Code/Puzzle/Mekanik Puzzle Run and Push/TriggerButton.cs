using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Puzzle
{
    public class TriggerButton : MonoBehaviour
    {
        [SerializeField] Transform Objek; // Objek
        [SerializeField] Transform pointA; // Point atas
        [SerializeField] Transform pointB; // Point bawah
        private Vector2 targetPointDown; // Titik up
        private Vector2 targetPointUp; // Titik down
        private float speed = 1.0f;
        private bool isSolve = false;
        private bool isActive = false;
        // Start is called before the first frame update
        void Start()
        {
            targetPointUp = pointA.position;
            targetPointDown = pointB.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (isSolve)
            {
                MoveTarget(targetPointDown);
            }
            else
            {
                MoveTarget(targetPointUp);
            }
        }
        void MoveTarget(Vector2 target)
        {
            Objek.position = Vector2.MoveTowards(Objek.position, target, speed * 2 * Time.deltaTime);

            if (Vector2.Distance(Objek.position, target) < 0.1f)
            {
                Objek.position = target;
            }
        }

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Player") || collider2D.CompareTag("Environment"))
            {
                isSolve = true;
                isActive = true;
            }
        }
        void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Player") || collider2D.CompareTag("Environment"))
            {
                isSolve = false;
                isActive = false;
            }
        }
        void OnDrawGizmos()
        {
            // Gambar garis antara pointA dan pointB
            if (pointA != null && pointB != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(pointA.position, pointB.position);
            }
        }
        public bool GetActive() => isActive;
    }
}
