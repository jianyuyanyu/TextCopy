﻿using System;
using System.Runtime.InteropServices;

namespace TextCopy
{
    /// <summary>
    /// Provides methods to place text on and retrieve text from the system Clipboard.
    /// </summary>
    public static class Clipboard
    {
        static Action<string> setAction = CreateSet();
        static Func<string> getFunc = CreateGet();

        /// <summary>
        /// Clears the Clipboard and then adds text data to it.
        /// </summary>
        public static void SetText(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            setAction(text);
        }

        /// <summary>
        /// Retrieves text data from the Clipboard.
        /// </summary>
        public static string GetText()
        {
           return getFunc();
        }

        static Action<string> CreateSet()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return WindowsClipboard.SetText;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OsxClipboard.SetText;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return LinuxClipboard.SetText;
            }

            return s => throw new NotSupportedException();
        }

        static Func<string> CreateGet()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return WindowsClipboard.GetText;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OsxClipboard.GetText;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return LinuxClipboard.GetText;
            }

            return () => throw new NotSupportedException();
        }
    }
}