using UnityEngine;

namespace Client{
    public class Despawner : MonoBehaviour{
        private void OnTriggerEnter(Collider collider){
            if (collider.TryGetComponent(out Navigation client))
                client.Exit();
        }
    }
}