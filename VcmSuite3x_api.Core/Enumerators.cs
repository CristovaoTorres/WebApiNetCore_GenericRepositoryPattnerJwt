using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x_api.Core
{

    public enum PortSpot
    {
        Top,
        Right,
        Bottom,
        Left
    }
    public enum FluxogramaTipo
    {
        Topologia,
        Cenario
    }

    public enum ModalColor
    {
        Silver = 0,
        Black = 4,
        Brown = 8,
        Blue = 16,
        Green = 32,
        BlueViolet = 64,
    }
    public enum SimboloCodigo
    {
        PrecoCompraNF,
        PrecoVendaNF,
        ICMSPorctSubstEnt,
        ICMSPorctSubstSai,
        ValorBenefICMS,
        SuprLo,
        SuprUp,
        ConseeT,
        ConsvapT



    }


    #region General
    public enum eGeneralCurrency { USD = 1, BRL = 2, EUR = 3 }
    public enum eGeneralStatus { Inactivated = -1, Activeted = 1 }
    public enum eGeneralFrequency { Minute = 0, Day = 1, Week = 2, Month = 3, Bimester = 4, Semester = 5, Year = 6 }
    #endregion

    #region Database Objects
    public enum ePlanUseType { Pre = 1, Pos = 2 }
    public enum eRecurrencyType { Recurrent_Fixed = 1, Recurrent_Infinite = 2 }
    public enum eProductType { Not_Cumulative = 1, Cumulative = 2 }
    public enum eProductName { SMS = 10, VOZ = 20, EMAIL = 30, CONTACT = 40, KEY = 1000 }
    public enum eApplicationType { Application = 1, SuperAdmin = 10 }
    public enum eInvoiceStatus
    {
        UNPAID = -1
                                , CANCELLED = -2
                                , PAYMENT_PENDING = -3

                                , DRAFT = 100
                                , SCHEDULED = 101
                                , SENT = 102
                                , PAID = 103
                                , PARTIALLY_PAID = 105
                                , MARKED_AS_PAID = 110

                                , REFUNDED = 200
                                , PARTIALLY_REFUNDED = 205
                                , MARKED_AS_REFUNDED = 210
    }
    public enum eAgreementStatus
    {
        Inactivated = -1
                                    , expired = -2
                                    , canceled = -3

                                    , Awaiting_Check = 100
                                    , Awaiting_Execute_1st = 105
                                    , Activated = 110
    }
    #endregion

    #region Others
    public enum eApiCallerMethod { POST, GET }
    public enum eFeedbackType { FATAL, ERROR, WARNING, INFO, SUCCESS }
    #endregion



    #region Paypal
    public enum ePaypalMode { SANDBOX, LIVE }
    #endregion
}

