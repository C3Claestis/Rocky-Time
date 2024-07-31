using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class MekanikPuzzlePushRun : MonoBehaviour
    {
        [SerializeField] List<TriggerButton> triggerButtons = new List<TriggerButton>();
        [SerializeField] Transform Barrier; // Objek barrier
        [SerializeField] Transform pointA; // Point atas
        [SerializeField] Transform pointB; // Point bawah
        private Vector2 targetPointDown; // Titik up
        private Vector2 targetPointUp; // Titik down
        private float speed = 1.0f;

        void Start()
        {
            targetPointUp = pointA.position;
            targetPointDown = pointB.position;
        }
        // Update is called once per frame
        void Update()
        {
            byte activeCount = 0;

            foreach (TriggerButton trigger in triggerButtons)
            {
                if (trigger.GetActive())
                {
                    activeCount++;
                }
            }

            if (activeCount == 5)
            {
                MoveTarget(targetPointUp);
            }
            else
            {
                MoveTarget(targetPointDown);
            }
        }
        void MoveTarget(Vector2 target)
        {
            Barrier.position = Vector2.MoveTowards(Barrier.position, target, speed * Time.deltaTime);

            if (Vector2.Distance(Barrier.position, target) < 0.1f)
            {
                Barrier.position = target;
            }
        }
    }
}
