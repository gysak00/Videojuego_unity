using UnityEngine;

public class UIcamara : MonoBehaviour
{

    public Transform Player;
    public float xPos;
    public float yPos;

    public float zPos;
    void Start()
    {
        transform.position = new Vector3(Player.position.x + xPos, Player.position.y + yPos, zPos);
    }

    void Update()
    {
        transform.position = new Vector3(Player.position.x + xPos, Player.position.y + yPos, zPos);

    }
}
