﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GACManagerApi
{
    /// <summary>
    /// The GacUtil class wraps functionality provided by the gacutil.exe program.
    /// </summary>
    public class GacUtil
    {
        /// <summary>
        /// Determines whether the gacutil.exe file can be found.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can find executable]; otherwise, <c>false</c>.
        /// </returns>
        public static bool CanFindExecutable()
        {
            return GetGacUtilPath() != null;
        }

        /// <summary>
        /// Gets the gac util path.
        /// </summary>
        private static string GetGacUtilPath()
        {
            //  Define all search paths here.
            var searchPaths = new[]
            {
                @"%PROGRAMFILES%\Microsoft SDKs\Windows\v6.0A\bin\gacutil.exe",
                @"%PROGRAMFILES%\Microsoft SDKs\Windows\v7.0A\Bin\gacutil.exe",
                @"%PROGRAMFILES%\Microsoft SDKs\Windows\v7.0A\Bin\gacutil.exe",
                @"%PROGRAMFILES%\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\gacutil.exe",
                @"%PROGRAMFILES(X86)%\Microsoft SDKs\Windows\v6.0A\bin\gacutil.exe",
                @"%PROGRAMFILES(X86)%\Microsoft SDKs\Windows\v7.0A\Bin\gacutil.exe",
                @"%PROGRAMFILES(X86)%\Microsoft SDKs\Windows\v7.0A\Bin\gacutil.exe",
                @"%PROGRAMFILES(X86)%\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\gacutil.exe",
            };

            //  Go through every search path until we find the gacutil file.
            foreach (var searchPath in searchPaths)
                if (System.IO.File.Exists(searchPath))
                    return searchPath;

            //  We can't find the path.
            return null;
        }
    }
}
