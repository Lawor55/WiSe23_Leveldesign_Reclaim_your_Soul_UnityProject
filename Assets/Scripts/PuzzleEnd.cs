using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnd : MonoBehaviour
{
    [SerializeField] private GameObject riddleEntraceTeleporter;

    [SerializeField] private GameObject[] endOfGameObjects;

    //private GameObject player;
    //private CharacterController characterController;

    //private void Start()
    //{
    //    //player = GameObject.FindGameObjectWithTag("Player");
    //    //characterController = player.GetComponent<CharacterController>();
    //    //Debug.Log("PuzzleEnd.cs\nName: " + transform.name + "\nPosition: " + transform.position);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            riddleEntraceTeleporter.SetActive(false);
            gameObject.SetActive(false);

            PuzzleEnd[] totalRiddleExits;
            totalRiddleExits = FindObjectsOfType<PuzzleEnd>(false);
            Debug.Log(totalRiddleExits.Length + " Keys left!");
            if (totalRiddleExits.Length <= 0)
            {
                foreach (var endOfGameObject in endOfGameObjects)
                {
                    endOfGameObject.SetActive(!endOfGameObject.activeInHierarchy);
                    Debug.Log("Active state of " + endOfGameObject.name + " is: " + endOfGameObject.activeInHierarchy);
                }
            }
            //characterController.enabled = false;
            //player.transform.SetPositionAndRotation(continueAfterRiddleTeleporter.transform.position, Quaternion.Euler(continueAfterRiddleTeleporter.transform.rotation.eulerAngles + new Vector3(0,90,0)));
            //characterController.enabled = true;
        }
    }
}
