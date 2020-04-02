using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.Util
{
    public class Enum
    {
        public enum EMessageType { ERROR = -1, WARNING = 0, INFO = 1, SUCCESS = 2 }
    }

    public enum EEntryBySymbolType
    {
        UF_ProductCost //"CusMP" 
        , UA_InitialVolume //"VolIni"
        , UA_AgrupedVolume //"VolMinT", "VolMaxT"
        , UA_VariableCost //"valor", "cFin", "cusArm", "cusSeg"
        , UA_FixedCost //"CfxoUA"
        , UA_Handling
        , UA_Retention
        , UA_EntryLimit
        , UA_ExitLimit
        , MC_DemandaProduto


    }
    public enum TipoElemento
    {
        UA,
        UF,
        MC,
        UP
    }

    public enum TipoArmazenamentoEnum
    {
        Agrupado
    }
    public enum EMessageInternalCode
    {
        Created_Successfully = 1
       , Updated_Successfully = 2
       , Records_Retrived_Successfully = 3
       , Deleted_Successfully = 4

       , Authorizated_Successfully = 10



       , Validation_Fields_Fail = -1
       , Invalid_Request_Parameters = -2
       , Login_Failed = -3
       , Object_Not_Found_On_Database = -4
       , Method_Not_Implemented = -5
       , Internal_Server_Error_Exception = -100
    }
}
