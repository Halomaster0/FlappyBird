using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Reference to the prefab to be spawned
    public GameObject prefab;
    // Variable for controlling the spawn rate
    public float spawnRate = 1f;
    // Variables for controlling the minimum and maximum height of the spawned prefab
    public float minHeight = -1f;
    public float maxHeight = 1f;

    // Function that runs when the script is enabled
    private void OnEnable()
    {
        // Invoke the Spawn function repeatedly with a delay of the spawn rate
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // Function that runs when the script is disabled
    private void OnDisable()
    {
        // Cancel any ongoing invocation of the Spawn function
        CancelInvoke(nameof(Spawn));
    }

    // Function for spawning the prefab
    private void Spawn()
    {
        // Instantiate a new game object with the prefab and the same position and rotation as the spawner
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        // Add a random value between minHeight and maxHeight to the y position of the spawned object
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
