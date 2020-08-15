using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillAnimationScript : MonoBehaviour
{
    [Header("Body Parts")] [Space(10)]
    public Transform hips;
    public Transform core, neck, lShoulder, rShoulder, lElbow, rElbow, rHip, lHip, rKnee, lKnee, rAnkle, lAnkle;

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
    public Text skillText;


    [HideInInspector] public Motion skill = new Motion();
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter() {
        foreach (string skillName in skillList) {
            string json = File.ReadAllText($"Assets/Motions/{skillName}.json");
            skill = JsonUtility.FromJson<Motion>(json);
            skillText.text = skillName;

            int i = 0;
            while (i < 2)
            {
                foreach (Frame frame in skill.Frames) {
                    hips.localPosition = frame.rootPosition;
                    hips.localRotation = frame.rootRotation;
                    core.localRotation = frame.chestRotation;
                    neck.localRotation = frame.neckRotation;
                    rHip.localRotation = frame.rHipRotation;
                    rKnee.localRotation = Quaternion.Euler(frame.rKneeRotation);
                    rAnkle.localRotation = frame.rAnkleRotation;
                    rShoulder.localRotation = frame.rShoulderRotation;
                    rElbow.localRotation = Quaternion.Euler(frame.rElbowRotation);
                    lHip.localRotation = frame.lHipRotation;
                    lKnee.localRotation = Quaternion.Euler(frame.lKneeRotation);
                    lAnkle.localRotation = frame.lAnkleRotation;
                    lShoulder.localRotation = frame.lShoulderRotation;
                    lElbow.localRotation = Quaternion.Euler(frame.lElbowRotation);
                    yield return new WaitForSeconds(frame.deltaTime);
                    }
                i++;
            }

        }
    }
}