using UnityEngine;
using System.Collections;

public class AnimatorTest : MonoBehaviour {

    public Avatar avatar;
    public Transform transEthan;
    public Transform transPos;
    public HumanPose currentPose;

    public int muscleIdx = 42;
    public float muscleValue = -2f;


    private HumanPoseHandler hph;
    private HumanPose targetPose;
    int i = 0;

    // Use this for initialization
    void Start () {
        hph = new HumanPoseHandler(avatar, transEthan);
    }
	
	// Update is called once per frame
	void Update () { 
        if (i == 0)
        {
            hph.GetHumanPose(ref currentPose);
            float[] muscles = currentPose.muscles;
            targetPose = new HumanPose();

            targetPose.bodyPosition = transPos.position;
            targetPose.bodyRotation = transPos.rotation;

            targetPose.muscles = new float[HumanTrait.MuscleName.Length];
            System.Array.Copy(muscles, targetPose.muscles, muscles.Length);

            targetPose.muscles[muscleIdx] = muscleValue;

            //currentPose.muscles[muscleIdx] = muscleValue;
            //Debug.Log(currentPose.muscles[muscleIdx]);
            hph.SetHumanPose(ref targetPose);
            //float[] muscles2 = currentPose.muscles;
            
        }
        i++;
    }

    void PrintPose()
    {
        Debug.Log("------");
        Debug.Log(currentPose.bodyPosition);
        Debug.Log(currentPose.bodyRotation);
        foreach (float muscle in currentPose.muscles)
        {
            Debug.Log(muscle);
        }
        Debug.Log(currentPose.muscles.Length);
    }

    //void PrintMuscles(float muscles1, float muscles2)

    //{
    //    for (int i = 0; i < muscles1; i++)
    //    {
    //        Debug.Log(muscle1[i] + " " + muscles2[i]);
    //    }

    //}
}
