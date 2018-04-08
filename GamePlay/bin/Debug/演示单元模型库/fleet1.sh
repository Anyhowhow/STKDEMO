stk.v.9.0
WrittenBy    STK_v9.2.2

BEGIN Ship

Name		fleet1

BEGIN VehiclePath
	CentralBody				Earth

    BEGIN Interval

         StartTime            8 Apr 2015 04:00:00.000000000
         StopTime             9 Apr 2015 04:40:26.097000000

    END Interval

	StoreEphemeris				Yes
	SmoothInterp				No

    BEGIN GreatArc

        VersionIndicator      20071204
        Method              DetVelFromTime

        TimeOfFirstWaypoint 8 Apr 2015 04:00:00.000000000

    UseScenTime          No
        ArcGranularity      5.729577951308e-001
        AltRef              WGS84
        AltInterpMethod     EllipsoidHeight
        NumberOfWaypoints   6

        BEGIN Waypoints

        0.000000000000e+000 3.000000000000e+001 1.300000000000e+002 0.000000000000e+000 1.922450779791e+003 0.000000000000e+000
        3.510240000000e+002 2.700000000000e+001 1.240000000000e+002 0.000000000000e+000 2.056952494521e+003 0.000000000000e+000
        6.439380000000e+002 2.400000000000e+001 1.190000000000e+002 0.000000000000e+000 4.370854033865e+003 0.000000000000e+000
        9.134950000000e+002 1.500000000000e+001 1.130000000000e+002 0.000000000000e+000 1.258653765297e+003 0.000000000000e+000
        1.534773000000e+003 8.000000000000e+000 1.120000000000e+002 0.000000000000e+000 5.666680464022e+000 0.000000000000e+000
        8.882609700000e+004 4.000000000000e+000 1.100000000000e+002 0.000000000000e+000 1.543333400000e+001 0.000000000000e+000

        END Waypoints

    END GreatArc

END VehiclePath

BEGIN Ephemeris

NumberOfEphemerisPoints 62

ScenarioEpoch            8 Apr 2015 04:00:00.000000

# Epoch in JDate format: 2457120.66666666666667
# Epoch in YYDDD format:   15098.16666666666667


InterpolationMethod     GreatArc

InterpolationSamplesM1      1

CentralBody             Earth

CoordinateSystem        Fixed 

BlockingFactor          20

# Time of first point: 8 Apr 2015 04:00:00.000000000 UTCG = 2457120.66666666666667 JDate = 15098.16666666666667 YYDDD

EphemerisTimePosVel

