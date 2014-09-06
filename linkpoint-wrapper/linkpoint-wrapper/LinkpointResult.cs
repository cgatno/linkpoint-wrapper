using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace linkpoint_wrapper
{
    public class LinkpointResult
    {
        public enum TransactionResult
        {
            APPROVED,
            DECLINED,
            BLOCKED
        }

        private const string AVS_RESPONSE_TAG = "r_avs";
        private const string ORDER_NUMBER_TAG = "r_ordernum";
        private const string ERROR_TAG = "r_error";
        private const string TRANSACTION_RESULT_TAG = "r_approved";
        private const string APPROVAL_CODE_TAG = "r_code";
        private const string MESSAGE_TAG = "r_message";
        private const string DATE_TIME_TAG = "r_time";
        private const string REFERENCE_NUMBER_TAG = "r_ref";
        private const string T_DATE_TAG = "tdate";
        private const string TAX_TAG = "r_tax";
        private const string SHIPPING_TAG = "r_shipping";
        private const string AUTHENTICATION_RESULT_TAG = "r_authresponse";

        public LinkpointResult(string ResultXML)
        {
           using (XmlReader reader = XmlReader.Create(new StringReader(ResultXML)))
           {
                while(reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case AVS_RESPONSE_TAG:
                                AddressVerificationSystemResponse = reader.ReadElementContentAsString();
                                break;
                            case ORDER_NUMBER_TAG:
                                OrderNumber = reader.ReadElementContentAsString();
                                break;
                            case ERROR_TAG:
                                Error = reader.ReadElementContentAsString();
                                break;
                            case TRANSACTION_RESULT_TAG:
                                switch (reader.ReadElementContentAsString().ToLower())
                                {
                                    case "approved":
                                        Result = TransactionResult.APPROVED;
                                        break;
                                    case "declined":
                                        Result = TransactionResult.DECLINED;
                                        break;
                                    case "blocked":
                                        Result = TransactionResult.BLOCKED;
                                        break;
                                    default:
                                        Result = TransactionResult.DECLINED;
                                        break;
                                }
                                break;
                            case APPROVAL_CODE_TAG:
                                ApprovalCode = reader.ReadElementContentAsString();
                                break;
                            case MESSAGE_TAG:
                                Message = reader.ReadElementContentAsString();
                                break;
                            case DATE_TIME_TAG:
                                TransactionDateTime = reader.ReadElementContentAsString();
                                break;
                            case T_DATE_TAG:
                                tdate = reader.ReadElementContentAsString();
                                break;
                            case TAX_TAG:
                                CalculatedTax = reader.ReadElementContentAsDecimal();
                                break;
                            case SHIPPING_TAG:
                                CalculatedShipping = reader.ReadElementContentAsDecimal();
                                break;
                            case AUTHENTICATION_RESULT_TAG:
                                AuthenticationResults = reader.ReadElementContentAsString();
                                break;
                        }
                    }
                }
           }
        }

        public readonly string AddressVerificationSystemResponse;
        public readonly string OrderNumber;
        public readonly string Error;
        public readonly TransactionResult Result;
        public readonly string ApprovalCode;
        public readonly string Message;
        public readonly string TransactionDateTime;
        public readonly string tdate;
        public readonly decimal CalculatedTax;
        public readonly decimal CalculatedShipping;
        public readonly string AuthenticationResults;
    }
}
