using Jacobi.Vst.Plugin.Framework;
using Jacobi.Vst.Plugin.Framework.Plugin;

namespace MeltySynthVst
{
    public sealed class PluginCommandStub : StdPluginCommandStub
    {
        protected override IVstPlugin CreatePluginInstance()
        {
            return new Plugin();
        }
    }
}
