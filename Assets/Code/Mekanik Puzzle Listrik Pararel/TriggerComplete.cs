using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Puzzle
{
    public class TriggerComplete : MonoBehaviour
    {
        public bool isComplete;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Ujung")
            {
                isComplete = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.name == "Ujung")
            {
                isComplete = false;
            }
        }
    }
}