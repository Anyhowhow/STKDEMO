stk.v.9.0
WrittenBy    STK_v9.2.2

BEGIN Ship

Name		fleet2

BEGIN VehiclePath
	CentralBody				Earth

    BEGIN Interval

         StartTime            8 Apr 2015 04:00:00.000000000
         StopTime             8 Apr 2015 23:40:00.000000000

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

        0.000000000000e+000 3.100000000000e+001 1.300000000000e+002 0.000000000000e+000 1.108432774619e+003 0.000000000000e+000
        3.000000000000e+002 2.800000000000e+001 1.300000000000e+002 0.000000000000e+000 3.295702250170e+003 0.000000000000e+000
        6.600000000000e+002 2.400000000000e+001 1.190000000000e+002 0.000000000000e+000 3.272761946685e+003 0.000000000000e+000
        1.020000000000e+003 1.500000000000e+001 1.130000000000e+002 0.000000000000e+000 1.629112279159e+003 0.000000000000e+000
        1.500000000000e+003 8.000000000000e+000 1.120000000000e+002 0.000000000000e+000 7.137836080655e+000 0.000000000000e+000
        7.080000000000e+004 4.000000000000e+000 1.100000000000e+002 0.000000000000e+000 1.543333400000e+001 0.000000000000e+000

        END Waypoints

    END GreatArc

END VehiclePath

BEGIN Ephemeris

NumberOfEphemerisPoints 66

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

