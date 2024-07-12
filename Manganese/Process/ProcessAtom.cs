using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manganese.Number;

namespace Manganese.Process
{
    public static class ProcessAtom
    {
        /// <summary>
        /// Get current computer installed memory size in MB
        /// </summary>
        /// <returns></returns>
        public static int GetComputerMemorySize()
        {
            return (int)Math.Truncate(GC.GetGCMemoryInfo().TotalAvailableMemoryBytes.BytesToMegabytes());
        }
    }
}
