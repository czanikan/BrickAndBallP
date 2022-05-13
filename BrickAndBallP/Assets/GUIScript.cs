using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour
{
    public int point;
    public int tempPoint;

    void Update()
    {
        GetComponent<Text>().text = "Score: " + point;
    }
}
