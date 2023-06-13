using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public new GameObject camera;
    public float distance = 15f;
    private GameObject _currentItem;
    private bool _canPickUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.G)) Drop();
    }

    private void PickUp()
    {
        RaycastHit hit;

        if (!Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance)) return;
        if (hit.transform.tag != "Item") return;
        if (_canPickUp) Drop();

        _currentItem = hit.transform.gameObject;
        _currentItem.GetComponent<Rigidbody>().isKinematic = true;
        _currentItem.transform.parent = transform;
        _currentItem.transform.localPosition = Vector3.zero;
        _currentItem.transform.localEulerAngles = new Vector3(25f, 0f, 0f);
        _canPickUp = true;
    }

    private void Drop()
    {
        _currentItem.transform.parent = null;
        _currentItem.GetComponent<Rigidbody>().isKinematic = false;
        _canPickUp = false;
        _currentItem = null;
    }
}
