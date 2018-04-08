using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_demonstration.Som
{
    public class SatUserParameter : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter SatUserName;
        public RACoN.RTILayer.CHlaInteractionParameter SatUserAltitude;
        public RACoN.RTILayer.CHlaInteractionParameter SatUserOrbitalInclination;
        public RACoN.RTILayer.CHlaInteractionParameter SatUserRightAscensionOfAscendingNode;
        public RACoN.RTILayer.CHlaInteractionParameter SatUserOrbitalNumber;
        public RACoN.RTILayer.CHlaInteractionParameter SatUserInPlaneSatelliteNumber;
        public RACoN.RTILayer.CHlaInteractionParameter SatUserPhaseParameters;
        public RACoN.RTILayer.CHlaInteractionParameter SatUserRAANSpread;
        #endregion
        public SatUserParameter() : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.SatUserParameter";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;
            // Create Parameters
            SatUserName = new RACoN.RTILayer.CHlaInteractionParameter("SatUserName");
            this.Parameters.Add(SatUserName);

            SatUserAltitude = new RACoN.RTILayer.CHlaInteractionParameter("SatUserAltitude");
            this.Parameters.Add(SatUserAltitude);

            SatUserOrbitalInclination = new RACoN.RTILayer.CHlaInteractionParameter("SatUserOrbitalInclination");
            this.Parameters.Add(SatUserOrbitalInclination);

            SatUserRightAscensionOfAscendingNode = new RACoN.RTILayer.CHlaInteractionParameter("SatUserRightAscensionOfAscendingNode");
            this.Parameters.Add(SatUserRightAscensionOfAscendingNode);

            SatUserOrbitalNumber = new RACoN.RTILayer.CHlaInteractionParameter("SatUserOrbitalNumber");
            this.Parameters.Add(SatUserOrbitalNumber);

            SatUserInPlaneSatelliteNumber = new RACoN.RTILayer.CHlaInteractionParameter("SatUserInPlaneSatelliteNumber");
            this.Parameters.Add(SatUserInPlaneSatelliteNumber);

            SatUserPhaseParameters = new RACoN.RTILayer.CHlaInteractionParameter("SatUserPhaseParameters");
            this.Parameters.Add(SatUserPhaseParameters);

            SatUserRAANSpread = new RACoN.RTILayer.CHlaInteractionParameter("SatUserRAANSpread");
            this.Parameters.Add(SatUserRAANSpread);

        }

    }
}