0.00000000000000e+000 -3.55349487090550e+006 4.23489027866673e+006 3.17037373537911e+006 1.00895835858505e+003 1.43684530154361e+003 -7.83131924257350e+002
3.19097895833642e+001 -3.52113503968611e+006 4.28054329973875e+006 3.14523736603100e+006 1.01923804902159e+003 1.42450697268821e+003 -7.92307190997874e+002
6.38197187488122e+001 -3.48844853665906e+006 4.32580068959027e+006 3.11980926591042e+006 1.02942383865503e+003 1.41203623794780e+003 -8.01409523183100e+002
9.57297875949563e+001 -3.45543837046115e+006 4.37065823781454e+006 3.09409177344638e+006 1.03951477351999e+003 1.39943423270301e+003 -8.10438069620514e+002
1.27639996273218e+002 -3.42210758002127e+006 4.41511177045019e+006 3.06808725411186e+006 1.04950990804698e+003 1.38670210483731e+003 -8.19391985601883e+002
1.59550344988085e+002 -3.38845923428918e+006 4.45915715037713e+006 3.04179810021392e+006 1.05940830515738e+003 1.37384101464459e+003 -8.28270432987626e+002
1.91460833997308e+002 -3.35449643196132e+006 4.50279027770929e+006 3.01522673068103e+006 1.06920903635797e+003 1.36085213473596e+003 -8.37072580289577e+002
2.23371463612044e+002 -3.32022230120375e+006 4.54600709018422e+006 2.98837559084805e+006 1.07891118183489e+003 1.34773664994414e+003 -8.45797602755298e+002
2.55282234196935e+002 -3.28563999937218e+006 4.58880356354943e+006 2.96124715223842e+006 1.08851383054753e+003 1.33449575722724e+003 -8.54444682449863e+002
2.87197618180369e+002 -3.25074780239574e+006 4.63118162006372e+006 2.93384005290910e+006 1.09801740488905e+003 1.32112878393827e+003 -8.63014203549467e+002
3.19110595123450e+002 -3.21555657409921e+006 4.67312795082689e+006 2.90616282099646e+006 1.10741891171513e+003 1.30763988058284e+003 -8.71503469529860e+002
3.51023999999999e+002 -3.18006646493130e+006 4.71464241818344e+006 2.87821557657322e+006 1.16052349392098e+003 1.38598956263352e+003 -9.81464068137863e+002
3.80314134380828e+002 -3.14593281374494e+006 4.75502733664903e+006 2.84933977393416e+006 1.17019009252476e+003 1.37156197021982e+003 -9.90215367443348e+002
4.09604402907426e+002 -3.11151739038784e+006 4.79498804253306e+006 2.82020880098680e+006 1.17975252800543e+003 1.35701111582213e+003 -9.98878555639937e+002
4.38894805673540e+002 -3.07682325591609e+006 4.83452094040749e+006 2.79082524777156e+006 1.18920993073074e+003 1.34233828430318e+003 -1.00745284547849e+003
4.68185342820418e+002 -3.04185349671004e+006 4.87362247265864e+006 2.76119172725960e+006 1.19856144016968e+003 1.32754477194980e+003 -1.01593745738823e+003
4.97476014536581e+002 -3.00661122420538e+006 4.91228911981785e+006 2.73131087512564e+006 1.20780620497935e+003 1.31263188636780e+003 -1.02433161955552e+003
5.26766821057543e+002 -2.97109957462180e+006 4.95051740088892e+006 2.70118534951878e+006 1.21694338309204e+003 1.29760094637461e+003 -1.03263456800243e+003
5.56057762665481e+002 -2.93532170868923e+006 4.98830387367238e+006 2.67081783083088e+006 1.22597214180089e+003 1.28245328189097e+003 -1.04084554666509e+003
5.85352023760888e+002 -2.89927687939108e+006 5.02564916991723e+006 2.64020768146381e+006 1.23489262147000e+003 1.26718856844993e+003 -1.04896468488988e+003
6.14644815352840e+002 -2.86297416802956e+006 5.06254378369013e+006 2.60936261127563e+006 1.24370254095753e+003 1.25181064443389e+003 -1.05698990762217e+003
6.43938000000000e+002 -2.82641451806035e+006 5.09898676677334e+006 2.57828342207140e+006 1.38161921564828e+003 2.46377453000196e+003 -3.33546224586868e+003
6.58123597930484e+002 -2.80668152217653e+006 5.13369491183224e+006 2.53084556840061e+006 1.40048430545534e+003 2.42960472094022e+003 -3.35261533664519e+003
6.72309292782066e+002 -2.78668170768008e+006 5.16791690686024e+006 2.48316632201493e+006 1.41921739704344e+003 2.39520144219935e+003 -3.36945055113823e+003
6.86493452782338e+002 -2.76641930267224e+006 5.20164560445058e+006 2.43525572619602e+006 1.43781453454984e+003 2.36057194750093e+003 -3.38596432796614e+003
7.00679163121261e+002 -2.74589181240252e+006 5.23488510136708e+006 2.38710790567530e+006 1.45627795381833e+003 2.32571198987304e+003 -3.40215861575174e+003
7.14865146336183e+002 -2.72510297344833e+006 5.26762911702781e+006 2.33873172118701e+006 1.47460416926395e+003 2.29062797487449e+003 -3.41803028220378e+003
7.29051398165999e+002 -2.70405474138197e+006 5.29987446779985e+006 2.29013176688928e+006 1.49279138329344e+003 2.25532323433479e+003 -3.43357772301499e+003
7.43239223981282e+002 -2.68274711889325e+006 5.33162092489405e+006 2.24130814324538e+006 1.51083947058610e+003 2.21979783505067e+003 -3.44880075547628e+003
7.57425502673163e+002 -2.66118680738741e+006 5.36285845264473e+006 2.19227622727107e+006 1.52874270195918e+003 2.18406297252497e+003 -3.46369451144327e+003
7.71611879340309e+002 -2.63937338526347e+006 5.39358774869741e+006 2.14303502403868e+006 1.54650143037613e+003 2.14811793920743e+003 -3.47825928165945e+003
7.85798354247468e+002 -2.61730891103683e+006 5.42380584934798e+006 2.09358920734245e+006 1.56411392163004e+003 2.11196615617876e+003 -3.49249360495748e+003
7.99986530026667e+002 -2.59499293348946e+006 5.45351316539510e+006 2.04393785299184e+006 1.58158041935564e+003 2.07560694913201e+003 -3.50639760369186e+003
8.14174298206745e+002 -2.57243084841618e+006 5.48270235509946e+006 1.99409303295542e+006 1.59889660326808e+003 2.03904916449611e+003 -3.51996777572974e+003
8.28362302282216e+002 -2.54962377465555e+006 5.51137194434428e+006 1.94405723042505e+006 1.61606157115960e+003 2.00229464032341e+003 -3.53320338459359e+003
8.42550537186989e+002 -2.52657386991033e+006 5.53951913944247e+006 1.89383521346288e+006 1.63307363338441e+003 1.96534689377486e+003 -3.54610308372789e+003
8.56738997762662e+002 -2.50328331626956e+006 5.56714119701330e+006 1.84343176974615e+006 1.64993111477766e+003 1.92820946358246e+003 -3.55866555978360e+003
8.70927678760507e+002 -2.47975432000103e+006 5.59423542431202e+006 1.79285170608303e+006 1.66663235487066e+003 1.89088590967814e+003 -3.57088953282362e+003
8.85116574843517e+002 -2.45598911134037e+006 5.62079917955379e+006 1.74209984792482e+006 1.68317570810484e+003 1.85337981281720e+003 -3.58277375652409e+003
8.99305680588479e+002 -2.43198994427649e+006 5.64682987223211e+006 1.69118103887474e+006 1.69955954404485e+003 1.81569477419767e+003 -3.59431701837047e+003
9.13495000000001e+002 -2.40775909633364e+006 5.67232496343127e+006 1.64010014019331e+006 3.77214965928910e+001 3.66356861891602e+002 -1.20356513713929e+003
9.61282930025587e+002 -2.40584876855969e+006 5.68957852753775e+006 1.58251112835842e+006 4.22288095496539e+001 3.55724832521195e+002 -1.20660095809226e+003
1.00907111585962e+003 -2.40372311629083e+006 5.70632331311614e+006 1.52477933179191e+006 4.67325531500608e+001 3.45060247668794e+002 -1.20952833569628e+003
1.05685955739936e+003 -2.40138231777588e+006 5.72255778233844e+006 1.46690993807845e+006 5.12323145034662e+001 3.34364079036697e+002 -1.21234698560187e+003
1.10464825461340e+003 -2.39882657098846e+006 5.73828044389532e+006 1.40890814812287e+006 5.57276809365792e+001 3.23637301754993e+002 -1.21505663381900e+003
1.15243720753563e+003 -2.39605609361480e+006 5.75348985315283e+006 1.35077917566140e+006 6.02182400389588e+001 3.12880894278162e+002 -1.21765701675787e+003
1.20022641625904e+003 -2.39307112303943e+006 5.76818461230445e+006 1.29252824677114e+006 6.47035797083607e+001 3.02095838281642e+002 -1.22014788126817e+003
1.24801588092955e+003 -2.38987191632900e+006 5.78236337051851e+006 1.23416059937805e+006 6.91832881958326e+001 2.91283118557533e+002 -1.22252898467692e+003
1.29580560173964e+003 -2.38645875021395e+006 5.79602482408090e+006 1.17568148276339e+006 7.36569541515291e+001 2.80443722909399e+002 -1.22480009482495e+003
1.34359557892201e+003 -2.38283192106829e+006 5.80916771653305e+006 1.11709615706870e+006 7.81241666690639e+001 2.69578642046755e+002 -1.22696099010191e+003
1.39139274219514e+003 -2.37899117262026e+006 5.82179263137354e+006 1.05840137641203e+006 8.25851615530754e+001 2.58687288754559e+002 -1.22901174877437e+003
1.43918569101736e+003 -2.37493774019263e+006 5.83389535533376e+006 9.99616414731525e+005 8.70384642417562e+001 2.47773255412132e+002 -1.23095167270786e+003
1.48697910993014e+003 -2.37067161021144e+006 5.84547603013729e+006 9.40740813972805e+005 9.14841028038554e+001 2.36836474467105e+002 -1.23278077702142e+003
1.53477300000000e+003 -2.36619315727383e+006 5.85653357621206e+006 8.81779906734936e+005 2.09699689754930e+000 1.60711641712360e+000 -5.01308770268428e+000
1.24460058791608e+004 -2.34320084000772e+006 5.87379235704827e+006 8.27039889308211e+005 2.11740078337151e+000 1.55634597283191e+000 -5.02052473519965e+000
2.33572685238635e+004 -2.31998691976245e+006 5.89049639658853e+006 7.72221179825670e+005 2.13760414057052e+000 1.50542645931636e+000 -5.02748517602289e+000
3.42685608971185e+004 -2.29655359421905e+006 5.90664409204815e+006 7.17328981866264e+005 2.15760500637157e+000 1.45436277630875e+000 -5.03396831860231e+000
4.51798829695676e+004 -2.27290308236529e+006 5.92223389418722e+006 6.62368506452111e+005 2.17740143802231e+000 1.40315983901973e+000 -5.03997350441294e+000
5.60912347181211e+004 -2.24903762427851e+006 5.93726430747328e+006 6.07344971531160e+005 2.19699151302263e+000 1.35182257759232e+000 -5.04550012305442e+000
6.70026161245867e+004 -2.22495948090616e+006 5.95173389023844e+006 5.52263601458956e+005 2.21637332934981e+000 1.30035593655289e+000 -5.05054761234289e+000
7.79140271742886e+004 -2.20067093384405e+006 5.96564125483080e+006 4.97129626479562e+005 2.23554500568216e+000 1.24876487425965e+000 -5.05511545839546e+000
8.88260970000000e+004 -2.17617286938206e+006 5.97898581945697e+006 4.41945105247284e+005 2.25450575387535e+000 1.19705141974804e+000 -5.05920341413014e+000


