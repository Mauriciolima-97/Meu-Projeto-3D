using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;


namespace Ebac.StateMachine
{
    public class StateMachine<T> where T : System.Enum
    {
        public Dictionary<T, StateBase> dictionaryState;

        private StateBase _currentState;

        public StateBase CurrentState => _currentState;

        public void Init()
        {
            dictionaryState = new Dictionary<T, StateBase>();
        }

        public void RegisterStates(T typeEnum, StateBase state)
        {
            dictionaryState.Add(typeEnum, state);
        }

        public void SwitchState(T state)
        {
            if (_currentState != null)
                _currentState.OnStateExit();

            _currentState = dictionaryState[state];
            _currentState.OnStateEnter();
        }

        // ✅ chamado pelo PlayerController
        public void Tick()
        {
            if (_currentState != null)
                _currentState.OnStateStay();
        }
    }
}


