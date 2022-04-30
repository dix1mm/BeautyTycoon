using UnityEngine;
using UnityEngine.UI;
using CharacterStates;

[RequireComponent(typeof(Text))]
public class StateUpdater : MonoBehaviour{
    private Text _text;

    public void UpdateState(CommonState state){
        _text.text = state switch{
            CommonState.Idle => "Idle",
            CommonState.Moving => "Moving",
            CommonState.Processing => "Processing",
            _ => "Idle"
        };
    }

    private void Awake() => _text = GetComponent<Text>();
}