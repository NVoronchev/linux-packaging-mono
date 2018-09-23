// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Internal.TypeSystem;

namespace Internal.IL.Stubs
{
    public partial class CalliMarshallingMethodThunk : IPrefixMangledSignature
    {
        MethodSignature IPrefixMangledSignature.BaseSignature
        {
            get
            {
                return _targetSignature;
            }
        }

        string IPrefixMangledSignature.Prefix
        {
            get
            {
                return "Calli";
            }
        }
    }
}
