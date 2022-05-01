using UnityEngine;
using UnityEngine.Events;

namespace WorkingParams{
    public class ParamsManager : MonoBehaviour{
        public UnityEvent<string> OnTimeChange;
        public UnityEvent<string> OnMoneyChange;
        public UnityEvent<string> OnReputationChange;
        public UnityEvent OnDayEnd;
        public UnityEvent OnDayStart;
        private WorkingTime _time;
        private Money _money;
        private Reputation _reputation;

        public int DailyMoney => _money.Daily;
        public int DailyReputation => _reputation.Daily;
        public int DailyClients => _reputation.DailyClients;

        public void StartNewDay(){
            _time.StartNewDay();
            _money.StartNewDay();
            _reputation.StartNewDay();//пока не вижу смысла добавлять их в одну коллекцию
            OnDayStart.Invoke();
        }

        public void ModMoney(int count){
            _money.Mod(count);
            OnMoneyChange.Invoke(_money.Total.ToString() + "$");
        }

        public void AddReputation(int count){
            _reputation.Add(count);
            OnReputationChange.Invoke(_reputation.Total.ToString() + "%");
        }

        private void Awake(){
            _time = new WorkingTime();
            _money = new Money();
            _reputation = new Reputation();
        }

        private void FixedUpdate(){
            _time.Update(Time.fixedDeltaTime);
            OnTimeChange.Invoke(_time.Time);
            if (_time.IsDayEnded)
                OnDayEnd.Invoke();
        }
    }
}