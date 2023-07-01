using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public new GameObject camera;
    public Transform trans;
    private Rigidbody _rb;
    private RaycastHit _hit;
    public float distance = 2f;
    [SerializeReference] private bool flag;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void PickUp()
    {
        if (!Physics.Raycast(camera.transform.position, camera.transform.forward, out _hit, distance)) return;
        if (_hit.transform.tag != "Item") return;
        if (transform.childCount >= 1) return;

        transform.SetParent(trans);
        transform.position = trans.position;
        transform.localEulerAngles = new Vector3(25f, 0f, 0f);
        _rb.isKinematic = true;
        _rb.detectCollisions = false;
        flag = true;
    }

    private void Drop()
    {
        if (flag)
        {
            transform.parent = null;
            _rb.isKinematic = false;
            _rb.detectCollisions = true;
            flag = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.G)) Drop();
    }
}
