using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manganese.Number
{
    public static class NumberMolecule
    {
        /// <summary>
        /// Convert bytes to kilobytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static long BytesToKilobytes(this long bytes)
        {
            return bytes / 1024;
        }

        /// <summary>
        /// Convert bytes to kilobytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static int BytesToKilobytes(this int bytes)
        {
            return bytes / 1024;
        }

        /// <summary>
        /// Convert bytes to megabytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double BytesToMegabytes(this long bytes)
        {
            return bytes / 1024.0 / 1024.0;
        }

        /// <summary>
        /// Convert bytes to megabytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double BytesToMegabytes(this int bytes)
        {
            return bytes / 1024.0 / 1024.0;
        }

        /// <summary>
        /// Convert bytes to gigabytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double BytesToGigabytes(this long bytes)
        {
            return bytes / 1024.0 / 1024.0 / 1024.0;
        }

        /// <summary>
        /// Convert bytes to gigabytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double BytesToGigabytes(this int bytes)
        {
            return bytes / 1024.0 / 1024.0 / 1024.0;
        }

        /// <summary>
        /// Convert bytes to terabytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double BytesToTerabytes(this long bytes)
        {
            return bytes / 1024.0 / 1024.0 / 1024.0 / 1024.0;
        }

        /// <summary>
        /// Convert bytes to terabytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double BytesToTerabytes(this int bytes)
        {
            return bytes / 1024.0 / 1024.0 / 1024.0 / 1024.0;
        }

        /// <summary>
        /// Convert kilobytes to bytes
        /// </summary>
        /// <param name="kilobytes"></param>
        /// <returns></returns>
        public static long KilobytesToBytes(this long kilobytes)
        {
            return kilobytes * 1024;
        }

        /// <summary>
        /// Convert kilobytes to bytes
        /// </summary>
        /// <param name="kilobytes"></param>
        /// <returns></returns>
        public static int KilobytesToBytes(this int kilobytes)
        {
            return kilobytes * 1024;
        }

        /// <summary>
        /// Convert kilobytes to megabytes
        /// </summary>
        /// <param name="kilobytes"></param>
        /// <returns></returns>
        public static double KilobytesToMegabytes(this long kilobytes)
        {
            return kilobytes / 1024.0;
        }

        /// <summary>
        /// Convert kilobytes to megabytes
        /// </summary>
        /// <param name="kilobytes"></param>
        /// <returns></returns>
        public static double KilobytesToMegabytes(this int kilobytes)
        {
            return kilobytes / 1024.0;
        }

        /// <summary>
        /// Convert megabytes to kilobytes
        /// </summary>
        /// <param name="megabytes"></param>
        /// <returns></returns>
        public static long MegabytesToKilobytes(this long megabytes)
        {
            return megabytes * 1024;
        }

        /// <summary>
        /// Convert megabytes to kilobytes
        /// </summary>
        /// <param name="megabytes"></param>
        /// <returns></returns>
        public static int MegabytesToKilobytes(this int megabytes)
        {
            return megabytes * 1024;
        }

        /// <summary>
        /// Convert megabytes to gigabytes
        /// </summary>
        /// <param name="megabytes"></param>
        /// <returns></returns>
        public static double MegabytesToGigabytes(this long megabytes)
        {
            return megabytes / 1024.0;
        }

        /// <summary>
        /// Convert megabytes to gigabytes
        /// </summary>
        /// <param name="megabytes"></param>
        /// <returns></returns>
        public static double MegabytesToGigabytes(this int megabytes)
        {
            return megabytes / 1024.0;
        }

        /// <summary>
        /// Convert gigabytes to megabytes
        /// </summary>
        /// <param name="gigabytes"></param>
        /// <returns></returns>
        public static long GigabytesToMegabytes(this long gigabytes)
        {
            return gigabytes * 1024;
        }

        /// <summary>
        /// Convert gigabytes to megabytes
        /// </summary>
        /// <param name="gigabytes"></param>
        /// <returns></returns>
        public static int GigabytesToMegabytes(this int gigabytes)
        {
            return gigabytes * 1024;
        }

        /// <summary>
        /// Convert gigabytes to terabytes
        /// </summary>
        /// <param name="gigabytes"></param>
        /// <returns></returns>
        public static double GigabytesToTerabytes(this long gigabytes)
        {
            return gigabytes / 1024.0;
        }

        /// <summary>
        /// Convert gigabytes to terabytes
        /// </summary>
        /// <param name="gigabytes"></param>
        /// <returns></returns>
        public static double GigabytesToTerabytes(this int gigabytes)
        {
            return gigabytes / 1024.0;
        }

        /// <summary>
        /// Convert terabytes to gigabytes
        /// </summary>
        /// <param name="terabytes"></param>
        /// <returns></returns>
        public static long TerabytesToGigabytes(this long terabytes)
        {
            return terabytes * 1024;
        }

        /// <summary>
        /// Convert terabytes to gigabytes
        /// </summary>
        /// <param name="terabytes"></param>
        /// <returns></returns>
        public static int TerabytesToGigabytes(this int terabytes)
        {
            return terabytes * 1024;
        }
    }
}
