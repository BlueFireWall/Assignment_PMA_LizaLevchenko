using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
   public int CurrentAge = 19;
    public int AddedAge = 1;

    
    void update()
    {
        Debug.Log(CurrentAge + AddedAge);
    }
}
