using System;
using RACoN;

namespace STK_demonstration.Som
{
    public class OpLinkAbilityDesignedIC : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter StogDownstrmDatarate;
        public RACoN.RTILayer.CHlaInteractionParameter StogUpstrmDatarate;
        public RACoN.RTILayer.CHlaInteractionParameter StosDatarate;
        #endregion //Declarations

        #region Constructor
        public OpLinkAbilityDesignedIC()
            : base()
        {
            // Initialize Class Properties

            this.ClassName = "InteractionRoot.OpLinkAbilityDesigned";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // clear_path
            StogDownstrmDatarate = new RACoN.RTILayer.CHlaInteractionParameter("StogDownstrmDatarate");
            this.Parameters.Add(StogDownstrmDatarate);
            StogUpstrmDatarate = new RACoN.RTILayer.CHlaInteractionParameter("StogUpstrmDatarate");
            this.Parameters.Add(StogUpstrmDatarate);
            StosDatarate = new RACoN.RTILayer.CHlaInteractionParameter("StosDatarate");
            this.Parameters.Add(StosDatarate);
        }
        #endregion //Constructor
    }
}
