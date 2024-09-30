using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public static class ServiceLocator
{
    private static AudioManager _audioManager;

    // Registrar el AudioManager
    public static void RegisterAudioManager(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    // Obtener el AudioManager
    public static AudioManager GetAudioManager()
    {
        if (_audioManager == null)
        {
            Debug.LogError("AudioManager no está registrado en el ServiceLocator.");
        }
        return _audioManager;
    }
}