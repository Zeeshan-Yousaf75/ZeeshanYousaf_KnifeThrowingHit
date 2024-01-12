using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    [System.Serializable]
    private class RotationElement
    {
        //Rotation speed variable
        public   float rotationSpeed;
        //Time duration for rotating
        public float Duration;

    }
    [SerializeField]
    private RotationElement [] rotationPattern;

    private WheelJoint2D wheelJoint;
    private JointMotor2D jointMotor;


    private void Awake()
    {
        //getting wheeljoint2d component
        wheelJoint = GetComponent<WheelJoint2D>();
        jointMotor = new JointMotor2D();

        StartCoroutine("PlayRotationPattern");
    }

    private IEnumerator PlayRotationPattern()
    {
        int rotationIndex = 0;
        while (true)
        {
yield return new WaitForFixedUpdate();

            jointMotor.motorSpeed = rotationPattern[rotationIndex].rotationSpeed;
            jointMotor.maxMotorTorque = 10000;
            wheelJoint.motor = jointMotor;

            //Change the rotation index and duration
            yield return new WaitForSecondsRealtime(rotationPattern[rotationIndex].Duration);
            rotationIndex++;
            rotationIndex = rotationIndex <rotationPattern.Length ?rotationIndex : 0;   

        }
    }
}
