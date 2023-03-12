﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Windows.Forms;
//
namespace Tables
{
    //class HydroResInfo
    //{
    //}
    public static class HydroResistanceConsts
    {
        public const string FrameElementLeft = "    :.....";
        public const string FrameElementRight = "....:     ";
        public const string FrameElementVertical = "    :     ";
        public const string FrameElementHorisontal = "..........";
        public const string FrameName = ".. Rs___..";
        public const string ConnectorCentral = "----|-----";
        public const string ConnectorLeft = "    |-----";
        public const string ConnectorRight = "----|     ";
        public const string LineVertical = "    |     ";
        public const string LineHorisontal = "----------";
        public const string LineFrameIntersection = "----:-----";
        public const string ResistanceElementar = "-[ Re___]-";
        public const string ResistanceLeftSide = "----:     ";
        public const string ResistanceRightSide = "    :-----";
        //
        public const double g_fall_acc = 9.81;
        //public const int QParallelHydroResistancesMax = 16;
        public const int LocResistanceGroupN = 1;
        public const int WayResistanceGroupN = 2;
        //public const string LocResistanceGroupName = "Loc.";
        public const string LocResistanceGroupName = "5AB=.";
        //public const string WayResistanceGroupName = "Way.";
        public const string WayResistanceGroupName = "CB52.";
        //
        public const int ResistanceTypeN_Loc_Simple_TJointUniting = 4;
        //
        public const int ResistanceTypeN_Loc_Simple_SuddBroad = 4;
        public const int ResistanceTypeN_Loc_Simple_SuddNarr = 5;
        public const int ResistanceTypeN_Loc_Simple_GradBroad = 4;
        public const int ResistanceTypeN_Loc_Simple_GradNarr = 5;
        //
        //public const string ResistanceTypeName_Loc_Simple_Inlet = "Inlet";
        public const string ResistanceTypeName_Loc_Simple_InletFromSpaceToPipeline = "ВходИзБака";
        public const string ResistanceTypeName_Loc_Simple_InletFromSpaceToPipeline_En = "InletFromSpace";
        public const int ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline = 1;
        public const double ResistanceCoefVal_min_InletFromSpaceToPipeline = 0.5;
        public const double ResistanceCoefVal_max_InletFromSpaceToPipeline = 0.5;
        public const double ResistanceCoefVal_InletFromSpaceToPipeline = 0.5;//1?
        public const int Resistance_DefWay_InletFromSpaceToPipeline_Const0ConstsRange1TableStdParams2TableSpecParams3 = 0;
        public const int Resistance_CoefDependanceSubTypeN_InletFromSpaceToPipeline = ResistanceLocConstResistCoefSubTypeN;
        //
        //public const string ResistanceTypeName_Loc_Simple_OutletFromPilelineToSpace= "Outlet"; //OutletFromPilelineToSpace
        public const string ResistanceTypeName_Loc_Simple_OutletFromPilelineToSpace = "ВыходВБак";
        public const string ResistanceTypeName_Loc_Simple_OutletFromPilelineToSpace_En = "OutletToSpace";
        public const int ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace = 2;
        public const double ResistanceCoefVal_min_OutletFromPilelineToSpace = 1;//0.5?
        public const double ResistanceCoefVal_max_OutletFromPilelineToSpace = 1;//0.5?
        public const double ResistanceCoefVal_OutletFromPilelineToSpace = 1;//0.5?
        public const int Resistance_DefWay_OutletFromPilelineToSpace_Const0ConstsRange1TableStdParams2TableSpecParams3 = 0;
        public const int Resistance_CoefDependanceSubTypeN_OutletFromPilelineToSpace = ResistanceLocConstResistCoefSubTypeN;
        //
        //public const string ResistanceTypeName_Loc_Simple_TJoint = "TJoint";
        public const string ResistanceTypeName_Loc_Simple_TJoint = "Тройник";
        public const string ResistanceTypeName_Loc_Simple_TJoint_En = "TJoint";
        public const int ResistanceTypeN_Loc_Simple_TJoint = 3;
        public const double ResistanceCoefVal_Simple_TJoint = 2;//0.5?
        public const double ResistanceCoefVal_max_Simple_TJoint = 1.5;//0.5?
        public const double ResistanceCoefVal_min_Simple_TJoint = 2.5;//0.5?
        public const int Resistance_DefWay_Simple_TJoint_Const0ConstsRange1TableStdParams2TableSpecParams3 = 1;
        public const int Resistance_CoefDependanceSubTypeN_TJoint = ResistanceLocConstResistCoefSubTypeN;
        //
        //public const string ResistanceTypeName_Loc_Simple_DuriteSchlange = "DuriteSchlange";
        public const string ResistanceTypeName_Loc_Simple_DuriteSchlange = "Дюрит.шланг";
        public const string ResistanceTypeName_Loc_Simple_DuriteSchlange_En = "DuriteSchlange";
        public const int ResistanceTypeN_Loc_Simple_DuriteSchlange = 5;
        public const double ResistanceCoefVal_DuriteSchlange = 0.25;//0.5?
        public const double ResistanceCoefVal_max_DuriteSchlange = 0.2;//0.5?
        public const double ResistanceCoefVal_min_DuriteSchlange = 0.3;//0.5?
        public const int Resistance_DefWay_DuriteSchlange_Const0ConstsRange1TableStdParams2TableSpecParams3 = 1;
        public const int Resistance_CoefDependanceSubTypeN_DuriteSchlange = ResistanceLocConstResistCoefSubTypeN;//ResistanceLocGeomDependentFlowIndepResistCoefSubTypeN
        //
        //
        public const string ResistanceTypeName_Loc_Geom_SuddBroad = "Резк.расшир";//"SuddBroad."
        public const string ResistanceTypeName_Loc_Geom_SuddBroad_En = "SuddBroad.";
        //public const string ResistanceTypeName_Loc_Geom_SuddBroad = "SuddBroad.";
        public const double ResistanceCoefVal_SuddBroad = 0;
        public const double ResistanceCoefVal_max_SuddBroad = 0;
        public const double ResistanceCoefVal_min_SuddBroad = 0;
        public const int ResistanceTypeN_Loc_Geom_SuddBroad = 10;
        public const int Resistance_CoefDependanceSubTypeN_SuddBroad = ResistanceLocGeomDependentFlowIndepResistCoefSubTypeN;//ResistanceLocConstResistCoefSubTypeN;

        //public const string ResistanceTypeName_Loc_Geom_SuddNarr = "SuddNarr.";
        public const string ResistanceTypeName_Loc_Geom_SuddNarr = "Резк.сужение";//table
        public const string ResistanceTypeName_Loc_Geom_SuddNarr_En = "SuddNarr";
        public const double ResistanceCoefVal_SuddNarr = 0;
        public const double ResistanceCoefVal_max_SuddNarr = 0;
        public const double ResistanceCoefVal_min_SuddNarr = 0;
        public const int ResistanceTypeN_Loc_Geom_SuddNarr = 20;
        public const int Resistance_CoefDependanceSubTypeN_SuddNarr = ResistanceLocGeomDependentFlowIndepResistCoefSubTypeN;//ResistanceLocConstResistCoefSubTypeN;

        //public const string ResistanceTypeName_Loc_Geom_SuddTurn90Deg = "SuddTurn90Deg.";
        public const string ResistanceTypeName_Loc_Geom_SuddTurn90 = "РезкПовор90град";
        public const string ResistanceTypeName_Loc_Geom_SuddTurn90_En = "SuddTurn90";
        public const int ResistanceTypeN_Loc_Geom_SuddTurn90 = 30;
        public const double ResistanceCoefVal_Loc_Geom_SuddTurn90 = 0;
        public const double ResistanceCoefVal_max_Loc_Geom_SuddTurn90 = 0;
        public const double ResistanceCoefVal_min_Loc_Geom_SuddTurn90 = 0;
        public const int Resistance_CoefDependanceSubTypeN_SuddTurn90 = ResistanceLocGeomDependentFlowIndepResistCoefSubTypeN;//ResistanceLocConstResistCoefSubTypeN;


        //public const string ResistanceTypeName_Loc_Geom_SuddTurn = "SuddTurn.";
        public const string ResistanceTypeName_Loc_Geom_SuddTurn = "Резк.поворот";//graph
        public const string ResistanceTypeName_Loc_Geom_SuddTurn_En = "SuddTurn";
        public const int ResistanceTypeN_Loc_Geom_SuddTurn = 40;
        public const double ResistanceCoefVal_Loc_Geom_SuddTurn = 0;
        public const double ResistanceCoefVal_max_Loc_Geom_SuddTurn = 0;
        public const double ResistanceCoefVal_min_Loc_Geom_SuddTurn = 0;

        //public const string ResistanceTypeName_Loc_Geom_GradTurn = "GradTurn.";
        public const string ResistanceTypeName_Loc_Geom_GradTurn = "Плавн.поворот";
        public const string ResistanceTypeName_Loc_Geom_GradTurn_En = "GradTurn";
        public const int ResistanceTypeN_Loc_Geom_GradTurn = 50;
        public const double ResistanceCoefVal_Loc_Geom_GradTurn = 0;
        public const double ResistanceCoefVal_max_Loc_Geom_GradTurn = 0;
        public const double ResistanceCoefVal_min_Loc_Geom_GradTurn = 0;

