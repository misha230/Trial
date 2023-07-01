using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private Transform rotatingLeaf;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float duration = 1.0f;
    [SerializeField] private float openAngle = -135.0f;
    private Coroutine _rotateCoroutine;
    
    private IEnumerator Rotate(float start, float end)
    {
        for (float i = 0; i < 1; i += Time.deltaTime / duration)
        {
            rotatingLeaf.transform.rotation = Quaternion.Lerp(
            Quaternion.Euler(0, start, 0),
            Quaternion.Euler(0, end, 0),
            animationCurve.Evaluate(i));

            yield return null;
        }

        rotatingLeaf.transform.rotation = Quaternion.Euler(0, end, 0);
        _rotateCoroutine = null;
    }

    private float GetCurrentAngle()
    {
        float currentAngle = Quaternion.Angle(Quaternion.identity, rotatingLeaf.transform.rotation);
        currentAngle *= openAngle > 0 ? 1 : -1;
        return currentAngle;
    }
    
    private enum DoorState
    {
        Undefined,
        Open,
        Close,
    }

    private DoorState GetDoorState(float angle)
    {
        if (Mathf.Approximately(0, angle))
            return DoorState.Close;

        if (Mathf.Approximately(openAngle, angle))
            return DoorState.Open;

        return DoorState.Undefined;
    }

    public void Open()
    {
        var currentAngle = GetCurrentAngle();
        
        if (GetDoorState(currentAngle) == DoorState.Open)
            return;

        if (_rotateCoroutine != null)
            StopCoroutine(_rotateCoroutine);

        _rotateCoroutine = StartCoroutine(Rotate(currentAngle, openAngle));
    }
    
    public void Close()
    {
        var currentAngle = GetCurrentAngle();
        
        if (GetDoorState(currentAngle) == DoorState.Close)
            return;

        if (_rotateCoroutine != null)
            StopCoroutine(_rotateCoroutine);

        _rotateCoroutine = StartCoroutine(Rotate(currentAngle, 0));
    }

    public void Toggle()
    {
        var currentAngle = GetCurrentAngle();
        if (GetDoorState(currentAngle) == DoorState.Close)
            Open();
        else if (GetDoorState(currentAngle) == DoorState.Open)
            Close();
    }
}
