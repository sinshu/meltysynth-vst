﻿using System;
using Jacobi.Vst.Core;
using Jacobi.Vst.Plugin.Framework.Plugin;

namespace MeltySynthVst
{
    internal sealed class AudioProcessor : VstPluginAudioProcessor
    {
        private readonly SynthManager synthManager;

        public AudioProcessor(SynthManager synthManager) : base(0, 2, 0, true)
        {
            if (synthManager == null)
            {
                throw new ArgumentNullException(nameof(synthManager));
            }

            this.synthManager = synthManager;
        }

        public override void Process(VstAudioBuffer[] inChannels, VstAudioBuffer[] outChannels)
        {
            synthManager.Synthesizer.Render(outChannels[0].AsSpan(), outChannels[1].AsSpan());
        }
    }
}