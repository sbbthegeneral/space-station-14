using Content.Server.GameTicking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Audio.OpenAL;
using Content.Shared.GameTicking;

namespace Content.Server.VoiceChat;
public sealed class ServerVoiceChatSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        //SubscribeLocalEvent<PlayerJoinedLobbyEvent>(OnJoinLobby);
        
        SubscribeLocalEvent<TickerLobbyStatusEvent>(OnJoinLobby);
    }

    public void OnJoinLobby(TickerLobbyStatusEvent args)
    {
        if (args.IsRoundStarted & args.YouAreReady)
        {

        }
    }

}
