using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : BaseManager
{

    public override string State
    {
        get { return _state; }
        set { _state = value; }
    }

    void Start()
    {
        Initialize();
    }
    public override void Initialize()
    {
        _state = "Combat Manager is not initialized...";
        Debug.Log(_state);
    }
}
