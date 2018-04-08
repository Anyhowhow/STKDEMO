using System;
using RACoN;

namespace STK_demonstration.Som
{
    public class OpAccessAbilityIC : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter AccessSignalingCost;
        public RACoN.RTILayer.CHlaInteractionParameter AccessTimeAverage;
        public RACoN.RTILayer.CHlaInteractionParameter AccessSuccessRate;
        public RACoN.RTILayer.CHlaInteractionParameter ChannelApplyAverage;
        #endregion //Declarations

        #region Constructor
        public OpAccessAbilityIC()
            : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.OpAccessAbility";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // clear_path
            AccessSignalingCost = new RACoN.RTILayer.CHlaInteractionParameter("AccessSignalingCost");
            this.Parameters.Add(AccessSignalingCost);
            AccessTimeAverage = new RACoN.RTILayer.CHlaInteractionParameter("AccessTimeAverage");
            this.Parameters.Add(AccessTimeAverage);
            AccessSuccessRate = new RACoN.RTILayer.CHlaInteractionParameter("AccessSuccessRate");
            this.Parameters.Add(AccessSuccessRate);
            ChannelApplyAverage = new RACoN.RTILayer.CHlaInteractionParameter("ChannelApplyAverage");
            this.Parameters.Add(ChannelApplyAverage);
        }
        #endregion //Constructor
    }
}
