using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorInteraction door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.Open();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            door.Close();
        }
    }
}
