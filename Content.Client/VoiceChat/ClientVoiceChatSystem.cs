using Content.Shared.GameTicking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Audio.OpenAL;

namespace Content.Client.VoiceChat;
public sealed class ClientVoiceChatSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TickerJoinLobbyEvent>(OnJoinLobby);
    }

    public void OnJoinLobby(TickerJoinLobbyEvent args)
    {

    } 

}
