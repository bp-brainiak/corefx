// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Win32;

namespace System.Security.AccessControl
{
    // We derived this enum from the definitions of KEY_READ and such from
    // winnt.h and from MSDN, plus some experimental validation with regedit.
    // http://msdn.microsoft.com/library/default.asp?url=/library/en-us/sysinfo/base/registry_key_security_and_access_rights.asp
    [Flags]
    public enum RegistryRights
    {
        // No None field - An ACE with the value 0 cannot grant nor deny.
        QueryValues = Interop.mincore.RegistryOperations.KEY_QUERY_VALUE,          // 0x0001 query the values of a registry key
        SetValue = Interop.mincore.RegistryOperations.KEY_SET_VALUE,            // 0x0002 create, delete, or set a registry value
        CreateSubKey = Interop.mincore.RegistryOperations.KEY_CREATE_SUB_KEY,       // 0x0004 required to create a subkey of a specific key
        EnumerateSubKeys = Interop.mincore.RegistryOperations.KEY_ENUMERATE_SUB_KEYS,   // 0x0008 required to enumerate sub keys of a key
        Notify = Interop.mincore.RegistryOperations.KEY_NOTIFY,               // 0x0010 needed to request change notifications
        CreateLink = Interop.mincore.RegistryOperations.KEY_CREATE_LINK,          // 0x0020 reserved for system use
        ///
        /// The Windows Kernel team agrees that it was a bad design to expose the WOW64_n options as permissions.
        /// in the .NET Framework these options are exposed via the RegistryView enum
        ///
        ///        Reg64             = Interop.mincore.RegistryOptions.KEY_WOW64_64KEY,          // 0x0100 operate on the 64-bit registry view
        ///        Reg32             = Interop.mincore.RegistryOptions.KEY_WOW64_32KEY,          // 0x0200 operate on the 32-bit registry view
        ExecuteKey = ReadKey,
        ReadKey = Interop.mincore.RegistryOperations.STANDARD_RIGHTS_READ | QueryValues | EnumerateSubKeys | Notify,
        WriteKey = Interop.mincore.RegistryOperations.STANDARD_RIGHTS_WRITE | SetValue | CreateSubKey,
        Delete = 0x10000,
        ReadPermissions = 0x20000,
        ChangePermissions = 0x40000,
        TakeOwnership = 0x80000,
        FullControl = 0xF003F | Interop.mincore.RegistryOperations.STANDARD_RIGHTS_READ | Interop.mincore.RegistryOperations.STANDARD_RIGHTS_WRITE
    }
}
