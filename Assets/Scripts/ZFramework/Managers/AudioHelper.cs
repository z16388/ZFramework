using UnityEngine;

/// <summary>
/// “Ù∆µπ‹¿Ì∆˜
/// </summary>

//PlayBGM("bgm");
//PlaySound("coin");
//StopPlay();
//PausePlay();
//BGMFade(2);
namespace ZFramework
{
    public class AudioHelper
    {
        public const string SoundDir = "Audio/Sounds/";
        public const string BGMDir = "Audio/BGM/";

        //BGM≤•∑≈∆˜
        private AudioSource bgmPlayer;
        public AudioSource BgmPlayer { get { return bgmPlayer; } }
        //“Ù–ß≤•∑≈∆˜
        private AudioSource soundPlayer;
        public AudioSource SoundPlayer { get { return soundPlayer; } }

        // «∑Ò»´æ÷æ≤“Ù
        public bool IsGlobalMute { get { return bgmPlayer.mute && soundPlayer.mute; } }

        public AudioHelper()
        {
            if (bgmPlayer == null)
            {
                bgmPlayer = Global.mainObject.AddComponent<AudioSource>();
                bgmPlayer.loop = true;
                bgmPlayer.playOnAwake = false;
                bgmPlayer.mute = false;
            }
            if (soundPlayer == null)
            {
                soundPlayer = Global.mainObject.AddComponent<AudioSource>();
                soundPlayer.loop = false;
                soundPlayer.playOnAwake = false;
                soundPlayer.mute = false;
            }
        }

        #region Interface

        /// <summary>
        /// ≤•∑≈“Ù–ß
        /// </summary>
        public void PlaySound(string soundName, float volume = 1, bool loop = false)
        {
            AudioClip clip = Resources.Load<AudioClip>(SoundDir + soundName);
            if (clip == null)
            {
                Debug.LogError("√ª”–¥À“Ù∆µ£∫" + soundName);
                return;
            }
            soundPlayer.clip = clip;
            soundPlayer.volume = volume;
            soundPlayer.loop = loop;
            soundPlayer.Play();
        }

        /// <summary>
        /// ≤•∑≈±≥æ∞“Ù¿÷
        /// </summary>
        public void PlayBGM(string bgmName, float volume = 1, bool loop = true)
        {
            AudioClip clip = Resources.Load<AudioClip>(BGMDir + bgmName);
            if (clip == null)
            {
                Debug.LogError("√ª”–¥À“Ù∆µ£∫" + bgmName);
                return;
            }
            bgmPlayer.clip = clip;
            bgmPlayer.volume = volume;
            bgmPlayer.loop = loop;
            bgmPlayer.Play();
        }

        /// <summary>
        /// ±≥æ∞“Ù¿÷Ω•“˛
        /// </summary>
        public void FadeBGM(float fadeDuration)
        {
            bgmFade = true;
            bgmFadeBeginTime = Time.realtimeSinceStartup;
            bgmFadeBeginVolume = bgmPlayer.volume;
            bgmFadeDuration = fadeDuration;
        }

        /// <summary>
        /// ‘›Õ£≤•∑≈
        /// </summary>
        public void PausePlay()
        {
            bgmPlayer.Pause();
            soundPlayer.Pause();
        }

        /// <summary>
        /// ºÃ–¯≤•∑≈
        /// </summary>
        public void ResumePlay()
        {
            bgmPlayer.Play();
            soundPlayer.Play();
        }

        /// <summary>
        /// Õ£÷π≤•∑≈
        /// </summary>
        public void StopPlay()
        {
            bgmPlayer.Stop();
            soundPlayer.Stop();
        }

        /// <summary>
        /// …Ë÷√æ≤“Ù◊¥Ã¨
        /// </summary>
        public void SetMuteState(bool b)
        {
            bgmPlayer.mute = b;
            soundPlayer.mute = b;
        }

        /// <summary>
        /// …Ë÷√BGMæ≤“Ù◊¥Ã¨
        /// </summary>
        public void SetBgmMuteState(bool b)
        {
            bgmPlayer.mute = b;
        }

        /// <summary>
        /// …Ë÷√Soundæ≤“Ù◊¥Ã¨
        /// </summary>
        public void SetSoundMuteState(bool b)
        {
            soundPlayer.mute = b;
        }

        /// <summary>
        /// Õ£÷π≤•∑≈BGM
        /// </summary>
        public void StopPlayBGM()
        {
            bgmPlayer.Stop();
        }

        /// <summary>
        /// ‘›Õ£≤•∑≈BGM
        /// </summary>
        public void PausePlayBGM()
        {
            bgmPlayer.Pause();
        }

        /// <summary>
        /// ºÃ–¯≤•∑≈BGM
        /// </summary>
        public void ResumePlayBGM()
        {
            bgmPlayer.Play();
        }

        /// <summary>
        /// Õ£÷π≤•∑≈“Ù–ß
        /// </summary>
        public void StopPlaySound()
        {
            soundPlayer.Stop();
        }

        #endregion

        #region Tools

        private bool bgmFade;//±≥æ∞“Ù¿÷ «∑ÒΩ•“˛
        private float bgmFadeBeginVolume;//±≥æ∞“Ù¿÷Ω•“˛ø™ º ±µƒ“Ù¡ø
        private float bgmFadeBeginTime;//±≥æ∞“Ù¿÷Ω•“˛ø™ ºµƒ ±º‰
        private float bgmFadeDuration;//±≥æ∞“Ù¿÷Ω•“˛µƒ ±º‰
        private void Update()
        {
            if (bgmFade)
            {
                float delta = Time.realtimeSinceStartup - bgmFadeBeginTime;
                if (delta <= bgmFadeDuration)
                {
                    bgmPlayer.volume = UnityEngine.Mathf.Lerp(bgmFadeBeginVolume, 0, delta / bgmFadeDuration);
                }
                else
                {
                    bgmFade = false;
                    bgmPlayer.volume = 0;
                }
            }
        }

        #endregion
    }
}