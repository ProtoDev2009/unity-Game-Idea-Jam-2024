using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultiTargetCamera : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;

    private Vector3 velocity;
    private float smoothTime = 0.5f;

    private float minZoom = 40f;
    private float maxZoom = 10f;
    private float zoomLimiter = 50f;

    private Camera cam;

    void Start(){
        cam = GetComponent<Camera>();
    }

    void LateUpdate(){
        //if no targets
        if(targets.Count == 0) return;

        Vector3 centerPoint = GetCenter();

        Vector3 adjustedPos = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, adjustedPos, ref velocity, smoothTime);

        Zoom();
    }

    void Zoom(){
        float zoomVal = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance()/zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomVal, Time.deltaTime);
    }

    //Get Distance between players
    float GetGreatestDistance(){
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++){
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenter(){
        if(targets.Count == 1){
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++){
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
