using System;
using RACoN;

namespace STK_demonstration.Som
{
    public class OpS2gLinkTrafficAbilityIC : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter SatName;
        public RACoN.RTILayer.CHlaInteractionParameter SatbeamID;
        public RACoN.RTILayer.CHlaInteractionParameter SimTime;
        public RACoN.RTILayer.CHlaInteractionParameter UplinkTrafficBps;
        public RACoN.RTILayer.CHlaInteractionParameter UplinkUtilizationRadio;
        public RACoN.RTILayer.CHlaInteractionParameter DownlinkTrafficBps;
        public RACoN.RTILayer.CHlaInteractionParameter DownlinkUtilizationRadio;
        public RACoN.RTILayer.CHlaInteractionParameter LinkPkLossRadio;
        #endregion //Declarations

        #region Constructor
        public OpS2gLinkTrafficAbilityIC()
            : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.OpS2gLinkTrafficAbility";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters

            SatName = new RACoN.RTILayer.CHlaInteractionParameter("SatName");
            this.Parameters.Add(SatName);

            SatbeamID = new RACoN.RTILayer.CHlaInteractionParameter("SatbeamID");
            this.Parameters.Add(SatbeamID);
            SimTime = new RACoN.RTILayer.CHlaInteractionParameter("SimTime");
            this.Parameters.Add(SimTime);

            UplinkTrafficBps = new RACoN.RTILayer.CHlaInteractionParameter("UplinkTrafficBps");
            this.Parameters.Add(UplinkTrafficBps);

            UplinkUtilizationRadio = new RACoN.RTILayer.CHlaInteractionParameter("UplinkUtilizationRadio");
            this.Parameters.Add(UplinkUtilizationRadio);

            DownlinkTrafficBps = new RACoN.RTILayer.CHlaInteractionParameter("DownlinkTrafficBps");
            this.Parameters.Add(DownlinkTrafficBps);
            DownlinkUtilizationRadio = new RACoN.RTILayer.CHlaInteractionParameter("DownlinkUtilizationRadio");
            this.Parameters.Add(DownlinkUtilizationRadio);

            LinkPkLossRadio = new RACoN.RTILayer.CHlaInteractionParameter("LinkPkLossRadio");
            this.Parameters.Add(LinkPkLossRadio);
        }
        #endregion //Constructor
    }
}
