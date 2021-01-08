namespace Utilities.BlueToothTools.MsBluetooth
{
    public enum BluetoothError
    {
        BTH_ERROR_ACL_CONNECTION_ALREADY_EXISTS = 11,
        BTH_ERROR_AUTHENTICATION_FAILURE = 5,
        BTH_ERROR_COMMAND_DISALLOWED = 12,
        BTH_ERROR_CONNECTION_TIMEOUT = 8,
        BTH_ERROR_ENCRYPTION_MODE_NOT_ACCEPTABLE = 0x25,
        BTH_ERROR_HARDWARE_FAILURE = 3,
        BTH_ERROR_HOST_REJECTED_LIMITED_RESOURCES = 13,
        BTH_ERROR_HOST_REJECTED_PERSONAL_DEVICE = 15,
        BTH_ERROR_HOST_REJECTED_SECURITY_REASONS = 14,
        BTH_ERROR_HOST_TIMEOUT = 0x10,
        BTH_ERROR_INSTANT_PASSED = 40,
        BTH_ERROR_INVALID_HCI_PARAMETER = 0x12,
        BTH_ERROR_INVALID_LMP_PARAMETERS = 30,
        BTH_ERROR_KEY_MISSING = 6,
        BTH_ERROR_LMP_PDU_NOT_ALLOWED = 0x24,
        BTH_ERROR_LMP_RESPONSE_TIMEOUT = 0x22,
        BTH_ERROR_LMP_TRANSACTION_COLLISION = 0x23,
        BTH_ERROR_LOCAL_HOST_TERMINATED_CONNECTION = 0x16,
        BTH_ERROR_MAX_NUMBER_OF_CONNECTIONS = 9,
        BTH_ERROR_MAX_NUMBER_OF_SCO_CONNECTIONS = 10,
        BTH_ERROR_MEMORY_FULL = 7,
        BTH_ERROR_NO_CONNECTION = 2,
        BTH_ERROR_PAGE_TIMEOUT = 4,
        BTH_ERROR_PAIRING_NOT_ALLOWED = 0x18,
        BTH_ERROR_PAIRING_WITH_UNIT_KEY_NOT_SUPPORTED = 0x29,
        BTH_ERROR_QOS_IS_NOT_SUPPORTED = 0x27,
        BTH_ERROR_REMOTE_LOW_RESOURCES = 20,
        BTH_ERROR_REMOTE_POWERING_OFF = 0x15,
        BTH_ERROR_REMOTE_USER_ENDED_CONNECTION = 0x13,
        BTH_ERROR_REPEATED_ATTEMPTS = 0x17,
        BTH_ERROR_ROLE_CHANGE_NOT_ALLOWED = 0x21,
        BTH_ERROR_SCO_AIRMODE_REJECTED = 0x1d,
        BTH_ERROR_SCO_INTERVAL_REJECTED = 0x1c,
        BTH_ERROR_SCO_OFFSET_REJECTED = 0x1b,
        BTH_ERROR_SUCCESS = 0,
        BTH_ERROR_UKNOWN_LMP_PDU = 0x19,
        BTH_ERROR_UNIT_KEY_NOT_USED = 0x26,
        BTH_ERROR_UNKNOWN_HCI_COMMAND = 1,
        BTH_ERROR_UNSPECIFIED = 0xff,
        BTH_ERROR_UNSPECIFIED_ERROR = 0x1f,
        BTH_ERROR_UNSUPPORTED_FEATURE_OR_PARAMETER = 0x11,
        BTH_ERROR_UNSUPPORTED_LMP_PARM_VALUE = 0x20,
        BTH_ERROR_UNSUPPORTED_REMOTE_FEATURE = 0x1a
    }
}
