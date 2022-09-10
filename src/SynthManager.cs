using System;
using System.Collections.Generic;
using MeltySynth;

namespace MeltySynthVst
{
    internal sealed class SynthManager
    {
        private SoundFont soundFont = new SoundFont("TimGM6mb.sf2");
        private List<MidiMessage> messages = new List<MidiMessage>();

        private Synthesizer? synthesizer;

        internal void ClearMessages()
        {
            messages.Clear();
        }

        internal void PushMessage(int delta, int channel, int command, int data1, int data2)
        {
            messages.Add(new MidiMessage(delta, channel, command, data1, data2));
        }

        internal void Render(Span<float> left, Span<float> right)
        {
            var start = 0;

            foreach (var msg in messages)
            {
                var count = msg.Delta - start;
                synthesizer!.Render(left.Slice(start, count), right.Slice(start, count));
                synthesizer!.ProcessMidiMessage(msg.Channel, msg.Command, msg.Data1, msg.Data2);
                start = msg.Delta;
            }

            synthesizer!.Render(left.Slice(start), right.Slice(start));
        }

        internal int SampleRate
        {
            get => synthesizer!.SampleRate;
            set => synthesizer = new Synthesizer(soundFont, value);
        }



        private struct MidiMessage
        {
            private int delta;
            private byte channel;
            private byte command;
            private byte data1;
            private byte data2;

            internal MidiMessage(int delta, int channel, int command, int data1, int data2)
            {
                this.delta = delta;
                this.channel = (byte)channel;
                this.command = (byte)command;
                this.data1 = (byte)data1;
                this.data2 = (byte)data2;
            }

            internal int Delta => delta;
            internal int Channel => channel;
            internal int Command => command;
            internal int Data1 => data1;
            internal int Data2 => data2;
        }
    }
}
