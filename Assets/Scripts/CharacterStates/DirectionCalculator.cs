using UnityEngine;
using System;

namespace CharacterStates{
    internal class DirectionCalculator{//я немного увлекся
        private static Vector2[] _directions;//направления для каждого MovingState
        /*
            по направлению в котором мы передвинулись с предыдущего апдейта определит направление MovingState
            с помощью которого можно будет подрубить нужную анимацию
            например, если двигаемся вверх (MovingState.Hours12), то подключаем анимацию передвижения вверх
        */
        public MovingState Calc(Vector3 lastPos, Vector3 newPos){
            if (_directions == null)
                initDirections();
            float minDistance = Mathf.Infinity;
            int minIndex = -1;
            Vector3 v3Dir = (newPos - lastPos).normalized;
            Vector2 currDir = new Vector2(v3Dir.x, v3Dir.z);
            for (int i=0; i<_directions.Length; i++){//наверное linq сильно упрощает подобную логику, редко его использую
                float distance = Vector2.Distance(currDir, _directions[i]);
                if (distance < minDistance){
                    minDistance = distance;
                    minIndex = i;
                }
            }
            return getDirectionByIndex(minIndex);
        }

        //смещаемся 1 раз против часовой стрелки из-за поворота изометрии
        private MovingState getDirectionByIndex(int index) =>
            index switch{
                0 => MovingState.Hours1h,
                1 => MovingState.Hours12,
                2 => MovingState.Hours10h,                
                3 => MovingState.Hours9,
                4 => MovingState.Hours7h,
                5 => MovingState.Hours6,
                6 => MovingState.Hours4h,
                7 => MovingState.Hours3,
                _ => MovingState.Hours1h
            };

        private void initDirections(){
            _directions = new Vector2[Enum.GetValues(typeof(MovingState)).Length];
            float angleInc = 360f / _directions.Length;
            for (int i=0; i<_directions.Length; i++)
                _directions[i] = getV2WithAngle(i * angleInc);
        }

        //поворачивает против часовой стрелки
        //если угол = 0, то указывает вправо
        private Vector2 getV2WithAngle(float angle){
            angle *= Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
    }
}