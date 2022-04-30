using UnityEngine;
using UnityEngine.UI;
using CharacterStates;

[RequireComponent(typeof(Image))]
public class DirectionUpdater : MonoBehaviour{
    private Image _image;

    public void UpdateDirection(MovingState state){
        string img = state switch{
            MovingState.Hours12 => "12",
            MovingState.Hours3 => "3",
            MovingState.Hours6 => "6",
            MovingState.Hours9 => "9",
            MovingState.Hours1h => "1.5",
            MovingState.Hours4h => "4.5",
            MovingState.Hours7h => "7.5",
            MovingState.Hours10h => "10.5",
            _ => "12"
        };
        _image.sprite = Resources.Load<Sprite>("Directions/"+img);
    }

    private void Awake() => _image = GetComponent<Image>();
}