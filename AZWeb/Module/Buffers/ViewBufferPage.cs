using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AZWeb.Module.Buffers
{
    internal class ViewBufferPage
    {
        public ViewBufferPage(ViewBufferValue[] buffer)
        {
            Buffer = buffer;
        }

        public ViewBufferValue[] Buffer { get; }

        public int Capacity => Buffer.Length;

        public int Count { get; set; }

        public bool IsFull => Count == Capacity;

        // Very common trivial method; nudge it to inline https://github.com/aspnet/Mvc/pull/8339
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ViewBufferValue value) => Buffer[Count++] = value;
    }
}