END Ephemeris

BEGIN MassProperties

	Mass           1.000000000000e+003
	InertiaXX      4.500000000000e+003
	InertiaYX      0.000000000000e+000
	InertiaYY      4.500000000000e+003
	InertiaZX      0.000000000000e+000
	InertiaZY      0.000000000000e+000
	InertiaZZ      4.500000000000e+003

END MassProperties

BEGIN Attitude

     	ScenarioEpoch		 8 Apr 2015 04:00:00.000000

      BEGIN Profile
          Name			 AircraftAtt
          UserNamed			 No
          StartTime			 0.000000000000e+000
          BEGIN ECFVelRadial
             	Azimuth		 0.000000000000e+000
          END ECFVelRadial
      END Profile

END Attitude

BEGIN Swath

    SwathType           ElevAngle
    ElevationAngle      0.000000000000e+000
    HalfAngle           0.000000000000e+000
    Distance            0.000000000000e+000
    RepType             NoSwath

END Swath

BEGIN Eclipse

    Sunlight                Off
    SunlightColor           #ffff00
    SunlightLineStyle       0
    SunlightLineWidth       3
    SunlightMarkerStyle     19

    Penumbra                Off
    PenumbraColor           #87cefa
    PenumbraLineStyle       0
    PenumbraLineWidth       3
    PenumbraMarkerStyle     19

    Umbra                   Off
    UmbraColor              #0000ff
    UmbraLineStyle          0
    UmbraLineWidth          3
    UmbraMarkerStyle        19

    SunlightPenumbraLine    Off
    PenumbraUmbraLine       Off

    UseCustomEclipseBodies  No

