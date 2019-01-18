using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TRTLFarm.Services.ServiceModels;

namespace TRTLFarm.Services
{
    public static class TRTLService
    {
        public static string token = ConfigurationManager.AppSetting["APIToken"].ToString();
        public static string CreateTRTLAddress()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            var client = new RestClient("https://api.trtl.services/v1/address");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", $"Bearer {token}");

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response = client.Execute(request);
            Address address = JsonConvert.DeserializeObject<Address>(response.Content);
            return address.address;
        }

        public static AddressBalance GetTRTLBalance(string addressToCheck)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            var client = new RestClient($"https://api.trtl.services/v1/address/{addressToCheck}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", $"Bearer {token}");

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.NotFound)
            {
                try
                {
                    AddressBalance addressBalance = JsonConvert.DeserializeObject<AddressBalance>(response.Content);
                    return addressBalance;
                }
                catch (Exception)
                {
                    return new AddressBalance();
                }
            }
            else
            {
                return new AddressBalance();
            }
        }


        public static float GetTRTLFee(float amount)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            var client = new RestClient($"https://api.trtl.services/v1/transfer/fee/{amount}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", $"Bearer {token}");

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.NotFound)
            {
                try
                {
                    float fee = JsonConvert.DeserializeObject<float>(response.Content);
                    return fee;
                }
                catch (Exception)
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

        public static KeysModel GetAddressKeys(string address)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            var client = new RestClient($"https://api.trtl.services/v1/address/keys/{address}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", $"Bearer {token}");

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.NotFound)
            {
                try
                {
                    KeysModel addressKeys = JsonConvert.DeserializeObject<KeysModel>(response.Content);
                    return addressKeys;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /**/
        public static Transfer TransferTRTL(string from, string to, float amount, float fee, string paymentId = "", string extra = "")
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            var client = new RestClient("https://api.trtl.services/v1/transfer");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", $"Bearer {token}");
            //TransferTRTL postData = new TransferTRTL() { from = from, to = to, amount = amount, fee = fee };
            //request.AddParameter("formData", JsonConvert.SerializeObject(postData), ParameterType.RequestBody);

            request.AddJsonBody(
            new
            {
                from = from,
                to = to,
                amount = amount,
                fee = fee
            });
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };


            IRestResponse response = client.Execute(request);
            Transfer transfer = JsonConvert.DeserializeObject<Transfer>(response.Content);
            return transfer;
        }


        public static List<string> GetAllAdresses()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            var client = new RestClient($"https://api.trtl.services/v1/address/all");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", $"Bearer {token}");

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.NotFound)
            {
                try
                {
                    List<string> addresses = JsonConvert.DeserializeObject<List<string>>(response.Content);
                    return addresses;
                }
                catch (Exception)
                {
                    return new List<string>();
                }
            }
            else
            {
                return new List<string>();
            }
        }


        internal static string GetPaymentId(int stringLength = 64)
        {
            StringBuilder sb = new StringBuilder();
            int numGuidsToConcat = (((stringLength - 1) / 32) + 1);
            for (int i = 1; i <= numGuidsToConcat; i++)
            {
                sb.Append(Guid.NewGuid().ToString("N"));
            }

            return sb.ToString(0, stringLength);
        }


    }
}
