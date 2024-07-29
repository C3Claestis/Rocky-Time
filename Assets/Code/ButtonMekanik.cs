using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonMekanik : MonoBehaviour
{
    [SerializeField] MekanikTapPuzzle mekanikTapPuzzle;
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Environment"))
        {
            mekanikTapPuzzle.SetSolve(true);
            Debug.Log("SOLVEPUZZLE");
        }
    }
}
