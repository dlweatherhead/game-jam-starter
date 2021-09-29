using UnityEngine;

public class TrackPosition : MonoBehaviour
{
    [SerializeField] private Transform transformToTrack;

    void Update()
    {
        transform.position = transformToTrack.position;
    }
}
