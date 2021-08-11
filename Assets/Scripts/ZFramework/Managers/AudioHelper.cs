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
        private AudioSource bgmPlayer;
        public AudioSource BgmPlayer { get { return bgmPlayer; } }
        //��Ч������
        private AudioSource soundPlayer;
        public AudioSource SoundPlayer { get { return soundPlayer; } }

        //�Ƿ�ȫ�־���
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
        /// ������Ч
        /// </summary>
        public void PlaySound(string soundName, float volume = 1, bool loop = false)
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
        public void PlayBGM(string bgmName, float volume = 1, bool loop = true)
        {
            AudioClip clip = Resources.Load<AudioClip>(BGMDir + bgmName);
            if (clip == null)
            {
                Debug.LogError("û�д���Ƶ��" + bgmName);
                return;
            }
            bgmPlayer.clip = clip;
            bgmPlayer.volume = volume;
            bgmPlayer.loop = loop;
            bgmPlayer.Play();
        }

        /// <summary>
        /// �������ֽ���
        /// </summary>
        public void FadeBGM(float fadeDuration)
        {
            bgmFade = true;
            bgmFadeBeginTime = Time.realtimeSinceStartup;
            bgmFadeBeginVolume = bgmPlayer.volume;
            bgmFadeDuration = fadeDuration;
        }

        /// <summary>
        /// ��ͣ����
        /// </summary>
        public void PausePlay()
        {
            bgmPlayer.Pause();
            soundPlayer.Pause();
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void ResumePlay()
        {
            bgmPlayer.Play();
            soundPlayer.Play();
        }

        /// <summary>
        /// ֹͣ����
        /// </summary>
        public void StopPlay()
        {
            bgmPlayer.Stop();
            soundPlayer.Stop();
        }

        /// <summary>
        /// ���þ���״̬
        /// </summary>
        public void SetMuteState(bool b)
        {
            bgmPlayer.mute = b;
            soundPlayer.mute = b;
        }

        /// <summary>
        /// ����BGM����״̬
        /// </summary>
        public void SetBgmMuteState(bool b)
        {
            bgmPlayer.mute = b;
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
            bgmPlayer.Stop();
        }

        /// <summary>
        /// ��ͣ����BGM
        /// </summary>
        public void PausePlayBGM()
        {
            bgmPlayer.Pause();
        }

        /// <summary>
        /// ��������BGM
        /// </summary>
        public void ResumePlayBGM()
        {
            bgmPlayer.Play();
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