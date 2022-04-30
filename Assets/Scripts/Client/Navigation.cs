using UnityEngine;
using CharacterStates;
using UnityEngine.Events;

namespace Client{
    [RequireComponent(typeof(Character))]
    public class Navigation : MonoBehaviour{
        [HideInInspector] public UnityEvent<Navigation> OnExit;
        private Character _client;

        public Vector3 BarPos {get; set;}
        public Vector3 ExitPos {get; set;}

        public void MoveToBar() => _client.MoveTo(BarPos);
        public void MoveToExit() => _client.MoveTo(ExitPos);

        public void Exit(){
            OnExit.Invoke(this);
            Destroy(this.gameObject);
        }

        private void Awake(){
            _client = GetComponent<Character>();
        }
    }
}