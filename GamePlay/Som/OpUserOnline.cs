using System;
using RACoN;

namespace STK_demonstration.Som
{
    public class OpUserOnline : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter UserId;
        public RACoN.RTILayer.CHlaInteractionParameter OnlineFlag;
        public RACoN.RTILayer.CHlaInteractionParameter SimTime;
        #endregion //Declarations

        #region Constructor
        public OpUserOnline()
            : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.OpUserOnline";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // TheValue
            UserId = new RACoN.RTILayer.CHlaInteractionParameter("UserId");
            this.Parameters.Add(UserId);
            // SimTime
            OnlineFlag = new RACoN.RTILayer.CHlaInteractionParameter("OnlineFlag");
            this.Parameters.Add(OnlineFlag);
            // NodeId
            SimTime = new RACoN.RTILayer.CHlaInteractionParameter("SimTime");
            this.Parameters.Add(SimTime);
        }
        #endregion //Constructor
    }
}