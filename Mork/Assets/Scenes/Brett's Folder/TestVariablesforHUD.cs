using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class TestVariablesforHUD : MonoBehaviour
{
    public float speedBoostTimeRemaining;
    public float slowTimeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        speedBoostTimeRemaining = 0;
        slowTimeRemaining = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
