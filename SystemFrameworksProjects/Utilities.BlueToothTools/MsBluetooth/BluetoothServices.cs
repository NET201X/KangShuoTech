namespace Utilities.BlueToothTools.MsBluetooth
{
    using System;

    public static class BluetoothServices
    {
        public static readonly Guid AdvancedAudioDistributionServiceClass_UUID = new Guid(0x110d, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid AudioSinkServiceClass_UUID = new Guid(0x110b, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid AudioSourceServiceClass_UUID = new Guid(0x110a, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid AudioVideoServiceClass_UUID = new Guid(0x112c, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid AVRemoteControlServiceClass_UUID = new Guid(0x110e, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid AVRemoteControlTargetServiceClass_UUID = new Guid(0x110c, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid BasicPringingServiceClass_UUID = new Guid(0x1122, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid BrowseGroupDescriptorServiceClassID_UUID = new Guid(0x1001, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid CommonISDNAccessServiceClass_UUID = new Guid(0x1128, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid CordlessTelephonyServiceClass_UUID = new Guid(0x1109, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid DialupNetworkingServiceClass_UUID = new Guid(0x1103, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid DirectPrintingReferenceObjectsServiceClass_UUID = new Guid(0x1120, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid DirectPrintingServiceClass_UUID = new Guid(0x1118, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid FaxServiceClass_UUID = new Guid(0x1111, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid GenericAudioServiceClass_UUID = new Guid(0x1203, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid GenericFileTransferServiceClass_UUID = new Guid(0x1202, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid GenericNetworkingServiceClass_UUID = new Guid(0x1201, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid GenericTelephonyServiceClass_UUID = new Guid(0x1204, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid GNServiceClass_UUID = new Guid(0x1117, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid HandsfreeAudioGatewayServiceClass_UUID = new Guid(0x111f, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid HandsfreeServiceClass_UUID = new Guid(0x111e, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid HardcopyCableReplacementServiceClass_UUID = new Guid(0x1125, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid HCRPrintServiceClass_UUID = new Guid(0x1126, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid HCRScanServiceClass_UUID = new Guid(0x1127, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid HeadsetAudioGatewayServiceClass_UUID = new Guid(0x1112, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid HeadsetServiceClass_UUID = new Guid(0x1108, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid HumanInterfaceDeviceServiceClass_UUID = new Guid(0x1124, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid ImagingAutomaticArchiveServiceClass_UUID = new Guid(0x111c, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid ImagingReferenceObjectsServiceClass_UUID = new Guid(0x111d, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid ImagingResponderServiceClass_UUID = new Guid(0x111b, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid ImagingServiceClass_UUID = new Guid(0x111a, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid IntercomServiceClass_UUID = new Guid(0x1110, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid IrMCSyncCommandServiceClass_UUID = new Guid(0x1107, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid IrMCSyncServiceClass_UUID = new Guid(0x1104, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid LANAccessUsingPPPServiceClass_UUID = new Guid(0x1102, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid NAPServiceClass_UUID = new Guid(0x1116, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid OBEXFileTransferServiceClass_UUID = new Guid(0x1106, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid OBEXObjectPushServiceClass_UUID = new Guid(0x1105, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid PANUServiceClass_UUID = new Guid(0x1115, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid PnPInformationServiceClass_UUID = new Guid(0x1200, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid PrintingStatusServiceClass_UUID = new Guid(0x1123, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid PublicBrowseGroupServiceClass_UUID = new Guid(0x1002, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid ReferencePrintingServiceClass_UUID = new Guid(0x1119, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid ReflectedUIServiceClass_UUID = new Guid(0x1121, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid SerialPortServiceClass_UUID = new Guid(0x1101, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid ServiceDiscoveryServerServiceClassID_UUID = new Guid(0x1000, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid UDIMTServiceClass_UUID = new Guid(0x112a, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid UDITAServiceClass_UUID = new Guid(0x112b, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid VideoConferencingGWServiceClass_UUID = new Guid(0x1129, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid VideoConferencingServiceClass_UUID = new Guid(0x110f, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid WAPClientServiceClass_UUID = new Guid(0x1114, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
        public static readonly Guid WAPServiceClass_UUID = new Guid(0x1113, 0, 0x1000, Convert.ToByte((sbyte) (-128)), 0, 0, Convert.ToByte((sbyte) (-128)), 0x5f, 0x9b, 0x34, 0xfb);
    }
}

