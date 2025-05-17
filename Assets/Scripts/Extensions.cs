using UnityEngine;

public static class Extensions
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");

    // Verifica si el Rigidbody está colisionando con un objeto en una dirección determinada.
    // Por ejemplo, si quieres comprobar si el jugador está tocando el suelo,
    // puedes pasar Vector2.down. Si quieres verificar si el jugador está chocando
    // contra una pared, puedes pasar Vector2.right o Vector2.left.
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.isKinematic) {
            return false;
        }

        float radius = 0.25f;
        float distance = 0.375f;

        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction.normalized, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }

    // Verifica si un transform está frente a otro transform en una dirección determinada.
    // Por ejemplo, si quieres comprobar si el jugador aplasta a un enemigo,
    // debes pasar el transform del jugador, el transform del enemigo y Vector2.down.
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }

}
