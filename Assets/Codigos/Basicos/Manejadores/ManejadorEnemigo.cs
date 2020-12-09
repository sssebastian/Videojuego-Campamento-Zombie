using UnityEngine;

namespace CompleteProject
{
    public class ManejadorEnemigo : MonoBehaviour
    {
        public SaludJugador saludJugador;       // Reference to the player's heatlh.
        public GameObject enemigo;                // The enemy prefab to be spawned.
        public float tiempoSpawn = 3f;            // How long between each spawn.
        public Transform[] puntosSpawn;         // An array of the spawn points this enemy can spawn from.


        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
			InvokeRepeating ("Spawn", tiempoSpawn, tiempoSpawn);
        }


        void Spawn ()
        {
            // If the player has no health left...
            if(saludJugador.saludActual <= 0f)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
			int spawnPointIndex = Random.Range (0, puntosSpawn.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			Instantiate (enemigo, puntosSpawn[spawnPointIndex].position, puntosSpawn[spawnPointIndex].rotation);
        }
    }
}