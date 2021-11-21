using UnityEngine;
using UnityEngine.AI;

public class GetPoint : MonoBehaviour
{
    public static GetPoint Instance;

    public float Range;

    private void Awake()
    {
        Instance = this;
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;

        return false;
    }

    public Vector3 GetRandomPoint(Transform point = null, float radius = 0)
    {
        if (RandomPoint(point == null ? transform.position : point.position, radius == 0 ? Range : radius, out Vector3 _point))
        {
            Debug.DrawRay(_point, Vector3.up, Color.black, 1);

            return _point;
        }

        return point == null ? Vector3.zero : point.position;
    }

    internal Vector3 GetRandomPoint(Transform transform, object radius)
    {
        throw new System.NotImplementedException();
    }
}
