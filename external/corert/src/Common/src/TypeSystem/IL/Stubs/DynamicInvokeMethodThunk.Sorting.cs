// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Internal.TypeSystem;

using Debug = System.Diagnostics.Debug;

namespace Internal.IL.Stubs
{
    // Functionality related to determinstic ordering of types
    partial class DynamicInvokeMethodThunk
    {
        private int CompareTo(DynamicInvokeMethodThunk otherMethod)
        {
            int result = _targetSignature.Length - otherMethod._targetSignature.Length;
            if (result != 0)
                return result;

            result = (_targetSignature.HasReturnValue ? 1 : 0) - (otherMethod._targetSignature.HasReturnValue ? 1 : 0);
            if (result != 0)
                return result;

            for (int i = 0; i < _targetSignature.Length; i++)
            {
                result = (int)_targetSignature[i] - (int)otherMethod._targetSignature[i];
                if (result != 0)
                    return result;
            }

            Debug.Assert(this == otherMethod);
            return 0;
        }

        partial class DynamicInvokeThunkGenericParameter
        {
            protected override int ClassCode => -234393261;

            protected override int CompareToImpl(TypeDesc other, TypeSystemComparer comparer)
            {
                var otherType = (DynamicInvokeThunkGenericParameter)other;
                int result = Index - otherType.Index;
                if (result != 0)
                    return result;

                return _owningMethod.CompareTo(otherType._owningMethod);
            }
        }
    }
}