END Eclipse

BEGIN RealTimeDef

	HistoryDuration     1.800000000000e+003
	LookAheadDuration   1.800000000000e+003

END RealTimeDef


BEGIN LineOfSightModel

	ModelType     CbShape
	HeightAboveSurface   0.000000000000e+000

END LineOfSightModel


BEGIN Extensions
    
    BEGIN Graphics

        BEGIN GenericGraphics
            ShowPassLabel        Off
            ShowPathLabel        Off
            TransformTrajectory  On
            MinGfxGndTrkTimeStep 0.000000000000e+000
            MaxGfxGndTrkTimeStep 6.000000000000e+002
            MinGfxOrbitTimeStep  0.000000000000e+000
            MaxGfxOrbitTimeStep  6.000000000000e+002
            ShowGlintPoint       Off
            ShowGlintColor       #ffffff
            ShowGlintStyle       2
        END GenericGraphics

        BEGIN AttributeData

            AttributeType    Basic
            ScenarioEpoch 8 Apr 2015 04:00:00.000000

            IntvlHideShowAll Off

            BEGIN DefaultAttributes
                Show                 On
                Inherit              On
                ShowLabel            On
                ShowGndTrack         On
                ShowGndMarker        On
                ShowOrbit            On
                ShowOrbitMarker      On
                ShowElsetNum         Off
                ShowSpecialSwath     On
                MarkerColor          #ffff00
                GroundTrackColor     #ffff00
                SwathColor           #ffff00
                LabelColor           #ffff00
                LineStyle            0
                LineWidth            1.000000
                MarkerStyle          19
                FontStyle            0
                SwathLineStyle       0
                SpecSwathLineStyle   1
            END DefaultAttributes

            BEGIN CustomIntervalList
                BEGIN DefaultAttributes
                    Show                 On
                    Inherit              On
                    ShowLabel            On
                    ShowGndTrack         On
                    ShowGndMarker        On
                    ShowOrbit            On
                    ShowOrbitMarker      On
                    ShowElsetNum         Off
                    ShowSpecialSwath     On
                    MarkerColor          #ffff00
                    GroundTrackColor     #ffff00
                    SwathColor           #ffff00
                    LabelColor           #ffff00
                    LineStyle            0
                    LineWidth            1.000000
                    MarkerStyle          19
                    FontStyle            0
                    SwathLineStyle       0
                    SpecSwathLineStyle   1
                END DefaultAttributes
            END CustomIntervalList

            BEGIN AccessIntervalsAttributes
                BEGIN AttrDuringAccess
                    Show                 On
                    Inherit              On
                    ShowLabel            On
                    ShowGndTrack         On
                    ShowGndMarker        On
                    ShowOrbit            On
                    ShowOrbitMarker      On
                    ShowElsetNum         Off
                    ShowSpecialSwath     On
                    MarkerColor          #ffff00
                    GroundTrackColor     #ffff00
                    SwathColor           #ffff00
                    LabelColor           #ffff00
                    LineStyle            0
                    LineWidth            1.000000
                    MarkerStyle          4
                    FontStyle            0
                    SwathLineStyle       0
                    SpecSwathLineStyle   1
                END AttrDuringAccess
                BEGIN AttrDuringNoAccess
                    Show                 Off
                    Inherit              On
                    ShowLabel            On
                    ShowGndTrack         On
                    ShowGndMarker        On
                    ShowOrbit            On
                    ShowOrbitMarker      On
                    ShowElsetNum         Off
                    ShowSpecialSwath     On
                    MarkerColor          #0000ff
                    GroundTrackColor     #0000ff
                    SwathColor           #0000ff
                    LabelColor           #0000ff
                    LineStyle            0
                    LineWidth            1.000000
                    MarkerStyle          4
                    FontStyle            0
                    SwathLineStyle       0
                    SpecSwathLineStyle   1
                END AttrDuringNoAccess
            END AccessIntervalsAttributes

            BEGIN RealTimeAttributes
                BEGIN HistoryAttr
                    Show                 On
                    Inherit              On
                    ShowLabel            On
                    ShowGndTrack         On
                    ShowGndMarker        On
                    ShowOrbit            On
                    ShowOrbitMarker      On
                    ShowElsetNum         Off
                    ShowSpecialSwath     On
                    MarkerColor          #0000ff
                    GroundTrackColor     #0000ff
                    SwathColor           #0000ff
                    LabelColor           #0000ff
                    LineStyle            0
                    LineWidth            1.000000
                    MarkerStyle          4
                    FontStyle            0
                    SwathLineStyle       0
                    SpecSwathLineStyle   1
                END HistoryAttr
                BEGIN SplineAttr
                    Show                 On
                    Inherit              On
                    ShowLabel            On
                    ShowGndTrack         On
                    ShowGndMarker        On
                    ShowOrbit            On
                    ShowOrbitMarker      On
                    ShowElsetNum         Off
                    ShowSpecialSwath     On
                    MarkerColor          #ffff00
                    GroundTrackColor     #ffff00
                    SwathColor           #ffff00
                    LabelColor           #ffff00
                    LineStyle            0
                    LineWidth            1.000000
                    MarkerStyle          4
                    FontStyle            0
                    SwathLineStyle       0
                    SpecSwathLineStyle   1
                END SplineAttr
                BEGIN LookAheadAttr
                    Show                 On
                    Inherit              On
                    ShowLabel            On
                    ShowGndTrack         On
                    ShowGndMarker        On
                    ShowOrbit            On
                    ShowOrbitMarker      On
                    ShowElsetNum         Off
                    ShowSpecialSwath     On
                    MarkerColor          #ffffff
                    GroundTrackColor     #ffffff
                    SwathColor           #ffffff
                    LabelColor           #ffffff
                    LineStyle            0
                    LineWidth            1.000000
                    MarkerStyle          4
                    FontStyle            0
                    SwathLineStyle       0
                    SpecSwathLineStyle   1
                END LookAheadAttr
                BEGIN DropOutAttr
                    Show                 On
                    Inherit              On
                    ShowLabel            On
                    ShowGndTrack         On
                    ShowGndMarker        On
                    ShowOrbit            On
                    ShowOrbitMarker      On
                    ShowElsetNum         Off
                    ShowSpecialSwath     On
                    MarkerColor          #ff0000
                    GroundTrackColor     #ff0000
                    SwathColor           #ff0000
                    LabelColor           #ff0000
                    LineStyle            0
                    LineWidth            1.000000
                    MarkerStyle          4
                    FontStyle            0
                    SwathLineStyle       0
                    SpecSwathLineStyle   1
                END DropOutAttr
            END RealTimeAttributes
        END AttributeData

        BEGIN LeadTrailData
                GtLeadingType             AllData
                GtTrailingType            AllData
                OrbitLeadingType          AllData
                OrbitTrailingType         OnePass
        END LeadTrailData
            BEGIN SaaData
               ShowSaa            Off
               ShowSaaFill        Off
               SaaFillStyle       7
               TrackSaa           On
               SaaAltitude        500000.000000
            END SaaData
            Begin GroundTracks
                Begin GroundTrack
                    CentralBody  Earth
                End GroundTrack
            End GroundTracks
            BEGIN WaypointData
                ShowWayptMarkers           On
                ShowWayptTurnMarkers       On
                ShowWayptMarkersExtEphem   Off
                NewWayptMarkerShow         On
                NewWayptShowLabel          Off
                NewWayptMarkerStyle        3
                WayptShow                  On
                WayptShowLabel             Off
                WayptMarkerStyle           3
            END WaypointData
        BEGIN EllipseSetGxData
            BEGIN DefEllipseSetGx
                ShowStatic     On
                ShowDynamic    On
                UseLastDynPos  Off
                HoldLastDynPos Off
                ShowName       Off
                ShowMarker     On
                MarkerStyle    0
                LineStyle      0
                LineWidth      1.000000
            END DefEllipseSetGx
        END EllipseSetGxData
    END Graphics
    
    BEGIN LaserCAT
    END LaserCAT
    
    BEGIN ExternData
    END ExternData
    
    BEGIN RFI
    END RFI
    
    BEGIN ADFFileData
    END ADFFileData
    
    BEGIN AccessConstraints
		LineOfSight   IncludeIntervals 
    END AccessConstraints
    
    BEGIN ObjectCoverage
    END ObjectCoverage
    
    BEGIN Desc
    END Desc
    
    BEGIN Atmosphere
