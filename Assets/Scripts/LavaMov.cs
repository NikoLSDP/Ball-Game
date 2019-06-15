using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMov : MonoBehaviour {
    [SerializeField]
    private float objectSpeed = 1f;
    [SerializeField]
    private float resetPosition = -31.4f;
    [SerializeField]
    private float startPositionX = 7.1f;
    [SerializeField]
    private float startPositionY = -1f;
    [SerializeField]
    private float startPositionZ = 36.1f;

    protected virtual void Update()
    {
        transform.Translate(Vector3.back * (objectSpeed * Time.deltaTime));

        if (transform.localPosition.z <= resetPosition)
        {
            Vector3 newPos = new Vector3(startPositionX, startPositionY, startPositionZ);
            transform.position = newPos;
        }
    }
}
