using UnityEngine;

namespace CharacterStates{
    public class MovingStateController : StateController<MovingState>{
        private DirectionCalculator _calc = new DirectionCalculator();

        protected override void RefreshState(Vector3 newPos, Vector3 lastPos){
            if (newPos == lastPos) return;
            State = _calc.Calc(lastPos, newPos);
        }
    }
}