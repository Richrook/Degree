using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiControlScript : MonoBehaviour
{
    private bool isValid = true;

    public bool getIsValid()
    {
        return isValid;
    }

    public void setIsValid(bool isValid)
    {
        this.isValid = isValid;
    }
}
