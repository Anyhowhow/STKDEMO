using System;
using RACoN;

namespace STK_demonstration.Som
{
    public class XGYHCoordinate : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter XGYHName;
        public RACoN.RTILayer.CHlaInteractionParameter XGYHLongitude;
        public RACoN.RTILayer.CHlaInteractionParameter XGYHLatitude;
        public RACoN.RTILayer.CHlaInteractionParameter XGYHType;
        #endregion //Declarations

        #region Constructor
        public XGYHCoordinate() : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.XGYHCoordinate";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // XGYHName
            XGYHName = new RACoN.RTILayer.CHlaInteractionParameter("XGYHName");
            this.Parameters.Add(XGYHName);
            // XGYHLongitude
            XGYHLongitude = new RACoN.RTILayer.CHlaInteractionParameter("XGYHLongitude");
            this.Parameters.Add(XGYHLongitude);
            // XGYHLatitude
            XGYHLatitude = new RACoN.RTILayer.CHlaInteractionParameter("XGYHLatitude");
            this.Parameters.Add(XGYHLatitude);
            XGYHType = new RACoN.RTILayer.CHlaInteractionParameter("XGYHType");
            this.Parameters.Add(XGYHType);
        }
        #endregion //Constructor
    }
}
