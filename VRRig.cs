using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class VRRig : MonoBehaviour
{

    public VRMAP head;
    public VRMAP leftHand;
    public VRMAP rightHand;
    public Transform hCosntraint;
    public Vector3 headBodyOffset;

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - hCosntraint.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = hCosntraint.position + headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(hCosntraint.up, Vector3.up).normalized;
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
