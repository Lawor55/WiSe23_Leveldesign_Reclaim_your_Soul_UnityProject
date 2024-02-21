using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnd : MonoBehaviour
{
    [SerializeField] private GameObject riddleEntraceTeleporter;
    private GameObject continueAfterRiddleTeleporter;

    private GameObject player;
    private CharacterController characterController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();
        continueAfterRiddleTeleporter = GameObject.Find("End_of_Game_Exit");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            riddleEntraceTeleporter.SetActive(false);
            gameObject.SetActive(false);

            PuzzleEnd[] totalRiddleExits;
            totalRiddleExits = FindObjectsOfType<PuzzleEnd>(false);
            Debug.Log(totalRiddleExits.Length+" to go!");
            if (totalRiddleExits.Length <= 0)
            {
                characterController.enabled = false;
                player.transform.SetPositionAndRotation(continueAfterRiddleTeleporter.transform.position, continueAfterRiddleTeleporter.transform.rotation);
                characterController.enabled = true;
            }
        }
    }
}
