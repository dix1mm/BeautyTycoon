using UnityEngine;

namespace WorkingParams{
    internal class Money : IDailyParam{
        public int Total {get; private set;}
        public int Daily {get; private set;}

        public void StartNewDay() => Daily = 0;

        public void Mod(int count){
            Total += count;
            if (Total < 0)
                Debug.Log("Деньги кончились, геймовер?");
            Daily += count;
        }
    }
}