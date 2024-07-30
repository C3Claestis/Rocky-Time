using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class MekanikPuzzleListrikPararel : MonoBehaviour
    {
        [Header("Saklar Putar")]
        [SerializeField] List<Transform> SaklarSambunganI = new List<Transform>();
        [SerializeField] List<Transform> SaklarSambunganII = new List<Transform>();
        [SerializeField] List<Transform> SaklarSambunganIII = new List<Transform>();
        [SerializeField] List<Transform> SaklarSambunganIV = new List<Transform>();
        [SerializeField] List<Transform> SaklarSambunganV = new List<Transform>();

        [Header("Jumlah Sambungan Yang Di Putar")]
        [Range(1, 5)]
        [SerializeField] byte JumlahSambungan;

        private Dictionary<byte, float> rotasiValues = new Dictionary<byte, float>();
        private Dictionary<byte, List<Transform>> saklarSambungans = new Dictionary<byte, List<Transform>>();

        private void Awake()
        {
            rotasiValues[1] = 0f;
            rotasiValues[2] = 0f;
            rotasiValues[3] = 0f;
            rotasiValues[4] = 0f;
            rotasiValues[5] = 0f;

            saklarSambungans[1] = SaklarSambunganI;
            saklarSambungans[2] = SaklarSambunganII;
            saklarSambungans[3] = SaklarSambunganIII;
            saklarSambungans[4] = SaklarSambunganIV;
            saklarSambungans[5] = SaklarSambunganV;
        }

        public void SetRotasi(byte index, float rotasi)
        {
            if (rotasiValues.ContainsKey(index))
            {
                rotasiValues[index] = rotasi;
            }
        }
        // Update is called once per frame
        void Update()
        {
            for (byte i = 1; i <= JumlahSambungan; i++)
            {
                ActiveSaklar(saklarSambungans[i], rotasiValues[i]);
            }
        }

        void ActiveSaklar(List<Transform> saklar, float valueRotasi)
        {
            foreach (Transform saklars in saklar)
            {
                saklars.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, valueRotasi);
            }
        }
    }
}
