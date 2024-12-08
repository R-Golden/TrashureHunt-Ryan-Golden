using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    private Vector3 offset = new Vector3(3f, 5f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetpositon = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetpositon, ref velocity, smoothTime);
    }
}
