using UnityEngine;
// if Movement is in a namespace, include it here:
//using MyGameNamespace;

public class PlayerSetup : MonoBehaviour
{
    public Movement movement;         // Ensure Movement component is referenced
    public GameObject camera;         // UI camera component

    // Rename method to match Unity message if intended:             // or OnStartLocalPlayer, etc.

    public void IsLocalPlayer()
    {
        movement.enabled = true;
        camera.SetActive(true);
    }
}
