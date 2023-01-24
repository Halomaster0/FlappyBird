using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Reference to the MeshRenderer component
    private MeshRenderer meshRenderer;
    // Variable to control the animation speed
    public float animationSpeed  = 1f; 

    // Function that runs when the script is first enabled
    private void Awake()
    {
        // Get the MeshRenderer component
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Function that runs every frame
    private void Update()
    {
        // Offset the main texture of the material attached to the MeshRenderer by the animation speed multiplied by Time.deltaTime
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
