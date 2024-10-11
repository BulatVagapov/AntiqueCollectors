using UnityEngine;

public class CharacterRotatorRelativeDirection : MonoBehaviour
{
    private Quaternion forwardRotation = new Quaternion(0, 0, 0, 1);
    private Quaternion backRotation = new Quaternion(0, 180, 0, 1);
    [SerializeField] private float dist;
    private float posXAfterRotating;

    public void RotateCharacterRelativeDirection(Vector2 direction)
    {
        if (direction.x > 0 && transform.rotation.y != 0 && Mathf.Abs(transform.position.x - posXAfterRotating) > dist)
        {
            transform.rotation = forwardRotation;
            posXAfterRotating = transform.position.x;
        }
        else if (direction.x < 0 && transform.rotation.y == 0 && Mathf.Abs(transform.position.x - posXAfterRotating) > dist)
        {
            transform.rotation = backRotation;
            posXAfterRotating = transform.position.x;
        }
    }
}
