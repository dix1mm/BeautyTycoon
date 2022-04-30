using UnityEngine;
using UnityEngine.Events;

namespace Client{
    public class TasteGenerator : MonoBehaviour{
        [SerializeField] private int _min;
        [SerializeField] private int _max;
        public UnityEvent<int> OnTasteGenerated;
        public UnityEvent OnCorrectChoice;
        public UnityEvent OnIncorrectChoice;

        public int Taste {get; private set;}

        public void CheckTaste(int selectedTaste){
            if (Taste == selectedTaste)
                OnCorrectChoice.Invoke();
            else
                OnIncorrectChoice.Invoke();
        }

        private void Start(){
            Taste = Random.Range(_min, _max+1);
            OnTasteGenerated.Invoke(Taste);
        }
    }
}