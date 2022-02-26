using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalControlScript : MonoBehaviour
{
    public GameObject GoalRange; //オブジェクト
    public ParticleSystem GoalEffect; //エフェクト
    //エフェクトの誤動作防止のため一度しか実行できないようにする
    private bool Count_for_effects = false;
    
    public void changeGoal()
    {
        GoalRange.GetComponent<Renderer>().material.color = new Color32(97,255,0,109);
        GoalRange.GetComponent<Collider>().enabled = false;
        if (Count_for_effects == false)
        {
            GoalEffect.Play(true);
            Count_for_effects = true;
        }
    }
}
