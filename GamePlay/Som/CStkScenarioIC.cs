using System;
using RACoN;

namespace STK_demonstration.Som
{
    public class CStkScenarioIC : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter ScenarioPath;
        public RACoN.RTILayer.CHlaInteractionParameter LoopMode;
        public RACoN.RTILayer.CHlaInteractionParameter StepTime;
        public RACoN.RTILayer.CHlaInteractionParameter StopTime;
        public RACoN.RTILayer.CHlaInteractionParameter StartTime;
        public RACoN.RTILayer.CHlaInteractionParameter ScenarioName;

        public RACoN.RTILayer.CHlaInteractionParameter SatelliteAltitude;
        public RACoN.RTILayer.CHlaInteractionParameter OrbitalInclination;
        public RACoN.RTILayer.CHlaInteractionParameter RightAscensionOfAscendingNode;
        public RACoN.RTILayer.CHlaInteractionParameter OrbitalNumber;
        public RACoN.RTILayer.CHlaInteractionParameter InPlaneSatelliteNumber;
        public RACoN.RTILayer.CHlaInteractionParameter PhaseParameters;
        public RACoN.RTILayer.CHlaInteractionParameter RAANSpread;
        #endregion //Declarations

        #region Constructor
        public CStkScenarioIC() : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.StkScenario";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // ScenarioPath
            ScenarioPath = new RACoN.RTILayer.CHlaInteractionParameter("ScenarioPath");
            this.Parameters.Add(ScenarioPath);
            // LoopMode
            LoopMode = new RACoN.RTILayer.CHlaInteractionParameter("LoopMode");
            this.Parameters.Add(LoopMode);
            // StepTime
            StepTime = new RACoN.RTILayer.CHlaInteractionParameter("StepTime");
            this.Parameters.Add(StepTime);
            // StopTime
            StopTime = new RACoN.RTILayer.CHlaInteractionParameter("StopTime");
            this.Parameters.Add(StopTime);
            // StartTime
            StartTime = new RACoN.RTILayer.CHlaInteractionParameter("StartTime");
            this.Parameters.Add(StartTime);
            // ScenarioName
            ScenarioName = new RACoN.RTILayer.CHlaInteractionParameter("ScenarioName");
            this.Parameters.Add(ScenarioName);

            SatelliteAltitude = new RACoN.RTILayer.CHlaInteractionParameter("SatelliteAltitude");
            this.Parameters.Add(SatelliteAltitude);

            OrbitalInclination = new RACoN.RTILayer.CHlaInteractionParameter("OrbitalInclination");
            this.Parameters.Add(OrbitalInclination);

            RightAscensionOfAscendingNode = new RACoN.RTILayer.CHlaInteractionParameter("RightAscensionOfAscendingNode");
            this.Parameters.Add(RightAscensionOfAscendingNode);

            OrbitalNumber = new RACoN.RTILayer.CHlaInteractionParameter("OrbitalNumber");
            this.Parameters.Add(OrbitalNumber);

            InPlaneSatelliteNumber = new RACoN.RTILayer.CHlaInteractionParameter("InPlaneSatelliteNumber");
            this.Parameters.Add(InPlaneSatelliteNumber);

            PhaseParameters = new RACoN.RTILayer.CHlaInteractionParameter("PhaseParameters");
            this.Parameters.Add(PhaseParameters);

            RAANSpread = new RACoN.RTILayer.CHlaInteractionParameter("RAANSpread");
            this.Parameters.Add(RAANSpread);
        }
        #endregion //Constructor
    }
}
