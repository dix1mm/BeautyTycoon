using UnityEngine;
using System;

namespace CharacterStates{
    internal abstract class StateController<T> where T : Enum{
        private Vector3 _lastPos;

        public T State{get; protected set;}

        public bool UpdateCurrentPos(Vector3 newPos){
            T oldState = State;
            RefreshState(newPos, _lastPos);
            _lastPos = newPos;
            return !oldState.Equals(State);
        }

        protected abstract void RefreshState(Vector3 newPos, Vector3 lastPos);
    }
}