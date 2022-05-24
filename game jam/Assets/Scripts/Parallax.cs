using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] Camera camera;

    [SerializeField] Transform subject;

    Vector2 startPos;


    float startz;


    float distanceFromSubject => transform.position.z - subject.position.z;

    float clippingPlanes => (camera.transform.position.z + (distanceFromSubject > 0 ? camera.farClipPlane : camera.nearClipPlane));

    float paralaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlanes;
    Vector2 trave => (Vector2)camera.transform.position - startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startz = transform.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = startPos + trave * paralaxFactor;

        transform.position = new Vector3(newPos.x, newPos.y, startz);
    }
}
