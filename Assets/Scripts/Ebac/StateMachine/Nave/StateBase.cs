using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Ebac.StateMachine
{
public class StateBase
{

        public virtual void OnStateEnter()
     {
        Debug.Log("OnStateEnter");
     }

        public virtual void OnStateStay()
    {
        Debug.Log("OnStateStay");
    }
    public virtual void OnStateExit()
    {
        Debug.Log("OnStateExit");
    }
}
}

