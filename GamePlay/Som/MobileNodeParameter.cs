using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_demonstration.Som
{
    public class MobileNodeParameter : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter MobileNodeName;
        public RACoN.RTILayer.CHlaInteractionParameter StartLongitude;
        public RACoN.RTILayer.CHlaInteractionParameter StartLatitude;
        public RACoN.RTILayer.CHlaInteractionParameter MobileStartTime;
        public RACoN.RTILayer.CHlaInteractionParameter EndLatitude;
        public RACoN.RTILayer.CHlaInteractionParameter EndLongitude;
        public RACoN.RTILayer.CHlaInteractionParameter MobileSpeed;
        #endregion
        public MobileNodeParameter() : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.MobileNodeParameter";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;
            // Create Parameters
            MobileNodeName = new RACoN.RTILayer.CHlaInteractionParameter("MobileNodeName");
            this.Parameters.Add(MobileNodeName);

            StartLongitude = new RACoN.RTILayer.CHlaInteractionParameter("StartLongitude");
            this.Parameters.Add(StartLongitude);

            StartLatitude = new RACoN.RTILayer.CHlaInteractionParameter("StartLatitude");
            this.Parameters.Add(StartLatitude);

            MobileStartTime = new RACoN.RTILayer.CHlaInteractionParameter("MobileStartTime");
            this.Parameters.Add(MobileStartTime);

            EndLatitude = new RACoN.RTILayer.CHlaInteractionParameter("EndLatitude");
            this.Parameters.Add(EndLatitude);

            EndLongitude = new RACoN.RTILayer.CHlaInteractionParameter("EndLongitude");
            this.Parameters.Add(EndLongitude);

            MobileSpeed = new RACoN.RTILayer.CHlaInteractionParameter("MobileSpeed");
            this.Parameters.Add(MobileSpeed);
        }
    }
}
