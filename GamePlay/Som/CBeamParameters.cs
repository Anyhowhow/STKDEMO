using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_demonstration.Som
{
   public class CBeamParameters:RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter BeamNumber;
        public RACoN.RTILayer.CHlaInteractionParameter BeamAzimuth;
        public RACoN.RTILayer.CHlaInteractionParameter BeamElevation;
        public RACoN.RTILayer.CHlaInteractionParameter BeamDiameter;
        public RACoN.RTILayer.CHlaInteractionParameter BeamType;
        #endregion //Declarations
        #region Constructor
        public CBeamParameters() : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.BeamParameters";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            BeamNumber = new RACoN.RTILayer.CHlaInteractionParameter("BeamNumber");
            this.Parameters.Add(BeamNumber);
            BeamAzimuth = new RACoN.RTILayer.CHlaInteractionParameter("BeamAzimuth");
            this.Parameters.Add(BeamAzimuth);
            BeamElevation = new RACoN.RTILayer.CHlaInteractionParameter("BeamElevation");
            this.Parameters.Add(BeamElevation);
            BeamDiameter = new RACoN.RTILayer.CHlaInteractionParameter("BeamDiameter");
            this.Parameters.Add(BeamDiameter);
            BeamType = new RACoN.RTILayer.CHlaInteractionParameter("BeamType");
            this.Parameters.Add(BeamType);
        }
        #endregion //Constructor
    }
}
