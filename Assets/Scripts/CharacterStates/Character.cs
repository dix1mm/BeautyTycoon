using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace CharacterStates{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Character : MonoBehaviour{
        public UnityEvent<CommonState> OnCommonStateChange;
        public UnityEvent<MovingState> OnMoveStateChange;
        private NavMeshAgent _agent;
        private CommonStateController _charCommonState;
        private MovingStateController _charMovingState;

        public void MoveTo(Vector3 point) => _agent.SetDestination(point);
        
        public void StartProcessing(){
            _charCommonState.StartProcessing();
            commonStateChanged();
        }

        public void StopProcessing(){
            _charCommonState.StopProcessing();   
            commonStateChanged();
        }

        private void FixedUpdate(){
            if (_charCommonState.UpdateCurrentPos(transform.position))
                commonStateChanged();
            if (_charMovingState.UpdateCurrentPos(transform.position))
                OnMoveStateChange.Invoke(_charMovingState.State);
        }

        private void Awake(){
            _agent = GetComponent<NavMeshAgent>();
            _charCommonState = new CommonStateController();
            _charMovingState = new MovingStateController();
        }

        private void commonStateChanged() => OnCommonStateChange.Invoke(_charCommonState.State);
    }
}