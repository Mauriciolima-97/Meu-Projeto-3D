using Boss;
using Ebac.StateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Ebac.StateMachine
{
public class StateBase
{

        public virtual void OnStateEnter(params object[] objs)
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

