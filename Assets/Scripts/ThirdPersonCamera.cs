using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 7.5f;
    private float currentX = 0f;
    private float currentY = 10f;
    [SerializeField]
    private Vector3 velocidad;
    [SerializeField]
    private float tiempo;
    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;

    }

    private void LateUpdate()
    {
        if (!GameManager.Instance.GameOver)
        {
            Vector3 direction = new Vector3(0f, 3f, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            camTransform.position = Vector3.SmoothDamp(transform.position, (lookAt.position + rotation * direction), ref velocidad, tiempo);
        }
    }
}