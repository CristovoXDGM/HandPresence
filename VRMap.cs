using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class VRMap
{
    public Vector3 trackingPositionOffSet;
    public Vector3 trackingRotationOffSet;
    public Transform rigTarget;
    public Transform vrTarget;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffSet);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffSet);
    }


}
