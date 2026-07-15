/*******************************************************************************

    System      : MESplus
    Module      : BATServer.exe
    File Name   : BATServer_main.c
    Description : MESplus Batch Process Main Application Server

    MES Version : 5.3.0

    Entry Point           : None
    Input Parameters      : None
        + Server No.

    Exit Values           : None

    Input Files           : None
        + Common INI File - MESplus.ini
        + Server INI File - BATServer.ini

    Output Files          :
        + BATServer.exe

    History
    Seq   Date        Developer      Description                        
    ---------------------------------------------------------------------------
    1     2013/01/15  Aiden          Create

    Copyright(C) 1998-2013 Miracom,Inc.
    All rights reserved.

*******************************************************************************/

#define BATServerVersion        "BAT_V5.3.7"

char s_app_name[30];

#if defined(WIN32) || defined(WIN64)
#include <windows.h>
#include "resource.h"
#endif

#include <MESCore_common.h>

extern int MAIN_initialize_server(char *s_exe_app_name);
extern void MAIN_dispatch_message();

/*******************************************************************************
    initialize_server()
        - Initialize Server
    Return Value
        - int : TRUE or FALSE
    Arguments
        - 
*******************************************************************************/
int initialize_server()
{
    memset(gs_server_version, 0x00, sizeof(gs_server_version));
    strcpy(gs_server_version, BATServerVersion);

    if(MAIN_initialize_server(s_app_name) == MP_FALSE)
        return MP_FALSE;

    return MP_TRUE;
}

/*******************************************************************************
    Windows MES Server Code
*******************************************************************************/
#if defined(WIN32) || defined(WIN64)

/* Function Prototype */
int  WinInitApplication(HINSTANCE hInst);
void WinInitInstance(HINSTANCE hInst);
LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam);

/*******************************************************************************
    WinMain()
        - Main Function
    Return Value
        - int : MSG.wParam
    Arguments
        - HINSTANCE hInstance : Handle to an instance, Instance of itself
        - HINSTANCE hInstance : Handle to an instance, Instance of Prev Window
        - LPSTR lpszCmdLine : Command-Line argument
        - int nCmdShow : Show Style
*******************************************************************************/
int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInstance, 
                   LPSTR lpszCmdLine, int nCmdShow)
{
    MSG msg;
    LPTSTR lpCmd;
    int i_pos = 0;
    int i_pos2 = 0;
    int i_count = 0;

    /* Get s_app_name */
    /* Get Application Name without extension(.exe). The value is used to find out INI File for the application */
    memset(s_app_name, '\0', sizeof(s_app_name));
    lpCmd = GetCommandLine();
    i_pos = (int)strlen(lpCmd);
    for (i_count = i_pos; i_count > 0; i_count--)
    {
        if(lpCmd[i_count] == '\\') 
        {
            break;
        }
        if(lpCmd[i_count] == '.') 
        {
            i_pos2 = i_count;
        }
    }
    if(i_count > 0)
    {
        memcpy(s_app_name, lpCmd + i_count + 1, i_pos2 - i_count - 1);
    }
    else
    {
        memcpy(s_app_name, lpCmd, i_pos2);
    }

    /* 같은 어플리케이션 인스턴스가 존재하는가? */
    if(!hPrevInstance)
    {
        /* 인스턴스의 서로 공유 가능한 자원의 초기화 */
        if(!WinInitApplication(hInst)) 
        {
            return MP_FALSE;
        }

        WinInitInstance(hInst);
    }

    /* Get Subno */
    if(lpszCmdLine[0] != '\0') 
    {
        memcpy(gs_subno, lpszCmdLine , MP_SIZE_SUBNO);
    } 
    else 
    {
        memcpy(gs_subno, "00", MP_SIZE_SUBNO);
    }


    if(initialize_server() == FALSE)
        return FALSE;

    /**** Dispatch for PULL ****/
    MAIN_dispatch_message();

    /* Message Loop */
    while(GetMessage(&msg, NULL, 0, 0)) 
    {
        /* 가상키(virtual key)를 문자(character)로 바꾼다. */
        TranslateMessage(&msg);
        /* 메세지를 MainWndPorc에 전달한다. */
        DispatchMessage(&msg);
    }

    return (int)msg.wParam;
}

/*******************************************************************************
    WinInitApplication(HINSTANCE hInst)
        - Initialize and register window class
    Return Value
        - int : RegisterClassEx(&wndclass)
    Arguments
        - HINSTANCE hInstance : Handle to an instance
*******************************************************************************/
int WinInitApplication(HINSTANCE hInst)
{
    WNDCLASSEX wndclass;

    wndclass.cbSize = sizeof(WNDCLASSEX);
    wndclass.style = CS_HREDRAW | CS_VREDRAW;
    wndclass.lpfnWndProc = WndProc;
    wndclass.cbClsExtra = 0;
    wndclass.cbWndExtra = 0;
    wndclass.hInstance = hInst;
    wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);
    wndclass.hbrBackground = (HBRUSH)(COLOR_BTNFACE + 1);
    wndclass.lpszMenuName = NULL;
    wndclass.lpszClassName = s_app_name;
    wndclass.hIcon = LoadIcon(hInst, (LPCTSTR)IDI_BATServer);
    wndclass.hIconSm = LoadIcon(hInst, (LPCTSTR)IDI_BATServer);

    return RegisterClassEx(&wndclass);
}


/*******************************************************************************
    End of Windows MES Server Code
*******************************************************************************/

#else

/*******************************************************************************
    Unix MES Server Code
*******************************************************************************/

/*******************************************************************************
    main()
        - main function
    Return Value
        - MP_TRUE or MP_FALSE
    Arguments
        - int argc, char *argv[]
*******************************************************************************/
int main(int argc, char *argv[])
{
    int i;
    int i_len;

    if(argc != 2)
    {
        // Error
        printf( "Wrong argument!\n" );
        printf( "   Usage : Server [\"Sub No\"]\n" );
        return FALSE;
    }

    /* Get s_app_name */
    /* Get Application Name without extension(.exe). The value is used to find out INI File for the application */
    memset(s_app_name, '\0', sizeof(s_app_name));    
    i_len = strlen(argv[0]);
    for (i = i_len; i > 0; i--)
    {
        if(argv[0][i] == '/') 
            break;
        if(argv[0][i] == '.') 
            i_len = i;
    }
    if(i > 0)
    {
        memcpy(s_app_name, argv[0] + i + 1, i_len - i - 1);
    }
    else
    {
        memcpy(s_app_name, argv[0], i_len);
    }

    /* Get Subno */
    if(argv[1][0] != '\0')
        memcpy(gs_subno, argv[1] , MP_SIZE_SUBNO);
    else 
        memcpy(gs_subno, "00", MP_SIZE_SUBNO);

    /* Initialize Server */
    if(initialize_server() == FALSE)
        return FALSE;

    /**** Message Loop ****/
    MAIN_dispatch_message();

    return TRUE;
}

/*******************************************************************************
    End of Unix MES Server Code
*******************************************************************************/

#endif

