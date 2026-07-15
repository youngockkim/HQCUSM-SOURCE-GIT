/*******************************************************************************

    System      : MESplus
    Module      : MESServer Module
    File Name   : MESServerAddService.c
    Description : register services of MESServer module

    MES Version : 4.2.0

    Function List
        - 
    Detail Description
        - 

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2008/08/24  Aiden          Create        

    Copyright(C) 1998-2004 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include <MESCore_service.h>
#include <MANCore_services.h>
#include <CUS_HQCUSM_service.h>
#include <CUS_common_service.h>

extern void BASCore_add_service();
extern void SECCore_add_service();
extern void SVMCore_add_service();
extern void CUS_common_add_service();
extern void CUS_HQCUSM_add_service();

#ifdef _ALM
extern void ALMCore_add_service();
#endif
#ifdef _BOM
extern void BOMCore_add_service();
#endif
#ifdef _EDC
extern void EDCCore_add_service();
#endif
#ifdef _FMB
extern void FMBCore_add_service();
#endif
#ifdef _INV
extern void INVCore_add_service();
#endif
#ifdef _ORD
extern void ORDCore_add_service();
#endif
#ifdef _POP
extern void POPCore_add_service();
#endif
#ifdef _QCM
extern void QCMCore_add_service();
#endif
#ifdef _RAS
extern void RASCore_add_service();
#endif
#ifdef _RCP
extern void RCPCore_add_service();
#endif
#ifdef _RTD
extern void RTDCore_add_service();
#endif
#ifdef _SPC
extern void SPCCore_add_service();
#endif
#ifdef _WIP
extern void WIPCore_add_service();
#endif
/*** SPM Module (2012.04.17 by JYPARK) ***/
#ifdef _SPM
extern void SPMCore_add_service();
#endif
/*** End of Add (2012.04.17) ***/

#ifdef _WEM
extern void WEMCore_add_service();
#endif


#if defined(_USE_STATIC_LIB)

//Add by J.S. 2009.02.23 for Support Static User Routine
extern void SLIB_UserRoutine_add_service();
extern void BAS_UserRoutine_add_service();
extern void CMN_UserRoutine_add_service();
extern void SEC_UserRoutine_add_service();
extern void SVM_UserRoutine_add_service();

#ifdef _ALM
extern void ALM_UserRoutine_add_service();
#endif
#ifdef _BOM
extern void BOM_UserRoutine_add_service();
#endif
#ifdef _EDC
extern void EDC_UserRoutine_add_service();
#endif
#ifdef _FMB
extern void FMB_UserRoutine_add_service();
#endif
#ifdef _INV
extern void INV_UserRoutine_add_service();
#endif
#ifdef _ORD
extern void ORD_UserRoutine_add_service();
#endif
#ifdef _POP
extern void POP_UserRoutine_add_service();
#endif
#ifdef _QCM
extern void QCM_UserRoutine_add_service();
#endif
#ifdef _RAS
extern void RAS_UserRoutine_add_service();
#endif
#ifdef _RCP
extern void RCP_UserRoutine_add_service();
#endif
#ifdef _RTD
extern void RTD_UserRoutine_add_service();
#endif
#ifdef _SPC
extern void SPC_UserRoutine_add_service();
#endif
#ifdef _WIP
extern void WIP_UserRoutine_add_service();
#endif
#ifdef _SPM
extern void SPM_UserRoutine_add_service();
#endif
#ifdef _WEM
extern void WEM_UserRoutine_add_service();
#endif


#endif

void MESServer_add_service()
{
    COM_add_service("MESplus", "Stop_Process", NO_REPLY, MES_Stop_Process);
    COM_add_service("ADM", "ADM_Change_EnvValues", NO_REPLY, ADM_Change_EnvValues);
    COM_add_service("ADM", "ADM_Check_Process", NO_REPLY, ADM_Check_Process);
    COM_add_service("ADM", "ADM_Init_Shared_Pool", NO_REPLY, ADM_Init_Shared_Pool);

    BASCore_add_service();
    SECCore_add_service();
    SVMCore_add_service();

#ifdef _ALM
    ALMCore_add_service();
#endif
#ifdef _BOM
    BOMCore_add_service();
#endif
#ifdef _EDC
    EDCCore_add_service();
#endif
#ifdef _FMB
    FMBCore_add_service();
#endif
#ifdef _INV
    INVCore_add_service();
#endif
#ifdef _ORD
    ORDCore_add_service();
#endif
#ifdef _POP
    POPCore_add_service();
#endif
#ifdef _QCM
    QCMCore_add_service();
#endif
#ifdef _RAS
    RASCore_add_service();
#endif
#ifdef _RCP
    RCPCore_add_service();
#endif
#ifdef _RTD
    RTDCore_add_service();
#endif
#ifdef _SPC
    SPCCore_add_service();
#endif
#ifdef _WIP
    WIPCore_add_service();
#endif
/*** SPM Module (2012.04.17 by JYPARK) ***/
#ifdef _SPM
	SPMCore_add_service();
#endif
/*** End of Add (2012.04.17) ***/

#ifdef _WEM
    WEMCore_add_service();
#endif

#if defined(_USE_STATIC_LIB)

    //Add by J.S. 2009.02.23 for Support Static User Routine
    SLIB_UserRoutine_add_service();
    BAS_UserRoutine_add_service();
    CMN_UserRoutine_add_service();
    SEC_UserRoutine_add_service();
    SVM_UserRoutine_add_service();

#ifdef _ALM
    ALM_UserRoutine_add_service();
#endif
#ifdef _BOM
    BOM_UserRoutine_add_service();
#endif
#ifdef _EDC
    EDC_UserRoutine_add_service();
#endif
#ifdef _FMB
    FMB_UserRoutine_add_service();
#endif
#ifdef _INV
    INV_UserRoutine_add_service();
#endif
#ifdef _ORD
    ORD_UserRoutine_add_service();
#endif
#ifdef _POP
    POP_UserRoutine_add_service();
#endif
#ifdef _QCM
    QCM_UserRoutine_add_service();
#endif
#ifdef _RAS
    RAS_UserRoutine_add_service();
#endif
#ifdef _RCP
    RCP_UserRoutine_add_service();
#endif
#ifdef _RTD
    RTD_UserRoutine_add_service();
#endif
#ifdef _SPC
    SPC_UserRoutine_add_service();
#endif
#ifdef _WIP
    WIP_UserRoutine_add_service();
#endif
#ifdef _SPM
    SPM_UserRoutine_add_service();
#endif
#ifdef _WEM
    WEM_UserRoutine_add_service();
#endif

	//add addservice for hanwha qcell service lib
	 CUS_common_add_service();
     CUS_HQCUSM_add_service();


#endif

}
