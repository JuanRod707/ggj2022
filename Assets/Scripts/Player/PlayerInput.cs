using Assets.Scripts.Actors;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    HeroCharacter character;


    void FixedUpdate()
    {
        var movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (movementVector.magnitude > 0)
            character.MoveTowards(movementVector);

        if (Input.GetButtonDown("Attack"))
            character.Attack();
    }

    public void Initialize(HeroCharacter character) => 
        this.character = character;
}