<!-- STKv4.0 Format="XML" -->
<STKOBJECT>
<OBJECT Class = "AtmosphereExtension" Name = "STK_Atmosphere_Extension">
    <OBJECT Class = "link" Name = "AtmosAbsorptionModel">
        <OBJECT Class = "AtmosphericAbsorptionModel" Name = "Simple_Satcom">
            <OBJECT Class = "bool" Name = "Clonable"> True </OBJECT>
            <OBJECT Class = "string" Name = "Description"> &quot;Simple Satcom gaseous absorption model&quot; </OBJECT>
            <OBJECT Class = "bool" Name = "ReadOnly"> False </OBJECT>
            <OBJECT Class = "double" Name = "SurfaceTemperature"> 293.15 K </OBJECT>
            <OBJECT Class = "string" Name = "Type"> &quot;Simple Satcom&quot; </OBJECT>
            <OBJECT Class = "string" Name = "UserComment"> &quot;Simple Satcom gaseous absorption model&quot; </OBJECT>
            <OBJECT Class = "string" Name = "Version"> &quot;1.0.0 a&quot; </OBJECT>
            <OBJECT Class = "double" Name = "WaterVaporConcentration"> 7.5 g*m^-3 </OBJECT>
        </OBJECT>
    </OBJECT>
    <OBJECT Class = "bool" Name = "Clonable"> True </OBJECT>
    <OBJECT Class = "string" Name = "Description"> &quot;STK Atmosphere Extension&quot; </OBJECT>
    <OBJECT Class = "bool" Name = "EnableLocalRainData"> False </OBJECT>
    <OBJECT Class = "bool" Name = "InheritAtmosAbsorptionModel"> True </OBJECT>
    <OBJECT Class = "double" Name = "LocalRainIsoHeight"> 2000 m </OBJECT>
    <OBJECT Class = "double" Name = "LocalRainRate"> 1 mm*hr^-1 </OBJECT>
    <OBJECT Class = "double" Name = "LocalSurfaceTemp"> 293.15 K </OBJECT>
    <OBJECT Class = "bool" Name = "ReadOnly"> False </OBJECT>
    <OBJECT Class = "string" Name = "Type"> &quot;STK Atmosphere Extension&quot; </OBJECT>
    <OBJECT Class = "string" Name = "UserComment"> &quot;STK Atmosphere Extension&quot; </OBJECT>
    <OBJECT Class = "string" Name = "Version"> &quot;1.0.0 a&quot; </OBJECT>
</OBJECT>
</STKOBJECT>
    END Atmosphere
    
    BEGIN RCS
	Inherited          True
	LinearClutterCoef        1.000000e+000
	BEGIN RCSBAND
		LinearConstantValue      1.000000e+000
		Swerling      0
		BandData      3.000000e+006 3.000000e+011
	END RCSBAND
    END RCS
    
    BEGIN Ellipse
        TimesTrackVehStartTime Yes
    END Ellipse
    
    BEGIN Crdn
    END Crdn
    
    BEGIN DIS

		Begin Input


		End Input


		Begin Output

			Enable                     Off
			ForceID                    1
			EntityID                   0:0:0
			PriEntityType              0:0:0:0:0:0:0
			AltEntityType              0:0:0:0:0:0:0
			DistanceThresh             1.000000

		End Output

    END DIS
    
    BEGIN VO
    END VO

END Extensions

BEGIN SubObjects

END SubObjects

END Ship

