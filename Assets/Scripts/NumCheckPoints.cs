using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NumCheckPoints : MonoBehaviour
{
    public Transform[] checkPoints;

    // Start is called before the first frame update
    void Start()
    {
        checkPoints = GetComponentsInChildren<Transform>();
        for (int i = 1; i < checkPoints.Length; i++)
        {
            checkPoints[i].gameObject.name = (i-1).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
