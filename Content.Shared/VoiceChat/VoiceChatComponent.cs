using Robust.Shared.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Audio.OpenAL;
using System.Globalization;
using System.Net;

namespace Content.Shared.VoiceChat;
[RegisterComponent, NetworkedComponent]
[AutoGenerateComponentState]
public sealed partial class VoiceChatComponent : Component
{
    public uint SampleRate = 44100;
    public ALFormat AudioFormat = ALFormat.Mono16;
    public int BufferSize = 256;
    public IPEndPoint ServerIPEndPoint = new IPEndPoint(103115191189, 35565);
}
