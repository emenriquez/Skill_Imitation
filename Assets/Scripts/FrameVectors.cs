using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Frame
{
    public float deltaTime;
    public Vector3 rootPosition;
    public Quaternion rootRotation;
    public Quaternion chestRotation;
    public Quaternion neckRotation;
    public Quaternion rHipRotation;
    public Vector3 rKneeRotation;
    public Quaternion rAnkleRotation;
    public Quaternion rShoulderRotation;
    public Vector3 rElbowRotation;
    public Quaternion lHipRotation;
    public Vector3 lKneeRotation;
    public Quaternion lAnkleRotation;
    public Quaternion lShoulderRotation;
    public Vector3 lElbowRotation;

}

[System.Serializable]
public class Motion 
{
    public List<Frame> Frames;
}