        //public const string ResistanceTypeName_Loc_Geom_GradBroad = "Diffusor";
        public const string ResistanceTypeName_Loc_Geom_GradBroad = "Плавн.расшир";//;02=. 0AH8@.
        public const string ResistanceTypeName_Loc_Geom_GradBroad_En = "GradBroad";
        public const int ResistanceTypeN_Loc_Geom_GradBroad = 60;
        public const double ResistanceCoefVal_Loc_Geom_GradBroad = 0;
        public const double ResistanceCoefVal_max_Loc_Geom_GradBroad = 0;
        public const double ResistanceCoefVal_min_Loc_Geom_GradBroad = 0;

        //public const string ResistanceTypeName_Loc_Geom_GradNarr = "Confusor";
        public const string ResistanceTypeName_Loc_Geom_GradNarr = "Плавн.сужение";//;02=.!C65=85.
        public const string ResistanceTypeName_Loc_Geom_GradNarr_En = "GradNarr";
        public const int ResistanceTypeN_Loc_Geom_GradNarr = 70;
        public const double ResistanceCoefVal_Loc_Geom_GradNarr = 0;
        public const double ResistanceCoefVal_max_Loc_Geom_GradNarr = 0;
        public const double ResistanceCoefVal_min_Loc_Geom_GradNarr = 0;
        //
        //public const string ResistanceTypeName_Loc_Geom_Schieber = "Schieber";
        public const string ResistanceTypeName_Loc_Geom_Schieber = "Шибер";//0A;>=:0!4286=0O.//table - % of closing
        public const string ResistanceTypeName_Loc_Geom_Schieber_En = "Schieber";
        public const int ResistanceTypeN_Loc_Geom_Schieber = 80;
        public const double ResistanceCoefVal_Loc_Geom_Schieber =0;
        public const double ResistanceCoefVal_max_Loc_Geom_Schieber = 0;
        public const double ResistanceCoefVal_min_Loc_Geom_Schieber = 0;

        //public const string ResistanceTypeName_Loc_Geom_DrosselTurningThrottle = "Throttle";
        public const string ResistanceTypeName_Loc_Geom_DrosselTurningThrottle = "ДроссельнаяЗаслонка"; //turn angle
        public const string ResistanceTypeName_Loc_Geom_DrosselTurningThrottle_En = "DrosselTurningThrottle";
        public const int ResistanceTypeN_Loc_Geom_DrosselTurningThrottle = 90;
        public const double ResistanceCoefVal_Loc_DrosselTurningThrottle = 0;
        public const double ResistanceCoefVal_max_Loc_DrosselTurningThrottle = 0;
        public const double ResistanceCoefVal_min_Loc_DrosselTurningThrottle = 0;

        //public const string ResistanceTypeName_Loc_Geom_Valve = "Valve";
        public const string ResistanceTypeName_Loc_Geom_Valve = "КлапанОбр";//table 
        public const string ResistanceTypeName_Loc_Geom_Valve_En = "Valve";
        public const int ResistanceTypeN_Loc_Geom_Valve = 100;
        public const double ResistanceCoefVal_Loc_Geom_Valve = 1.85;//obratnyj klapan
        public const double ResistanceCoefVal_max_Loc_Geom_Valvee = 2;//obratnyj klapan
        public const double ResistanceCoefVal_min_Loc_Geom_Valve = 1.7;//obratnyj klapan

        //public const string ResistanceTypeName_Loc_Geom_DiaphragmAcute = "DiaphragmAcute";//acute diaphragm
        public const string ResistanceTypeName_Loc_Geom_DiaphragmAcute = "ДиафрагмаОстр";//AB@0O 480D@03<0
        public const string ResistanceTypeName_Loc_Geom_DiaphragmAcute_En = "DiaphragmAcute";
        public const int ResistanceTypeN_Loc_Geom_DiaphragmAcute = 110;
        public const double ResistanceCoefVal_Loc_Geom_DiaphragmAcute = 0;
        public const double ResistanceCoefVal_max_Loc_Geom_DiaphragmAcute = 0;
        public const double ResistanceCoefVal_min_Loc_Geom_DiaphragmAcute =0;
        //
        //public const string ResistanceTypeName_Loc_Geom_FlowMeter = "FlowMeter";// 0AE>4><5@.
        public const string ResistanceTypeName_Loc_Geom_FlowMeter = "Расходомер";// 0AE>4><5@.
        public const string ResistanceTypeName_Loc_Geom_FlowMeter_En = "FlowMeter";
        public const int ResistanceTypeN_Loc_Geom_FlowMeter = 120;// 0AE>4><5@.
        public const double ResistanceCoefVal_Loc_Geom_FlowMeter = 8.5;
        public const double ResistanceCoefVal_max_Loc_Geom_FlowMeter = 10;
        public const double ResistanceCoefVal_min_Loc_Geom_FlowMeter = 7;

        //public const string ResistanceTypeName_Loc_Geom_SelfLockngConnection = "SlfLockConnect";//!0<>70?>@=>5 A>548=5=85.
        public const string ResistanceTypeName_Loc_Geom_SelfLockngConnection = "Самозапорн.соед";//!0<>70?>@=>5 A>548=5=85.
        public const string ResistanceTypeName_Loc_Geom_SelfLockngConnection_En = "SelfLockingConnection";
        public const int ResistanceTypeN_Loc_Geom_SelfLockngConnection = 130;
        public const double ResistanceCoefVal_Loc_Geom_SelfLockngConnection = 2.25;
        public const double ResistanceCoefVal_max_Loc_Geom_SelfLockngConnection = 2.5;
        public const double ResistanceCoefVal_min_Loc_Geom_SelfLockngConnection = 2;

        //public const string ResistanceTypeName_Loc_Geom_StopCock = "StopCock";//0?>@=K9 :@0=.
        public const string ResistanceTypeName_Loc_Geom_StopCock = "КранЗапорный";//0?>@=K9 :@0=.
        public const string ResistanceTypeName_Loc_Geom_StopCock_En = "StopCock";
        public const int ResistanceTypeN_Loc_Geom_StopCock = 140;
        public const double ResistanceCoefVal_Loc_Geom_StopCock = 2.25;
        public const double ResistanceCoefVal_max_Loc_Geom_StopCock = 2.5;
        public const double ResistanceCoefVal_min_Loc_Geom_StopCock = 1;

        //public const string ResistanceTypeName_Loc_Geom_CheckValve = "CheckValve";//1@0B=K9;0?0=.
        public const string ResistanceTypeName_Loc_Geom_CheckValve = "Обратный клапан";//1@0B=K9;0?0=.
        public const string ResistanceTypeName_Loc_Geom_CheckValve_En = "CheckValve";
        public const int ResistanceTypeN_Loc_Geom_CheckValve = 150;
        public const double ResistanceCoefVal_Loc_Geom_CheckValve = 1.85;
        public const double ResistanceCoefVal_max_Loc_Geom_CheckValve = 2;
        public const double ResistanceCoefVal_min_Loc_Geom_CheckValve = 1.7;

        public const double ResistanceCoef_val_Loc_Geom_CheckValve = 2.5;//?
        //public const string ResistanceTypeName_Loc_Geom_TransferValve = "TransferValve";//5@52>4=>9;0?0=.
        public const string ResistanceTypeName_Loc_Geom_TransferValve = "Перепуск.клапан";//5@52>4=>9;0?0=.
        public const string ResistanceTypeName_Loc_Geom_TransferValve_En = "TransferValve";
        public const int ResistanceTypeN_Loc_Geom_TransferValve = 160;
        public const double ResistanceCoefVal_Loc_Geom_TransferValve = 1.85;
        public const double ResistanceCoefVal_max_Loc_Geom_TransferValve = 2;
        public const double ResistanceCoefVal_min_Loc_Geom_TransferValve = 1.7;