0.00000000000000e+000 -3.51732811759836e+006 4.19178842048048e+006 3.26589351664932e+006 -3.66957857526182e+002 4.37323345037516e+002 -9.50112329430253e+002
4.99976714523253e+001 -3.53554188299502e+006 4.21349474082661e+006 3.21826579135738e+006 -3.61615672781534e+002 4.30956777175738e+002 -9.55056845038791e+002
9.99957777240002e+001 -3.55348800107008e+006 4.23488209151569e+006 3.17039224671563e+006 -3.56245503418609e+002 4.24556858544661e+002 -9.59929076029630e+002
1.49994319060922e+002 -3.57116507821444e+006 4.25594881170904e+006 3.12227650247545e+006 -3.50847755302735e+002 4.18124072835651e+002 -9.64728629286365e+002
1.99993295829231e+002 -3.58857174118256e+006 4.27669326483637e+006 3.07392219787199e+006 -3.45422836765653e+002 4.11658906679535e+002 -9.69455117188294e+002
2.49992708512566e+002 -3.60570663721200e+006 4.29711383873819e+006 3.02533299134906e+006 -3.39971158574686e+002 4.05161849609819e+002 -9.74108157654233e+002
3.00000000000000e+002 -3.62257092328632e+006 4.31721191225379e+006 2.97650527732680e+006 2.04944143194105e+003 2.39220597760016e+003 -9.68913669815702e+002
3.18946259235198e+002 -3.58356846842495e+006 4.36232780055232e+006 2.95800533547349e+006 2.06769770918209e+003 2.37026122102925e+003 -9.83941689993027e+002
3.37892575545957e+002 -3.54422187502135e+006 4.40702589171866e+006 2.93922149788671e+006 2.08575641308098e+003 2.34808868119251e+003 -9.98875894355984e+002
3.56838948969014e+002 -3.50453490074260e+006 4.45130188744612e+006 2.92015555398471e+006 2.10361579939106e+003 2.32569045656438e+003 -1.01371484677692e+003
3.75785379564056e+002 -3.46451133611367e+006 4.49515152940615e+006 2.90080932030506e+006 2.12127414234738e+003 2.30306866756521e+003 -1.02845711979940e+003
3.94731867414081e+002 -3.42415500416368e+006 4.53857059966175e+006 2.88118464033771e+006 2.13872973483930e+003 2.28022545638100e+003 -1.04310129477656e+003
4.13678412625711e+002 -3.38346976006905e+006 4.58155492107717e+006 2.86128338435533e+006 2.15598088858399e+003 2.25716298677821e+003 -1.05764596201060e+003
4.32625015329494e+002 -3.34245949079336e+006 4.62410035772396e+006 2.84110744924106e+006 2.17302593429751e+003 2.23388344391765e+003 -1.07208972089063e+003
4.51571675680171e+002 -3.30112811472409e+006 4.66620281528344e+006 2.82065875831371e+006 2.18986322186502e+003 2.21038903416536e+003 -1.08643118003064e+003
4.70518393856925e+002 -3.25947958130625e+006 4.70785824144527e+006 2.79993926115037e+006 2.20649112050909e+003 2.18668198490178e+003 -1.10066895740674e+003
4.89465170063590e+002 -3.21751787067286e+006 4.74906262630240e+006 2.77895093340644e+006 2.22290801895732e+003 2.16276454432811e+003 -1.11480168049333e+003
5.08412004528847e+002 -3.17524699327242e+006 4.78981200274209e+006 2.75769577663314e+006 2.23911232560811e+003 2.13863898127004e+003 -1.12882798640022e+003
5.27358897506383e+002 -3.13267098949329e+006 4.83010244683315e+006 2.73617581809249e+006 2.25510246869556e+003 2.11430758498061e+003 -1.14274652200518e+003
5.46308599206452e+002 -3.08978768453170e+006 4.86993582494442e+006 2.71438993009605e+006 2.27087917018965e+003 2.08976908932562e+003 -1.15655794038872e+003
5.65256695337126e+002 -3.04661114285062e+006 4.90929898027516e+006 2.69234524398862e+006 2.28643720419791e+003 2.06503152343841e+003 -1.17025768112991e+003
5.84204978959321e+002 -3.00314144432119e+006 4.94819190096489e+006 2.67004180947934e+006 2.30177655753430e+003 2.04009492112556e+003 -1.18384573055846e+003
6.03153450693920e+002 -2.95938273957165e+006 4.98661082984907e+006 2.64748174964915e+006 2.31689573486269e+003 2.01496164742011e+003 -1.19732077363562e+003
6.22102111089940e+002 -2.91533920763540e+006 5.02455205446227e+006 2.62466721252427e+006 2.33179326133778e+003 1.98963408697929e+003 -1.21068150563561e+003
6.41050960624275e+002 -2.87101505556790e+006 5.06201190741609e+006 2.60160037088490e+006 2.34646768276757e+003 1.96411464387864e+003 -1.22392663228119e+003
6.60000000000000e+002 -2.82641451806035e+006 5.09898676677334e+006 2.57828342207140e+006 1.03451425253473e+003 1.84479908606595e+003 -2.49749221280452e+003
6.78945214759677e+002 -2.80668152217653e+006 5.13369491183224e+006 2.53084556840061e+006 1.04863985534896e+003 1.81921377711802e+003 -2.51033592305575e+003
6.97890558959863e+002 -2.78668170768008e+006 5.16791690686024e+006 2.48316632201493e+006 1.06266662193011e+003 1.79345365320814e+003 -2.52294161725880e+003
7.16833853328394e+002 -2.76641930267224e+006 5.20164560445058e+006 2.43525572619602e+006 1.07659159024903e+003 1.76752414570142e+003 -2.53530662875992e+003
7.35779218212303e+002 -2.74589181240252e+006 5.23488510136708e+006 2.38710790567530e+006 1.09041643443725e+003 1.74142207459502e+003 -2.54743241662832e+003
7.54724947528819e+002 -2.72510297344833e+006 5.26762911702781e+006 2.33873172118701e+006 1.10413854459523e+003 1.71515223617568e+003 -2.55931663550002e+003
7.73671035587128e+002 -2.70405474138197e+006 5.29987446779985e+006 2.29013176688928e+006 1.11775657474009e+003 1.68871712521551e+003 -2.57095808411876e+003
7.92619225741722e+002 -2.68274711889325e+006 5.33162092489405e+006 2.24130814324538e+006 1.13127043103550e+003 1.66211679172988e+003 -2.58235662567756e+003
8.11565349674980e+002 -2.66118680738741e+006 5.36285845264473e+006 2.19227622727107e+006 1.14467582364448e+003 1.63535961856921e+003 -2.59350861505866e+003
8.30511604456613e+002 -2.63937338526347e+006 5.39358774869741e+006 2.14303502403868e+006 1.15797301685528e+003 1.60844507594150e+003 -2.60441426996189e+003
8.49457990440198e+002 -2.61730891103683e+006 5.42380584934798e+006 2.09358920734245e+006 1.17116071214675e+003 1.58137572544744e+003 -2.61507249630980e+003
8.68406647980204e+002 -2.59499293348946e+006 5.45351316539510e+006 2.04393785299184e+006 1.18423909194514e+003 1.55415106218661e+003 -2.62548338571769e+003
8.87354761161566e+002 -2.57243084841618e+006 5.48270235509946e+006 1.99409303295542e+006 1.19720492135315e+003 1.52677771009467e+003 -2.63564431589551e+003
9.06303189387022e+002 -2.54962377465555e+006 5.51137194434428e+006 1.94405723042505e+006 1.21005752482519e+003 1.49925704544905e+003 -2.64555473539138e+003
9.25251925890687e+002 -2.52657386991033e+006 5.53951913944247e+006 1.89383521346288e+006 1.22279563720612e+003 1.47159170179242e+003 -2.65521363594567e+003
9.44200963783385e+002 -2.50328331626956e+006 5.56714119701330e+006 1.84343176974615e+006 1.23541800418367e+003 1.44378432881916e+003 -2.66462003416275e+003
9.63150296055314e+002 -2.47975432000103e+006 5.59423542431202e+006 1.79285170608303e+006 1.24792338244964e+003 1.41583759209753e+003 -2.67377297166483e+003
9.82099915578767e+002 -2.45598911134037e+006 5.62079917955379e+006 1.74209984792482e+006 1.26031053986005e+003 1.38775417278768e+003 -2.68267151524269e+003
1.00104981511091e+003 -2.43198994427649e+006 5.64682987223211e+006 1.69118103887474e+006 1.27257825559472e+003 1.35953676735668e+003 -2.69131475700248e+003
1.02000000000000e+003 -2.40775909633364e+006 5.67232496343127e+006 1.64010014019331e+006 4.88240332504960e+001 4.74186371754771e+002 -1.55780946098254e+003
1.05692100221202e+003 -2.40584876855969e+006 5.68957852753775e+006 1.58251112835842e+006 5.46579798737287e+001 4.60425026039796e+002 -1.56173881258675e+003
1.09384220206190e+003 -2.40372311629083e+006 5.70632331311614e+006 1.52477933179191e+006 6.04873065749237e+001 4.46621542814942e+002 -1.56552780280148e+003
1.13076359947027e+003 -2.40138231777588e+006 5.72255778233844e+006 1.46690993807845e+006 6.63114789376758e+001 4.32777179782834e+002 -1.56917606358491e+003
1.16768519441286e+003 -2.39882657098846e+006 5.73828044389532e+006 1.40890814812287e+006 7.21299628269082e+001 4.18893199082788e+002 -1.57268324030374e+003
1.20460698691584e+003 -2.39605609361480e+006 5.75348985315283e+006 1.35077917566140e+006 7.79422244477587e+001 4.04970867156974e+002 -1.57604899178603e+003
1.24152897705108e+003 -2.39307112303943e+006 5.76818461230445e+006 1.29252824677114e+006 8.37477304042725e+001 3.91011454616544e+002 -1.57927299037193e+003
1.27845116493129e+003 -2.38987191632900e+006 5.78236337051851e+006 1.23416059937805e+006 8.95459477577716e+001 3.77016236106639e+002 -1.58235492196272e+003
1.31537355070521e+003 -2.38645875021395e+006 5.79602482408090e+006 1.17568148276339e+006 9.53363440861533e+001 3.62986490170219e+002 -1.58529448606803e+003
1.35229613455259e+003 -2.38283192106829e+006 5.80916771653305e+006 1.11709615706870e+006 1.01118387541297e+002 3.48923499111507e+002 -1.58809139585111e+003
1.38922427038084e+003 -2.37899117262026e+006 5.82179263137354e+006 1.05840137641203e+006 1.06892383332024e+002 3.34826502880947e+002 -1.59074575261467e+003
1.42614915012013e+003 -2.37493774019263e+006 5.83389535533376e+006 9.99616414731525e+005 1.12656422889978e+002 3.20700151199872e+002 -1.59325665274290e+003
1.46307439305185e+003 -2.37067161021144e+006 5.84547603013729e+006 9.40740813972805e+005 1.18410542545361e+002 3.06544356633278e+002 -1.59562411580482e+003
1.50000000000000e+003 -2.36619315727383e+006 5.85653357621206e+006 8.81779906734936e+005 2.64140888327519e+000 2.02434805011335e+000 -6.31456079214184e+000
1.01623550185336e+004 -2.34320084000772e+006 5.87379235704827e+006 8.27039889308211e+005 2.66710992524006e+000 1.96039683363010e+000 -6.32392859033661e+000
1.88247336677324e+004 -2.31998691976245e+006 5.89049639658853e+006 7.72221179825670e+005 2.69255837833020e+000 1.89625784730675e+000 -6.33269606645615e+000
2.74871359182307e+004 -2.29655359421905e+006 5.90664409204815e+006 7.17328981866264e+005 2.71775177020495e+000 1.83193726291928e+000 -6.34086233051731e+000
3.61495617467211e+004 -2.27290308236529e+006 5.92223389418722e+006 6.62368506452111e+005 2.74268765374417e+000 1.76744127174111e+000 -6.34842655303211e+000
4.48120111348728e+004 -2.24903762427851e+006 5.93726430747328e+006 6.07344971531160e+005 2.76736360733778e+000 1.70277608385464e+000 -6.35538796513107e+000
5.34744840682433e+004 -2.22495948090616e+006 5.95173389023844e+006 5.52263601458956e+005 2.79177723516930e+000 1.63794792745977e+000 -6.36174585867892e+000
6.21369805351812e+004 -2.20067093384405e+006 5.96564125483080e+006 4.97129626479562e+005 2.81592616749759e+000 1.57296304817919e+000 -6.36749958638105e+000
7.08000000000000e+004 -2.17617286938206e+006 5.97898581945697e+006 4.41945105247284e+005 2.83980941156417e+000 1.50782400181654e+000 -6.37264883700924e+000


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

