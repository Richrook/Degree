using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            transform.GetComponentInParent<EnemyControlScript>().SetState(EnemyControlScript.EnemyState.Freeze);
        }
    }
}
