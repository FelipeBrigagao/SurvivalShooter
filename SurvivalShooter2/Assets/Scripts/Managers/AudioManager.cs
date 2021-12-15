﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : SingletonBase<AudioManager>
{
    #region Variables
    [Header("Audio References")]
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Animator _musicAnim;
    [SerializeField] private AudioClip _mainMenuAudio;
    [SerializeField] private AudioClip _inGameAudio;

    [Header("Audio Fade animation parameters")]
    [SerializeField] private string _fadeInParameter;
    [SerializeField] private string _fadeOutParameter;

    [Header("Mixers parameters")]
    [SerializeField] private string _masterMixerParameter;
    [SerializeField] private string _musicMixerParameter;
    [SerializeField] private string _soundEffectsMixerParameter;
    #endregion


    #region Unity Methods
    #endregion


    #region Methods
    public void FadeInMusic()
    {
        Debug.Log("FadeIn");
        _musicAnim.SetTrigger(_fadeInParameter);
    }

    public void FadeOutMusic()
    {
        Debug.Log("FadeOut");
        _musicAnim.SetTrigger(_fadeOutParameter);
    }

    public void EnterMenuMusic()
    {
        Debug.Log("EnterMenuMusic");
        _audio.clip = _mainMenuAudio;
        _audio.Play();
        FadeInMusic();
    }

    public void EnterGameMusic()
    {
        Debug.Log("EnterGameMusic");
        _audio.clip = _inGameAudio;
        _audio.Play();
        FadeInMusic();
    }

    public void SetMainVolume(float volume)
    {
        _audioMixer.SetFloat(_masterMixerParameter, volume);
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat(_musicMixerParameter, volume);
    }

    public void SetSoundEffectsVolume(float volume)
    {
        _audioMixer.SetFloat(_soundEffectsMixerParameter, volume);
    }
    #endregion

}
