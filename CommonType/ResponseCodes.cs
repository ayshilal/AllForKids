namespace CommonType
{
    public static class ResponseCode
    {
        public const string SUCCESSFUL = "00";
        public const string SYSTEM_ERROR = "01";
        public const string DB_ERROR = "02";
        public const string DB_VALIDATION_ERROR = "03";
        public const string NO_PERMISSION_FOUND = "04";
        public const string NO_RECORD_FOUND = "05";
        public const string WORKFLOW_ERROR = "06";
        public const string SERVICE_ERROR = "07";
        public const string INCORRECT_LOGIN_CREDENTIALS = "08";
        public const string EMAIL_ADDRESS_DEFINED_ALREADY = "09";
        public const string AUTHORIZED = "10";
        public const string NOT_AUTHORIZED = "11";
        public const string ALREADY_DEFINED = "12";
        public const string MISSING_DATA = "13";
        public const string PROVISION_ALREADY_TAKEN = "14";
        public const string TICKET_ALREADY_TAKEN = "15";
        public const string PROVISION_NOT_FOUND = "16";
        public const string SOME_DATA_NOT_UPDATED = "17";
        public const string PROVISION_EXPIRED = "18";
        public const string TRANSACTION_ALREADY_CANCELLED = "19";
        public const string INQUIRY_ERROR = "30";
        public const string PAYMENT_ERROR = "31";
        public const string REFUND_ERROR = "32";
        public const string VOID_ERROR = "33";
        public const string INCORRECT_DATA = "34";
    }

    public static class ResponseMessage
    {
        public const string SUCCESSFUL = "Successful";
    }
}
