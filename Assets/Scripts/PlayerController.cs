using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Скорость передвижение игрока")]
    public float speed = 0.3f;


    private void Update()
    {
        GetInput(KeyCode.W, transform.forward);
        GetInput(KeyCode.S, -transform.forward);
        GetInput(KeyCode.A, -transform.right);
        GetInput(KeyCode.D, transform.right);
    }

    private void GetInput(KeyCode key, Vector3 trans)
    {
        if (!Input.GetKey(key)) return;

        transform.localPosition += trans * (speed * Time.deltaTime);
    }
}