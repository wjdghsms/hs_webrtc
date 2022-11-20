using Microsoft.MixedReality.WebRTC;
using Microsoft.MixedReality.WebRTC.Unity;
using SocketIOClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using WebSocketSharp;

public class ExSignaler : Signaler
{
    public bool AutoLogErrors = true;

    [Header("Server")]
    [Tooltip("The node-dss server to connect to")]
    public string HttpServerAddress = "http://127.0.0.1:3000/";

    [Tooltip("The interval (in ms) that the server is polled at")]
    public float PollTimeMs = 500f;

    private SocketIOUnity mSocket;

    private bool mConnected;

    // Start is called before the first frame update
    void Start()
    {
        // 설정
        mSocket = new SocketIOUnity(new Uri("http://localhost:3000"), new SocketIOOptions
        {
            Query = new Dictionary<string, string>
            {
                {"token", "UNITY" }
            }
    ,
            Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
        });

        // on
        // answer
        // ice
        // offer
   ///     mSocket.On("offer", onWelcome);
        // welcome
        mSocket.OnUnityThread("welcome", onWelcome);
        // emit
        // join_room

    }


    bool bIsConnected = false;
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // 서버에 연결
        if (mSocket.Connected == false)
        {
            mSocket.Connect();
            bIsConnected = true;
            return;
        }

        if (bIsConnected)
        {
            mSocket.Emit("join_room", "ttt");
            bIsConnected = false;
        }

    }

    private void onWelcome(SocketIOResponse response)
    {
        Debug.Log("aa");
    }


        


    public void OnRecv(object sender, MessageEventArgs e)
    {
        
    }

    public void CloseConnect(object sender, CloseEventArgs e)
    {

    }


    /// <inheritdoc/>
    public override Task SendMessageAsync(SdpMessage message)
    {
        return null;
    }

    /// <inheritdoc/>
    public override Task SendMessageAsync(IceCandidate candidate)
    {
        return null;
    }
}
