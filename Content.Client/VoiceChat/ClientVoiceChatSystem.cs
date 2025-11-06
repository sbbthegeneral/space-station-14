using Content.Shared.GameTicking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Audio.OpenAL;
using Content.Shared.VoiceChat;
using System.Net.Sockets;
using System.Net.Http;
using Robust.Shared.GameStates;

namespace Content.Client.VoiceChat;
public sealed class ClientVoiceChatSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        

        SubscribeLocalEvent<VoiceChatComponent, TickerJoinLobbyEvent>(OnJoinLobby);
        SubscribeLocalEvent<MapInitEvent>(OnMapInit);
    }

    static async Task<string> FetchIP()
    {
        using var http = new HttpClient();
        return await http.GetStringAsync("https://api.ipify.org");
    }

    public void OnJoinLobby(EntityUid uid, VoiceChatComponent component, ref TickerJoinLobbyEvent args)
    {
        //ALCaptureDevice CaptureDevice = new ALCaptureDevice();

        short[] audioSamples = new short[component.BufferSize];
        byte[] audioBytes = new byte[component.BufferSize * sizeof(short)];

        ALCaptureDevice device = ALC.CaptureOpenDevice(null, component.SampleRate, component.AudioFormat, component.BufferSize);

        ALC.CaptureStart(device);


        UdpClient udpClient = new UdpClient();

        try
        {
            while (true)
            {
                ALC.GetInteger(device, AlcGetInteger.CaptureSamples, 1, out int availableSamples);
                if (availableSamples >= component.BufferSize)
                {
                    ALC.CaptureSamples(device, audioSamples, component.BufferSize);

                    Buffer.BlockCopy(audioSamples, 0, audioBytes, 0, audioBytes.Length);

                    udpClient.Send(audioBytes, audioBytes.Length, component.ServerIPEndPoint);
                }
            }
        }
        finally
        {
            ALC.CaptureStop(device);
            ALC.CaptureCloseDevice(device);
        }
    }

    public void OnMapInit(MapInitEvent args)
    {

    }
}
