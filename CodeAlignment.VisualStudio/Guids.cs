// Guids.cs
// MUST match guids.h
using System;

namespace CMcG.CodeAlignment
{
    static class GuidList
    {
        public const string PackageGuidStr = "2adcbb11-89c4-451e-97f2-14049154ccad",
                            CmdSetGuidStr  = "580373b2-1046-48bc-acda-f2c41c3c2857";

        public static readonly Guid CmdSetGuid = new Guid(CmdSetGuidStr);
    };
}