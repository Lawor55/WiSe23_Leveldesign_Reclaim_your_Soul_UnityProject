using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
