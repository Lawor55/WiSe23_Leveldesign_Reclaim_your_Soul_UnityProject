using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform teleportGoal;
    [SerializeField] private GameObject endTeleportGoal;
    [SerializeField] private bool flipViewDirection;

    [SerializeField] private GameObject riddleEntraceTeleporter;

    [SerializeField] private GameObject[] endOfGameObjects;
    [SerializeField] private bool isEndOfRiddleTeleporter = false;

    //[SerializeField] private bool ignoreModX;
    //[SerializeField] private bool ignoreModZ;
    //private TorchFlicker torchFlicker;

    private GameObject player;
    private CharacterController characterController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();
        //torchFlicker = player.GetComponentInChildren<TorchFlicker>();
        //Debug.Log("Teleporter.cs\nName: " + transform.name + "\nPosition: " + transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isEndOfRiddleTeleporter)
            {
                riddleEntraceTeleporter.SetActive(false);
                gameObject.SetActive(false);

                GameObject[] totalRiddleExits;
                totalRiddleExits = GameObject.FindGameObjectsWithTag("End of Game Teleporter");
                Debug.Log(totalRiddleExits.Length + " Keys left!");
                if (totalRiddleExits.Length <= 0)
                {
                    foreach (var endOfGameObject in endOfGameObjects)
                    {
                        endOfGameObject.SetActive(!endOfGameObject.activeInHierarchy);
                        //Debug.Log("Active state of " + endOfGameObject.name + " is: " + endOfGameObject.activeInHierarchy);
                    }
                    Teleport(endTeleportGoal.transform, transform);
                }
                else
                {
                    Teleport(teleportGoal, transform);
                }
            }
            else
            {
                Teleport(teleportGoal, transform);
            }
            //torchFlicker.Flicker();
        }
    }

    public void Teleport(Transform teleportGoal, Transform originPosition)
    {
        //preperation of positional modifier
        //Vector3 goalPosition = teleportGoal.position;
        Vector3 goalPosition;
        Vector3 relativePlayerPosition = player.transform.position - originPosition.position;
        if (flipViewDirection)
        {
            goalPosition = teleportGoal.position - relativePlayerPosition;
            goalPosition.y = teleportGoal.position.y + relativePlayerPosition.y;
        }
        else
        {
            goalPosition = teleportGoal.position + relativePlayerPosition;
        }

        //if (ignoreModX)
        //{
        //    goalPosition.x = player.transform.position.x;
        //}
        //if (ignoreModZ)
        //{

        //    goalPosition.z = player.transform.position.z;
        //}

        //preperation of rotation modifier
        Quaternion relativePlayerRotation = Quaternion.Euler(player.transform.rotation.eulerAngles - transform.rotation.eulerAngles);
        //Quaternion goalRotation = player.transform.rotation;
        Quaternion goalRotation = Quaternion.Euler(teleportGoal.rotation.eulerAngles + relativePlayerRotation.eulerAngles);
        if (flipViewDirection)
        {
            goalRotation.eulerAngles = new Vector3(goalRotation.eulerAngles.x, goalRotation.eulerAngles.y + 180, goalRotation.eulerAngles.z);
        }

        //teleportation gets applied
        characterController.enabled = false;
        player.transform.SetPositionAndRotation(goalPosition, goalRotation);
        characterController.enabled = true;
        //Debug.Log("Teleport\n" + "Relative Player Position: " + relativePlayerPosition + "\n" + "Relative Player Rotation: " + relativePlayerRotation);
    }
}
