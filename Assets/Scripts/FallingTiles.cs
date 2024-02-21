using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTiles : MonoBehaviour
{
    private Rigidbody rbTile;

    // Start is called before the first frame update
    void Start()
    {
        rbTile = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");

        if (other.CompareTag("Player"))
        {
            rbTile.isKinematic = false;
            rbTile.AddForce(new Vector3(0, -500, 0));
            Debug.Log("Wrong Tile");

            StartCoroutine(DestroyTile());
        }
    }

    private IEnumerator DestroyTile()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
