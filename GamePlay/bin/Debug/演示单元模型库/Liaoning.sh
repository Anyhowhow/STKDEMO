stk.v.9.0
WrittenBy    STK_v9.2.2

BEGIN Ship

Name		Liaoning

BEGIN VehiclePath
	CentralBody				Earth

    BEGIN Interval

         StartTime            8 Apr 2015 04:00:30.000000000
         StopTime             9 Apr 2015 04:00:00.000000000

    END Interval

	StoreEphemeris				Yes
	SmoothInterp				No

    BEGIN GreatArc

        VersionIndicator      20071204
        Method              DetVelFromTime

        TimeOfFirstWaypoint 8 Apr 2015 04:00:30.000000000

    UseScenTime          No
        ArcGranularity      5.729577951308e-001
        AltRef              WGS84
        AltInterpMethod     EllipsoidHeight
        NumberOfWaypoints   10

        BEGIN Waypoints

        0.000000000000e+000 3.873692083000e+001 1.215186689700e+002 -3.000000000000e+000 1.000000409934e+003 0.000000000000e+000
        3.266220000000e+002 3.638158963000e+001 1.237354512800e+002 -3.000000000000e+000 1.000000064399e+003 0.000000000000e+000
        1.177102000000e+003 2.872676322000e+001 1.231812557100e+002 -3.000000000000e+000 9.999996383023e+002 0.000000000000e+000
        2.214134000000e+003 2.141322786000e+001 1.167569851500e+002 -3.000000000000e+000 1.000001439337e+003 0.000000000000e+000
        2.600111000000e+003 1.799037743000e+001 1.160555813700e+002 -3.000000000000e+000 9.999995343528e+002 0.000000000000e+000
        3.302581000000e+003 1.170579959000e+001 1.169814343600e+002 -3.000000000000e+000 9.999978326472e+002 0.000000000000e+000
        3.520158000000e+003 1.061160971000e+001 1.153261214500e+002 -3.000000000000e+000 1.000000763911e+003 0.000000000000e+000
        3.784232000000e+003 1.134106963000e+001 1.130255170600e+002 -3.000000000000e+000 5.000002506777e+002 0.000000000000e+000
        3.858077000000e+003 1.143529506000e+001 1.127009782400e+002 -3.000000000000e+000 0.000000000000e+000 0.000000000000e+000
        8.637000000000e+004 1.143529506000e+001 1.127009782400e+002 -3.000000000000e+000 1.000000000000e-005 0.000000000000e+000

        END Waypoints

    END GreatArc

END VehiclePath

BEGIN Ephemeris

NumberOfEphemerisPoints 68

ScenarioEpoch            8 Apr 2015 04:00:00.000000

# Epoch in JDate format: 2457120.66666666666667
# Epoch in YYDDD format:   15098.16666666666667


InterpolationMethod     GreatArc

InterpolationSamplesM1      1

CentralBody             Earth

CoordinateSystem        Fixed 

BlockingFactor          20

# Time of first point: 8 Apr 2015 04:00:30.000000000 UTCG = 2457120.66701388888889 JDate = 15098.16701388888889 YYDDD

EphemerisTimePosVel

