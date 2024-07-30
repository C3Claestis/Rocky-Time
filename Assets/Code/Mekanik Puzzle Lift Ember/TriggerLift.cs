using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class TriggerLift : MonoBehaviour
    {
        [SerializeField] MekanikLiftEmberPuzzle liftEmberPuzzle;
        private int CountPlayer = 1;
        private HashSet<Collider2D> triggerColliders = new HashSet<Collider2D>();

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                triggerColliders.Add(other);

                if (triggerColliders.Count == CountPlayer)
                {
                    liftEmberPuzzle.SetSolve(true);
                    liftEmberPuzzle.SetIsNotSolve(false);
                    Debug.Log("Player Active : " + triggerColliders.Count);
                }
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                triggerColliders.Remove(other);
                liftEmberPuzzle.SetIsNotSolve(true);
            }
        }
    }
}
