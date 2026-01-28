using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Health healthcomponent;
    public abstract void Move(Vector3 movevector);
}
