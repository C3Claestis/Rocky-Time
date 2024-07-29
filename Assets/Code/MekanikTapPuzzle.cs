using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MekanikTapPuzzle : MonoBehaviour
{
    [SerializeField] Transform pointA; // Titik pertama
    [SerializeField] Transform pointB; // Titik kedua
    [SerializeField] Transform buttonMekanik;
    bool isSolve = false;
    float speed = 1.5f; // Kecepatan pergerakan

    public void SetSolve(bool isSolves) => this.isSolve = isSolves;
    private Vector3 targetPoint; // Titik tujuan saat ini

    void Start()
    {
        // Mulai dengan bergerak ke titik B
        targetPoint = pointB.position;
    }

    void Update()
    {
        if (isSolve)
        {
            MoveButtonDown();
        }
    }
    void MoveButtonDown()
    {
        // Gerakkan objek menuju target point
        buttonMekanik.position = Vector3.MoveTowards(buttonMekanik.position, targetPoint, speed * Time.deltaTime);

        // Jika objek sudah dekat dengan target point, ubah target point ke titik yang lain
        if (Vector3.Distance(buttonMekanik.position, targetPoint) < 0.1f)
        {
            buttonMekanik.position = targetPoint;
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
}
