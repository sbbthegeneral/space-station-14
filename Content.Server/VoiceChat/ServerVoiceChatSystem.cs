using Content.Server.GameTicking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Audio.OpenAL;

namespace Content.Server.VoiceChat;
public sealed class ServerVoiceChatSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<PlayerJoinedLobbyEvent>(OnJoinLobby);
    }

    public void OnJoinLobby(PlayerJoinedLobbyEvent args)
    {
        
    }

}
