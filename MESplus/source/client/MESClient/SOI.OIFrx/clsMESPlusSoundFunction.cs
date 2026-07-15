using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SOI.OIFrx
{
    public class MOSF
    {
        #region " Constant Definition "

        private const string MP_SUCCESS_SOUND_FILE = "MpSuccess.wav";
        private const string MP_FAIL_SOUND_FILE = "MpError.wav";
        private const string MP_WARN_SOUND_FILE = "MpWarning.wav";

        public const int SND_SYNC = 0x0;
        public const int SND_APPLICATION = 0x80;
        public const int SND_ASYNC = 0x1;
        public const int SND_FILENAME = 0x20000;
        public const int SND_NODEFAULT = 0x2;

        //public enum MP_MSG_TYPE
        //{
        //    TYPE_INFO = 1,
        //    TYPE_SUCCESS = 2,
        //    TYPE_WARN = 3,
        //    TYPE_ERROR = 4
        //}

        #endregion

        #region " Variable Definition "

        #endregion

        #region " Function Definition "

        // sndPlaySoundA()
        //       - Play Sound
        // Return Value
        //       - int
        // Arguments
        //       - ByVal lpszFileName As string : File Name
        //       - ByVal uFlags As int : SND_SYNC = 0x0 / SND_ASYNC = 0x1
        //
        [DllImport("winmm.dll")]
        private static extern int sndPlaySoundA(string lpszFileName, int uFlags);

        // waveOutGetNumDevs()
        //       - Detect the number of sound devices
        // Return Value
        //       - int
        // Arguments
        //       - 
        //
        [DllImport("winmm", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        protected static extern int waveOutGetNumDevs();

        // IsSoundSupported()
        //       - Check sound devices
        // Return Value
        //       - Boolean : true / false
        // Arguments
        //       - 
        //
        private static Boolean IsSoundSupported()
        {
            if (waveOutGetNumDevs() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // PlaySound()
        //       - Choice sound type and sound sync
        // Return Value
        //       - 
        // Arguments
        //       - ByVal iSoundType As int : sound type : MP_MSG_TYPE
        //       - ByVal uFlags As int : SND_SYNC = 0x0 / SND_ASYNC = 0x1
        //
        public static void PlaySound(int iSoundType, int uFlags)
        {
            int intCtr;
            string sSoundPath = "";

            if (iSoundType == (int)MSSAG_LEVEL.INFO)
            {
                return;
            }

            if (IsSoundSupported())
            {
                if (iSoundType == (int)MSSAG_LEVEL.SUCCESS)
                {
                    sSoundPath = MP_SUCCESS_SOUND_FILE;
                }
                else if (iSoundType == (int)MSSAG_LEVEL.ERROR)
                {
                    sSoundPath = MP_FAIL_SOUND_FILE;
                }
                else if (iSoundType == (int)MSSAG_LEVEL.WARNING)
                {
                    sSoundPath = MP_WARN_SOUND_FILE;
                }

                if (!System.IO.File.Exists(Application.StartupPath + "\\" + sSoundPath))
                {
                    return;
                }

                sndPlaySoundA(sSoundPath, uFlags);

            }
            else
            {
                for (intCtr = 0; intCtr < 2; intCtr++)
                {
                    Console.Beep();
                }
            }
        }

        // PlaySound()
        //       - Choice sound type and sound sync
        // Return Value
        //       - 
        // Arguments
        //       - ByVal iSoundType As int : sound type : MP_MSG_TYPE
        //
        public static void PlaySound(int iSoundType)
        {
            int uFlags = SND_ASYNC;
            int intCtr;
            string sSoundPath = "";

            if (iSoundType == (int)MSSAG_LEVEL.INFO)
            {
                return;
            }

            if (IsSoundSupported())
            {
                if (iSoundType == (int)MSSAG_LEVEL.SUCCESS)
                {
                    sSoundPath = MP_SUCCESS_SOUND_FILE;
                }
                else if (iSoundType == (int)MSSAG_LEVEL.ERROR)
                {
                    sSoundPath = MP_FAIL_SOUND_FILE;
                }
                else if (iSoundType == (int)MSSAG_LEVEL.WARNING)
                {
                    sSoundPath = MP_WARN_SOUND_FILE;
                }

                if (!System.IO.File.Exists(Application.StartupPath + "\\" + sSoundPath))
                {
                    return;
                }

                sndPlaySoundA(sSoundPath, uFlags);

            }
            else
            {
                for (intCtr = 0; intCtr < 2; intCtr++)
                {
                    Console.Beep();
                }
            }
        }

        // MpSuccessSound()
        //       - Play Success Sound
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        public void MpSuccessSound()
        {
            PlaySound((int)MSSAG_LEVEL.SUCCESS);
        }

        // MpErrorSound()
        //       - Play Error Sound
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        public void MpErrorSound()
        {
            PlaySound((int)MSSAG_LEVEL.ERROR);
        }

        // MpWarnSound()
        //       - Play Warn Sound
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        public void MpWarnSound()
        {
            PlaySound((int)MSSAG_LEVEL.WARNING);
        }

        #endregion

    }
}
