using MeltySynth;

namespace MeltySynthVst
{
    internal sealed class SynthManager
    {
        private Synthesizer synthesizer = new Synthesizer("TimGM6mb.sf2", 44100);

        internal Synthesizer Synthesizer => synthesizer!;
    }
}
