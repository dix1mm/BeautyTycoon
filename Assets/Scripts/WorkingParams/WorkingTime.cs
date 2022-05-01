using UnityEngine;
using System;

namespace WorkingParams{
    internal class WorkingTime : IDailyParam{
        private const int _startHour = 10;
        private const int _endHour = 20;
        private const float _realTimeWorkDayDurationInSeconds = 300f;
        private readonly float _realSecondValueInGameMinutes = (_endHour-_startHour)*60 / _realTimeWorkDayDurationInSeconds;
        private DateTime _time = new DateTime();//а в .net 6 оказывается есть TimeOnly, возможно стоило сделать свой велосипед

        public string Time => _time.ToString("HH:mm");
        public bool IsDayEnded => _time.Hour == _endHour;

        public WorkingTime() => StartNewDay();

        public void StartNewDay(){
            _time = new DateTime();
            _time.AddHours(_startHour);
        }

        public void Update(float seconds){
            if (IsDayEnded) return;
            _time = _time.AddMinutes(seconds * _realSecondValueInGameMinutes);
            if (_time.Hour > _endHour){//да, это не поможет если будет перебор до следующего дня, но велосипед займет через чур много времени
                _time = new DateTime();
                _time.AddHours(_endHour);
            }
        }
    }
}