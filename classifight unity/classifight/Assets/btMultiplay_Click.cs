using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btMultiplay_Click : MonoBehaviour
{
    public Canvas canvas;
    
    
    public void click()
    {
        canvas.GetComponent<Canvas>();
        canvas.enabled = true;
    }
}
