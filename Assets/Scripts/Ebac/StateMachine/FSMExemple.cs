using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class FSMExemple : MonoBehaviour
{
    public enum ExampleENum
    {
        STATE_ONE,
        STATE_TWO,
        STATE_THREE,
    }

    public StateMachine<ExampleENum> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<ExampleENum>();   
        stateMachine.Init();
        stateMachine.RegisterStates(ExampleENum.STATE_ONE, new StateBase());
        stateMachine.RegisterStates(ExampleENum.STATE_TWO, new StateBase());
    }

}
