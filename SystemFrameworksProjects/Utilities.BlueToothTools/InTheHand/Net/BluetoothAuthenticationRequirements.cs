namespace Utilities.BlueToothTools.InTheHand.Net.Bluetooth
{
    public enum BluetoothAuthenticationRequirements
    {
        MITMProtectionNotDefined = 0xff,
        MITMProtectionNotRequired = 0,
        MITMProtectionNotRequiredBonding = 2,
        MITMProtectionNotRequiredGeneralBonding = 4,
        MITMProtectionRequired = 1,
        MITMProtectionRequiredBonding = 3,
        MITMProtectionRequiredGeneralBonding = 5
    }
}

