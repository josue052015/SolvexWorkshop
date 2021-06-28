using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
   
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        public SingleResponsability.FilePolicySource PolicySource { get; set; } = new SingleResponsability.FilePolicySource();
        public decimal Rating { get; set; }
        public void Rate()
        {
            Logger.Log("Starting rate.");

             Logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = PolicySource.GetPolicyFromSource();

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    var raterAuto = new Open_Closed.AutoPolicyRater(this, this.Logger);
                    raterAuto.Rate(policy);
                    break;

                case PolicyType.Land:
                    var raterLand = new Open_Closed.LandPolicyRate(this, this.Logger);
                    raterLand.Rate(policy);
                    break;

                case PolicyType.Life:
                    var raterLife = new Open_Closed.LifePolicyRate(this, this.Logger);
                    raterLife.Rate(policy);
                    break;

                default:
                    Logger.Log("Unknown policy type");
                    break;
            }

            Logger.Log("Rating completed.");
        }
        
    }
}
