using System;
using RACoN;

namespace STK_demonstration.Som
{
    public class FederateSom : RACoN.ObjectModel.CObjectModel
    {
        //#region SOM Declaration
        public STK_demonstration.Som.CStartOpnetIC StartOpnetIC;
        public STK_demonstration.Som.CStkScenarioIC StkScenarioIC;
        public STK_demonstration.Som.XGYHCoordinate StkXGYHCoordinate;
        public STK_demonstration.Som.SatUserParameter SatUserParameter;
        //public STK_demonstration.Som.CStkSatelliteIC StkSatelliteIC;
        //public STK_demonstration.Som.CStkFacilityIC StkFacilityIC;
        //public STK_demonstration.Som.CStkVehicleIC StkVehicleIC;
        public STK_demonstration.Som.OpFinishIC OpFinish;
        public STK_demonstration.Som.COpSimTimeIC OpSimTimeIC;
        public STK_demonstration.Som.CPlanComplete PlanComplete;
        public STK_demonstration.Som.CInterSatellitePathIC InterSatellitePathIC;
        public STK_demonstration.Som.CBeamParameters BeamParameters;
        //public STK_demonstration.Som.CStkAreaIC StkAreaIC;
        //public STK_demonstration.Som.CStkChainIC StkChainIC;
        //public STK_demonstration.Som.CStkConstellationIC StkConstellationIC;

        //public STK_demonstration.Som.CStkScaleIC StkScaleIC;
        //public STK_demonstration.Som.CStkCoverageIC StkCoverageIC;
        //public STK_demonstration.Som.CStkAddRegionIC StkAddRegionIC;
        //public STK_demonstration.Som.CStkAssignAssetIC StkAssignAssetIC;
        //public STK_demonstration.Som.CStkScenarioReadyIC StkScenarioReadyIC;
        //public STK_demonstration.Som.CStkAccessIC StkAccessIC;
        //public STK_demonstration.Som.CStkLineTargetIC StkLineTargetIC;
        //public STK_demonstration.Som.CStkCoverageCalIC StkCoverageCalIC;
        //public STK_demonstration.Som.CStkFomIC StkFomIC;
        //public STK_demonstration.Som.CStkSensorIC StkSensorIC;
        //public STK_demonstration.Som.CStkAnnotationIC StkAnnotationIC;
        ////public STK_demonstration.Som.OpCpuUtilization OpCpuUtilizationIC;
        //public STK_demonstration.Som.OpRouteTrafficSendIC OpRouteTrafficSend;
        //public STK_demonstration.Som.OpPkLossRatio OpPkLossRatioIC;
        public STK_demonstration.Som.OpUserNum OpUserNumIC;
        public STK_demonstration.Som.OpUserOnline OpUserOnlineIC;
        public STK_demonstration.Som.OpAppTrafficInfoAllIC OpAppTrafficInfoAll;
        public STK_demonstration.Som.OpAppTrafficInfoSingleIC OpAppTrafficInfoSingle;
        public STK_demonstration.Som.OpAccessAbilityIC OpAccessAbility;
        public STK_demonstration.Som.OpLinkAbilityDesignedIC OpLinkAbilityDesigned;
        public STK_demonstration.Som.OpS2gLinkTrafficAbilityIC OpS2gLinkTrafficAbility;

        public STK_demonstration.Som.MobileNodeParameter mobilenodeparameter;

        //public STK_demonstration.Som.StkCoverageSend StkCoverageSend;

        //#endregion //Declarations

