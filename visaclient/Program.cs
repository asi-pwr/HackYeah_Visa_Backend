using System;
using Newtonsoft.Json;
using Vdp.Lib;

namespace Vdp.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                return;
            }
            string result = "";
            if (args[0] == "push")
            {
                result = PushFundTransactions();
            }
            else if (args[0] == "pull")
            {
                result = PullFundTransactions();
            }
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        private static string PushFundTransactions()
        {
            var visaAPIClient = new VisaAPIClient();
            string strDate = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss");
            var pushFundsRequest =
            "{\r\n\"acquirerCountryCode\": \"840\",\r\n\"acquiringBin\": \"408999\",\r\n\"amount\": \"124.05\",\r\n\"businessApplicationId\": \"AA\",\r\n\"cardAcceptor\": {\r\n\"address\": {\r\n\"country\": \"USA\",\r\n\"county\": \"San Mateo\",\r\n\"state\": \"CA\",\r\n\"zipCode\": \"94404\"\r\n},\r\n\"idCode\": \"CA-IDCode-77765\",\r\n\"name\": \"Visa Inc. USA-Foster City\",\r\n\"terminalId\": \"TID-9999\"\r\n},\r\n\"localTransactionDateTime\": \"2018-11-24T23:14:29\",\r\n\"merchantCategoryCode\": \"6012\",\r\n\"pointOfServiceData\": {\r\n\"motoECIIndicator\": \"0\",\r\n\"panEntryMode\": \"90\",\r\n\"posConditionCode\": \"00\"\r\n},\r\n\"recipientName\": \"rohan\",\r\n\"recipientPrimaryAccountNumber\": \"4957030420210496\",\r\n\"retrievalReferenceNumber\": \"412770451018\",\r\n\"senderAccountNumber\": \"4653459515756154\",\r\n\"senderAddress\": \"901 Metro Center Blvd\",\r\n\"senderCity\": \"Foster City\",\r\n\"senderCountryCode\": \"124\",\r\n\"senderName\": \"Mohammed Qasim\",\r\n\"senderReference\": \"\",\r\n\"senderStateCode\": \"CA\",\r\n\"sourceOfFundsCode\": \"05\",\r\n\"systemsTraceAuditNumber\": \"451018\",\r\n\"transactionCurrencyCode\": \"USD\",\r\n\"transactionIdentifier\": \"381228649430015\"\r\n}";

            string baseUri = "visadirect/";
            string resourcePath = "fundstransfer/v1/pushfundstransactions/";
            string status = visaAPIClient.DoMutualAuthCall(baseUri + resourcePath, "POST", "Push Funds Transaction Test", pushFundsRequest);
            return status;
        }


        private static string PullFundTransactions()
        {
            var visaAPIClient = new VisaAPIClient();
            string strDate = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss");
            var pushFundsRequest =
            "{\r\n\"acquirerCountryCode\": \"840\",\r\n\"acquiringBin\": \"408999\",\r\n\"amount\": \"124.02\",\r\n\"businessApplicationId\": \"AA\",\r\n\"cardAcceptor\": {\r\n\"address\": {\r\n\"country\": \"USA\",\r\n\"county\": \"081\",\r\n\"state\": \"CA\",\r\n\"zipCode\": \"94404\"\r\n},\r\n\"idCode\": \"ABCD1234ABCD123\",\r\n\"name\": \"Visa Inc. USA-Foster City\",\r\n\"terminalId\": \"ABCD1234\"\r\n},\r\n\"cavv\": \"0700100038238906000013405823891061668252\",\r\n\"foreignExchangeFeeTransaction\": \"11.99\",\r\n\"localTransactionDateTime\": \"2018-11-24T20:42:42\",\r\n\"retrievalReferenceNumber\": \"330000550000\",\r\n\"senderCardExpiryDate\": \"2015-10\",\r\n\"senderCurrencyCode\": \"USD\",\r\n\"senderPrimaryAccountNumber\": \"4895142232120006\",\r\n\"surcharge\": \"11.99\",\r\n\"systemsTraceAuditNumber\": \"451001\",\r\n\"nationalReimbursementFee\": \"11.22\",\r\n\"cpsAuthorizationCharacteristicsIndicator\": \"Y\",\r\n\"addressVerificationData\": {\r\n\"street\": \"XYZ St\",\r\n\"postalCode\": \"12345\"\r\n}\r\n}";

            string baseUri = "visadirect/";
            string resourcePath = "fundstransfer/v1/pullfundstransactions/";
            string status = visaAPIClient.DoMutualAuthCall(baseUri + resourcePath, "POST", "Push Funds Transaction Test", pushFundsRequest);
            return status;
        }

        private static string pullfundstransactionsget()
        {
            var visaAPIClient = new VisaAPIClient();
            string strDate = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss");
            var pushFundsRequest =
            "{\r\n\"acquirerCountryCode\": \"840\",\r\n\"acquiringBin\": \"408999\",\r\n\"amount\": \"124.02\",\r\n\"businessApplicationId\": \"AA\",\r\n\"cardAcceptor\": {\r\n\"address\": {\r\n\"country\": \"USA\",\r\n\"county\": \"081\",\r\n\"state\": \"CA\",\r\n\"zipCode\": \"94404\"\r\n},\r\n\"idCode\": \"ABCD1234ABCD123\",\r\n\"name\": \"Visa Inc. USA-Foster City\",\r\n\"terminalId\": \"ABCD1234\"\r\n},\r\n\"cavv\": \"0700100038238906000013405823891061668252\",\r\n\"foreignExchangeFeeTransaction\": \"11.99\",\r\n\"localTransactionDateTime\": \"2018-11-24T20:42:42\",\r\n\"retrievalReferenceNumber\": \"330000550000\",\r\n\"senderCardExpiryDate\": \"2015-10\",\r\n\"senderCurrencyCode\": \"USD\",\r\n\"senderPrimaryAccountNumber\": \"4895142232120006\",\r\n\"surcharge\": \"11.99\",\r\n\"systemsTraceAuditNumber\": \"451001\",\r\n\"nationalReimbursementFee\": \"11.22\",\r\n\"cpsAuthorizationCharacteristicsIndicator\": \"Y\",\r\n\"addressVerificationData\": {\r\n\"street\": \"XYZ St\",\r\n\"postalCode\": \"12345\"\r\n}\r\n}";

            string baseUri = "visadirect/";
            string resourcePath = "fundstransfer/v1/pullfundstransactions/23423432";
            string status = visaAPIClient.DoMutualAuthCall(baseUri + resourcePath, "GET", "Push Funds Transaction Test", "");
            return status;
        }


    }
}
