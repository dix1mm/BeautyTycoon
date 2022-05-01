using UnityEngine;
using UnityEngine.UI;

public class Speedup : MonoBehaviour{
    [SerializeField] private Text _text;

    public void Inc(){
        Time.timeScale *= 2f;
        updateText();
    }

    public void Dec(){
        Time.timeScale /= 2f;
        updateText();
    }

    private void updateText() => _text.text = "Speed = " + Time.timeScale.ToString();
}