using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnd : MonoBehaviour
{
    [SerializeField] private GameObject riddleEntraceTeleporter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            riddleEntraceTeleporter.SetActive(false);
        }
    }
}
