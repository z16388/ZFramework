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
        private static AudioSource bgmPlayer;
        //“Ù–ß≤•∑≈∆˜
        private static AudioSource soundPlayer;

        // «∑Ò»´æ÷æ≤“Ù
        public bool IsGlobalMute { get { return BgmPlayer.mute && soundPlayer.mute; } }

        public static AudioSource BgmPlayer { get => bgmPlayer; set => bgmPlayer = value; }

        public AudioHelper()
        {
            if (BgmPlayer == null)
            {
                BgmPlayer = Global.mainObject.AddComponent<AudioSource>();
                BgmPlayer.loop = true;
                BgmPlayer.playOnAwake = false;
                BgmPlayer.mute = false;
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
        public static void PlaySound(string soundName, float volume = 1, bool loop = false)
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
        public static void PlayBGM(string bgmName, float volume = 1, bool loop = true)
        {
            AudioClip clip = Resources.Load<AudioClip>(BGMDir + bgmName);
            if (clip == null)
            {
                Debug.LogError("√ª”–¥À“Ù∆µ£∫" + bgmName);
                return;
            }
            BgmPlayer.clip = clip;
            BgmPlayer.volume = volume;
            BgmPlayer.loop = loop;
            BgmPlayer.Play();
        }

        /// <summary>
        /// ±≥æ∞“Ù¿÷Ω•“˛
        /// </summary>
        public void FadeBGM(float fadeDuration)
        {
            bgmFade = true;
            bgmFadeBeginTime = Time.realtimeSinceStartup;
            bgmFadeBeginVolume = BgmPlayer.volume;
            bgmFadeDuration = fadeDuration;
        }

        /// <summary>
        /// ‘›Õ£≤•∑≈
        /// </summary>
        public void PausePlay()
        {
            BgmPlayer.Pause();
            soundPlayer.Pause();
        }

        /// <summary>
        /// ºÃ–¯≤•∑≈
        /// </summary>
        public void ResumePlay()
        {
            BgmPlayer.Play();
            soundPlayer.Play();
        }

        /// <summary>
        /// Õ£÷π≤•∑≈
        /// </summary>
        public void StopPlay()
        {
            BgmPlayer.Stop();
            soundPlayer.Stop();
        }

        /// <summary>
        /// …Ë÷√æ≤“Ù◊¥Ã¨
        /// </summary>
        public void SetMuteState(bool b)
        {
            BgmPlayer.mute = b;
            soundPlayer.mute = b;
        }

        /// <summary>
        /// …Ë÷√BGMæ≤“Ù◊¥Ã¨
        /// </summary>
        public void SetBgmMuteState(bool b)
        {
            BgmPlayer.mute = b;
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
            BgmPlayer.Stop();
        }

        /// <summary>
        /// ‘›Õ£≤•∑≈BGM
        /// </summary>
        public void PausePlayBGM()
        {
            BgmPlayer.Pause();
        }

        /// <summary>
        /// ºÃ–¯≤•∑≈BGM
        /// </summary>
        public void ResumePlayBGM()
        {
            BgmPlayer.Play();
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
                    BgmPlayer.volume = UnityEngine.Mathf.Lerp(bgmFadeBeginVolume, 0, delta / bgmFadeDuration);
                }
                else
                {
                    bgmFade = false;
                    BgmPlayer.volume = 0;
                }
            }
        }

        #endregion
    }
}