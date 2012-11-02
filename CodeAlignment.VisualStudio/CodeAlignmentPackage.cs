using System;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;

namespace CMcG.CodeAlignment
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "7.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.PackageGuidStr)]
    public sealed class CodeAlignmentPackage : Package
    {
    }
}