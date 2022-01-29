using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    PlayerControlScript playerControlScript;

    public GameObject GoalRange; //オブジェクト
    public ParticleSystem GoalEffect; //エフェクト

    private void Start()
    {
        GoalEffect.Stop (true, ParticleSystemStopBehavior.StopEmitting);
    }
    public void changeGoalState()
    {
        GoalRange.GetComponent<Renderer>().material.color = new Color32(97,255,0,109);
        GoalRange.GetComponent<Collider>().enabled = false;
        GoalEffect.Play (true);
    }
}
