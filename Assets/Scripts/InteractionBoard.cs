using System;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionBoard : MonoBehaviour
{
    private Rigidbody _rb;
    private RaycastHit _hit;
    public float distance = 2f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void ItemPosition()
    {
         if (!Physics.Raycast(transform.position, transform.forward, out _hit, distance)) return;
         if (_hit.transform.tag != "ItemPosition") return;
         
         transform.parent = null;
         _rb.isKinematic = false;
         _rb.detectCollisions = true;
         _rb.freezeRotation = true;

         transform.eulerAngles = new Vector3(90f, 90f, 0f);
         transform.position = new Vector3(-24.9f, -0.137f, -0.3f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) ItemPosition();
    }
}
