using Questronaut.Audio;
using UnityEngine;

public class PlayerRespawnModel : MonoBehaviour
{
    [SerializeField] private LayerMask _deathLayer;
    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = GameObject.FindGameObjectWithTag("Spawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _deathLayer) != 0)
        {
            transform.position = _spawnPoint.position;
            AudioManager.Instance.PlaySound("SFX_Death");
        }
    }
}
