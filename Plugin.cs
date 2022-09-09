﻿using Microsoft.Extensions.DependencyInjection;
using Jacobi.Vst.Core;
using Jacobi.Vst.Plugin.Framework;
using Jacobi.Vst.Plugin.Framework.Plugin;

namespace MeltySynthVst
{
    internal sealed class Plugin : VstPluginWithServices
    {
        public Plugin() : base("MeltySynthVST", 36373435,
            new VstProductInfo("MeltySynthVST", "Nobuaki Tanaka", 1000),
            VstPluginCategory.Synth)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SynthManager>()
                .AddSingletonAll<AudioProcessor>()
                .AddSingletonAll<MidiProcessor>();
        }
    }
}
