using System;
using System.Runtime.InteropServices;

namespace ParticleSim.CSGSolid
{
    public abstract class CSGSolid : IPointerGettable, IDisposable
    {
        private protected IntPtr Ptr;

        public IntPtr GetPointer() => Ptr;

        public void Dispose()
        {
            Marshal.FreeCoTaskMem(Ptr);
            GC.SuppressFinalize(this);
        }
    }
}
