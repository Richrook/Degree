using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiControlScript : MonoBehaviour
{
    private bool isValid = true;
    private GameObject monitor;
    public Material[] materials;

    public bool getIsValid()
    {
        return isValid;
    }

    public void changePiState()
    {
        this.isValid = false;
        monitor = transform.Find("Monitor").gameObject;
        monitor.GetComponent<Renderer>().material = materials[1];
    }
}