        #region Constructor
        #region
        public FederateSom() : base()
        {
            //    //    // Construct SOM
            StartOpnetIC = new STK_demonstration.Som.CStartOpnetIC();
            this.AddToObjectModel(StartOpnetIC);
            //    //    //StkConnectIC = new STK_demonstration.Som.CStkConnectIC();
            //    //    //this.AddToObjectModel(StkConnectIC);
            StkScenarioIC = new STK_demonstration.Som.CStkScenarioIC();
            this.AddToObjectModel(StkScenarioIC);

            StkXGYHCoordinate= new STK_demonstration.Som.XGYHCoordinate();
            this.AddToObjectModel(StkXGYHCoordinate);

            SatUserParameter = new STK_demonstration.Som.SatUserParameter();
            this.AddToObjectModel(SatUserParameter);

            PlanComplete = new STK_demonstration.Som.CPlanComplete();
            this.AddToObjectModel(PlanComplete);
            //    StkSatelliteIC = new STK_demonstration.Som.CStkSatelliteIC();
            //    this.AddToObjectModel(StkSatelliteIC);
            //    StkFacilityIC = new STK_demonstration.Som.CStkFacilityIC();
            //    this.AddToObjectModel(StkFacilityIC);
            //    //    StkAreaIC = new STK_demonstration.Som.CStkAreaIC();
            //    //    this.AddToObjectModel(StkAreaIC);
            //    //    StkChainIC = new STK_demonstration.Som.CStkChainIC();
            //    //    this.AddToObjectModel(StkChainIC);
            //    //    StkConstellationIC = new STK_demonstration.Som.CStkConstellationIC();
            //    //    this.AddToObjectModel(StkConstellationIC);
            //    StkVehicleIC = new STK_demonstration.Som.CStkVehicleIC();
            //    this.AddToObjectModel(StkVehicleIC);
            //    //    StkScaleIC = new STK_demonstration.Som.CStkScaleIC();
            //    //    this.AddToObjectModel(StkScaleIC);
            //    //    StkCoverageIC = new STK_demonstration.Som.CStkCoverageIC();
            //    //    this.AddToObjectModel(StkCoverageIC);
            //    //    StkAddRegionIC = new STK_demonstration.Som.CStkAddRegionIC();
            //    //    this.AddToObjectModel(StkAddRegionIC);
            //    //    StkAssignAssetIC = new STK_demonstration.Som.CStkAssignAssetIC();
            //    //    this.AddToObjectModel(StkAssignAssetIC);
            //    //    StkScenarioReadyIC = new STK_demonstration.Som.CStkScenarioReadyIC();
            //    //    this.AddToObjectModel(StkScenarioReadyIC);
            //    //    StkAccessIC = new STK_demonstration.Som.CStkAccessIC();
            //    //    this.AddToObjectModel(StkAccessIC);
            //    //    StkLineTargetIC = new STK_demonstration.Som.CStkLineTargetIC();
            //    //    this.AddToObjectModel(StkLineTargetIC);
            //    //    StkCoverageCalIC = new STK_demonstration.Som.CStkCoverageCalIC();
            //    //    this.AddToObjectModel(StkCoverageCalIC);
            //    //    StkFomIC = new STK_demonstration.Som.CStkFomIC();
            //    //    this.AddToObjectModel(StkFomIC);
            //    //    StkSensorIC = new STK_demonstration.Som.CStkSensorIC();
            //    //    this.AddToObjectModel(StkSensorIC);
            //    //    StkAnnotationIC = new STK_demonstration.Som.CStkAnnotationIC();
            //    //    this.AddToObjectModel(StkAnnotationIC);
            //    //    //OpCpuUtilizationIC = new STK_demonstration.Som.OpCpuUtilization();
            //    //    //this.AddToObjectModel(OpCpuUtilizationIC);
            //    //    OpPkLossRatioIC = new STK_demonstration.Som.OpPkLossRatio();
            //    //    this.AddToObjectModel(OpPkLossRatioIC);
            mobilenodeparameter = new STK_demonstration.Som.MobileNodeParameter();
            this.AddToObjectModel(mobilenodeparameter);

            OpUserNumIC = new STK_demonstration.Som.OpUserNum();
            this.AddToObjectModel(OpUserNumIC);

            OpUserOnlineIC = new STK_demonstration.Som.OpUserOnline();
            this.AddToObjectModel(OpUserOnlineIC);

            OpAppTrafficInfoAll = new STK_demonstration.Som.OpAppTrafficInfoAllIC();
            this.AddToObjectModel(OpAppTrafficInfoAll);

            OpAppTrafficInfoSingle = new STK_demonstration.Som.OpAppTrafficInfoSingleIC();
            this.AddToObjectModel(OpAppTrafficInfoSingle);

            OpAccessAbility = new STK_demonstration.Som.OpAccessAbilityIC();
            this.AddToObjectModel(OpAccessAbility);

            OpLinkAbilityDesigned = new STK_demonstration.Som.OpLinkAbilityDesignedIC();
            this.AddToObjectModel(OpLinkAbilityDesigned);
            //    //    OpRouteTrafficSend = new STK_demonstration.Som.OpRouteTrafficSendIC();
            //    //    this.AddToObjectModel(OpRouteTrafficSend);
            OpS2gLinkTrafficAbility = new STK_demonstration.Som.OpS2gLinkTrafficAbilityIC();
            this.AddToObjectModel(OpS2gLinkTrafficAbility);

            OpFinish = new STK_demonstration.Som.OpFinishIC();
            this.AddToObjectModel(OpFinish);

            OpSimTimeIC = new STK_demonstration.Som.COpSimTimeIC();
            this.AddToObjectModel(OpSimTimeIC);
            InterSatellitePathIC = new STK_demonstration.Som.CInterSatellitePathIC();
            this.AddToObjectModel(InterSatellitePathIC);
            BeamParameters = new STK_demonstration.Som.CBeamParameters();
            this.AddToObjectModel(BeamParameters);
        }
        #endregion
        #endregion //Constructor
    }
}

