using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class MekanikLiftEmberPuzzle : MonoBehaviour
    {
        [Header("Point Move")]
        [SerializeField] Transform pointUp;
        [SerializeField] Transform pointDown;

        [Header("Katrol Object & Lift Object")]
        [SerializeField] Transform KatrolPoint;
        [SerializeField] Transform LiftObject;

        [Header("Rope Line Renderer")]
        [SerializeField] LineRenderer lineRenderer;
        private Vector2 targetPointUp;
        private Vector2 targetPointDown;
        private float speed = 1.0f;
        private bool isSolve = false;
        private bool isNotSolve = true;
        // Start is called before the first frame update
        void Start()
        {
            targetPointUp = pointUp.position;
            targetPointDown = pointDown.position;
            lineRenderer.positionCount = 2;
        }

        // Update is called once per frame
        void Update()
        {
            if (isSolve)
            {
                MoveLift();
            }

            UpdateLineRenderer();
        }

        void MoveLift()
        {
            if (!isNotSolve)
            {
                LiftObject.position = Vector2.MoveTowards(LiftObject.position, targetPointUp, speed * Time.deltaTime);

                if (Vector2.Distance(LiftObject.position, targetPointUp) < 0.1f)
                {
                    LiftObject.position = targetPointUp;
                }
            }
            else
            {
                LiftObject.position = Vector2.MoveTowards(LiftObject.position, targetPointDown, speed * Time.deltaTime);

                if (Vector2.Distance(LiftObject.position, targetPointDown) < 0.1f)
                {
                    LiftObject.position = targetPointDown;
                    isSolve = false;
                }
            }
        }

        void UpdateLineRenderer()
        {
            // Atur posisi titik-titik pada LineRenderer
            lineRenderer.SetPosition(0, KatrolPoint.position);
            lineRenderer.SetPosition(1, LiftObject.position);
        }
        public void SetSolve(bool solved) => this.isSolve = solved;
        public void SetIsNotSolve(bool solved) => this.isNotSolve = solved;
    }
}