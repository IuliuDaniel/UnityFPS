using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GlobalScore : MonoBehaviour
{
    public GameObject scoreDisplay;
    public static int scoreValue;
    public int internalScore;
    
    void Update()
    {
        
        internalScore = scoreValue;
        scoreDisplay.GetComponent<Text>().text = "" + scoreValue;
    }
}
