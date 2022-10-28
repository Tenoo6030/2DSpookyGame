using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private Vector3 originalPos;
    private Vector3 pos;

    public WitchControler followTarget;

    void Start()
    {
        originalPos = pos;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, followTarget.WitchSpeed);
    }
    
    void Update()
    {
        pos =new Vector3 (followTarget.transform.position.x, originalPos.y, originalPos.z);
    }
}
