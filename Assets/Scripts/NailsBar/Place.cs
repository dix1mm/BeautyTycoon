using UnityEngine;
using UnityEngine.Events;
using CharacterStates;

namespace NailsBar{
    public class Place : MonoBehaviour{
        [SerializeField] private Bar _bar;
        public UnityEvent<Character> OnEnter;
        public UnityEvent<Character> OnExit;

        private void OnTriggerEnter(Collider collider){
            if (collider.TryGetComponent(out Character character))
                OnEnter.Invoke(character);
        }

        private void OnTriggerExit(Collider collider){
            if (collider.TryGetComponent(out Character character))
                OnExit.Invoke(character);
        }
    }
}