using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private AudioClip menuMusic;
        [SerializeField] private AudioClip gameMusic;

        private AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Game game = GetComponent<Game>();
            game.OnMenuEvent += OnMenu;
            game.OnGameEvent += OnGame;
        }

        private void OnMenu()
        {
            if (source.isPlaying)
                source.Stop();
            source.clip = menuMusic;
            source.Play();
        }

        private void OnGame()
        {
            if(source.isPlaying)
                source.Stop();
            source.clip = gameMusic;
            source.Play();
        }

    }
}