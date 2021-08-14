using UnityEngine;

/// <summary>
/// ��Ƶ������
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

        //BGM������
        private static AudioSource bgmPlayer;
        //��Ч������
        private static AudioSource soundPlayer;

        //�Ƿ�ȫ�־���
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
        /// ������Ч
        /// </summary>
        public static void PlaySound(string soundName, float volume = 1, bool loop = false)
        {
            AudioClip clip = Resources.Load<AudioClip>(SoundDir + soundName);
            if (clip == null)
            {
                Debug.LogError("û�д���Ƶ��" + soundName);
                return;
            }
            soundPlayer.clip = clip;
            soundPlayer.volume = volume;
            soundPlayer.loop = loop;
            soundPlayer.Play();
        }

        /// <summary>
        /// ���ű�������
        /// </summary>
        public static void PlayBGM(string bgmName, float volume = 1, bool loop = true)
        {
            AudioClip clip = Resources.Load<AudioClip>(BGMDir + bgmName);
            if (clip == null)
            {
                Debug.LogError("û�д���Ƶ��" + bgmName);
                return;
            }
            BgmPlayer.clip = clip;
            BgmPlayer.volume = volume;
            BgmPlayer.loop = loop;
            BgmPlayer.Play();
        }

        /// <summary>
        /// �������ֽ���
        /// </summary>
        public void FadeBGM(float fadeDuration)
        {
            bgmFade = true;
            bgmFadeBeginTime = Time.realtimeSinceStartup;
            bgmFadeBeginVolume = BgmPlayer.volume;
            bgmFadeDuration = fadeDuration;
        }

        /// <summary>
        /// ��ͣ����
        /// </summary>
        public void PausePlay()
        {
            BgmPlayer.Pause();
            soundPlayer.Pause();
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void ResumePlay()
        {
            BgmPlayer.Play();
            soundPlayer.Play();
        }

        /// <summary>
        /// ֹͣ����
        /// </summary>
        public void StopPlay()
        {
            BgmPlayer.Stop();
            soundPlayer.Stop();
        }

        /// <summary>
        /// ���þ���״̬
        /// </summary>
        public void SetMuteState(bool b)
        {
            BgmPlayer.mute = b;
            soundPlayer.mute = b;
        }

        /// <summary>
        /// ����BGM����״̬
        /// </summary>
        public void SetBgmMuteState(bool b)
        {
            BgmPlayer.mute = b;
        }

        /// <summary>
        /// ����Sound����״̬
        /// </summary>
        public void SetSoundMuteState(bool b)
        {
            soundPlayer.mute = b;
        }

        /// <summary>
        /// ֹͣ����BGM
        /// </summary>
        public void StopPlayBGM()
        {
            BgmPlayer.Stop();
        }

        /// <summary>
        /// ��ͣ����BGM
        /// </summary>
        public void PausePlayBGM()
        {
            BgmPlayer.Pause();
        }

        /// <summary>
        /// ��������BGM
        /// </summary>
        public void ResumePlayBGM()
        {
            BgmPlayer.Play();
        }

        /// <summary>
        /// ֹͣ������Ч
        /// </summary>
        public void StopPlaySound()
        {
            soundPlayer.Stop();
        }

        #endregion

        #region Tools

        private bool bgmFade;//���������Ƿ���
        private float bgmFadeBeginVolume;//�������ֽ�����ʼʱ������
        private float bgmFadeBeginTime;//�������ֽ�����ʼ��ʱ��
        private float bgmFadeDuration;//�������ֽ�����ʱ��
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