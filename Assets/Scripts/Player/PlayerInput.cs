using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Hero;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float minimumAxisThreshold;

    HeroCharacter character;
    Vector3 lastFrmeInput;
    Vector3 lastMovementVector;

    void FixedUpdate()
    {
        var movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (movementVector.magnitude > minimumAxisThreshold)
        {
            character.MoveTowards(movementVector);
            lastMovementVector = movementVector;
        }
        else if (lastFrmeInput == lastMovementVector)
            character.StopMoving();

        lastFrmeInput = movementVector;
    }

    void Update()
    {
        if (Input.GetButtonDown("Attack"))
            character.Attack();

        if (Input.GetButtonDown("Dash"))
            character.Dash(lastMovementVector);
    }

    public void Initialize(HeroCharacter character) => 
        this.character = character;
}
