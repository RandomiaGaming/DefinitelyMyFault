using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace DefinitelyMyFault
{
    public static class BSODHelper
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern void RtlSetProcessIsCritical(uint v1, uint v2, uint v3);
        private static int SeDebugPrivilege = 20;
        public static void ACPDBSOD()
        {
            Process.EnterDebugMode();
            RtlSetProcessIsCritical(1, 0, 0);
            Process.GetCurrentProcess().Kill();
        }
        public static void RaiseHardException(uint stopCode)
        {
            try
            {
                RtlAdjustPrivilege(19, true, false, out _);
            }
            catch
            {

            }
            NtRaiseHardError(stopCode, 0, 0, IntPtr.Zero, 6, out _);
        }
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);
    }
}