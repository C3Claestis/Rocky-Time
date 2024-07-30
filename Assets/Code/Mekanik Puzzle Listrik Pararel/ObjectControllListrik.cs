using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class ObjectControllListrik : MonoBehaviour
    {
        [Header("Reference To MekanikPuzzleListrikPararel")]
        [SerializeField] MekanikPuzzleListrikPararel listrikPararel;

        [Header("Nilai Listrik Pararel Yang Akan Di Eksekusi")]
        [Range(1, 5)]
        [SerializeField] byte PararelNumbers;
        float valueRotasi;
        bool isInTrigger = false;
        float changeSpeed = 10f; // kecepatan perubahan

        // Start is called before the first frame update
        void Start()
        {
            valueRotasi = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (isInTrigger)
            {
                valueRotasi += changeSpeed * Time.deltaTime;
            }

            listrikPararel.SetRotasi(PararelNumbers, valueRotasi);
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isInTrigger = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isInTrigger = false;
            }
        }
    }
}
