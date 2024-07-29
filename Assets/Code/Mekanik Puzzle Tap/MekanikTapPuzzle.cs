using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MekanikTapPuzzle : MonoBehaviour
{
    [Header("Point Moving Button")]
    [SerializeField] Transform pointA; // Titik pertama
    [SerializeField] Transform pointB; // Titik kedua
    [Header("Point Barrier")]    
    [SerializeField] Transform pointBarrierUp; // Titik Barrier up
    [Header("Button Object")]
    [SerializeField] Transform buttonMekanik; // Button Untuk Solve puzzle
    [Header("Barrier Object")]
    [SerializeField] Transform Barrier; // Barrier objek
    bool isSolve = false;
    float speed = 1.0f; // Kecepatan pergerakan

    private Vector2 targetPoint; // Titik tujuan saat ini
    private Vector2 targetPointBarrierUp; // Titik tujuan dari barrier up
    void Start()
    {
        // Mulai dengan bergerak ke titik B
        targetPoint = pointB.position;
        targetPointBarrierUp = pointBarrierUp.position;
    }

    void Update()
    {
        if (isSolve)
        {
            MoveButtonDown();
            BarrierUp();
        }
    }
    void BarrierUp()
    {
        Barrier.position = Vector3.MoveTowards(Barrier.position, targetPointBarrierUp, speed * 2 * Time.deltaTime);

        if (Vector3.Distance(Barrier.position, targetPointBarrierUp) < 0.1f)
        {
            Barrier.position = targetPointBarrierUp;
            isSolve = false;
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

    public void SetSolve(bool isSolves) => this.isSolve = isSolves;
}
