namespace VideoSource
{
    using System;

    public interface IVideoSource
    {
        event CameraEventHandler NewFrame;

        void SignalToStop();
        void Start();
        void Stop();
        void WaitForStop();

        int BytesReceived { get; }

        int FramesReceived { get; }

        string Login { get; set; }

        string Password { get; set; }

        bool Running { get; }

        object UserData { get; set; }

        string VideoSource { get; set; }
    }
}

