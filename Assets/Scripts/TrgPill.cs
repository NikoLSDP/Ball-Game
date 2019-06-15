using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrgPill : MonoBehaviour {
    [SerializeField]
    private GameObject pillObject;

    void Start()
    {
        pillObject.gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 10f), 50f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        pillObject.gameObject.SetActive(true);
    }

}
