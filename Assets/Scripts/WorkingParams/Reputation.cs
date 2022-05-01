using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace WorkingParams{
    internal class Reputation : IDailyParam{
        private int _totalClients;//еще чуть-чуть и казалось бы нужно выводить эти total/daily в новую сущность, но пока думаю рановато, т.к. не понятно в какую сторону расширяемся
        private int _dailyClients;
        private List<int> _totalReputation = new List<int>();
        private List<int> _dailyReputation = new List<int>();

        public int Total {get; private set;}
        public int Daily {get; private set;}
        public int DailyClients => _dailyClients;

        public void StartNewDay(){
            _dailyClients = 0;
            _dailyReputation.Clear();
        }

        public void Add(int count){
            _totalClients++;
            _dailyClients++;
            _totalReputation.Add(count);//меня несколько напрягает этот потенциально огромный лист, но пока других идей нет, возможно математически можно каким-то образом закешировать результат
            _dailyReputation.Add(count);
            Total = (int)(_totalReputation.Average());//руки очень чесались написать велосипед
            Daily = (int)(_dailyReputation.Average());
        }
    }
}