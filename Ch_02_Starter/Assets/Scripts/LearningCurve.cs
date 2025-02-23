using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    
    public int MyVariable = 17;
    public int AddedAge = 8;
    void Start()
    {
        ComputeAge();
    }
    


   
void ComputeAge()
{
    Debug.Log(MyVariable + AddedAge);
}
}