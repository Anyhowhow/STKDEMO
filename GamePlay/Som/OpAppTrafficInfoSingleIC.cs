using System;
using RACoN;

namespace STK_demonstration.Som
{
    public class OpAppTrafficInfoSingleIC : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter SubnetName_1;
        public RACoN.RTILayer.CHlaInteractionParameter ScrName;
        public RACoN.RTILayer.CHlaInteractionParameter SubnetName_2;
        public RACoN.RTILayer.CHlaInteractionParameter DestName;
        public RACoN.RTILayer.CHlaInteractionParameter SimTime;
        public RACoN.RTILayer.CHlaInteractionParameter AppTrafficSend;
        public RACoN.RTILayer.CHlaInteractionParameter AppTrafficRcvd;
        public RACoN.RTILayer.CHlaInteractionParameter DelayTime;
        public RACoN.RTILayer.CHlaInteractionParameter DelayVar;
        #endregion //Declarations

        #region Constructor
        public OpAppTrafficInfoSingleIC()
            : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.OpAppTrafficInfoSingle";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // TypeData
            SubnetName_1 = new RACoN.RTILayer.CHlaInteractionParameter("SubnetName_1");
            this.Parameters.Add(SubnetName_1);
            // SensorType
            ScrName = new RACoN.RTILayer.CHlaInteractionParameter("ScrName");
            this.Parameters.Add(ScrName);
            // SensorName
            SubnetName_2 = new RACoN.RTILayer.CHlaInteractionParameter("SubnetName_2");
            this.Parameters.Add(SubnetName_2);
            // ObjectType
            DestName = new RACoN.RTILayer.CHlaInteractionParameter("DestName");
            this.Parameters.Add(DestName);
            // ObjectName
            SimTime = new RACoN.RTILayer.CHlaInteractionParameter("SimTime");
            this.Parameters.Add(SimTime);
            AppTrafficSend = new RACoN.RTILayer.CHlaInteractionParameter("AppTrafficSend");
            this.Parameters.Add(AppTrafficSend);
            // SensorName
            AppTrafficRcvd = new RACoN.RTILayer.CHlaInteractionParameter("AppTrafficRcvd");
            this.Parameters.Add(AppTrafficRcvd);
            // ObjectType
            DelayTime = new RACoN.RTILayer.CHlaInteractionParameter("DelayTime");
            this.Parameters.Add(DelayTime);
            // ObjectName
            DelayVar = new RACoN.RTILayer.CHlaInteractionParameter("DelayVar");
            this.Parameters.Add(DelayVar);
        }
        #endregion //Constructor
    }
}
