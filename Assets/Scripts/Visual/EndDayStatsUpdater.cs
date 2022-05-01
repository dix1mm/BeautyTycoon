using UnityEngine;
using UnityEngine.UI;
using WorkingParams;

public class EndDayStatsUpdater : MonoBehaviour{
    [SerializeField] private ParamsManager _params;
    [SerializeField] private Text _clients;
    [SerializeField] private Text _money;
    [SerializeField] private Text _reputation;

    public void UpdateStats(){
        _clients.text = "Клиентов обслужено: " + _params.DailyClients.ToString();
        _money.text = "Деньги: " + _params.DailyMoney.ToString();
        _reputation.text = "Репутация: " + _params.DailyReputation.ToString();
    }
}