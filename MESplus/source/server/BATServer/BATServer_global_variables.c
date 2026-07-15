/*******************************************************************************

    System      : MESplus
    Module      : BATServer
    File Name   : BATServer_global_variables.c
    Description : Common function module of Batch Server

    MES Version : 5.3.0

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2013/01/16  Aiden          Create

    Copyright(C) 1998-2013 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#include <COMCore_common.h>

unsigned int gi_batch_server_count;

//Added by YJJung 2016.08.02 for Max Windows in row
int gi_max_windows_in_row;

//Added by YJJung 2016.08.02 whether to hide the window of MES Server
char gc_hide_server_window;

