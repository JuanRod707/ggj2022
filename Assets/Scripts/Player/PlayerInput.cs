using Assets.Scripts.Actors;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    HeroCharacter character;


    void FixedUpdate()
    {
        var movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (movementVector.magnitude > 0)
            character.MoveTowards(movementVector);

        if (Input.GetButtonDown("Attack"))
            character.Attack();
    }

    public void Initialize(HeroCharacter character) => 
        this.character = character;
}
