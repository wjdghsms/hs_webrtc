using Microsoft.MixedReality.WebRTC;
using Microsoft.MixedReality.WebRTC.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ExSignaler : Signaler
{
    public bool AutoLogErrors = true;

    [Header("Server")]
    [Tooltip("The node-dss server to connect to")]
    public string HttpServerAddress = "http://127.0.0.1:3000/";

    [Tooltip("The interval (in ms) that the server is polled at")]
    public float PollTimeMs = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region ISignaler interface

    /// <inheritdoc/>
    public override Task SendMessageAsync(SdpMessage message)
    {
        return SendMessageImplAsync(new NodeDssMessage(message));
    }

    /// <inheritdoc/>
    public override Task SendMessageAsync(IceCandidate candidate)
    {
        return SendMessageImplAsync(new NodeDssMessage(candidate));
    }

    #endregion
