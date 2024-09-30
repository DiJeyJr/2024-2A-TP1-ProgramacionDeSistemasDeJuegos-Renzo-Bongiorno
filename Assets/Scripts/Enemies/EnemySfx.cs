using Audio;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Enemy))]
    public class EnemySfx : MonoBehaviour
    {
        //[SerializeField] private AudioPlayer audioSourcePrefab;
        [SerializeField] private AudioClip[] spawnClips;
        [SerializeField] private AudioClip[] explosionClips;
        private Enemy _enemy;

        private void Reset() => FetchComponents();

        private void Awake() => FetchComponents();
    
        private void FetchComponents()
        {
            // "a ??= b" is equivalent to "if(a == null) a = b" 
            _enemy ??= GetComponent<Enemy>();
        }
        
        private void OnEnable()
        {
            /*if (!audioSourcePrefab)
            {
                Debug.LogError($"{nameof(audioSourcePrefab)} is null!");
                return;
            }*/
            _enemy.OnSpawn += HandleSpawn;
            _enemy.OnDeath += HandleDeath;
        }
        
        private void OnDisable()
        {
            _enemy.OnSpawn -= HandleSpawn;
            _enemy.OnDeath -= HandleDeath;
        }

        private void HandleDeath()
        {
            ServiceLocator.GetAudioManager().PlaySFX(explosionClips[Random.Range(0, explosionClips.Length)]);
        }

        private void HandleSpawn()
        {
            ServiceLocator.GetAudioManager().PlaySFX(spawnClips[Random.Range(0, spawnClips.Length)]);
        }

        private void PlayRandomClip(RandomContainer<AudioClip> container)
        {
            if (!container.TryGetRandom(out var clipData))
                return;
            
            ServiceLocator.GetAudioManager().PlaySFX(clipData);
        }
    }
}
