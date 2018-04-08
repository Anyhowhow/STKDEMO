using System;
using RACoN;

namespace STK_demonstration.Som
{
    public class OpAppTrafficInfoAllIC : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter NodeId;
        public RACoN.RTILayer.CHlaInteractionParameter SimTime;
        public RACoN.RTILayer.CHlaInteractionParameter AppTrafficSend;
        public RACoN.RTILayer.CHlaInteractionParameter AppTrafficRcvd;
        #endregion //Declarations

        #region Constructor
        public OpAppTrafficInfoAllIC()
            : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.OpAppTrafficInfoAll";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // TypeData
            NodeId = new RACoN.RTILayer.CHlaInteractionParameter("NodeId");
            this.Parameters.Add(NodeId);
            // SensorType
            SimTime = new RACoN.RTILayer.CHlaInteractionParameter("SimTime");
            this.Parameters.Add(SimTime);
            // SensorName
            AppTrafficSend = new RACoN.RTILayer.CHlaInteractionParameter("AppTrafficSend");
            this.Parameters.Add(AppTrafficSend);
            // ObjectType
            AppTrafficRcvd = new RACoN.RTILayer.CHlaInteractionParameter("AppTrafficRcvd");
            this.Parameters.Add(AppTrafficRcvd);
        }
        #endregion //Constructor
    }
}
