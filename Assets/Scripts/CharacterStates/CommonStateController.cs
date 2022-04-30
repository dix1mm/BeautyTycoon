using UnityEngine;

namespace CharacterStates{
    public class CommonStateController : StateController<CommonState>{
        protected override void RefreshState(Vector3 newPos, Vector3 lastPos){
            if (State == CommonState.Processing) return;
            State = (newPos == lastPos) ? CommonState.Idle : CommonState.Moving;
        }

        public void StartProcessing() => State = CommonState.Processing;

        public void StopProcessing() => State = CommonState.Idle;
    }
}