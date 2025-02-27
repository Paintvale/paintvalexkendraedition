using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Ngc;
using Paintvale.Horizon.Sdk.Ngc.Detail;
using Paintvale.Horizon.Sdk.Sf;
using Paintvale.Horizon.Sdk.Sf.Hipc;
using System;

namespace Paintvale.Horizon.Ngc.Ipc
{
    partial class Service : INgcService
    {
        private readonly ProfanityFilter _profanityFilter;

        public Service(ProfanityFilter profanityFilter)
        {
            _profanityFilter = profanityFilter;
        }

        [CmifCommand(0)]
        public Result GetContentVersion(out uint version)
        {
            lock (_profanityFilter)
            {
                return _profanityFilter.GetContentVersion(out version);
            }
        }

        [CmifCommand(1)]
        public Result Check(
            out uint checkMask,
            [Buffer(HipcBufferFlags.In | HipcBufferFlags.MapAlias)] ReadOnlySpan<byte> text,
            uint regionMask,
            ProfanityFilterOption option)
        {
            lock (_profanityFilter)
            {
                return _profanityFilter.CheckProfanityWords(out checkMask, text, regionMask, option);
            }
        }

        [CmifCommand(2)]
        public Result Mask(
            out int maskedWordsCount,
            [Buffer(HipcBufferFlags.Out | HipcBufferFlags.MapAlias)] Span<byte> filteredText,
            [Buffer(HipcBufferFlags.In | HipcBufferFlags.MapAlias)] ReadOnlySpan<byte> text,
            uint regionMask,
            ProfanityFilterOption option)
        {
            lock (_profanityFilter)
            {
                int length = Math.Min(filteredText.Length, text.Length);

                text[..length].CopyTo(filteredText[..length]);

                return _profanityFilter.MaskProfanityWordsInText(out maskedWordsCount, filteredText, regionMask, option);
            }
        }

        [CmifCommand(3)]
        public Result Reload()
        {
            lock (_profanityFilter)
            {
                return _profanityFilter.Reload();
            }
        }
    }
}
