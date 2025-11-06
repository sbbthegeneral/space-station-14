using Content.Shared.GameTicking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Audio.OpenAL;
using Content.Shared.VoiceChat;

namespace Content.Client.VoiceChat;
public sealed class ClientVoiceChatSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<VoiceChatComponent, TickerJoinLobbyEvent>(OnJoinLobby);
    }

    public void OnJoinLobby(VoiceChatComponent component, ref TickerJoinLobbyEvent args)
    {
        ALCaptureDevice CaptureDevice = new ALCaptureDevice();

        ALC.CaptureOpenDevice(CaptureDevice, component.SampleRate, );
    }
}