3.00000000000000e+001 -2.60429001797029e+006 4.24670845468790e+006 3.96957632637270e+006 -7.78652025844772e+002 1.04680006218134e+002 -6.18663025251392e+002
8.44347846762917e+001 -2.64658078473252e+006 4.25225186206959e+006 3.93575426444477e+006 -7.75146966776785e+002 9.89811905774038e+001 -6.23979746206421e+002
1.38869972350984e+002 -2.68867951670253e+006 4.25748488036752e+006 3.90164376259447e+006 -7.71585032068497e+002 9.32747259661298e+001 -6.29251288159984e+002
1.93305563308136e+002 -2.73058312177613e+006 4.26240709983877e+006 3.86724728669438e+006 -7.67966469420468e+002 8.75610276111488e+001 -6.34477255823044e+002
2.47741557949380e+002 -2.77228852146995e+006 4.26701813336678e+006 3.83256732402846e+006 -7.64291530833061e+002 8.18405115191454e+001 -6.39657257004359e+002
3.02177956793700e+002 -2.81379265115392e+006 4.27131761650104e+006 3.79760638312075e+006 -7.60560472594681e+002 7.61135944479487e+001 -6.44790902645167e+002
3.56621999999999e+002 -2.85509793897748e+006 4.27530571704437e+006 3.76236228870848e+006 -2.75658464918924e+002 5.27724150413510e+002 -8.03442443854237e+002
4.17362475941003e+002 -2.87171173420245e+006 4.30716552024727e+006 3.71338895332338e+006 -2.71372633643945e+002 5.21304658249494e+002 -8.09072602301002e+002
4.78103574611157e+002 -2.88806460072801e+006 4.33863424745668e+006 3.66407535992803e+006 -2.67061594898282e+002 5.14836925884950e+002 -8.14629469804100e+002
5.38838251213179e+002 -2.90415316291060e+006 4.36970539686074e+006 3.61443174762795e+006 -2.62726241598327e+002 5.08322291643377e+002 -8.20111881752502e+002
5.99580667018235e+002 -2.91997967061322e+006 4.40038332732099e+006 3.56445103402811e+006 -2.58365954093945e+002 5.01759821303910e+002 -8.25520589863016e+002
6.60330613267501e+002 -2.93554250040919e+006 4.43066494550632e+006 3.51413780287529e+006 -2.53981132915049e+002 4.95150111082763e+002 -8.30855029722697e+002
7.21074210180359e+002 -2.95083664354143e+006 4.46054051927827e+006 3.46350810765766e+006 -2.49573176476127e+002 4.88495265978065e+002 -8.36113469272098e+002
7.81818434528102e+002 -2.96586247331922e+006 4.49001077149539e+006 3.41256077715786e+006 -2.45141981655238e+002 4.81795129100808e+002 -8.41296018772504e+002
8.42563287864348e+002 -2.98061858513069e+006 4.51907296155523e+006 3.36130042907750e+006 -2.40687949947141e+002 4.75050304602200e+002 -8.46402178426537e+002
9.03319637441715e+002 -2.99510616540033e+006 4.54772947362006e+006 3.30972245989723e+006 -2.36210682642314e+002 4.68260183111985e+002 -8.51432347937973e+002
9.64072704740596e+002 -3.00932028707653e+006 4.57597059812939e+006 3.25784404353924e+006 -2.31711671662867e+002 4.61427022667431e+002 -8.56384804141840e+002
1.02482749163596e+003 -3.02326080765157e+006 4.60379605783293e+006 3.20566564041944e+006 -2.27190957274977e+002 4.54550882313095e+002 -8.61259480713248e+002
1.08558398046253e+003 -3.03692640153675e+006 4.63120322878528e+006 3.15319198945007e+006 -2.22648951181690e+002 4.47632384957726e+002 -8.66055899623309e+002
1.14634215290553e+003 -3.05031576822883e+006 4.65818952490438e+006 3.10042785957889e+006 -2.18086067551445e+002 4.40672158219457e+002 -8.70773589923201e+002
1.20710200000000e+003 -3.06342763247672e+006 4.68475239828521e+006 3.04737804935785e+006 3.37419081547864e+002 6.60129159405858e+002 -6.71101432656922e+002
1.26809723505037e+003 -3.04270636663766e+006 4.72480220554037e+006 3.00630416262678e+006 3.42017726023837e+002 6.53066867417324e+002 -6.75667683385752e+002
1.32909289373784e+003 -3.02170540227411e+006 4.76441966989403e+006 2.96495335491294e+006 3.46585259549915e+002 6.45944084282734e+002 -6.80172165298992e+002
1.39008247300338e+003 -3.00042892962888e+006 4.80359696128124e+006 2.92333385545986e+006 3.51120772164511e+002 6.38762224328542e+002 -6.84613979356332e+002
1.45107845587336e+003 -2.97887453027532e+006 4.84233846763034e+006 2.88144095209757e+006 3.55624767284559e+002 6.31520469694232e+002 -6.88993612347488e+002
1.51207566878339e+003 -2.95704594520402e+006 4.88063723284589e+006 2.83928198196513e+006 3.60096434976551e+002 6.24220082038294e+002 -6.93310264817957e+002
1.57307977330020e+003 -2.93494308438968e+006 4.91849317501670e+006 2.79685683960415e+006 3.64535764623550e+002 6.16861036636463e+002 -6.97563914200536e+002
1.63407755776566e+003 -2.91257274684612e+006 4.95589458233650e+006 2.75417859444892e+006 3.68941378046214e+002 6.09445596717517e+002 -7.01753233559812e+002
1.69507576989910e+003 -2.88993453825425e+006 4.99284219166380e+006 2.71124647210829e+006 3.73313354064535e+002 6.01973626260409e+002 -7.05878296570055e+002
1.75607441085586e+003 -2.86703051889381e+006 5.02933256974030e+006 2.66806439998703e+006 3.77651281657897e+002 5.94445805614878e+002 -7.09938708800758e+002
1.81707348192115e+003 -2.84386277400710e+006 5.06536232496648e+006 2.62463632933936e+006 3.81954752796703e+002 5.86862820760366e+002 -7.13934081711931e+002
1.87808417204242e+003 -2.82042909273345e+006 5.10093458785412e+006 2.58095820372615e+006 3.86224142152442e+002 5.79223957560944e+002 -7.17864747435552e+002
1.93908968321087e+003 -2.79673802708412e+006 5.13603619145185e+006 2.53704601611198e+006 3.90457867307992e+002 5.71532009229133e+002 -7.21729237933774e+002
2.00009632988888e+003 -2.77278931656961e+006 5.17066755884633e+006 2.49289927315768e+006 3.94655971723561e+002 5.63786889031844e+002 -7.25527590339188e+002
2.06110409827348e+003 -2.74858514248296e+006 5.20482544247986e+006 2.44852202252226e+006 3.98818057377328e+002 5.55989305260808e+002 -7.29259436791901e+002
2.12211297413515e+003 -2.72412771076910e+006 5.23850663809037e+006 2.40391833480263e+006 4.02943729439066e+002 5.48139971701092e+002 -7.32924415566792e+002
2.18312294282282e+003 -2.69941925183222e+006 5.27170798506805e+006 2.35909230315623e+006 4.07032596317584e+002 5.40239607566368e+002 -7.36522171123290e+002
2.24413400000000e+003 -2.67446202033980e+006 5.30442636680811e+006 2.31404804291997e+006 1.06537536803672e+001 4.06591997507693e+002 -9.13549300131781e+002
2.29927134506693e+003 -2.67377415039909e+006 5.32664547089700e+006 2.26359029327205e+006 1.42988728338150e+001 3.99354435260051e+002 -9.16686672724031e+002
2.35440905246898e+003 -2.67288531174248e+006 5.34846480662395e+006 2.21296113516869e+006 1.79431451815385e+001 3.92086254477766e+002 -9.19755016983673e+002
2.40954712225627e+003 -2.67179555621645e+006 5.36988269583072e+006 2.16216437931197e+006 2.15862913801458e+001 3.84788006317097e+002 -9.22754084734937e+002
2.46468555457171e+003 -2.67050495107077e+006 5.39089749082865e+006 2.11120384991398e+006 2.52280320343122e+001 3.77460244617411e+002 -9.25683633218761e+002
2.51982434964683e+003 -2.66901357895964e+006 5.41150757454148e+006 2.06008338440040e+006 2.88680877217073e+001 3.70103525855892e+002 -9.28543425121504e+002
2.57496350779755e+003 -2.66732153794150e+006 5.43171136064567e+006 2.00880683311283e+006 3.25061790168509e+001 3.62718409100310e+002 -9.31333228603763e+002
2.63011100000000e+003 -2.66542865351051e+006 5.45151012468227e+006 1.95737061672015e+006 -2.63579057340854e+002 2.11343934431525e+002 -9.41200770620216e+002
2.68864653914888e+003 -2.68074442149405e+006 5.46365029526791e+006 1.90219407577033e+006 -2.59714269809698e+002 2.03447591449697e+002 -9.44010934415651e+002
2.74718243556903e+003 -2.69583339614486e+006 5.47532779159772e+006 1.84685506043191e+006 -2.55827131787199e+002 1.95533453612341e+002 -9.46740838807403e+002
2.80571868922603e+003 -2.71069427618822e+006 5.48654158654484e+006 1.79135827413136e+006 -2.51917976021329e+002 1.87602203073002e+002 -9.49390233500035e+002
2.86425530018413e+003 -2.72532577989327e+006 5.49729069296913e+006 1.73570843471080e+006 -2.47987137411890e+002 1.79654523854273e+002 -9.51958875394694e+002
2.92279226859990e+003 -2.73972664519510e+006 5.50757416382070e+006 1.67991027401112e+006 -2.44034952978990e+002 1.71691101780242e+002 -9.54446528622640e+002
2.98132959471594e+003 -2.75389562981508e+006 5.51739109223981e+006 1.62396853745357e+006 -2.40061761830838e+002 1.63712624408509e+002 -9.56852964578012e+002
3.03986727885435e+003 -2.76783151137945e+006 5.52674061165292e+006 1.56788798361966e+006 -2.36067905131289e+002 1.55719780960968e+002 -9.59177961949800e+002
3.09840532141007e+003 -2.78153308753596e+006 5.53562189586502e+006 1.51167338382955e+006 -2.32053726066481e+002 1.47713262255792e+002 -9.61421306752764e+002
3.15695183578699e+003 -2.79500102597816e+006 5.54403529247471e+006 1.45532170420816e+006 -2.28019009346456e+002 1.39692648334621e+002 -9.63583086237871e+002
3.21549411787740e+003 -2.80823122067216e+006 5.55197818810283e+006 1.39884995808096e+006 -2.23964975916688e+002 1.31660372466411e+002 -9.65662624621261e+002
3.27403717497409e+003 -2.82122368659105e+006 5.55945060764526e+006 1.34225813714075e+006 -2.19891630293951e+002 1.23616444355207e+002 -9.67659916663609e+002
3.33258100000000e+003 -2.83397729066376e+006 5.56645187357187e+006 1.28555108775020e+006 6.90947649766977e+002 4.77885961729163e+002 -5.42413143427437e+002
3.38697486176011e+003 -2.79629106261750e+006 5.59224288717744e+006 1.25600051489176e+006 6.94723539945595e+002 4.70413932729789e+002 -5.44119104827523e+002
3.44136883829513e+003 -2.75840074493400e+006 5.61762658062716e+006 1.22635816655354e+006 6.98448792913151e+002 4.62907409052060e+002 -5.45785378717698e+002
3.49576292963811e+003 -2.72030909864986e+006 5.64260109084060e+006 1.19662620448146e+006 7.02123132219308e+002 4.55366939461372e+002 -5.47411840342608e+002
3.55015800000000e+003 -2.68201828990661e+006 5.66716497159205e+006 1.16680632273935e+006 8.83967946162672e+002 3.55364065569500e+002 3.03839725647015e+002
3.60297304985038e+003 -2.63524007507443e+006 5.68573887905460e+006 1.18281342009827e+006 8.87419011530129e+002 3.47988697583926e+002 3.02312573590846e+002
3.65578804498458e+003 -2.58828124906654e+006 5.70392260614318e+006 1.19873929685247e+006 8.90809131212666e+002 3.40589521616756e+002 3.00764687646994e+002
3.70860298538075e+003 -2.54114503724101e+006 5.72171490967841e+006 1.21458286092025e+006 8.94138074172355e+002 3.33167046836580e+002 2.99196174841748e+002
3.76141787100162e+003 -2.49383467705042e+006 5.73911457341340e+006 1.23034302590832e+006 8.97405613608827e+002 3.25721783974509e+002 2.97607143614224e+002
3.81423200000000e+003 -2.44635404986637e+006 5.75612018476510e+006 1.24601850345503e+006 4.52254830606877e+002 1.61992598880179e+002 1.38651421840914e+002
3.88807700000000e+003 -2.41291650083790e+006 5.76798594759597e+006 1.25623627794819e+006 0.00000000000000e+000 0.00000000000000e+000 0.00000000000000e+000
8.64000000000000e+004 -2.41291650083790e+006 5.76798594759597e+006 1.25623627794819e+006 0.00000000000000e+000 0.00000000000000e+000 0.00000000000000e+000


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
                MarkerColor          #87cefa
                GroundTrackColor     #87cefa
                SwathColor           #87cefa
                LabelColor           #87cefa
                LineStyle            1
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
        ShortText    0

        LongText    0

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

