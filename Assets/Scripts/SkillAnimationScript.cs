using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillAnimationScript : MonoBehaviour
{
    [Header("Body Parts")] [Space(10)]
    public Transform hips;
    public ConfigurableJoint chest;
    public ConfigurableJoint head;
    public ConfigurableJoint upperArmR, upperArmL, foreArmR, foreArmL;
    public ConfigurableJoint thighR, thighL, shinR, shinL, footR, footL;


    List<string> skillList = new List<string> 
    {
        "walk",
        "run",
        "jump",
        "kick",
        "punch",
        "roll",
        "spin",
        "spinkick",
        "backflip",
        "cartwheel",
        "crawl",
        "dance_a",
        "dance_b",
        "getup_facedown",
        "getup_faceup"
    };

    [Header("Player Controls")] [Space(10)]
    public int skillSelect;
    public Text skillText;

    [HideInInspector] public Motion skill = new Motion();
    void Start()
    {
        string json = File.ReadAllText($"Assets/Motions/{skillList[skillSelect]}.json");

        skill = JsonUtility.FromJson<Motion>(json);

        skillText.text = skillList[skillSelect];

        StartCoroutine(waiter());
    }

    IEnumerator waiter() {
        while (true)
        {
        foreach (Frame frame in skill.Frames) {
            this.transform.localPosition = frame.rootPosition;
            this.transform.localRotation = frame.rootRotation;
            chest.targetRotation = frame.chestRotation;
            head.targetRotation = frame.neckRotation;
            thighR.targetRotation = frame.rHipRotation;
            shinR.targetRotation = Quaternion.Euler(frame.rKneeRotation);
            footR.targetRotation = frame.rAnkleRotation;
            upperArmR.targetRotation = frame.rShoulderRotation;
            foreArmR.targetRotation = Quaternion.Euler(frame.rElbowRotation);
            thighL.targetRotation = frame.lHipRotation;
            shinL.targetRotation = Quaternion.Euler(frame.lKneeRotation);
            footL.targetRotation = frame.lAnkleRotation;
            upperArmL.targetRotation = frame.lShoulderRotation;
            foreArmL.targetRotation = Quaternion.Euler(frame.lElbowRotation);
            yield return new WaitForSeconds(frame.deltaTime);
            }
        }
    }
}