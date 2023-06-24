using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Timer : MonoBehaviour
{

    private float Timer2 = 0f;
    private float Limit = 1f;
    private int n = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer2 += Time.deltaTime;
        Debug.Log($"{n}: {Time.deltaTime}");
        n++;
        if (Timer2 > Limit)
        {
            Debug.Log("1 second");
            Timer2 = 0f;
        }
    }
}