        public const double ResistanceCoef_val_Loc_Geom_TransferValve = 2;//such const //const given in table
        //public const string ResistanceTypeName_Loc_Geom_StrainerFilter = "Strainer";//!5BG0BK9$8;LB@.
        public const string ResistanceTypeName_Loc_Geom_StrainerFilter = "Фильтр";//!5BG0BK9$8;LB@.
        public const string ResistanceTypeName_Loc_Geom_StrainerFilter_En = "StrainerFilter";
        public const int ResistanceTypeN_Loc_Geom_StrainerFilter = 170;
        public const double ResistanceCoefVal_Loc_Geom_StrainerFilter = 1.75;
        public const double ResistanceCoefVal_max_Loc_Geom_StrainerFilter = 2.5;
        public const double ResistanceCoefVal_min_Loc_Geom_StrainerFilter = 1.5;
        //
        //
        //public const string TubeInnerSurfaceMatAndQua_Name_Glass = "Glass";
        public const string TubeInnerSurfaceMatAndQua_Name_Glass = "Стекло";
        public const string TubeInnerSurfaceMatAndQua_Name_Glass_En = "Glass";
        public const int TubeInnerSurfaceMatAndQua_N_Glass = 1;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_Glass = 0;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_min_Glass = 0;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_max_Glass = 0;
        //public const string TubeInnerSurfaceMatAndQua_Name_PipesDrawnOfBrassOrCopper = "PipesDrawnBrassCopper";//TubesGezogenAusCuprum
        public const string TubeInnerSurfaceMatAndQua_Name_PipesDrawnOfBrassOrCopper_En = "PipesDrawnBrassCopper";
        public const string TubeInnerSurfaceMatAndQua_Name_PipesDrawnOfBrassOrCopper = "Медные трубы";
        public const int TubeInnerSurfaceMatAndQua_N_PipesDrawnOfBrassOrCopper = 2;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_PipesDrawnOfBrassOrCopper = 0.001;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_min_PipesDrawnOfBrassOrCopper = 0;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_max_PipesDrawnOfBrassOrCopper = 0.002;
        //public const string TubeInnerSurfaceMatAndQua_Name_HiQuaSteelSeamlessTubes = "HiQuaSteelSeamlessTubes";
        public const string TubeInnerSurfaceMatAndQua_Name_HiQuaSteelSeamlessTubes_En = "HiQuaSteelSeamlessTubes";
        public const string TubeInnerSurfaceMatAndQua_Name_HiQuaSteelSeamlessTubes = "ВысКачНержТрубы";
        public const int TubeInnerSurfaceMatAndQua_N_HiQuaSteelSeamlessTubes = 3;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_HiQuaSteelSeamlessTubes = 0.13;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_min_HiQuaSteelSeamlessTubes = 0.06;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_max_HiQuaSteelSeamlessTubes = 0.2;
        //public const string TubeInnerSurfaceMatAndQua_Name_SteelTubes = "SteelTubes";
        public const string TubeInnerSurfaceMatAndQua_Name_SteelTubes_En = "SteelTubes";
        public const string TubeInnerSurfaceMatAndQua_Name_SteelTubes = "СтальнТрубы";
        public const int TubeInnerSurfaceMatAndQua_N_SteelTubes = 4;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_SteelTubes = 0.35;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_min_SteelTubes = 0.5;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_max_SteelTubes = 0.1;
        //public const string TubeInnerSurfaceMatAndQua_Name_CastIronAsphaltTubes = "CastIronAsphaltTubes";
        public const string TubeInnerSurfaceMatAndQua_Name_CastIronAsphaltTubes_En = "CastIronAsphaltTubes";
        public const string TubeInnerSurfaceMatAndQua_Name_CastIronAsphaltTubes = "ЧугуннАсфальтТрубы";
        public const int TubeInnerSurfaceMatAndQua_N_CastIronAsphaltTubes = 5;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_CastIronAsphaltTubes = 0.15;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_min_CastIronAsphaltTubes = 0.1;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_max_CastIronAsphaltTubes = 0.2;
        //public const string TubeInnerSurfaceMatAndQua_Name_CastIronTubes = "CastIronTubes";
        public const string TubeInnerSurfaceMatAndQua_Name_CastIronTubes_En = "CastIronTubes";
        public const string TubeInnerSurfaceMatAndQua_Name_CastIronTubes = "ЧугуннЛитыеТрубы";
        public const int TubeInnerSurfaceMatAndQua_N_CastIronTubes = 6;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_CastIronTubes = 0.06;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_min_CastIronTubes = 0.2;
        public const double TubeInnerSurfaceMatAndQua_CoefDeltaEqvVal_max_CastIronTubes = 1.0;
        //
        //
        public const int ResistanceLocConstResistCoefSubTypeN = 10;
        //
        public const int ResistanceLocConstSingleResistCoefSubTypeN = 11;
        public const int ResistanceLocConstRangeResistCoefSubTypeN = 12;
        //
        public const int ResistanceLocGeomDependentFlowIndepResistCoefSubTypeN = 20;
        public const int ResistanceLocFlowDependentResistCoefSubTypeN = 30;
        //
        //
        public static string[] TubeInnerSurfaceMatAndQua_ItemNames ={
            TubeInnerSurfaceMatAndQua_Name_Glass,
            TubeInnerSurfaceMatAndQua_Name_PipesDrawnOfBrassOrCopper,
            TubeInnerSurfaceMatAndQua_Name_HiQuaSteelSeamlessTubes,
            TubeInnerSurfaceMatAndQua_Name_SteelTubes,
            TubeInnerSurfaceMatAndQua_Name_CastIronAsphaltTubes,
            TubeInnerSurfaceMatAndQua_Name_CastIronTubes
        };
        public static int[] TubeInnerSurfaceMatAndQua_ItemNs = {
            TubeInnerSurfaceMatAndQua_N_Glass,
            TubeInnerSurfaceMatAndQua_N_PipesDrawnOfBrassOrCopper,
            TubeInnerSurfaceMatAndQua_N_HiQuaSteelSeamlessTubes,
            TubeInnerSurfaceMatAndQua_N_SteelTubes,
            TubeInnerSurfaceMatAndQua_N_CastIronAsphaltTubes,
            TubeInnerSurfaceMatAndQua_N_CastIronTubes
        };
        //
        public static string[] HydroResistancesGroups_ItemNames ={
            LocResistanceGroupName, WayResistanceGroupName
                                                                 };
        public static int[] HydroResistancesGroups_ItemNs ={
            1, 2
                                                                 };
        //
        public static string[] HydroResistancesLocal_Types_ItemNames ={
            ResistanceTypeName_Loc_Simple_InletFromSpaceToPipeline,
            ResistanceTypeName_Loc_Simple_OutletFromPilelineToSpace,
            ResistanceTypeName_Loc_Simple_TJoint,
            ResistanceTypeName_Loc_Simple_DuriteSchlange,
            ResistanceTypeName_Loc_Geom_SuddBroad,
            ResistanceTypeName_Loc_Geom_SuddNarr,
            ResistanceTypeName_Loc_Geom_SuddTurn90,
            ResistanceTypeName_Loc_Geom_SuddTurn,
            ResistanceTypeName_Loc_Geom_GradBroad,
            ResistanceTypeName_Loc_Geom_GradNarr,
            ResistanceTypeName_Loc_Geom_Schieber,
            ResistanceTypeName_Loc_Geom_DrosselTurningThrottle,
            ResistanceTypeName_Loc_Geom_Valve,
            ResistanceTypeName_Loc_Geom_DiaphragmAcute,
            ResistanceTypeName_Loc_Geom_FlowMeter,
            ResistanceTypeName_Loc_Geom_SelfLockngConnection,
            ResistanceTypeName_Loc_Geom_StopCock,
            ResistanceTypeName_Loc_Geom_CheckValve,
            ResistanceTypeName_Loc_Geom_TransferValve,
            ResistanceTypeName_Loc_Geom_StrainerFilter
                                                                 };
        public static string[] HydroResistancesLocal_Types_ItemNames_En ={
            ResistanceTypeName_Loc_Simple_InletFromSpaceToPipeline_En,
            ResistanceTypeName_Loc_Simple_OutletFromPilelineToSpace_En,
            ResistanceTypeName_Loc_Simple_TJoint_En,
            ResistanceTypeName_Loc_Simple_DuriteSchlange_En,
            ResistanceTypeName_Loc_Geom_SuddBroad_En,
            ResistanceTypeName_Loc_Geom_SuddNarr_En,
            ResistanceTypeName_Loc_Geom_SuddTurn90_En,
            ResistanceTypeName_Loc_Geom_SuddTurn_En,
            ResistanceTypeName_Loc_Geom_GradBroad_En,
            ResistanceTypeName_Loc_Geom_GradNarr_En,
            ResistanceTypeName_Loc_Geom_Schieber_En,
            ResistanceTypeName_Loc_Geom_DrosselTurningThrottle_En,
            ResistanceTypeName_Loc_Geom_Valve_En,
            ResistanceTypeName_Loc_Geom_DiaphragmAcute_En,
            ResistanceTypeName_Loc_Geom_FlowMeter_En,
            ResistanceTypeName_Loc_Geom_SelfLockngConnection_En,
            ResistanceTypeName_Loc_Geom_StopCock_En,
            ResistanceTypeName_Loc_Geom_CheckValve_En,
            ResistanceTypeName_Loc_Geom_TransferValve_En,
            ResistanceTypeName_Loc_Geom_StrainerFilter_En
                                                                 };
        public static int[] HydroResistancesLocal_Types_ItemNs ={
            ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline,
            ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace,
            ResistanceTypeN_Loc_Simple_TJoint,
            ResistanceTypeN_Loc_Simple_DuriteSchlange,
            ResistanceTypeN_Loc_Geom_SuddBroad,
            ResistanceTypeN_Loc_Geom_SuddNarr,
            ResistanceTypeN_Loc_Geom_SuddTurn90,
            ResistanceTypeN_Loc_Geom_SuddTurn,
            ResistanceTypeN_Loc_Geom_GradBroad,
            ResistanceTypeN_Loc_Geom_GradNarr,
            ResistanceTypeN_Loc_Geom_Schieber,
            ResistanceTypeN_Loc_Geom_DrosselTurningThrottle,
            ResistanceTypeN_Loc_Geom_Valve,
            ResistanceTypeN_Loc_Geom_DiaphragmAcute,
            ResistanceTypeN_Loc_Geom_FlowMeter,
            ResistanceTypeN_Loc_Geom_SelfLockngConnection,
            ResistanceTypeN_Loc_Geom_StopCock,
            ResistanceTypeN_Loc_Geom_CheckValve,
            ResistanceTypeN_Loc_Geom_TransferValve,
            ResistanceTypeN_Loc_Geom_StrainerFilter
                                                                 };
        //
        //
        public static double[] CoefTable_SuddenTurnTo90Deg__x_alfa = { 30, 60, 90, 120, 180 };
        public static double[] CoefTable_SuddenTurnTo90Deg__y_dzeta = { 0.60, 1, 1.2, 1.4, 1.7 };
        public static double[] CoefGraph_SuddenTurnTo90Deg__x_alfa = { 0, 20, 37, 40, 50, 60, 70, 76, 80, 90, 98, 100, 101.5, 102 };
        public static double[] CoefGraph_SuddenTurnTo90Deg__y_dzeta = { 0, 0.125, 0.25, 0.3, 0.4, 0.5, 0.65, 0.75, 0.78, 1, 1.25, 1.42, 1.5, 1.58 };
        public static double[] CoefTable_GradualTurnTo90Deg__x_r_to_d = { 0.5, 0.75, 1, 2, 5 };
        public static double[] CoefTable_GradualTurnTo90Deg__y_dzeta = { 1.2, 0.38, 0.19, 0.12, 0.08 };
        public static double[] CoefTable_GradualTurn_From90ToAnyDegK__theta = { 30, 60, 90, 120, 150, 180 };
        public static double[] CoefTable_GradualTurn_From90ToAnyDegK__y_K = { 0.5, 0.8, 1, 1.2, 1.3, 1.5 };
        public static double[] CoefTable_SuddenBroadening__F2ToF1 = { 0.1, 0.5, 0.9 }; //may be not needed
        public static double[] CoefTable_SuddenBroadening__y_dzeta = { 0.8, 0.3, 0.01 }; //may be not needed
        public static double[] CoefTable_GradualBroadening_FromSuddenToGradual__x_alfa = { 4, 8, 15, 30, 60 }; //may be not needed
        public static double[] CoefTable_GradualBroadening_FromSuddenToGradual__y_K = { 0.08, 0.16, 0.35, 0.8, 0.95 }; //may be not needed
        //
        //
        public static int[] Length = { 12, 12, 14, 16, 13, 11 };
        public static double[] delta = { 4E-4, 2E-3, 4E-3, 8.3E-3, 0.016, 0.033 };
        //
        public static double[] x_lg_Re_1 = { 2.655, 3.325, 3.502, 3.625, 4.891, 4.994, 5.307, 5.393, 5.767, 5.8, 5.87, 6.046 };
        public static double[] y_lg_1000_lambda_1 = { 1.107, 0.452, 0.584, 0.593, 0.276, 0.261, 0.25, 0.261, 0.291, 0.287, 0.294, 0.294 };
        public static double[] x_lg_Re_2 = { 2.655, 3.325, 3.502, 3.625, 4.527, 4.823, 5, 5.236, 5.393, 5.642, 5.8, 6.046 };
        public static double[] y_lg_1000_lambda_2 = { 1.107, 0.452, 0.584, 0.593, 0.369, 0.328, 0.321, 0.357, 0.358, 0.373, 0.373, 0.381 };
        public static double[] x_lg_Re_3 = { 2.655, 3.325, 3.502, 3.625, 4.2, 4.481, 4.6, 4.74, 5, 5.22, 5.4, 5.594, 5.8, 6.046 };
        public static double[] y_lg_1000_lambda_3 = { 1.107, 0.452, 0.584, 0.593, 0.454, 0.402, 0.401, 0.398, 0.428, 0.446, 0.451, 0.448, 0.446, 0.459 };
        public static double[] x_lg_Re_4 = { 2.655, 3.325, 3.502, 3.625, 4.038, 4.2, 4.364, 4.6, 4.895, 5, 5.12, 5.4, 5.431, 5.587, 5.8, 6.046 };
        public static double[] y_lg_1000_lambda_4 = { 1.107, 0.452, 0.584, 0.593, 0.493, 0.481, 0.481, 0.501, 0.536, 0.539, 0.552, 0.562, 0.564, 0.549, 0.553, 0.558 };
        public static double[] x_lg_Re_5 = { 2.655, 3.325, 3.502, 3.625, 3.8, 3.876, 4.155, 4.2, 4.372, 4.6, 4.787, 5, 6.046 };
        public static double[] y_lg_1000_lambda_5 = { 1.107, 0.452, 0.584, 0.593, 0.585, 0.582, 0.599, 0.605, 0.639, 0.653, 0.662, 0.657, 0.657 };
        public static double[] x_lg_Re_6 = { 2.655, 3.325, 3.502, 3.518, 3.651, 3.8, 3.976, 4.2, 4.402, 4.6, 6.046 };
        public static double[] y_lg_1000_lambda_6 = { 1.107, 0.452, 0.584, 0.617, 0.659, 0.701, 0.737, 0.763, 0.781, 0.78, 0.78 };
        //
        public static int[] ReversiveResistances1 = { ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline, ResistanceTypeN_Loc_Simple_SuddBroad, ResistanceTypeN_Loc_Simple_GradBroad };
        public static int[] ReversiveResistances2 = { ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace, ResistanceTypeN_Loc_Simple_SuddNarr, ResistanceTypeN_Loc_Simple_GradNarr };
        public static bool[] ReversiveDResistances = { false, true, true };
        //
        public static void fReversedNOfN(int RsstTypeN, ref int RsltTypeN, ref bool IsReversiveD)
        {
            bool IsIn1 = false, IsIn2 = false;
            int Q = ReversiveResistances1.Length;
            RsltTypeN = RsstTypeN;
            IsReversiveD = false;
            for (int i = 1; i <= Q; i++)
            {
                if (RsstTypeN == ReversiveResistances1[i - 1])
                {
                    IsIn1 = true;
                    RsltTypeN = ReversiveResistances2[i - 1];
                }
                if (RsstTypeN == ReversiveResistances2[i - 1])
                {
                    IsIn2 = true;
                    RsltTypeN = ReversiveResistances1[i - 1];
                }
                if (IsIn1 || IsIn2) IsReversiveD = ReversiveDResistances[i - 1];
            }
        }
        public static PositionInSuccession fDeltaAmongN(double delta)
        {
            //return MyMathLib.DefPosInSucc(delta, LambdaNikuradzeDiagram.delta, 6);
            return MyMathLib.DefPosInSucc(delta, HydroResistanceConsts.delta, 6);
        }
        public static int fNearestDeltaStN(double delta)
        {
            int N = 0;
            PositionInSuccession loc = fDeltaAmongN(delta);
            if (loc.EqualN != 0) N = loc.EqualN;
            //else if (delta < LambdaNikuradzeDiagram.delta[1 - 1]) delta = LambdaNikuradzeDiagram.delta[1 - 1];
            //else if (delta > LambdaNikuradzeDiagram.delta[6 - 1]) delta = LambdaNikuradzeDiagram.delta[6 - 1];
            else if (delta < HydroResistanceConsts.delta[1 - 1]) delta = HydroResistanceConsts.delta[1 - 1];
            else if (delta > HydroResistanceConsts.delta[6 - 1]) delta = HydroResistanceConsts.delta[6 - 1];
            else
            {
                //if (Math.Abs(delta - LambdaNikuradzeDiagram.delta[loc.LessN - 1]) <= Math.Abs(delta - LambdaNikuradzeDiagram.delta[loc.LessN + 1 - 1]))
                if (Math.Abs(delta - HydroResistanceConsts.delta[loc.LessN - 1]) <= Math.Abs(delta - HydroResistanceConsts.delta[loc.LessN + 1 - 1]))
                {
                    N = loc.LessN;
                }
                else N = loc.LessN + 1;
            }
            return N;
        }
        //
        public static double CalcLambda(double Re, double delta, int Nearest1InterpBetweenTwoNearest2 = 1)
        {
            double lambda = 0, lg_Re = Math.Log10(Re);
            double[] lmbd = new double[6];
            int NearestDeltaN;//, N1, N2;
            //PositionInSuccession loc = null;
            NearestDeltaN = fNearestDeltaStN(delta);
            for (int N = 1; N <= 6; N++)
            {
                switch (N)
                {
                    case 1:
                        //lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_1, y_lg_1000_lambda_1, LambdaNikuradzeDiagram.Length[N - 1]);
                        lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_1, y_lg_1000_lambda_1, HydroResistanceConsts.Length[N - 1]);
                        break;
                    case 2:
                        //lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_2, y_lg_1000_lambda_2, LambdaNikuradzeDiagram.Length[N - 1]);
                        lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_2, y_lg_1000_lambda_2, HydroResistanceConsts.Length[N - 1]);
                        break;
                    case 3:
                        //lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_3, y_lg_1000_lambda_3, LambdaNikuradzeDiagram.Length[N - 1]);
                        lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_3, y_lg_1000_lambda_3, HydroResistanceConsts.Length[N - 1]);
                        break;
                    case 4:
                        //lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_4, y_lg_1000_lambda_4, LambdaNikuradzeDiagram.Length[N - 1]);
                        lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_4, y_lg_1000_lambda_4, HydroResistanceConsts.Length[N - 1]);
                        break;
                    case 5:
                        //lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_5, y_lg_1000_lambda_5, LambdaNikuradzeDiagram.Length[N - 1]);
                        lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_5, y_lg_1000_lambda_5, HydroResistanceConsts.Length[N - 1]);
                        break;
                    case 6:
                        //lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_6, y_lg_1000_lambda_6, LambdaNikuradzeDiagram.Length[N - 1]);
                        lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_6, y_lg_1000_lambda_6, HydroResistanceConsts.Length[N - 1]);
                        break;
                }//sw
            }//for
            if (Nearest1InterpBetweenTwoNearest2 == 1) lambda = lmbd[NearestDeltaN - 1];
            //else lambda = MyMathLib.LInterp(delta, LambdaNikuradzeDiagram.delta, lmbd, 6);
            else lambda = MyMathLib.LInterp(delta, HydroResistanceConsts.delta, lmbd, 6);
            return lambda;
        }//fn

        //
        //
        public static string fSubTypeName(int TypeN, int En=0)
        {
            string SubTypeName = "";
            switch (TypeN)
            {
                case ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Simple_InletFromSpaceToPipeline_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Simple_InletFromSpaceToPipeline;
                    }
                    break;
                case ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Simple_OutletFromPilelineToSpace_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Simple_OutletFromPilelineToSpace;
                    }
                    break;
                case ResistanceTypeN_Loc_Simple_TJoint:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Simple_TJoint_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Simple_TJoint;
                    }
                    break;
                case ResistanceTypeN_Loc_Simple_DuriteSchlange:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Simple_DuriteSchlange_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Simple_DuriteSchlange;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_SuddBroad:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_SuddBroad_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_SuddBroad;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_SuddNarr:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_SuddNarr_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_SuddNarr;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_SuddTurn90:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_SuddTurn90_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_SuddTurn90;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_SuddTurn:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_SuddTurn_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_SuddTurn;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_GradBroad:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_GradBroad_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_GradBroad;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_GradNarr:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_GradNarr_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_GradNarr;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_Schieber:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_Schieber_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_Schieber;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_DrosselTurningThrottle:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_DrosselTurningThrottle_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_DrosselTurningThrottle;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_Valve:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_Valve_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_Valve;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_DiaphragmAcute:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_Valve_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_Valve;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_FlowMeter:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_FlowMeter_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_FlowMeter;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_SelfLockngConnection:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_SelfLockngConnection_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_SelfLockngConnection;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_StopCock:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_StopCock_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_StopCock;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_CheckValve:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_CheckValve_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_CheckValve;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_TransferValve:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_TransferValve_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_TransferValve;
                    }
                    break;
                case ResistanceTypeN_Loc_Geom_StrainerFilter:
                    if (En == 1)
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_StrainerFilter_En;
                    }
                    else
                    {
                        SubTypeName = ResistanceTypeName_Loc_Geom_StrainerFilter;
                    }
                    break;
            }
            return SubTypeName;
        }
        public static int fReverseTypeN(int TypeN)
        {
            int ReversedTypeN = 0;
            switch (TypeN)
            {
                case ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline:
                    ReversedTypeN = ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace;
                    break;
                case ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace:
                    ReversedTypeN = ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline;
                    break;
                case ResistanceTypeN_Loc_Simple_TJoint:
                    ReversedTypeN = ResistanceTypeN_Loc_Simple_TJoint;
                    break;
                case ResistanceTypeN_Loc_Simple_DuriteSchlange:
                    ReversedTypeN = ResistanceTypeN_Loc_Simple_DuriteSchlange;
                    break;
                case ResistanceTypeN_Loc_Geom_SuddBroad:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_SuddNarr;
                    break;
                case ResistanceTypeN_Loc_Geom_SuddNarr:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_SuddBroad;
                    break;
                case ResistanceTypeN_Loc_Geom_SuddTurn90:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_SuddTurn90;
                    break;
                case ResistanceTypeN_Loc_Geom_SuddTurn:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_SuddTurn90;
                    break;
                case ResistanceTypeN_Loc_Geom_GradBroad:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_GradNarr;
                    break;
                case ResistanceTypeN_Loc_Geom_GradNarr:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_GradBroad;
                    break;
                case ResistanceTypeN_Loc_Geom_Schieber:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_Schieber;
                    break;
                case ResistanceTypeN_Loc_Geom_DrosselTurningThrottle:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_DrosselTurningThrottle;
                    break;
                case ResistanceTypeN_Loc_Geom_Valve:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_Valve;
                    break;
                case ResistanceTypeN_Loc_Geom_DiaphragmAcute:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_DiaphragmAcute;
                    break;
                case ResistanceTypeN_Loc_Geom_FlowMeter:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_FlowMeter;
                    break;
                case ResistanceTypeN_Loc_Geom_SelfLockngConnection:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_SelfLockngConnection;
                    break;
                case ResistanceTypeN_Loc_Geom_StopCock:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_StopCock;
                    break;
                case ResistanceTypeN_Loc_Geom_CheckValve:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_CheckValve;
                    break;
                case ResistanceTypeN_Loc_Geom_TransferValve:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_TransferValve;
                    break;
                case ResistanceTypeN_Loc_Geom_StrainerFilter:
                    ReversedTypeN = ResistanceTypeN_Loc_Geom_StrainerFilter;
                    break;
            }
            return ReversedTypeN;
        }
        public static int fSubTypeN(int TypeN)//ne done
        {
            int SubTypeN = 0;
            switch (TypeN)
            {
                case ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline:

                    break;
                case ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace:

                    break;
                case ResistanceTypeN_Loc_Simple_TJoint:

                    break;
                case ResistanceTypeN_Loc_Simple_DuriteSchlange:

                    break;
                case ResistanceTypeN_Loc_Geom_SuddBroad:

                    break;
                case ResistanceTypeN_Loc_Geom_SuddNarr:

                    break;
                case ResistanceTypeN_Loc_Geom_SuddTurn90:

                    break;
                case ResistanceTypeN_Loc_Geom_SuddTurn:

                    break;
                case ResistanceTypeN_Loc_Geom_GradBroad:

                    break;
                case ResistanceTypeN_Loc_Geom_GradNarr:

                    break;
                case ResistanceTypeN_Loc_Geom_Schieber:

                    break;
                case ResistanceTypeN_Loc_Geom_DrosselTurningThrottle:

                    break;
                case ResistanceTypeN_Loc_Geom_Valve:

                    break;
                case ResistanceTypeN_Loc_Geom_DiaphragmAcute:

                    break;
                case ResistanceTypeN_Loc_Geom_FlowMeter:

                    break;
                case ResistanceTypeN_Loc_Geom_SelfLockngConnection:

                    break;
                case ResistanceTypeN_Loc_Geom_StopCock:

                    break;
                case ResistanceTypeN_Loc_Geom_CheckValve:

                    break;
                case ResistanceTypeN_Loc_Geom_TransferValve:

                    break;
                case ResistanceTypeN_Loc_Geom_StrainerFilter:

                    break;
            }
            return SubTypeN;
        }
        public static double fDzetaWay(double lambda, double L, double d)
        {
            double DzetaWay = 0;
            DzetaWay = lambda * L / d;
            return DzetaWay;
        }
        public static double fDzetaLocSimplePrg(int TypeN, HydroResistanceIniData geom){
            double dzeta = 0;
            switch(TypeN){
                case ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline:

                break;
                case ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace:

                break;
                case ResistanceTypeN_Loc_Simple_TJoint:

                break;
                case ResistanceTypeN_Loc_Simple_DuriteSchlange:

                break;
                case ResistanceTypeN_Loc_Geom_SuddBroad:

                break;
                case ResistanceTypeN_Loc_Geom_SuddNarr:

                break;
                case ResistanceTypeN_Loc_Geom_SuddTurn90:

                break;
                case ResistanceTypeN_Loc_Geom_SuddTurn:

                break;
                case ResistanceTypeN_Loc_Geom_GradBroad:

                break;
                case ResistanceTypeN_Loc_Geom_GradNarr:

                break;
                case ResistanceTypeN_Loc_Geom_Schieber:

                break;
                case ResistanceTypeN_Loc_Geom_DrosselTurningThrottle:

                break;
                case ResistanceTypeN_Loc_Geom_Valve:

                break;
                case ResistanceTypeN_Loc_Geom_DiaphragmAcute:

                break;
                case ResistanceTypeN_Loc_Geom_FlowMeter:

                break;
                case ResistanceTypeN_Loc_Geom_SelfLockngConnection:

                break;
                case ResistanceTypeN_Loc_Geom_StopCock:

                break;
                case ResistanceTypeN_Loc_Geom_CheckValve:

                break;
                case ResistanceTypeN_Loc_Geom_TransferValve:

                break;
                case ResistanceTypeN_Loc_Geom_StrainerFilter:

                break;
            }
            return dzeta;
        }
        public static double fDzetaLocSimple(int TypeN)
        {
            double dzeta = 0;
            switch (TypeN)
            {
                case ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline:
                    dzeta = ResistanceCoefVal_InletFromSpaceToPipeline;
                    break;
                case ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace:
                    dzeta = ResistanceCoefVal_OutletFromPilelineToSpace;
                    break;
                case ResistanceTypeN_Loc_Simple_TJoint:
                    dzeta = ResistanceCoefVal_Simple_TJoint;
                    break;
                case ResistanceTypeN_Loc_Simple_DuriteSchlange:
                    dzeta = ResistanceCoefVal_DuriteSchlange;
                    break;

            }
            return dzeta;
        }
        public static double fHLoss(double dzeta, double v)
        {
            double dH = 0;
            dH = dzeta * v * v / 2 / g_fall_acc;
            return dH;
        }
        public static double fPLoss(double dzeta, double v, double ro)
        {
            double dH = 0;
            dH = fHLoss(dzeta, v) * g_fall_acc * ro;
            return dH;
        }
        public static string HydroResistanceNameByN(int TypeN)
        {
            string name = "unknown";
            switch (TypeN)
            {
                case ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline:
                    name = ResistanceTypeName_Loc_Simple_InletFromSpaceToPipeline;
                    break;
                case ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace:
                    name = ResistanceTypeName_Loc_Simple_OutletFromPilelineToSpace;
                    break;
                case ResistanceTypeN_Loc_Simple_TJoint:
                    name = ResistanceTypeName_Loc_Simple_TJoint;
                    break;
                case ResistanceTypeN_Loc_Simple_DuriteSchlange:
                    name = ResistanceTypeName_Loc_Simple_DuriteSchlange;
                    break;

            }
            return name;
        }
        public static int HydroResistanceNByName(string name)
        {
            int TypeN = 0;
            if (name.Equals(ResistanceTypeName_Loc_Simple_InletFromSpaceToPipeline))
            {
                TypeN = ResistanceTypeN_Loc_Simple_InletFromSpaceToPipeline;
            }
            else if (name.Equals(ResistanceTypeName_Loc_Simple_OutletFromPilelineToSpace))
            {
                TypeN = ResistanceTypeN_Loc_Simple_OutletFromPilelineToSpace;
            }
            else if (name.Equals(ResistanceTypeName_Loc_Simple_TJoint))
            {
                TypeN = ResistanceTypeN_Loc_Simple_TJoint;
            }
            else if (name.Equals(ResistanceTypeName_Loc_Simple_DuriteSchlange))
            {
                TypeN = ResistanceTypeN_Loc_Simple_DuriteSchlange;
            }

            return TypeN;
        }
        //
        public static double part_by_k(double[] k, int N, int L = 0)
        {
            L = k.Length;
            double denominator_summand = 1, numerator = 1, denominator = 0, part = 1;
            for (int i = 1; i <= L; i++)
            {
                denominator_summand = 1;
                for (int j = 1; j <= N - 1; j++)
                {
                    denominator_summand *= k[j - 1];
                }
                for (int j = N + 1; j <= L; j++)
                {
                    denominator_summand *= k[j - 1];
                }
                denominator += denominator_summand;
                numerator *= k[i - 1];
            }
            part = numerator / denominator;
            return part;
        }
        public static double Calc_dzeta_Loc_own_by_type(HydroResistanceIniData data)
        {
            double dzeta=0;

            return dzeta;
        }
    }//cl
    public class HydroSchemCanvas
    {
        public DataGridView dg;
        public HydroSchemCanvas()
        {
            dg = null;
        }
        public HydroSchemCanvas(DataGridView dg)
        {
            this.dg = dg;
        }

        public void Draw_FrameElementLeft(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.FrameElementLeft;
            }
        }
        public void Draw_FrameElementRight(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.FrameElementRight;
            }
        }
        public void Draw_FrameElementVertical(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.FrameElementVertical;
            }
        }
        public void Draw_FrameElementHorisontal(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.FrameElementHorisontal;
            }
        }
        public void Draw_FrameName(int x, int y, int N)
        {
            string sn = N.ToString();
            int L = sn.Length;
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = "..[   R" + N.ToString() + "  ]..";
                switch (L)
                {
                    case 1:
                        this.dg.Rows[y - 1].Cells[x - 1].Value = "..[  R" + sn + " ]..";
                        break;
                    case 2:
                        this.dg.Rows[y - 1].Cells[x - 1].Value = "..[ R" + sn + " ]..";
                        break;
                    case 3:
                        this.dg.Rows[y - 1].Cells[x - 1].Value = "..[ R" + sn + "]..";
                        break;
                    case 4:
                        this.dg.Rows[y - 1].Cells[x - 1].Value = "..[R" + sn + "]..";
                        break;
                    default:
                        this.dg.Rows[y - 1].Cells[x - 1].Value = "..[R" + sn + "]..";
                        break;
                }
            }
        }
        public void Draw_ConnectorCentral(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.ConnectorCentral;
            }
        }
        public void Draw_ConnectorLeft(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.ConnectorLeft;
            }
        }
        public void Draw_ConnectorRight(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.ConnectorRight;
            }
        }
        public void Draw_LineVertical(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.LineVertical;
            }
        }
        public void Draw_LineHorisontal(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.LineHorisontal;
            }
        }
        public void Draw_LineFrameIntersection(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.LineFrameIntersection;
            }
        }
        public void Draw_ResistanceElementar(int x, int y, int N)
        {
            string sn = N.ToString();
            int L = sn.Length;
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = "--[   R" + N.ToString() + "  ]--";
                switch (L)
                {
                    case 1:
                        this.dg.Rows[y - 1].Cells[x - 1].Value = "--[  R" + sn+ " ]--";
                    break;
                    case 2:
                        this.dg.Rows[y - 1].Cells[x - 1].Value = "--[ R" + sn + " ]--";
                    break;
                    case 3:
                        this.dg.Rows[y - 1].Cells[x - 1].Value = "--[ R" + sn + "]--";
                    break;
                    case 4:
                        this.dg.Rows[y - 1].Cells[x - 1].Value = "--[R" + sn + "]--";
                    break;
                    default:
                        this.dg.Rows[y - 1].Cells[x - 1].Value = "--[R" + sn + "]--";
                    break;
                }
            }
        }
        public void Draw_ResistanceLeftSide(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.ResistanceLeftSide;
            }
        }
        public void Draw_ResistanceRightSide(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = HydroResistanceConsts.ResistanceRightSide;
            }
        }
        //
        public void DrawEmptyCell(int x, int y)
        {
            if (dg != null)
            {
                this.dg.Rows[y - 1].Cells[x - 1].Value = "";
            }
        }
        public void SetSize(int x, int y)
        {
            if (dg != null)
            {
                this.dg.RowCount = y;
                this.dg.ColumnCount = x;
            }
            this.SetParams();
            //
            //for(x=1; x<=this.dg.ColumnCount; x++){
            //    for(y=1; y<=this.dg.RowCount; y++){
            //        DrawEmptyCell(x, y);
            //    }
            //}
        }
        public void SetParams()
        {
            if (dg != null)
            {
                //for (int i = 1; i <= dg.RowCount; i++)
                //{
                    for (int j = 1; j <= dg.ColumnCount; j++)
                    {
                        this.dg.Columns[j - 1].Width = 86;

                    }
                //}//
                    for (int i = 1; i <= dg.RowCount; i++)
                    {
                        this.dg.Rows[i - 1].Height = 20;
                    }
            }
        }
        public void Clear()
        {
            for (int i = 1; i <= this.dg.ColumnCount; i++)
            {
                for (int j = 1; j <= this.dg.RowCount; j++)
                {
                    DrawEmptyCell(i, j);
                }
            }
        }
        public void SetResistance(int x, int y, int yUpper, int L, int H, int N, int QSubElts = 0)
        {
            int yLower = H - Math.Abs(yUpper);
            if (QSubElts == 0)
            {
                this.Draw_ResistanceElementar(x, y, N);
            }
            else
            {
                this.Draw_LineFrameIntersection(x, y);
                this.Draw_FrameName(x + 1, y - Math.Abs(yUpper) + 1, N);
                this.Draw_FrameElementLeft(x, y - Math.Abs(yUpper) + 1);
                for (int i = 1; i <= Math.Abs(yUpper - 1); i++)
                {
                    this.Draw_FrameElementVertical(x, y - 1 + i);
                    this.Draw_FrameElementVertical(x + L - 1, y - 1 + i);
                }
                this.Draw_FrameElementRight(x + L - 1, y - Math.Abs(yUpper) + 1);
                this.Draw_FrameElementLeft(x, y + yLower - 1);
                for (int i = 1; i <= Math.Abs(yLower - 1); i++)
                {
                    this.Draw_FrameElementVertical(x, y - 1 + i);
                    this.Draw_FrameElementVertical(x + L - 1, y - 1 + i);
                }
                this.Draw_FrameElementRight(x + L - 1, y + yLower - 1);
                this.Draw_LineFrameIntersection(x + L - 1, y);
            }
        }//fn
    }//cl
    /*
    public class ResistanceGeom
    {
        public int N;
        public int L,//length, quantity of columns
                   H,//height, quantity of lines
                   xBase,//coordinate x(ColN) of intersection cell of left wakll and ciontact line//not Left upper corner or single cell
                   yBase,//coordinate y(LineN) of Left upper corner or single cell
            //LeftConDist,//distance between left wall and left connector//alw 1
                   RightContDist;//distance between right wall and right connector;
        public int QSubElts;
        public int[] SE_L, SE_H;
        public bool[] SE_NotEmpty;
        bool SE_SucNotPar;
        //
        public ResistanceGeom(int N = 0)
        {
            this.N = N;
            this.L = 0;
            this.H = 0;
            this.xBase = 0;
            this.yBase = 0;
            //this.LeftConDist = 0;
            this.RightContDist = 0;
            //
            this.QSubElts = 0;
            this.SE_L = null;
            this.SE_H = null;
            this.SE_NotEmpty = null;
            this.SE_SucNotPar = true;
        }
        public int countSESimple()
        {
            int y = 0;

            return y;
        }
        public int countSEComplex()
        {
            int y = 0;

            return y;
        }
        public int GetSEmaxL()
        {
            int y = 0;
            for (int i = 1; i <= this.QSubElts; i++)
            {
                if (i == 1 || (i > 1 && y < SE_L[i - 1])) y = SE_L[i - 1];
            }
            return y;
        }
        public int GetSEmaxH()
        {
            int y = 0;
            for (int i = 1; i <= this.QSubElts; i++)
            {
                if (i == 1 || (i > 1 && y < SE_H[i - 1])) y = SE_H[i - 1];
            }
            return y;
        }
        public int fL()
        {
            int L = 0;
            L = 1;//or left wall
            if (this.QSubElts > 0)
            {
                if (this.SE_SucNotPar)
                {
                    for (int i = 1; i <= this.QSubElts - 1; i++)
                    {
                        L = L + this.SE_L[i - 1];
                        L = L + 1;
                    }
                    L = L + this.SE_L[this.QSubElts - 1];
                    L = L + 1;//wall right
                }
                else
                {
                    L = L + 1;// par cont left
                    L = L + this.GetSEmaxL();
                    L = L + 1;//par cont right
                }
            }
            this.L = L;
            return this.L;
        }

        //public int fXLeftCon() { return xBase - LeftConDist;  }//alw -1
        //public int fYLeftCon() { return yBase; }//sflu, exnot
        public int fRightCon() { return xBase + L - 1 + RightContDist; }
        public int fYRightCon() { return yBase; }
    }//cl
    */
    public class TWorkLiquidOrGas : ICloneable
    {
        public double ro, nu;
        public TWorkLiquidOrGas() { }
        public TWorkLiquidOrGas(double ro, double nu) { }
        public void SetWater() { }
        public void SetOil() { }
        public void SetAir() { }
        public object Clone() { return this.MemberwiseClone(); }
    }
    public class TResistanceSectionParams : ICloneable
    {
        public double Qv, kr;
        public TResistanceSectionParams(double kr = 0, double Qv = 0) { this.kr = kr; this.Qv = Qv; }
        public object Clone() { return this.MemberwiseClone(); }
    }
    public class HydroResistanceIniData : ICloneable
    {
        public double D, D1, alfa, R, L, S;
        public string PartName, TypeName;
        public int TypeN, GroupN, RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4;
        public double kG, Gv;
        public double dzeta;
        public bool SectIsNotRound;
        public bool SectIsConst;
        public int GvIsKnown_No0Yes1;
        //
        public HydroResistanceIniData()
        {
            SetNull();
        }
        public HydroResistanceIniData(double k)
        {
            SetNull();
            this.kG = k;
        }
        public void SetNull()
        {
            D = 0;
            D1 = 0;
            alfa = 0;
            R = 0;
            L = 0;
            S = 0;
            //
            PartName = null; TypeName = null;
            TypeN = 0; GroupN = 0;
            //
            kG = 0; Gv = 0;
            //
            SectIsNotRound = false;
            SectIsConst = false;
            RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4 = 1;//0;
            dzeta = 0;
            GvIsKnown_No0Yes1 = 0;
        }
        public void CalcSByD()
        {
            S = Math.PI * D * D / 4;
        }
        public void CalcDByS()
        {
            D = Math.Sqrt(4 * S / Math.PI);
        }
        public void Reverse()
        {
            int ReversedTypeN = this.TypeN;//to change!
            bool NeedToReverseD = false;
            HydroResistanceConsts.fReversedNOfN(this.TypeN, ref ReversedTypeN, ref NeedToReverseD);
            if (NeedToReverseD) MyLib.Swap(ref this.D, ref this.D1);
        }
        public object Clone() { return this.MemberwiseClone(); }
        public DataCellRow GetAsDataCellRow()
        {
            int CountItems=0;
            DataCell [] cells=null;
            DataCell cell;
            cell=new DataCell(this.TypeN);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.GroupN);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.TypeName);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.PartName);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.D);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.SectIsConst);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.D1);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell= new DataCell(this.alfa);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.R);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.L);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.SectIsNotRound);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell= new DataCell(this.S);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.GvIsKnown_No0Yes1);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.GvIsKnown_No0Yes1);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.Gv);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.dzeta);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            cell=new DataCell(this.kG);
            MyLib.AddToVector(ref cells, ref CountItems, cell);
            //DataCellRow row=new DataCellRow
            //(
            //    new DataCell[]
            //    {
            //        new DataCell(this.TypeN),
            //        new DataCell(this.GroupN),
            //        new DataCell(this.TypeName),
            //        new DataCell(this.PartName),
            //        new DataCell(this.D),
            //        new DataCell(this.SectIsConst),
            //        new DataCell(this.D1),
            //        new DataCell(this.alfa),
            //        new DataCell(this.R),
            //        new DataCell(this.L),
            //        new DataCell(this.SectIsNotRound),
            //        new DataCell(this.S),
            //        new DataCell(this.RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4),
            //        new DataCell(this.
            //    }
            //);
            DataCellRow row = new DataCellRow(cells, CountItems);
            return row;
        }
        public void GetItemNames(ref string[]names, int FromN=1) {
            if (names==null || names.Length-FromN+1 < 17)
            {
                names = new string[17 + FromN-1];
            }
            names[FromN + 0 - 1] = "RTypeN:";
            names[FromN + 1 - 1] = "RGroupN:";
            names[FromN + 2 - 1] = "RTypeName:";
            names[FromN + 3 - 1] = "PartName:";
            names[FromN + 4 - 1] = "D[mm]=";
            names[FromN + 5 - 1] = "SectIsConst:";
            names[FromN + 6 - 1] = "D1[mm]=";
            names[FromN + 7 - 1] = "alfa[deg]=";
            names[FromN + 8 - 1] = "R[mm]=";
            names[FromN + 9 - 1] = "L[mm]=";
            names[FromN + 10 - 1] = "SectIsRound:";
            names[FromN + 11 - 1] = "S[mm^2]=";
            names[FromN + 12 - 1] = "RCalcTypeN(1-dzeta,2-f(geom),3-f(Gv)):";
            names[FromN + 13 - 1] = "GvIsKnown(no-0,yes-1):";
            names[FromN + 14 - 1] = "Gv:";
            names[FromN + 15 - 1] = "dzeta:";
            names[FromN + 16 - 1] = "kG:";
            
        }
        public void SetFromDataCellRow(DataCellRow row, int ExcludeQLines=0)
        {
            this.TypeN = row.GetIntVal(ExcludeQLines + 1);
            this.GroupN = row.GetIntVal(ExcludeQLines + 2);
            this.TypeName = row.ToString(ExcludeQLines + 3);
            this.PartName = row.ToString(ExcludeQLines + 4);
            this.D = row.GetDoubleVal(ExcludeQLines + 5);
            this.SectIsConst = row.GetBoolVal(ExcludeQLines + 6);
            this.D1 = row.GetDoubleVal(ExcludeQLines + 7);
            this.alfa = row.GetDoubleVal(ExcludeQLines + 8);
            this.R = row.GetDoubleVal(ExcludeQLines + 9);
            this.L = row.GetDoubleVal(ExcludeQLines + 10);
            this.SectIsNotRound = row.GetBoolVal(ExcludeQLines + 11);
            this.S = row.GetDoubleVal(ExcludeQLines + 12);
            this.RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4 = row.GetIntVal(ExcludeQLines + 13);
            this.GvIsKnown_No0Yes1 = row.GetIntVal(ExcludeQLines + 14);
            this.Gv = row.GetDoubleVal(ExcludeQLines + 15);
            //this.kG = row.GetDoubleVal(ExcludeQLines + 15, 1);
            //this.dzeta = row.GetDoubleVal(ExcludeQLines + 16, 1);
            this.dzeta = row.GetDoubleVal(ExcludeQLines + 16);
            this.kG = row.GetDoubleVal(ExcludeQLines + 17);
        }
        public TTable GetAsTable()
        {
            int QItems=17;
            TTable tbl = null;
            DataCell[]cells=new DataCell[]{new DataCell(this.TypeN)};
            //string[] caps = { "TypeN", "GroupN", "TypeName", "Name", "D", "D1", "alfa", "R", "L", "S", "RCalcType", "k", "G" };
            DataCellRowCoHeader[] rows = new DataCellRowCoHeader[QItems];//=null;
            DataCellRowCoHeader row;
            DataCell cellComboBox=new DataCell(new string[]{"dzeta=const","dzeta=f(Geom)", "dzeta=g(Geom, Gv)"},3);
            //int count = 0;
            rows[1 - 1] = new DataCellRowCoHeader(new DataCell("TypeN"), new DataCellRow(new DataCell[] { new DataCell(this.TypeN) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("TypeN"), new DataCellRow(new DataCell[] { new DataCell(this.TypeN) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            rows[2 - 1] = new DataCellRowCoHeader(new DataCell("GroupN"), new DataCellRow(new DataCell[] { new DataCell(this.GroupN) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("GroupN"), new DataCellRow(new DataCell[] { new DataCell(this.GroupN) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            rows[3 - 1] = new DataCellRowCoHeader(new DataCell("TypeName"), new DataCellRow(new DataCell[] { new DataCell(this.TypeName) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("TypeName"), new DataCellRow(new DataCell[] { new DataCell(this.TypeName) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            rows[4 - 1] = new DataCellRowCoHeader(new DataCell("PartName"), new DataCellRow(new DataCell[] { new DataCell(this.PartName) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("PartName"), new DataCellRow(new DataCell[] { new DataCell(this.PartName) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            rows[5 - 1] = new DataCellRowCoHeader(new DataCell("D"), new DataCellRow(new DataCell[] { new DataCell(this.D) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("D"), new DataCellRow(new DataCell[] { new DataCell(this.D) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            rows[6 - 1] = new DataCellRowCoHeader(new DataCell("SectIsConst"), new DataCellRow(new DataCell[] { new DataCell(this.SectIsConst) }, 1));
            //rows[6 - 1] = new DataCellRowCoHeader(new DataCell("D1"), new DataCellRow(new DataCell[] { new DataCell(this.D1) }, 1));
            rows[7 - 1] = new DataCellRowCoHeader(new DataCell("D1"), new DataCellRow(new DataCell[] { new DataCell(this.D1) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("D1"), new DataCellRow(new DataCell[] { new DataCell(this.D1) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            //rows[7 - 1] = new DataCellRowCoHeader(new DataCell("alfa"), new DataCellRow(new DataCell[] { new DataCell(this.alfa) }, 1));
            rows[8- 1] = new DataCellRowCoHeader(new DataCell("alfa"), new DataCellRow(new DataCell[] { new DataCell(this.alfa) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("alfa"), new DataCellRow(new DataCell[] { new DataCell(this.alfa) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            //rows[8 - 1] = new DataCellRowCoHeader(new DataCell("R"), new DataCellRow(new DataCell[] { new DataCell(this.R) }, 1));
            rows[9 - 1] = new DataCellRowCoHeader(new DataCell("R"), new DataCellRow(new DataCell[] { new DataCell(this.R) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("R"), new DataCellRow(new DataCell[] { new DataCell(this.R) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            //rows[9 - 1] = new DataCellRowCoHeader(new DataCell("L"), new DataCellRow(new DataCell[] { new DataCell(this.L) }, 1));
            rows[10 - 1] = new DataCellRowCoHeader(new DataCell("L"), new DataCellRow(new DataCell[] { new DataCell(this.L) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("L"), new DataCellRow(new DataCell[] { new DataCell(this.L) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            //rows[10-1] = new DataCellRowCoHeader(new DataCell("S"), new DataCellRow(new DataCell[] { new DataCell(this.S) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("S"), new DataCellRow(new DataCell[] { new DataCell(this.S) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            //rows[11 - 1] = new DataCellRowCoHeader(new DataCell("SectIsNotRound"), new DataCellRow(new DataCell[] { new DataCell(this.SectIsNotRound) }, 1));
            rows[11 - 1] = new DataCellRowCoHeader(new DataCell("SectIsNotRound"), new DataCellRow(new DataCell[] { new DataCell(this.SectIsNotRound) }, 1));
            rows[12 - 1] = new DataCellRowCoHeader(new DataCell("S"), new DataCellRow(new DataCell[] { new DataCell(this.S) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("S"), new DataCellRow(new DataCell[] { new DataCell(this.S) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            //if (RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4 == 0)
            //{
            //    RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4 = 1;
            //}
            cellComboBox.SetActiveN(this.RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4);
            //rows[12 - 1] = new DataCellRowCoHeader(new DataCell("RCalcType"), new DataCellRow(new DataCell[] { cellComboBox }, 1));
            rows[13 - 1] = new DataCellRowCoHeader(new DataCell("RCalcType"), new DataCellRow(new DataCell[] { cellComboBox }, 1));
            //row = new DataCellRowCoHeader(new DataCell("RCalcType"), new DataCellRow(new DataCell[] { new DataCell(this.RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            //rows[12 - 1].SetActiveN = NotFiniteNumberException defined
            //rows[13 - 1] = new DataCellRowCoHeader(new DataCell("G"), new DataCellRow(new DataCell[] { new DataCell(this.Gv) }, 1));
            rows[14 - 1] = new DataCellRowCoHeader(new DataCell("GvIsKnown(no-0,yes-1):"), new DataCellRow(new DataCell[] { new DataCell(this.GvIsKnown_No0Yes1) }, 1));
            rows[15 - 1] = new DataCellRowCoHeader(new DataCell("G"), new DataCellRow(new DataCell[] { new DataCell(this.Gv) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("G"), new DataCellRow(new DataCell[] { new DataCell(this.Gv) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            //rows[14- 1] = new DataCellRowCoHeader(new DataCell("kG"), new DataCellRow(new DataCell[] { new DataCell(this.kG) }, 1));
            //rows[15 - 1] = new DataCellRowCoHeader(new DataCell("kG"), new DataCellRow(new DataCell[] { new DataCell(this.kG) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("k"), new DataCellRow(new DataCell[] { new DataCell(this.kG) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            //rows[15 - 1] = new DataCellRowCoHeader(new DataCell("dzeta"), new DataCellRow(new DataCell[] { new DataCell(this.dzeta) }, 1));
            //rows[16 - 1] = new DataCellRowCoHeader(new DataCell("dzeta"), new DataCellRow(new DataCell[] { new DataCell(this.dzeta) }, 1));
            //row = new DataCellRowCoHeader(new DataCell("k"), new DataCellRow(new DataCell[] { new DataCell(this.dzeta) }, 1));
            //MyLib.AddToVector(ref rows, ref count, row);
            rows[16 - 1] = new DataCellRowCoHeader(new DataCell("dzeta"), new DataCellRow(new DataCell[] { new DataCell(this.dzeta) }, 1));
            rows[17 - 1] = new DataCellRowCoHeader(new DataCell("kG"), new DataCellRow(new DataCell[] { new DataCell(this.kG) }, 1));
            tbl = new TTable
                (
                   new TableInfo(true, true, true, QItems, 1),
                    false,
                    rows,
                    new DataCellRow(new DataCell[] { new DataCell("Values") }, 1),
                    new TableHeaders(new DataCell("Hydro resistance Params"), new DataCell("Params"), null),
                    true
                );
            return tbl;
        }
        public void SetFromTable(TTable tbl, int ExcludeQLines=0)
        {
            this.TypeN = tbl.GetIntVal(ExcludeQLines+1, 1);
            this.GroupN = tbl.GetIntVal(ExcludeQLines + 2, 1);
            this.TypeName = tbl.ToString(ExcludeQLines + 3, 1);
            this.PartName = tbl.ToString(ExcludeQLines + 4, 1);
            this.D = tbl.GetDoubleVal(ExcludeQLines + 5, 1);
            //
            //this.D1 = tbl.GetDoubleVal(ExcludeQLines + 6, 1);
            //this.alfa = tbl.GetDoubleVal(ExcludeQLines + 7, 1);
            //this.R = tbl.GetDoubleVal(ExcludeQLines + 8, 1);
            //this.L = tbl.GetDoubleVal(ExcludeQLines + 9, 1);
            //this.SectIsNotRound = tbl.GetBoolVal(ExcludeQLines + 10, 1);
            //this.S = tbl.GetDoubleVal(ExcludeQLines + 11, 1);
            //this.RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4 = tbl.GetIntVal(ExcludeQLines + 12, 1);
            //this.Gv = tbl.GetDoubleVal(ExcludeQLines + 13, 1);
            //this.kG = tbl.GetDoubleVal(ExcludeQLines + 14, 1);
            //this.dzeta = tbl.GetDoubleVal(ExcludeQLines + 15, 1);
            //
            this.SectIsConst = tbl.GetBoolVal(ExcludeQLines + 6, 1);
            this.D1 = tbl.GetDoubleVal(ExcludeQLines + 7, 1);
            this.alfa = tbl.GetDoubleVal(ExcludeQLines + 8, 1);
            this.R = tbl.GetDoubleVal(ExcludeQLines + 9, 1);
            this.L = tbl.GetDoubleVal(ExcludeQLines + 10, 1);
            this.SectIsNotRound = tbl.GetBoolVal(ExcludeQLines + 11, 1);
            this.S = tbl.GetDoubleVal(ExcludeQLines + 12, 1);
            this.RCalcTypeN_dzetaKnown1_kKnown2_dzetaCalcGeomOnlyNoG3_dzetaDependsOnG4 = tbl.GetIntVal(ExcludeQLines + 13, 1);
            this.GvIsKnown_No0Yes1 = tbl.GetIntVal(ExcludeQLines + 14, 1);
            this.Gv = tbl.GetDoubleVal(ExcludeQLines + 15, 1);
            //this.kG = tbl.GetDoubleVal(ExcludeQLines + 15, 1);
            //this.dzeta = tbl.GetDoubleVal(ExcludeQLines + 16, 1);
            this.dzeta = tbl.GetDoubleVal(ExcludeQLines + 16, 1);
            this.kG = tbl.GetDoubleVal(ExcludeQLines + 17, 1);
        }
        public void ToStringArray(ref string[] arr, bool WriteSupplInf=true, bool WriteSubElements=false, int FromN=1)
        {
            string[] names = new string[16];
            names[FromN+0 - 1] = "RTypeN:";
            names[FromN + 1 - 1] = "RGroupN:";
            names[FromN + 2 - 1] = "RTypeName:";
            names[FromN + 3 - 1] = "PartName:";
            names[FromN + 4 - 1] = "D[mm]=";
            names[FromN + 5 - 1] = "SectIsConst:";
            names[FromN + 6 - 1] = "D1[mm]=";
            names[FromN + 7 - 1] = "alfa[deg]=";
            names[FromN + 8 - 1] = "R[mm]=";
            names[FromN + 9 - 1] = "L[mm]=";
            names[FromN + 10 - 1] = "SectIsRound:";
            names[FromN + 11 - 1] = "S[mm^2]=";
            names[FromN + 12 - 1] = "RCalcTypeN(1-dzeta,2-f(geom),3-f(Gv)):";
            names[FromN + 13 - 1] = "RCalcTypeN(1-dzeta,2-f(geom),3-f(Gv)):";
        }
    }//cl
    public class HydroResistanceCalcdData : ICloneable
    {
        public double lambda, Re, V, dzeta, Gv, kG, KEqv, dzetaEqv, dzetaLoc, dzetaWay, dzetaSum, dzetaSumEqv;
        public HydroResistanceCalcdData()
        {
            lambda = 0;
            Re = 0;
            V = 0;
            dzeta = 0;
            Gv = 0;
            kG = 0;
            KEqv = 0;
            dzetaEqv = 0;
            dzetaLoc = 0;
            dzetaWay = 0;
            dzetaSum = 0;
            dzetaSumEqv = 0;
        }
        public object Clone() { return this.MemberwiseClone(); }

    }//cl
    public class HydroResistanceData : ICloneable
    {
        public HydroResistanceIniData IniData;
        public HydroResistanceCalcdData CalcData;
        public HydroResistanceData()
        {
            this.IniData = new HydroResistanceIniData();
            this.CalcData = new HydroResistanceCalcdData();
        }
        public object Clone()
        {
            HydroResistanceData obj = new HydroResistanceData();
            obj.IniData = (HydroResistanceIniData)this.IniData.Clone();
            obj.CalcData = (HydroResistanceCalcdData)this.CalcData.Clone();
            return obj;
        }
        public TTable IniData_GetAsTable()
        {
            return this.IniData.GetAsTable();
        }
        public void IniData_SetFromtTable(TTable tbl)
        {
            this.IniData.SetFromTable(tbl);
        }
        
    }//cl
}
