using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidScripts : MonoBehaviour
{
    public GameObject OutsideObject;           // アクティブな親オブジェクト
    public GameObject InsideObject;         // 非アクティブな子オブジェクト
    public enum Position {
        Outside,
        Middle,
        Inside
    }
    public Position PositionName;

    private void OnCollisionEnter(Collision collision){
        if(PositionName.ToString() == "Outside"){
            OutsideObject.SetActive (true);
            InsideObject.SetActive (false);
        }
        else if(PositionName.ToString() == "Middle"){
            OutsideObject.SetActive (true);
            InsideObject.SetActive (true);
        }
        else if(PositionName.ToString() == "Inside"){
            OutsideObject.SetActive (false);
            InsideObject.SetActive (true);
        }
    }
}
