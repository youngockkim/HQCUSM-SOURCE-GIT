#include <MESCore_common.h>
#include <MessageHandler.h>
#include <MessageCaster.h>
#include "BATServer_common.h"

/* System default log level */
int  i_system_log_level;

/* Check Transaction Time */
char s_tran_start_time[17];
char s_tran_end_time[17];
char s_appl_name[30];

char s_extra_channel[5000];
char s_allow_module[200];
char s_extra_allow_module[2000];

#if defined(_TIBRV)
char s_cmessage_error_desc[1024];
#endif

/* Added by Aiden.Koo. 2012.08.02. for Logging SQL Query Interval Time */
extern double   gd_from_interval_time_for_logging_query;
extern void     DB_init_service_total_query_time();
extern void     DB_init_long_query_rank_by_time();
extern void     DB_init_long_query_rank_by_size();
extern char     gc_DB_collect_sql_trace;

extern void     BATServer_add_service();

/* Function Prototype */
int  MAIN_get_env_values(char *s_ret);
int  MAIN_db_connect(void);
void MAIN_display_status(char *);
void MAIN_display_error(char *);
int  MAIN_get_channel_info(char *s_ret);
int  MAIN_initial_middleware();
void MAIN_exit_program();
void MAIN_store_channel_info();
/*******************************************************************************
    Windows MES Server Code
*******************************************************************************/
#if defined(WIN32) || defined(WIN64)

/* Include Header File */
#include <windows.h>
#include "MessageBoxTimeout.h"

/* Window Position */
#define MP_MAX_WINDOWS_H        ( 3 )    /* How may windows are located in a raws */
#define MP_DEFAULT_WIDTH        ( 250 )
#define MP_DEFAULT_HEIGHT       ( 180 )
#define MP_DEFAULT_TOP          ( 10 )
#define MP_DEFAULT_LEFT         ( (1024 - MP_DEFAULT_WIDTH * MP_MAX_WINDOWS_H) / 2 - 20 )  /* 1024 - 300 * 3 */
#define MP_MAX_WINDOWS_V        ( 5 )

/* Window Display */
#define MP_ERROR_MSG_CAPTION    ( "BATCH Server: Error !!!" )
#define MP_WARNING_MSG_CAPTION  ( "BATCH Server: Warning !!!" )

/* Edit Control Options */
#define MP_MAX_LINE_COUNT       ( 100 )

#define IDC_EDIT_BOX            1001
#define IDC_EXIT_BUTTON         1002
#define IDC_COUNT_GROUP         1003
#define IDC_TIME_GROUP          1004
#define IDC_COUNT_LABEL         1005
#define IDC_TIME_LABEL          1006
#define IDC_TOP_CHECK           1007
#define IDC_CLEAR_BUTTON        1008
#define IDC_SHOW_HIDE_BUTTON    1009
#define IDC_TRAN_STATUS         1010
#define IDC_SITEID_SUBNO        1011


/* Function Prototype */
int  WinCreateWindow();
void WinSetDefaultFont(int identifier, HWND hwnd);
void WinCreateControl(HWND hwnd);
void WinSetTranTime(double interval);
void WinSetTranCount();
void WinSetTransStatus(int bTrans);


/* Global Variable */
HINSTANCE hInstance = NULL;
HWND hwndMain;
HWND hwndEdit;
HWND hwndCount;
HWND hwndTime;
HWND hwndCheck;
HWND hwndTranStatus;

/* Global Variable */
char s_win_title_name[255];                 /* Window's Title */
int i_window_left = 0;                       /* Left of Main Window */
int i_window_top = 0;                        /* Top of Main Window */
int i_window_tran_count = 0;


/*******************************************************************************
    WinInitInstance()
        - 
    Return Value
    Arguments
        - void : 
*******************************************************************************/
void WinInitInstance(HINSTANCE hInst)
{
    hInstance = hInst;
}

/*******************************************************************************
    WinCreateWindow()
        - 
    Return Value
    Arguments
        - int bTrans : 
*******************************************************************************/
int WinCreateWindow()
{
    HWND findHwnd;
    int i_subno = 0;
    int i_pos = 0;
    int i_left = 0;
    int i_top = 0;
    int i_err = 0;
    char s_msg[256];

    /* Set Position */
    i_subno = COM_atoi(gs_subno, MP_SIZE_SUBNO);
	if(i_subno > (MP_MAX_WINDOWS_V * gi_max_windows_in_row))
    {
        i_subno = i_subno - (MP_MAX_WINDOWS_V * gi_max_windows_in_row);
    }

    i_pos = (i_subno - 1) % gi_max_windows_in_row;
    i_left = i_pos * MP_DEFAULT_WIDTH + MP_DEFAULT_LEFT;
    i_left += i_pos * 5;

    i_pos = (int)((i_subno - 1) / gi_max_windows_in_row);

	if( gc_hide_server_window == 'Y')
	{
		i_top = i_pos * 85 + MP_DEFAULT_TOP;
	}
	else
	{
		i_top = i_pos * MP_DEFAULT_HEIGHT + MP_DEFAULT_TOP;
	}

    i_top += i_pos * 30;

    /* Make Window's Title */
    /* Change by using Channel Name : MESServer - Channel Subno */
    sprintf(s_win_title_name, "%s - %s %.2s", s_appl_name, gs_main_channel, gs_subno);
    /* Check Process which has same Channel Name is running already */
    findHwnd = FindWindow(s_appl_name, s_win_title_name);
    if(findHwnd != NULL)
    {
        i_err = 1;  /* 1: same process is already running */
    }            

    /* Save Window Position */
    i_window_left = i_left;
    i_window_top = i_top;

    /* Create Window */
    hwndMain = CreateWindowEx(0, s_appl_name, s_win_title_name,
                WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_MINIMIZEBOX,
                i_left, i_top, MP_DEFAULT_WIDTH, MP_DEFAULT_HEIGHT,
                NULL, NULL, hInstance, NULL);
    if(hwndMain == NULL) 
    {
        return FALSE;
    }

    /* Error Handling and Exit with popup message box */
    if(i_err == 1)
    {
        sprintf(s_msg, "Process [%.*s] is already running !!", strlen(s_win_title_name), s_win_title_name);
        MAIN_display_error(s_msg);
        return FALSE;
    }

    return TRUE;
}

/*******************************************************************************
    WndProc()
        - Window Procedure Function
    Return Value
        - Result (32-bit value)
    Arguments
        - HWND hwnd : Handle
        - UINT message : Window Message
        - WPARAM wParam : 32-bit message parameter
            UINT nId = LOWORD(wParam) : item, control, or accelerator identifier 
            UINT wmEvent = HIWORD(wParam) : notification code
        - LPARAM lParam : 32-bit message parameter
            HWND hwndCtl = (HWND)LOWORD(lParam) : handle of control 
            int  nCode = HIWORD(lParam) : notification code
*******************************************************************************/
LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    RECT rect_window;

    switch(message)
    {
        /* When Create Window */
        case WM_CREATE:
            GetWindowRect(hwnd, &rect_window);
            rect_window.right = rect_window.left + MP_DEFAULT_WIDTH;
            rect_window.bottom = rect_window.top + MP_DEFAULT_HEIGHT;
            AdjustWindowRect(&rect_window, WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_MINIMIZEBOX, FALSE);
            MoveWindow(hwnd, i_window_left, i_window_top, rect_window.right - rect_window.left, rect_window.bottom - rect_window.top, FALSE);

            /* Create window controls */
            WinCreateControl(hwnd);
			if (gc_hide_server_window == 'Y')
			{
				ShowWindow(hwndEdit, SW_HIDE);
				SetWindowText(GetDlgItem(hwnd, IDC_SHOW_HIDE_BUTTON), "↓");
				MoveWindow(hwnd,
					i_window_left,
					i_window_top,
					rect_window.right - rect_window.left,
					rect_window.bottom - rect_window.top - 100,
					TRUE);
				MoveWindow(GetDlgItem(hwnd, IDC_TOP_CHECK),
					3, 160 - 100, 50, 14, TRUE);
				MoveWindow(GetDlgItem(hwnd, IDC_CLEAR_BUTTON),
					123, 155 - 100, 60, 22, TRUE);
				MoveWindow(GetDlgItem(hwnd, IDC_EXIT_BUTTON),
					188, 155 - 100, 60, 22, TRUE);
			}

            break;

        /* If a button is clicked... */
        case WM_COMMAND:

            if(HIWORD(wParam) != BN_CLICKED) 
            {
                break;
            }

            switch(LOWORD(wParam))
            {
                case IDC_EXIT_BUTTON:
                    gc_stop_process = 'Y';
                    // Log Write
                    LOG_head("PROCESS TERMINATE");
                    LOG_head("Exit Procedure is processing ... ");
                    COM_log_write(MP_LOG_SYSTEM, ' ', MP_LOG_CATE_SYSTEM);
                    MAIN_exit_program();
                    break;
                case IDC_CLEAR_BUTTON:
                    SetWindowText(hwndEdit, "");
                    break;
                case IDC_TOP_CHECK:
                    GetWindowRect(hwnd, &rect_window);
                    if(SendMessage(hwndCheck, BM_GETCHECK, 0, 0) == BST_UNCHECKED) 
                    {
                        SendMessage(hwndCheck, BM_SETCHECK, BST_CHECKED, 0);
                        SetWindowPos(hwnd, HWND_TOPMOST, rect_window.left, rect_window.top, 
                        rect_window.right - rect_window.left, rect_window.bottom - rect_window.top, SWP_SHOWWINDOW);
                    } 
                    else 
                    {
                        SendMessage(hwndCheck, BM_SETCHECK, BST_UNCHECKED, 0);
                        SetWindowPos(hwnd, HWND_NOTOPMOST, rect_window.left, rect_window.top, 
                            rect_window.right - rect_window.left, rect_window.bottom - rect_window.top, SWP_SHOWWINDOW);
                    }
                    break;
                case IDC_SHOW_HIDE_BUTTON:
                    GetWindowRect(hwnd, &rect_window);
                    if(IsWindowVisible(hwndEdit) == MP_TRUE)
                    {
                        ShowWindow(hwndEdit, SW_HIDE);                        
                        SetWindowText(GetDlgItem(hwnd, IDC_SHOW_HIDE_BUTTON), "↓");
                        MoveWindow(hwnd, 
                            rect_window.left, 
                            rect_window.top, 
                            rect_window.right - rect_window.left,
                            rect_window.bottom - rect_window.top - 100, 
                            TRUE);
                        MoveWindow(GetDlgItem(hwnd, IDC_TOP_CHECK),
                            3, 160 - 100, 50, 14, TRUE);  
                        MoveWindow(GetDlgItem(hwnd, IDC_CLEAR_BUTTON),
                            123, 155 - 100, 60, 22, TRUE);  
                        MoveWindow(GetDlgItem(hwnd, IDC_EXIT_BUTTON),
                            188, 155 - 100, 60, 22, TRUE);  
                    }
                    else
                    {
                        ShowWindow(hwndEdit, SW_SHOW);
                        SetWindowText(GetDlgItem(hwnd, IDC_SHOW_HIDE_BUTTON), "↑");
                        MoveWindow(hwnd, 
                            rect_window.left, 
                            rect_window.top, 
                            rect_window.right - rect_window.left,
                            rect_window.bottom - rect_window.top + 100, 
                            TRUE);
                        MoveWindow(GetDlgItem(hwnd, IDC_TOP_CHECK),
                            3, 160, 50, 14, TRUE);
                        MoveWindow(GetDlgItem(hwnd, IDC_CLEAR_BUTTON),
                            123, 155, 60, 22, TRUE);  
                        MoveWindow(GetDlgItem(hwnd, IDC_EXIT_BUTTON),
                            188, 155, 60, 22, TRUE);  
                    }
                    break;
                default:
                    break;
            }

            break;

        /* PostQuitMessage 함수를 호출하는 경우 발생 */
        case WM_QUIT:   /* Exit Handler */
            break;

        /* Destory Window */
        case WM_DESTROY:
            gc_stop_process = 'Y';
            // Log Write
            LOG_head("PROCESS TERMINATE");
            LOG_head("Exit Procedure is processing ... ");
            COM_log_write(MP_LOG_SYSTEM, ' ', MP_LOG_CATE_SYSTEM);
            MAIN_exit_program();
            break;
            
        default:
            return DefWindowProc(hwnd, message, wParam, lParam);
    }

    return 0;
}


/*******************************************************************************
    WinSetDefaultFont()
        - Set Default Font to draw windows
    Return Value
        - void
    Arguments
        - int identifier : Control ID
        - HWND hwnd : Handle
*******************************************************************************/
void WinSetDefaultFont(int identifier, HWND hwnd)
{
    SendDlgItemMessage(hwnd,
        identifier,
        WM_SETFONT,
        (WPARAM)GetStockObject(DEFAULT_GUI_FONT),
        MAKELPARAM(TRUE, 0));
}


/*******************************************************************************
    WinCreateControl()
        - Set Default Font to draw windows
    Return Value
        - void
    Arguments
        - HWND hwnd : Handle
*******************************************************************************/
void WinCreateControl(HWND hwnd)
{
    HWND hTemp;

    // s_win_title_name 이 길면 화면에 모두 표시되지 않음.
    // 그래서 공통되는 속성인 Subno를 대신 표시하도록 변경함.
    {
        char s_window_name[100];
        sprintf(s_window_name, "%s - %.2s", s_appl_name, gs_subno);
        hTemp = CreateWindowEx(0, "STATIC", s_window_name,
                            WS_CHILD | WS_VISIBLE | WS_BORDER,
                            5, 3, 240, 14,
                            hwnd, (HMENU)IDC_SITEID_SUBNO, hInstance, NULL);
        WinSetDefaultFont(IDC_SITEID_SUBNO, hwnd);
    }

    hTemp = CreateWindowEx(0, "BUTTON", "Tran Count",
                        WS_CHILD | WS_VISIBLE | BS_GROUPBOX,
                        1, 1 + 20, 80, 30,
                        hwnd, (HMENU)IDC_COUNT_GROUP, hInstance, NULL);
    WinSetDefaultFont(IDC_COUNT_GROUP, hwnd);
    
    hTemp = CreateWindowEx(0, "BUTTON", "Proc Time",
                        WS_CHILD | WS_VISIBLE | BS_GROUPBOX,
                        90, 1 + 20, 80, 30,
                        hwnd, (HMENU)IDC_TIME_GROUP, hInstance, NULL);
    WinSetDefaultFont(IDC_TIME_GROUP, hwnd);

    hwndCount = CreateWindowEx(0, "STATIC", "0",
                        WS_CHILD | WS_VISIBLE | SS_CENTER,
                        10, 15 + 20, 60, 14,
                        hwnd, (HMENU)IDC_COUNT_LABEL, hInstance, NULL);
    WinSetDefaultFont(IDC_COUNT_LABEL, hwnd);

    hwndTime = CreateWindowEx(0, "STATIC", "0",
                        WS_CHILD | WS_VISIBLE | SS_RIGHT,
                        100, 15 + 20, 60, 14,
                        hwnd, (HMENU)IDC_TIME_LABEL, hInstance, NULL);
    WinSetDefaultFont(IDC_TIME_LABEL, hwnd);

    hwndEdit = CreateWindowEx(WS_EX_CLIENTEDGE, "EDIT", "Start Process ...\r\n\0",
                        WS_CHILD | WS_VISIBLE | WS_VSCROLL | ES_LEFT | ES_WANTRETURN | ES_MULTILINE | ES_AUTOVSCROLL | ES_READONLY,
                        1, 32 + 20, 249, 100,
                        hwnd, (HMENU)IDC_EDIT_BOX, hInstance, NULL);
    WinSetDefaultFont(IDC_EDIT_BOX, hwnd);

    hwndCheck = CreateWindowEx(0, "BUTTON", "Top",
                        WS_CHILD | WS_VISIBLE | BS_CHECKBOX,
                        3, 160, 50, 14,
                        hwnd, (HMENU)IDC_TOP_CHECK, hInstance, NULL);
    WinSetDefaultFont(IDC_TOP_CHECK, hwnd);

    hTemp = CreateWindowEx(0, "BUTTON", "Clear",
                        WS_CHILD | WS_VISIBLE,
                        123, 155, 60, 22,
                        hwnd, (HMENU)IDC_CLEAR_BUTTON, hInstance, NULL);
    WinSetDefaultFont(IDC_CLEAR_BUTTON, hwnd);

    hTemp = CreateWindowEx(0, "BUTTON", "Exit",
                        WS_CHILD | WS_VISIBLE,
                        188, 155, 60, 22,
                        hwnd, (HMENU)IDC_EXIT_BUTTON, hInstance, NULL);
    WinSetDefaultFont(IDC_EXIT_BUTTON, hwnd);

    hTemp = CreateWindowEx(0, "BUTTON", "↑",
                        WS_CHILD | WS_VISIBLE,
                        180, 7 + 20, 20, 20,
                        hwnd, (HMENU)IDC_SHOW_HIDE_BUTTON, hInstance, NULL);
    WinSetDefaultFont(IDC_SHOW_HIDE_BUTTON, hwnd);

    hwndTranStatus = CreateWindowEx(0, "STATIC", "",
                        WS_CHILD | WS_VISIBLE | WS_BORDER | SS_GRAYRECT,
                        210, 7 + 20, 20, 20,
                        hwnd, (HMENU)IDC_TRAN_STATUS, hInstance, NULL);
    WinSetDefaultFont(IDC_TRAN_STATUS, hwnd);
}

/*******************************************************************************
    WinSetProcTime()
        - Display trans time
    Return Value
        - void
    Arguments
        - double interval
*******************************************************************************/
void WinSetProcTime(double interval)
{
    char s_interval[20];

    sprintf(s_interval, "%.3f", interval);
    SetWindowText(hwndTime, s_interval);
}


/*******************************************************************************
    WinSetTranCount()
        - Display trans count
    Return Value
        - void
    Arguments
*******************************************************************************/
void WinSetTranCount()
{
    char s_count[20];

    sprintf(s_count, "%d", ++i_window_tran_count);
    SetWindowText(hwndCount, s_count);
}

/*******************************************************************************
    WinSetTransStatus()
        - 
    Return Value
    Arguments
        - int bTrans : 
*******************************************************************************/
void WinSetTransStatus(int bTrans)
{
    LONG style;

    if(bTrans == MP_TRUE)
    {
        style = GetWindowLong(hwndTranStatus, GWL_STYLE);
        style &= ~SS_GRAYRECT;
        style |= SS_WHITERECT;
        SetWindowLong(hwndTranStatus, GWL_STYLE, style);
    }
    else
    {
        style = GetWindowLong(hwndTranStatus, GWL_STYLE);
        style &= ~SS_WHITERECT;
        style |= SS_GRAYRECT;
        SetWindowLong(hwndTranStatus, GWL_STYLE, style);
    }
    InvalidateRect(hwndTranStatus, NULL, TRUE);
    UpdateWindow(hwndTranStatus);
}

/*
 * MessageBoxTimeout API
 * License : This article, along with any associated source code and files, is licensed under The Code Project Open License (CPOL)
**/

int MessageBoxTimeoutA(HWND hWnd, LPCSTR lpText, 
    LPCSTR lpCaption, UINT uType, WORD wLanguageId, 
    DWORD dwMilliseconds)
{
    static MSGBOXAAPI MsgBoxTOA = NULL;

    if (!MsgBoxTOA)
    {
        HMODULE hUser32 = GetModuleHandle(_T("user32.dll"));
        if (hUser32)
        {
            MsgBoxTOA = (MSGBOXAAPI)GetProcAddress(hUser32, 
                                      "MessageBoxTimeoutA");
            //fall through to 'if (MsgBoxTOA)...'
        }
        else
        {
            //stuff happened, add code to handle it here 
            //(possibly just call MessageBox())
            return 0;
        }
    }

    if (MsgBoxTOA)
    {
        return MsgBoxTOA(hWnd, lpText, lpCaption, 
              uType, wLanguageId, dwMilliseconds);
    }

    return 0;
}

int MessageBoxTimeoutW(HWND hWnd, LPCWSTR lpText, 
    LPCWSTR lpCaption, UINT uType, WORD wLanguageId, DWORD dwMilliseconds)
{
    static MSGBOXWAPI MsgBoxTOW = NULL;

    if (!MsgBoxTOW)
    {
        HMODULE hUser32 = GetModuleHandle(_T("user32.dll"));
        if (hUser32)
        {
            MsgBoxTOW = (MSGBOXWAPI)GetProcAddress(hUser32, 
                                      "MessageBoxTimeoutW");
            //fall through to 'if (MsgBoxTOW)...'
        }
        else
        {
            //stuff happened, add code to handle it here 
            //(possibly just call MessageBox())
            return 0;
        }
    }

    if (MsgBoxTOW)
    {
        return MsgBoxTOW(hWnd, lpText, lpCaption, 
               uType, wLanguageId, dwMilliseconds);
    }

    return 0;
}

/*******************************************************************************
    End of Windows MES Server Code
*******************************************************************************/

#endif

/*******************************************************************************
    Common Routine for Main
*******************************************************************************/

/*******************************************************************************
    MAIN_display_status()
        - Display Message on window's edit control
    Return Value
    Arguments
        - char *s_msg : String to display
*******************************************************************************/
void MAIN_display_status(char *s_msg)
{

#if defined(WIN32) || defined(WIN64)

    int i_len = 0, i, i_line_count;
    char s_edit[MP_MAX_LINE_COUNT * 40 + 500];   /* 500 * 100 */
    char s_tmp[MP_MAX_LINE_COUNT * 40 + 500];
    char s_date_time[14];
    char s_time[9];

    int sts_val;
    char sts_msg[MP_SIZE_MSG];
    MP_STSINIT(&sts_val, sts_msg);

    if(s_msg[0] == '\0')
        return;

    memset(s_edit, 0, sizeof(s_edit));
    memset(s_tmp, 0, sizeof(s_edit));
    memset(s_date_time, ' ', sizeof(s_date_time));
    memset(s_time, ' ', sizeof(s_time));

    /* Get Total Line Count of Edit Control ##### Important
       Line Count가 일정 이상이 되면 한 Line씩 지우기 위해 사용됨 */
    i_len = GetWindowTextLength(hwndEdit);

    /* ...Then get the text from the edit control */
    GetWindowText(hwndEdit, s_tmp, i_len + 1);

    /* Add current time */
    COM_get_date_time(s_date_time);
    sprintf(s_time, "%.2s:%.2s:%.2s", s_date_time + 8, s_date_time + 10, s_date_time + 12);

    sprintf(s_edit, "[%.8s]\r\n%s ", s_time, s_msg);
    strcat(s_edit, "\r\n\0");
    strcat(s_edit, s_tmp);
    
    i_line_count = 0;
    for (i = 0; i < strlen(s_edit); i++)
    {
        if (s_edit[i] == '\r')
        {
            i_line_count++;
            if (i_line_count == gi_max_line_count) 
            {
                i += 2;
                break;
            }
        }
    }

    if (i_line_count == gi_max_line_count)
    {
        sprintf(s_edit, "%.*s\r\n", i, s_edit);
    }

    SetWindowText(hwndEdit, s_edit);

#endif

}

/*******************************************************************************
    MAIN_display_error()
        - Display Error Message on screen
    Return Value
    Arguments
        - char *s_msg : String to display
*******************************************************************************/
void MAIN_display_error(char *s_msg)
{
#if defined(WIN32) || defined(WIN64)
    //MessageBox(hwndMain, s_msg, MP_ERROR_MSG_CAPTION, MB_OK | MB_TOPMOST);
    MessageBoxTimeout(hwndMain, s_msg, MP_ERROR_MSG_CAPTION, MB_OK | MB_TOPMOST, 0, 2000);
#else
    printf("%s\n", s_msg);
#endif
}

/*******************************************************************************
    MAIN_dispatch_message()
        - dispatch middleware message
    Return Value
    Arguments
        - void
*******************************************************************************/
extern int BAT_check_process_batch();

#if defined(_H101)

extern IOISession mioi_session;
void BATCH_dispatch_message() 
{
    IOIMessage msg;

    BAT_check_process_batch();

    while(True32) 
    {
        /* Check process status every minute */
        msg = IOIGetMessage(mioi_session, 60 * 1000);

        if(Null_Ptr == msg) 
        {
            if(gc_stop_process == 'Y')
            {
                break;
            }

            /**** DB Re-Connect ****/
            if(MAIN_db_connect() == MP_TRUE)
            {
                BAT_check_process_batch();
            }
        }
        else
        {
            on_message(mioi_session, msg);
            if(msg) IOIMessageRelease(msg);
        }
    }
}

#elif defined(_TIBRV)

extern char cm_initialized;
void BATCH_CMessage_dispatch()
{
    tibrv_status ret;

    BAT_check_process_batch();

    while(cm_initialized == CMESSAGE_TRUE)
    {
        ret = tibrvQueue_TimedDispatch(TIBRV_DEFAULT_QUEUE, 60);
        if(TIBRV_OK != ret)
        {
            if(TIBRV_TIMEOUT == ret)
            {
                if(gc_stop_process == 'Y')
                {
                    return;
                }

                /**** DB Re-Connect ****/
                if(MAIN_db_connect() == MP_TRUE)
                {
                    BAT_check_process_batch();
                }
            }
            else
            {
                return;
            }
        }
    }
}

#endif

void MAIN_dispatch_message()
{
#if defined(WIN32) || defined(WIN64)
    /* Thread 생성을 위한 변수 */
    HANDLE dispatch_thread_handle = NULL;
    DWORD thread_id = 0;
    int num = 0;

#if defined(_H101)
    dispatch_thread_handle = CreateThread(NULL , 0 , (LPTHREAD_START_ROUTINE) BATCH_dispatch_message, (void*)&num,0,&thread_id);
#elif defined(_TIBRV)
    dispatch_thread_handle = CreateThread(NULL , 0 , (LPTHREAD_START_ROUTINE) BATCH_CMessage_dispatch, (void*)&num,0,&thread_id);
#endif

#else

#if defined(_H101)
    BATCH_dispatch_message();
#elif defined(_TIBRV)
    BATCH_CMessage_dispatch();
#endif

#endif

}

/*******************************************************************************
    MAIN_initialize_server()
        - Initialize Server
    Return Value
        - int : TRUE or FALSE
    Arguments
        - 
*******************************************************************************/
int MAIN_initialize_server(char *s_exe_app_name)
{
    int i_subno = 0;
    int i_err = 0;            /* 1: subno is wrong, 2: fail to get env values */
    int i_ret = 0;
    char s_ret[32];
    char s_msg[256];
    int sts_val;
    char sts_msg[MP_SIZE_MSG];

    MP_STSINIT(&sts_val, sts_msg);

    memcpy(s_appl_name, s_exe_app_name, sizeof(s_appl_name));

    COM_init_memory_check();
    TRS_initialize();

    DB_init_service_total_query_time();
    DB_init_long_query_rank_by_time();
    DB_init_long_query_rank_by_size();

    /**** Get Start Options ****/
    i_ret = MAIN_get_env_values(s_ret);
    if(i_ret == MP_FALSE) 
    {
        i_err = 2; /* 2: fail to get env values */
    } 
    else 
    {
        i_subno = COM_atoi(gs_subno, MP_SIZE_SUBNO);
        if(i_subno > 0) 
        {
#if defined(WIN32) || defined(WIN64)
            if(WinCreateWindow() == MP_FALSE)
            {
                return MP_FALSE;
            }

            /* ShowWindow() */
            ShowWindow(hwndMain, SW_SHOWDEFAULT);
            UpdateWindow(hwndMain);
#endif
        }
        else
        {
            i_err = 1; /* 1: subno is wrong */
        }

    } 
    
    if(i_err) 
    {
        switch(i_err)
        {
            case 1:
                sprintf(s_msg, "Subno value is wrong. Check command-line argument !!");
                break;
            case 2:
                sprintf(s_msg, "Fail to get environment value for  [%s] !!", s_ret);
                break;
            default:
                sprintf(s_msg, "Unexpected error happened !!");
                break;
        }
        MAIN_display_error(s_msg);
        return MP_FALSE;
    }

    /**** Open Log File ****/
    LOG_open(gs_site_id,
             gs_server_name,
             gs_subno,
             gi_log_level,
             gi_log_mode,
             gi_log_file_size,
             gi_log_file_count,
             gs_log_file_dir,
             gc_log_file_by_time,
             &sts_val,
             sts_msg);

    if(sts_val != MP_TRUE) 
    {
        sprintf(s_msg, "Fail to Open Log File !! [%.*s]", MP_SIZE_MSG, sts_msg);
        MAIN_display_error(s_msg);
        return MP_FALSE;
    }

    /**** Message Bus Initializing ****/
    if(MAIN_initial_middleware() == MP_FALSE)
        return MP_FALSE;

    /**** DB Connection Test ****/
    i_ret = MAIN_db_connect();
    if(i_ret != MP_TRUE) 
    {
        sprintf(s_msg, "Fail to connect database !!\n [%d][%.*s]", 
            DB_error_code, sizeof(DB_error_msg), DB_error_msg);
        MAIN_display_error(s_msg);
        return MP_FALSE;
    } 

    /* Initial TRSNode global variables node */
    g_node_var = TRS.create_node("GLOBAL_NODE_VARIABLES");
    TRS.set_object(g_node_var, "CALL_SERVICE", CallService);

    /* Variable for reaction when STOP Message receive */
    gc_stop_process = 'N';

    COM_INIT_MES_SERVICE_MODULE_LIST();

    TRS_set_log_head_handler(LOG_head);
    TRS_set_log_add_handler(LOG_add);
    TRS_set_log_write_handler(COM_log_write);

    TRS_set_log_level(gi_log_level);

    BATServer_add_service();

    gp_future_action = 0x00;

    {
        TRSNode *in_node = TRS.create_node("SERVER_START_IN");
        TRS.add_nstring(in_node, "SERVER_NAME", gs_server_name);
        if(COM_proc_user_routine("MESplus", gs_server_name,
                                 MP_UPOINT_SERVER_START,
                                 in_node,
                                 0x00) == MP_FALSE)
        {
            LOG_head("### Can't run server start function ...");
            COM_log_write(MP_LOG_ERROR, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

            MAIN_display_error("### Can't run server start function ...");
        }
        TRS.free_node(in_node);
    }

#if defined(_TIBRV)
    
#if defined(WIN32) || defined(WIN64)
    Sleep(1000 * 3);
#else
    sleep(3);
#endif

#endif

	//Add by J.S. 2011.12.11 for DST
    LOG_head("DST Options");
    LOG_add("DST_time_compress", MP_CHR, gc_DST_time_compress);
    LOG_add("DST_end_time", MP_STR, sizeof(gs_DST_end_time), gs_DST_end_time);
    LOG_add("time_zone_offset", MP_STR, sizeof(gs_time_zone_offset), gs_time_zone_offset);
    COM_log_write(MP_LOG_SYSTEM, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

    LOG_head("Server Running !!!");
    COM_log_write(MP_LOG_SYSTEM, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

#if defined(WIN32) || defined(WIN64)
    MAIN_display_status("Server Running !!!");
#else
    MAIN_display_error("Server Running !!!");
#endif

    return MP_TRUE;
}

/*******************************************************************************
    MAIN_initial_middleware()
        - Initial Middleware
    Return Value
        - int : TRUE or FALSE
    Arguments
*******************************************************************************/
int MAIN_initial_middleware()
{
    char s_msg[256];
    unsigned int i;
    int i_reconnect_count;
    int i_max_reconnect_count;

#if defined(_H101)

    char            s_proc_name[35];    /* Process admin에게 전달할 이 process name (MESServer 01) */
    
#elif defined(_TIBRV)

    unsigned short  status_val;
    char            status_msg[SIZE_MSG];

#endif

    /* Write log */
    LOG_head("### Start initialize message bus ...");
    COM_log_write(MP_LOG_SYSTEM, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    /**** Message Bus Initializing ****/

    i_reconnect_count = 0;
    i_max_reconnect_count = -1;

#if defined(_H101)

    /* Admin에 전달할 process 이름 */
    sprintf(s_proc_name, "%s_%.2s", gs_server_name, gs_subno);

    if(gc_h101_inter_station_mode == 'Y')
    {
        while(1)
        {
            if(IOI_SUCCESS != init(s_proc_name, SESSION_MODE_DOMAIN_INTER_STATION | SESSION_MODE_DISPATCH_PULL, gs_connect_string, 10104))
            {
                i_reconnect_count++;

                if(i_max_reconnect_count < 0)
                {
                    char value[10];
                    int  i_len;

                    /* Reconnect Option */
                    memset(value, ' ', sizeof(value));
                    COM_get_init_value(gs_com_file, "Basic", "MESplusMaxReconnectCount", value, &i_len);
                    i_max_reconnect_count = COM_atoi(value, i_len);
                }

                if(i_reconnect_count < i_max_reconnect_count)
                {
                    char s_reconnect_log[100];

                    term();

                    sprintf(s_reconnect_log, "H101 Initialize - [%d]", i_reconnect_count);

                    LOG_head(s_reconnect_log);
                    COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

                    continue;
                }

                LOG_head("H101 Initialize Error!!!");
                LOG_add("proc_name", MP_NSTR, s_proc_name);
                LOG_add("connect_string", MP_NSTR, gs_connect_string);
                COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

                sprintf(s_msg, "H101 Initialize Error!!!");
                MAIN_display_error(s_msg);
                return MP_FALSE;
            }

            break;
        }
    }
    else
    {
        while(1)
        {
            if(IOI_SUCCESS != init(s_proc_name, SESSION_MODE_DOMAIN_INNER_STATION | SESSION_MODE_DISPATCH_PULL, gs_connect_string, 10104))
            {
                i_reconnect_count++;

                if(i_max_reconnect_count < 0)
                {
                    char value[10];
                    int  i_len;

                    /* Reconnect Option */
                    memset(value, ' ', sizeof(value));
                    COM_get_init_value(gs_com_file, "Basic", "MESplusMaxReconnectCount", value, &i_len);
                    i_max_reconnect_count = COM_atoi(value, i_len);
                }

                if(i_reconnect_count < i_max_reconnect_count)
                {
                    char s_reconnect_log[100];

                    term();

                    sprintf(s_reconnect_log, "H101 Initialize - [%d]", i_reconnect_count);

                    LOG_head(s_reconnect_log);
                    COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

                    continue;
                }

                LOG_head("H101 Initialize Error!!!");
                LOG_add("proc_name", MP_NSTR, s_proc_name);
                LOG_add("connect_string", MP_NSTR, gs_connect_string);
                COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
        
                sprintf(s_msg, "H101 Initialize Error!!!");
                MAIN_display_error(s_msg);
                return MP_FALSE;
            }

            break;
        }
    }

    for(i = 0; i < gi_channel_count; i++)
    {
        if(ga_channel_mod[i].c_tune_mode == 'D')
        {
            tune(ga_channel_mod[i].s_channel, DT_UNICAST);
        }
        else if(ga_channel_mod[i].c_tune_mode == 'S')
        {
            tune(ga_channel_mod[i].s_channel, DT_MULTICAST);
        }
        else if(ga_channel_mod[i].c_tune_mode == 'G')
        {
            tune(ga_channel_mod[i].s_channel, DT_GUARANTEED_UNICAST);
        }
        else if(ga_channel_mod[i].c_tune_mode == 'M')
        {
            tune(ga_channel_mod[i].s_channel, DT_GUARANTEED_MULTICAST);
        }
    }

#elif defined(_TIBRV)

    while(1)
    {
        CMessage_initialize(gs_server_name,
                            gs_subno,
                            CMESSAGE_TRUE,
                            gs_rv_service,
                            gs_rv_network,
                            gs_connect_string,
                            &status_val, status_msg);

        if(status_val != CMESSAGE_SUCCESS )
        {
            i_reconnect_count++;

            if(i_max_reconnect_count < 0)
            {
                char value[10];
                int  i_len;

                /* Reconnect Option */
                memset(value, ' ', sizeof(value));
                COM_get_init_value(gs_com_file, "Basic", "MESplusMaxReconnectCount", value, &i_len);
                i_max_reconnect_count = COM_atoi(value, i_len);
            }

            if(i_reconnect_count < i_max_reconnect_count)
            {
                char s_reconnect_log[100];

#if defined(WIN32) || defined(WIN64)
                Sleep(1000);
#else
                sleep(1);
#endif
                sprintf(s_reconnect_log, "TIBRV Initialize - [%d]", i_reconnect_count);

                LOG_head(s_reconnect_log);
                COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

                continue;
            }

            CMessage_get_description(status_msg, s_cmessage_error_desc);
    
            LOG_head("CMessage_initialize()");
            LOG_add("status_code", MP_NSTR, status_msg);
            LOG_add("status_cmessage_error_desc", MP_NSTR, s_cmessage_error_desc);
            COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
    
            sprintf(s_msg, "CMessage_initialize returns with error\nstatus_val=[%d]\nstatus_msg=[%.*s]\nstatus_cmessage_error_desc=[%s] !\n", status_val, SIZE_MSG, status_msg, s_cmessage_error_desc);
            MAIN_display_error(s_msg);
    
            return MP_FALSE;
        }

        break;
    }

    //Add by J.S. 2011.06.07 rvd connect, disconnect message를 받기 위한 rv advisory channel설정
    if(gi_channel_count <= 27)
    {
        sprintf(ga_channel_mod[gi_channel_count].s_channel, "_RV.WARN.SYSTEM.RVD.DISCONNECTED");
        ga_channel_mod[gi_channel_count].c_tune_mode = 'S';
        ga_channel_mod[gi_channel_count].i_allow_mod_count = 0;
        gi_channel_count++;

        sprintf(ga_channel_mod[gi_channel_count].s_channel, "_RV.INFO.SYSTEM.LISTEN.START.%s", gs_main_channel);
        ga_channel_mod[gi_channel_count].c_tune_mode = 'S';
        ga_channel_mod[gi_channel_count].i_allow_mod_count = 0;
        gi_channel_count++;
    }
    //End Add

    for(i = 0; i < gi_channel_count; i++)
    {
        if(ga_channel_mod[i].c_tune_mode == 'D')
        {
            CMessage_create_server(ga_channel_mod[i].s_channel, gs_subno, &status_val, status_msg, ga_channel_mod[i].i_scheduler_weight, ga_channel_mod[i].d_heartbeat_interval, ga_channel_mod[i].d_activate_interval);
            if( status_val != CMESSAGE_SUCCESS )
            {
                CMessage_get_description(status_msg, s_cmessage_error_desc);

                LOG_head("CMessage_create_server()");
                LOG_add("status_code", MP_NSTR, status_msg);
                LOG_add("status_cmessage_error_desc", MP_NSTR, s_cmessage_error_desc);
                COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

                sprintf(s_msg, "CMessage_create_server returns with error\nsubject=[%s]\nstatus_val=[%d]\nstatus_msg=[%.*s]\nstatus_cmessage_error_desc=[%s] !\n", 
                                ga_channel_mod[i].s_channel, status_val, SIZE_MSG, status_msg, s_cmessage_error_desc );
                CMessage_terminate( &status_val, status_msg );
                MAIN_display_error(s_msg);
                return MP_FALSE;
            }
        }
        else if(ga_channel_mod[i].c_tune_mode == 'S')
        {
            CMessage_start_subscribe(ga_channel_mod[i].s_channel, &status_val, status_msg);
            if( status_val != CMESSAGE_SUCCESS )
            {
                CMessage_get_description(status_msg, s_cmessage_error_desc);

                LOG_head("CMessage_start_subscribe()");
                LOG_add("status_code", MP_NSTR, status_msg);
                LOG_add("status_cmessage_error_desc", MP_NSTR, s_cmessage_error_desc);
                COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

                sprintf(s_msg, "CMessage_start_subscribe returns with error\nsubject=[%s]\nstatus_val=[%d]\nstatus_msg=[%.*s]\nstatus_cmessage_error_desc=[%s] !\n", 
                               ga_channel_mod[i].s_channel, status_val, SIZE_MSG, status_msg, s_cmessage_error_desc );
                CMessage_terminate( &status_val, status_msg );
                MAIN_display_error(s_msg);
                return MP_FALSE;
            }
        }
    }
    
    CMessage_startup_server(message_callback, &status_val, status_msg);
    if( status_val != CMESSAGE_SUCCESS )
    {
        CMessage_get_description(status_msg, s_cmessage_error_desc);

        LOG_head("CMessage_startup_server()");
        LOG_add("status_code", MP_NSTR, status_msg);
        LOG_add("status_cmessage_error_desc", MP_NSTR, s_cmessage_error_desc);
        COM_log_write(MP_LOG_ERROR, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);

        sprintf(s_msg, "CMessage_startup_server returns with error\nstatus_val=[%d]\nstatus_msg=[%.*s]\nstatus_cmessage_error_desc=[%s] !\n", status_val, SIZE_MSG, status_msg, s_cmessage_error_desc );
        CMessage_terminate( &status_val, status_msg );
        MAIN_display_error(s_msg);
        return MP_FALSE;
    }

#endif

    /* for MOA.call_service() */
    gi_default_ttl = XGEN_DEFAULT_TTL;

    /* Write log */
    LOG_head("### Success message bus Connection !!!");
    COM_log_write(MP_LOG_SYSTEM, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

    return MP_TRUE;
}

/*******************************************************************************
    MAIN_get_env_values()
        - Get Environment values from INI file or Registry
    Return Value
        - int : TRUE or FALSE
    Arguments
        - char *s_ret : Return Value for failed environment name
    Special Logic Notes  : Environment Lists
        + DB Username
        + DB Password
        + TNS Name
        + Use Local DB flag
        + Customer
        + Site ID
        + Facility
        + Nodename
        + Channel name
        + Server Name
        + Bay ID
        + Log Level
        + Log File Size
        + Log File Count
        + Default Language
*******************************************************************************/
void TRS_decrypt(char *dest, const char *src);

int MAIN_get_env_values(char *s_ret)
{
    int i_len;
    int i_ret;
    char s_com_file[256];
    char s_svr_file[256];
    char value[10000];

	//Add by J.S. 2011.11.21 for DST
	int i_pos;
	int i_cur_pos;
	char s_temp[100];
	char s_localtime[14], s_utctime[14];
	int i_isdst, i_diff_sec;

    memset(s_com_file, '\0', sizeof(s_com_file));
    memset(s_svr_file, '\0', sizeof(s_svr_file));
    
    /**** Get INI File Name ****/
    COM_get_init_file(s_appl_name, s_com_file, s_svr_file);
    if(s_com_file[0] == '\0') 
    {
        sprintf(s_ret, "INI File");
        return MP_FALSE;
    }
    strcpy(gs_com_file, s_com_file);
    strcpy(gs_svr_file, s_svr_file);

    /**** Environment : Channel information ****/
    if(MAIN_get_channel_info(s_ret) == MP_FALSE)
        return MP_FALSE;

    /**** Environment : Directories ****/
    /* Home Directory */
    memset(gs_home_dir, '\0', sizeof(gs_home_dir));
    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusHomeDir", gs_home_dir, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "MESplusHomeDir");
        return MP_FALSE;
    }    

#if defined(WIN32) || defined(WIN64)
    if(gs_home_dir[i_len - 1] != '\\')
    {
        strcat(gs_home_dir, "\\");
        i_len = i_len + 1;
    }
#else
    if(gs_home_dir[i_len - 1] != '/') 
    {
        strcat(gs_home_dir, "/");
        i_len = i_len + 1;
    }
#endif

    /* Command Directory */
    memset(gs_command_dir, '\0', sizeof(gs_command_dir));
    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusCommandDir", gs_command_dir, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "MESplusCommandDir");
        return MP_FALSE;
    }    

#if defined(WIN32) || defined(WIN64)
    if(gs_command_dir[i_len - 1] != '\\')
    {
        strcat(gs_command_dir, "\\");
        i_len = i_len + 1;
    }
#else
    if(gs_command_dir[i_len - 1] != '/') 
    {
        strcat(gs_command_dir, "/");
        i_len = i_len + 1;
    }
#endif

    /* Bin Directory */
    memset(gs_bin_dir, '\0', sizeof(gs_bin_dir));
    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusBinDir", gs_bin_dir, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "MESplusBinDir");
        return MP_FALSE;
    }

#if defined(WIN32) || defined(WIN64)
    if(gs_bin_dir[i_len - 1] != '\\') 
    {
        strcat(gs_bin_dir, "\\");
        i_len = i_len + 1;
    }
#else
    if(gs_bin_dir[i_len - 1] != '/') 
    {
        strcat(gs_bin_dir, "/");
        i_len = i_len + 1;
    }
#endif

    /* Temp Directory */
    memset(gs_temp_dir, '\0', sizeof(gs_temp_dir));
    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusTempDir", gs_temp_dir, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "MESplusTempDir");
        return MP_FALSE;
    }

#if defined(WIN32) || defined(WIN64)
    if(gs_temp_dir[i_len - 1] != '\\') 
    {
        strcat(gs_temp_dir, "\\");
        i_len = i_len + 1;
    }
#else
    if(gs_temp_dir[i_len - 1] != '/') 
    {
        strcat(gs_temp_dir, "/");
        i_len = i_len + 1;
    }
#endif

    /* Shared Library Directory */
    memset(gs_slib_dir, '\0', sizeof(gs_slib_dir));
    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusSLibDir", gs_slib_dir, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "MESplusSLibDir");
        return MP_FALSE;
    }

#if defined(WIN32) || defined(WIN64)
    if(gs_slib_dir[i_len - 1] != '\\') 
    {
        strcat(gs_slib_dir, "\\");
        i_len = i_len + 1;
    }
#else
    if(gs_slib_dir[i_len - 1] != '/') 
    {
        strcat(gs_slib_dir, "/");
        i_len = i_len + 1;
    }
#endif

//    /* Upgrade Directory */
//    memset(gs_upgrade_dir, '\0', sizeof(gs_upgrade_dir));
//    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusUpgradeDir", gs_upgrade_dir, &i_len);
//    if(i_ret == MP_FALSE)
//    {
//        sprintf(s_ret, "MESplusUpgradeDir");
//        return MP_FALSE;
//    }
//    /* 만약 Upgrade 위치를 UNIX로 정하는 경우를 대비하여 '/'허용. */
//#if defined(WIN32) || defined(WIN64)
//    if(gs_upgrade_dir[i_len-1] != '\\' &&  gs_upgrade_dir[i_len-1] != '/')
//    {
//        strcat(gs_upgrade_dir, "\\");
//        i_len = i_len + 1;
//    }
//#else
//    if(gs_upgrade_dir[i_len-1] != '/')
//    {
//        strcat(gs_upgrade_dir, "/");
//        i_len = i_len + 1;
//    }
//#endif

    /* Screen Directory */
    memset(gs_screen_dir, '\0', sizeof(gs_screen_dir));
    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusScreenDir", gs_screen_dir, &i_len);
    if(i_ret == MP_TRUE)
    {
#if defined(WIN32) || defined(WIN64)
        if(gs_screen_dir[i_len - 1] != '\\') 
        {
            strcat(gs_screen_dir, "\\");
            i_len = i_len + 1;
        }
#else
        if(gs_screen_dir[i_len - 1] != '/') 
        {
            strcat(gs_screen_dir, "/");
            i_len = i_len + 1;
        }
#endif
    }

	/* Document Template Directory */
    memset(gs_doctemp_dir, '\0', sizeof(gs_doctemp_dir));
    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusDocTempDir", gs_doctemp_dir, &i_len);
    if(i_ret == MP_TRUE)
    {
#if defined(WIN32) || defined(WIN64)
        if(gs_doctemp_dir[i_len - 1] != '\\') 
        {
            strcat(gs_doctemp_dir, "\\");
            i_len = i_len + 1;
        }
#else
        if(gs_doctemp_dir[i_len - 1] != '/') 
        {
            strcat(gs_doctemp_dir, "/");
            i_len = i_len + 1;
        }
#endif
    }

    /* Alarm Attach Directory */
    memset(gs_alm_attach_dir, '\0', sizeof(gs_alm_attach_dir));
    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusAlarmAttachDir", gs_alm_attach_dir, &i_len);
    if(i_ret == MP_TRUE)
    {
#if defined(WIN32) || defined(WIN64)
        if(gs_alm_attach_dir[i_len - 1] != '\\') 
        {
            strcat(gs_alm_attach_dir, "\\");
            i_len = i_len + 1;
        }
#else
        if(gs_alm_attach_dir[i_len - 1] != '/') 
        {
            strcat(gs_alm_attach_dir, "/");
            i_len = i_len + 1;
        }
#endif
    }

    /* BBS Attach Directory */
    memset(gs_bbs_attach_dir, '\0', sizeof(gs_bbs_attach_dir));
    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusBBSAttachDir", gs_bbs_attach_dir, &i_len);
    if(i_ret == MP_TRUE)
    {
#if defined(WIN32) || defined(WIN64)
        if(gs_bbs_attach_dir[i_len - 1] != '\\') 
        {
            strcat(gs_bbs_attach_dir, "\\");
            i_len = i_len + 1;
        }
#else
        if(gs_bbs_attach_dir[i_len - 1] != '/') 
        {
            strcat(gs_bbs_attach_dir, "/");
            i_len = i_len + 1;
        }
#endif
    }

	/*** #989 SPM Development (2012.04.26 by JYPARK) ***/
	/* Spec Attach Directory */
	memset(gs_spec_attach_dir, '\0', sizeof(gs_spec_attach_dir));
	i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusSpecAttachDir", gs_spec_attach_dir, &i_len);
	if(i_ret == MP_TRUE)
	{
#if defined(WIN32) || defined(WIN64)
		if(gs_spec_attach_dir[i_len - 1] != '\\') 
		{
			strcat(gs_spec_attach_dir, "\\");
			i_len = i_len + 1;
		}
#else
		if(gs_spec_attach_dir[i_len - 1] != '/') 
		{
			strcat(gs_spec_attach_dir, "/");
			i_len = i_len + 1;
		}
#endif
	}
	/*** End of Add (2012.04.26) ***/

	/* Work Process Status Attach Directory */
	memset(gs_work_proc_status_attach_dir, '\0', sizeof(gs_work_proc_status_attach_dir));
	i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusWorkProcStatusAttachDir", gs_work_proc_status_attach_dir, &i_len);
	if(i_ret == MP_TRUE)
	{
#if defined(WIN32) || defined(WIN64)
		if(gs_work_proc_status_attach_dir[i_len - 1] != '\\') 
		{
			strcat(gs_work_proc_status_attach_dir, "\\");
			i_len = i_len + 1;
		}
#else
		if(gs_work_proc_status_attach_dir[i_len - 1] != '/') 
		{
			strcat(gs_work_proc_status_attach_dir, "/");
			i_len = i_len + 1;
		}
#endif
	}

    /**** Environment : Database ****/
    /* DB User */
    i_len = 0;
    memset(gs_database_user, 0x00, sizeof(gs_database_user));
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "DatabaseUID", value, &i_len);

    if(i_ret == MP_TRUE && i_len > 0)
    {
        char s_dest[10000];
        memset(s_dest, 0x00, sizeof(s_dest));
        value[i_len] = 0x00;

        TRS_decrypt(s_dest, value);
        i_len = strlen(s_dest);
        strcpy(value, s_dest);
    }
    memcpy(gs_database_user, value, i_len);

    /* DB Password */
    memset(gs_database_password, 0x00, sizeof(gs_database_password));
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "DatabasePWD", value, &i_len);

    if(i_ret == MP_TRUE && i_len > 0)
    {
        char s_dest[10000];
        memset(s_dest, 0x00, sizeof(s_dest));
        value[i_len] = 0x00;

        TRS_decrypt(s_dest, value);
        i_len = strlen(s_dest);
        strcpy(value, s_dest);
    }
    memcpy(gs_database_password, value, i_len);

    /* DB TNS name */
    memset(gs_tns_name, 0x00, sizeof(gs_tns_name));
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "DatabaseTNS", value, &i_len);
    memcpy(gs_tns_name, value, i_len);
 
    /* Use Local DB */
    gc_use_local_db = 0;
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "DatabaseUseLocalDB", value, &i_len);
    gc_use_local_db = value[0];

    if(gs_database_user[0] == 0x00 || gs_database_password[0] == 0x00 || gs_tns_name[0] == 0x00)
    {
        /* DB User */
        memset(gs_database_user, 0x00, sizeof(gs_database_user));
        memset(value, ' ', sizeof(value));
        i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusUID", value, &i_len);
        if(i_ret == MP_FALSE) 
        {
            sprintf(s_ret, "MESplusUID");
            return MP_FALSE;
        }

        {
            char s_dest[10000];
            memset(s_dest, 0x00, sizeof(s_dest));
            value[i_len] = 0x00;

            TRS_decrypt(s_dest, value);
            i_len = strlen(s_dest);
            strcpy(value, s_dest);
        }
        memcpy(gs_database_user, value, i_len);

        /* DB Password */
        memset(gs_database_password, 0x00, sizeof(gs_database_password));
        memset(value, ' ', sizeof(value));
        i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusPWD", value, &i_len);
        if(i_ret == MP_FALSE)
        {
            sprintf(s_ret, "MESplusPWD");
            return MP_FALSE;
        }

        {
            char s_dest[10000];
            memset(s_dest, 0x00, sizeof(s_dest));
            value[i_len] = 0x00;

            TRS_decrypt(s_dest, value);
            i_len = strlen(s_dest);
            strcpy(value, s_dest);
        }
        memcpy(gs_database_password, value, i_len);

        /* DB TNS name */
        memset(gs_tns_name, 0x00, sizeof(gs_tns_name));
        memset(value, ' ', sizeof(value));
        i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusTNS", value, &i_len);
        if(i_ret == MP_FALSE) 
        {
            sprintf(s_ret, "MESplusTNS");
            return MP_FALSE;
        }
        memcpy(gs_tns_name, value, i_len);
     
        /* Use Local DB */
        gc_use_local_db = 0;
        memset(value, ' ', sizeof(value));
        i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusUseLocalDB", value, &i_len);
        if(i_ret == MP_FALSE) 
        {
            sprintf(s_ret, "MESplusUseLocalDB");
            return MP_FALSE;
        }
        gc_use_local_db = value[0];
    }

    ///* Label Remote Connect */
    //memset(value, ' ', sizeof(value));
    //i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusLabelRemoteConnect", value, &i_len);
    //gc_label_remote_connected = value[0];


    /**** Environment : Server ****/
    /* Site ID */
    memset(value, ' ', sizeof(value));
    memset(gs_site_id, 0x00, sizeof(gs_site_id));
    i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusSiteID", value, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "MESplusSiteID");
        return MP_FALSE;
    }
    memcpy(gs_site_id, value, i_len);


    /**** Environment : Middleware ****/
    /* Connect String */
    memset(value, ' ', sizeof(value));
    memset(gs_connect_string, 0x00, sizeof(gs_connect_string));
    i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusConnectString", value, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "MESplusConnectString");
        return MP_FALSE;
    } 
    memcpy(gs_connect_string, value, i_len);

    /* H101 Inter Station Mode Connetion */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusH101InterStationMode", value, &i_len);
    gc_h101_inter_station_mode = value[0];


#if defined(_TIBRV)

    /* Service Port */
    memset(value, ' ', sizeof(value));
    memset(gs_rv_service, 0x00, sizeof(gs_rv_service));
    i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusTibRvService", value, &i_len);
    if(i_ret == MP_TRUE) 
    {
        memcpy(gs_rv_service, value, i_len);
    } 

    /* Network */
    memset(value, ' ', sizeof(value));
    memset(gs_rv_network, 0x00, sizeof(gs_rv_network));
    i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusTibRvNetwork", value, &i_len);
    if(i_ret == MP_TRUE) 
    {
        memcpy(gs_rv_network, value, i_len);
    } 

#endif

    ///**** Environment : Client Upgrade ****/
    ///* Upgrade Program Version */
    //memset(value, ' ', sizeof(value));
    //i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusUpgradeVersion", value, &i_len);
    //if(i_ret == MP_FALSE) 
    //{
    //    sprintf(s_ret, "MESplusUpgradeVersion");
    //    return MP_FALSE;
    //}
    //memcpy(gs_upgrade_version, value, sizeof(gs_upgrade_version));

    ///* Upgrade Method */
    //memset(value, ' ', sizeof(value));
    //i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusUpgradeMethod", value, &i_len);
    //if(i_ret == MP_FALSE) 
    //{
    //    sprintf(s_ret, "MESplusUpgradeMethod");
    //    return MP_FALSE;
    //}
    //memcpy(gs_upgrade_method, value, sizeof(gs_upgrade_method));

    ///* FTP */
    //if(memcmp(gs_upgrade_method, "FTP", 3) == 0)
    //{
    //    /* FTP Server IP Address */
    //    memset(value, ' ', sizeof(value));
    //    i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusUpgradeAddress", value, &i_len);
    //    if(i_ret == MP_FALSE) 
    //    {
    //        sprintf(s_ret, "MESplusUpgradeAddress");
    //        return MP_FALSE;
    //    }
    //    memcpy(gs_upgrade_address, value, sizeof(gs_upgrade_address));

    //    /* FTP User ID */
    //    memset(value, ' ', sizeof(value));
    //    i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusUpgradeUser", value, &i_len);
    //    if(i_ret == MP_FALSE) 
    //    {
    //        sprintf(s_ret, "MESplusUpgradeUser");
    //        return MP_FALSE;
    //    }
    //    memcpy(gs_upgrade_user, value, sizeof(gs_upgrade_user));

    //    /* FTP Password */
    //    memset(value, ' ', sizeof(value));
    //    i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusUpgradePassword", value, &i_len);
    //    if(i_ret == MP_FALSE)
    //    {
    //        sprintf(s_ret, "MESplusUpgradePassword");
    //        return MP_FALSE;
    //    }
    //    memcpy(gs_upgrade_password, value, sizeof(gs_upgrade_password));

    //} 
    //else 
    //{
    //    memset(gs_upgrade_address, ' ', sizeof(gs_upgrade_address));
    //    memset(gs_upgrade_user, ' ', sizeof(gs_upgrade_user));
    //    memset(gs_upgrade_password, ' ', sizeof(gs_upgrade_password));
    //}

    /* Server Name */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "ServerName", value, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "ServerName");
        return MP_FALSE;
    }
    memcpy(gs_server_name, value, sizeof(gs_server_name));


    /**** Environment : Log Option ****/
    /* Log Directory */
    memset(gs_log_file_dir, '\0', sizeof(gs_log_file_dir));
    i_ret = COM_get_init_value(s_com_file, "Directories", "MESplusLogDir", gs_log_file_dir, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "MESplusLogDir");
        return MP_FALSE;
    }
    /* 만약 Upgrade 위치를 UNIX로 정하는 경우를 대비하여 '/'허용. */
#if defined(WIN32) || defined(WIN64)
    if(gs_log_file_dir[i_len-1] != '\\' &&  gs_log_file_dir[i_len-1] != '/') 
    {
        strcat(gs_log_file_dir, "\\");
        i_len = i_len + 1;
    }
#else
    if(gs_log_file_dir[i_len-1] != '/') 
    {
        strcat(gs_log_file_dir, "/");
        i_len = i_len + 1;
    }
#endif

    

    /* Log File Size */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "LogFileSize", value, &i_len);
    gi_log_file_size = COM_atoi(value, i_len);

    /* Number of Log File */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "LogFileCount", value, &i_len);
    gi_log_file_count = COM_atoi(value, i_len);

    /* Log Level */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "LogLevel", value, &i_len);
    gi_log_level = COM_atoi(value, i_len);
    /* LogLevel = 0 은 Debug로 사용 */
    if(gi_log_level < 0) {
        gi_log_level = 1;    /* Write All Log except debug */
    }
    i_system_log_level = gi_log_level;

    /* Added by lake Kim (2004/11/12) */
    /* gi_log_mode 1번은 Log파일 하나를 공유하여 사용하고, gi_log_mode 2번은 Subno별로 Log파일을 사용한다. */
    /* Log Mode */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "LogMode", value, &i_len);
    gi_log_mode = COM_atoi(value, i_len);
    if(gi_log_mode <= 0) {
        gi_log_mode = 1;    /* Write Error Only */
    }
    /* End of Add */

    /* Added by Aiden.Koo. 2012.08.02. for Logging SQL Query Interval Time */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "LogFromIntervalTimeOfQuery", value, &i_len);
    gd_from_interval_time_for_logging_query = COM_atof(value, i_len);
    if(gd_from_interval_time_for_logging_query <= 0) {
        gd_from_interval_time_for_logging_query = 1;    // It logging interval time for SQL query when it from 1 seconds.
    }

    /* Max_XML_Message_Length */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "MaxMsgLength", value, &i_len);
    gi_max_message_length = COM_atoi(value, i_len);
    if(gi_max_message_length <= 900000) {
        gi_max_message_length = MP_DEFAULT_MSG_LENGTH;
    }
    else if(gi_max_message_length > (MP_MAX_MSG_LENGTH - 10000)) {
        gi_max_message_length = MP_MAX_MSG_LENGTH - 10000;
    }

    /* Added by ICBAE 2010.05.06 */
    /* Request XML 로그 옵션 */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "LogWriteXML", value, &i_len);
    gc_write_request_xml = value[0];

    /* Added by ICBAE 2010.06.23 */
    /* Add time to log file name */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "LogFileByTime", value, &i_len);
    gc_log_file_by_time = value[0];

    ///* Added by ICBAE 2011.05.30 */
    ///* EDC Option - Use Spec Out Mask Character */
    //memset(value, ' ', sizeof(value));
    //i_ret = COM_get_init_value(s_svr_file, "StartOption", "UseSpecOutMaskCharacter", value, &i_len);
    //if (i_ret == MP_FALSE)
    //{
    //    gc_use_spec_out_mask_char = '_';
    //}
    //else
    //{
    //    gc_use_spec_out_mask_char = value[0];
    //}

    /* Add 2008.06.03. by Aiden. */
    /* Get Shared Library Pool Count */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusSharedLibPoolCount", value, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "MESplusSharedLibPoolCount");
        return MP_FALSE;
    }
    gi_max_shared_pool_count = COM_atoi(value, i_len);
    SLP_init_pool(gi_max_shared_pool_count);


    /* Add 2009 .02.16. by Phillip */
    /* Get Default Language Option */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_com_file, "Basic", "MESplusLanguage", value, &i_len);
    if(i_ret == MP_FALSE)
    {
        gc_language_type = '1';
    }
    else
    {            
        gc_language_type = value[0];
    }

    /* Unicode <-> Ansi code converting character locale */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CharacterLocale", value, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "CharacterLocale");
        return MP_FALSE;
    }
    value[i_len] = 0x00;
    TRS_set_char_locale(value);

    /* Set validate xml value flag */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "ValidateXMLValue", value, &i_len);
    TRS_set_xml_value_validation(value[0]);

    /* Set time zone offset */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "TimeZoneOffSet", value, &i_len);
    value[i_len] = 0x00;
	memcpy(gs_time_zone_offset, value, sizeof(gs_time_zone_offset));
	//Add by J.S. 2011.12.07 for DST
	if(gs_time_zone_offset[0] != 0x00)
	{
		//format check
		if(gs_time_zone_offset[0] != '+' && gs_time_zone_offset[0] != '-')
		{
            sprintf(s_ret, "TimeZoneOffSet(invalid format)");
            return MP_FALSE;
		}
		if(COM_isdigit(gs_time_zone_offset + 1, 4) == MP_FALSE)
		{
            sprintf(s_ret, "TimeZoneOffSet(invalid format)");
            return MP_FALSE;
		}
	}
	else
	{
		memset(gs_time_zone_offset, 0x0, sizeof(gs_time_zone_offset));
		//calulate offset
        COM_get_local_utc_time_dst(s_localtime, s_utctime, &i_isdst);
        COM_diff_time_sec(&i_diff_sec, s_localtime, s_utctime);

		//DST적용중일때는 GMT에서 1시간더 멀어짐으로 1시간을 빼준다. s_time_zone_offset에는 DST 적용전 시간 설정.
		if(i_isdst > 0)
		{
			i_diff_sec = i_diff_sec - 3600;
		}

		if(i_diff_sec >= 0)
		{
			gs_time_zone_offset[0] = '+';
		}
		else
		{
			gs_time_zone_offset[0] = '-';
			i_diff_sec = i_diff_sec * -1;
		}

		COM_itoa_zero(gs_time_zone_offset + 1, (int)(i_diff_sec / 3600), 2);
		COM_itoa_zero(gs_time_zone_offset + 3, (int)((i_diff_sec % 3600) / 60), 2);

	}
    TRS_set_time_zone_offset(gs_time_zone_offset);


	//Add by J.S. 2011.11.21 for DST Time Compress 여부 및 DST 종료시간, DATE넘길때 짧은 XML 형식 사용여부
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "DSTTimeCompress", value, &i_len);
    gc_DST_time_compress = value[0];

    memset(gs_DST_end_time, ' ', sizeof(gs_DST_end_time));
	if(gc_DST_time_compress == 'Y')
	{
		//"10 SECOND MON 03" 형태로 만듬 나중에 size로 잘라서 사용하게 만들어 놓음. 
        memset(value, ' ', sizeof(value));
        i_ret = COM_get_init_value(s_svr_file, "StartOption", "DSTEndTime", value, &i_len);
        if(i_ret == MP_FALSE) 
        {
            sprintf(s_ret, "DSTEndTime");
            return MP_FALSE;
        }

		i_cur_pos = 0;
		i_pos = COM_search_string(value + i_cur_pos, (int)strlen(value) - i_cur_pos, "/", (int)strlen("/"));
		if(i_pos < 0)
		{
            sprintf(s_ret, "DSTEndTime(MONTH)");
            return MP_FALSE;
		}

		memset(s_temp, 0x0, sizeof(s_temp));
		memcpy(s_temp, value + i_cur_pos, i_pos);
		if(COM_atoi(s_temp, (int)strlen(s_temp)) < 1 || COM_atoi(s_temp, (int)strlen(s_temp)) > 12)
		{
            sprintf(s_ret, "DSTEndTime(MONTH)");
            return MP_FALSE;
		}
		COM_itoa_zero(gs_DST_end_time, COM_atoi(s_temp, (int)strlen(s_temp)), 2);

		i_cur_pos = i_cur_pos + i_pos + 1;
		i_pos = COM_search_string(value + i_cur_pos, (int)strlen(value) - i_cur_pos, "/", (int)strlen("/"));
		if(i_pos < 0)
		{
            sprintf(s_ret, "DSTEndTime(FIRST~LAST)");
            return MP_FALSE;
		}

		memset(s_temp, 0x0, sizeof(s_temp));
		memcpy(s_temp, value + i_cur_pos, i_pos);
		if(strcmp(s_temp, "FIRST") != 0 && strcmp(s_temp, "SECOND") != 0 && strcmp(s_temp, "THIRD") != 0 && strcmp(s_temp, " FOURTH") != 0 && strcmp(s_temp, "LAST") != 0)
		{
            sprintf(s_ret, "DSTEndTime(FIRST~LAST)");
            return MP_FALSE;
		}
		memcpy(gs_DST_end_time+3, s_temp, strlen(s_temp));

		i_cur_pos = i_cur_pos + i_pos + 1;
		i_pos = COM_search_string(value + i_cur_pos, (int)strlen(value) - i_cur_pos, " ", (int)strlen(" "));
		if(i_pos < 0)
		{
            sprintf(s_ret, "DSTEndTime(WEEK)");
            return MP_FALSE;
		}

		memset(s_temp, 0x0, sizeof(s_temp));
		memcpy(s_temp, value + i_cur_pos, i_pos);
		if(strcmp(s_temp, "SUN") != 0 && strcmp(s_temp, "MON") != 0 && strcmp(s_temp, "TUE") != 0 && strcmp(s_temp, "WED") != 0 && 
		   strcmp(s_temp, "THU") != 0 && strcmp(s_temp, "FRI") != 0 && strcmp(s_temp, "SAT") != 0)
		{
            sprintf(s_ret, "DSTEndTime(WEEK)");
            return MP_FALSE;
		}
		memcpy(gs_DST_end_time+10, s_temp, strlen(s_temp));

		i_cur_pos = i_cur_pos + i_pos + 1;
		memset(s_temp, 0x0, sizeof(s_temp));
		memcpy(s_temp, value + i_cur_pos, strlen(value) - i_cur_pos);
		if(COM_atoi(s_temp, (int)strlen(s_temp)) < 0 || COM_atoi(s_temp, (int)strlen(s_temp)) > 23)
		{
            sprintf(s_ret, "DSTEndTime(HOUR)");
            return MP_FALSE;
		}
		COM_itoa_zero(gs_DST_end_time+14, COM_atoi(s_temp, (int)strlen(s_temp)), 2);
	}
	DB_set_DST_option(gc_DST_time_compress, gs_DST_end_time, gs_time_zone_offset);

    /* Set time zone offset ignore */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "TimeZoneOffSetIgnore", value, &i_len);
    TRS_set_time_zone_offset_ignore(value[0]);

	/*short XML date format */
	memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "ShortXMLDateFormat", value, &i_len);
    gc_short_XML_date_format = value[0];
	TRS_set_short_XML_date_format(gc_short_XML_date_format);
	//End Add


    /* Set case sensitive flag for member name */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CaseSensitiveName", value, &i_len);
    gc_case_sensitive_member_name = value[0];
    TRS_set_case_sensitive_name(gc_case_sensitive_member_name);

    /* Set not use iconvert encoding change method */
/* OSS 검증으로 주석처리함 */
//***/    memset(value, ' ', sizeof(value));
//***/    i_ret = COM_get_init_value(s_svr_file, "StartOption", "NotUseIconvMethod", value, &i_len);
//***/    TRS_set_not_use_iconv_method(value[0]);


    /* Set use common prologue/epilogue shared library */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "UseProEpiCommonSharedLibrary", value, &i_len);
    gc_use_pro_epi_shared_library = value[0];

    /* Set use custom xml format */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "UseCustomXMLFormat", value, &i_len);
    gc_use_custom_xml_format = value[0];

    /* Set check memory allocation */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CheckMemoryAllocation", value, &i_len);
    COM_set_mem_check_flag(value[0]);

    /*
    2009.05.19. Aiden
    Carrier 와 LOT 의 Relation 을 정의하기 위한 Global Variable
    현재는 0 의 값을 사용하여 Carrier의 QTY_2, QTY_3 를 따로 관리 하지 않는다.
    향후 보완하여 Option 별로 처리할 수 있도록 한다.
    */
    gi_carrier_lot_relation = 0;

    //Add by J.S. 2011.10.20 for Service 실행 통계, 에러 로깅 
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CollectPerformanceInfo", value, &i_len);
    gc_collect_performance_info = value[0];

    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CollectErrorLogging", value, &i_len);
    gc_collect_error_logging = value[0];

    memset(value, ' ', sizeof(value));
    gi_collect_time_limit_sec = -1;
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CollectTimeLimitSec", value, &i_len);
    if(i_ret == MP_TRUE)
    {
        gi_collect_time_limit_sec = COM_atoi(value, i_len);
    }

    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CollectNode", value, &i_len);
    memcpy(gs_collect_node, value, sizeof(gs_collect_node));

    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CollectTableSpaceIncreaseInfo", value, &i_len);
    gc_collect_table_space_inc_info = value[0];

    memset(value, ' ', sizeof(value));
    gi_collect_table_space_check_size = -1;
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CollectTableSpaceCheckSize", value, &i_len);
    if(i_ret == MP_TRUE)
    {
        gi_collect_table_space_check_size = COM_atoi(value, i_len);
    }

    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CollectLongQueryRankingInfo", value, &i_len);
    gc_collect_long_query_ranking_info = value[0];

    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CollectLongQueryRankingType", value, &i_len);
    gc_collect_long_query_ranking_type = value[0];

    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "CollectSQLTraceInfo", value, &i_len);
    gc_DB_collect_sql_trace = value[0];


    /* Added by ICBAE 2012.06.13 */
    /* WinForm Log Max Line Count Option */
#if defined(WIN32) || defined(WIN64)
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "WinLogMaxLineCount", value, &i_len);
    if (i_ret == MP_FALSE)
    {
        gi_max_line_count = MP_MAX_LINE_COUNT;
    }
    else
    {
        gi_max_line_count = COM_atoi(value, i_len);
    }

	/* Added By YJJung 160802 */
	/* Number of Max Windows in a row */
    memset(value, ' ', sizeof(value));
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "MaxWindowsInRow", value, &i_len);
	if (i_ret == MP_FALSE)
    {
        gi_max_windows_in_row = MP_MAX_WINDOWS_H;
    }
    else
    {
        gi_max_windows_in_row = COM_atoi(value, i_len);
    }
	
	/* Whether to hide the window of MES Server */
	memset(value, ' ', sizeof(value));
	i_ret = COM_get_init_value(s_svr_file, "StartOption", "HideServerWindow", value, &i_len);
	gc_hide_server_window = value[0];

#endif


    /*********************************/
    /* Global Variable for BATServer */
    memset(value, ' ', sizeof(value));
    gi_batch_server_count = 0;
    i_ret = COM_get_init_value(s_svr_file, "StartOption", "BatchServerCount", value, &i_len);
    if(i_ret == MP_TRUE)
    {
        gi_batch_server_count = COM_atoi(value, i_len);
    }
    if(gi_batch_server_count < 1)
    {
        gi_batch_server_count = 1;
    }


    return MP_TRUE;
}

/*******************************************************************************
    MAIN_get_channel_info()
        - Get channel information from MESServer.ini
    Return Value
    Arguments
*******************************************************************************/
int MAIN_get_channel_info(char *s_ret)
{
    int i_len;
    int i_ret;
    char value[10000];

    /* Main Request Reply Channel Name */
    memset(value, ' ', sizeof(value));
    i_len = 0;
    memset(gs_main_channel, 0x00, sizeof(gs_main_channel));
    i_ret = COM_get_init_value(gs_svr_file, "StartOption", "MainChannel", value, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "MainChannel");
        return MP_FALSE;
    }
    memcpy(gs_main_channel, value, i_len);


#if defined(_TIBRV)
    if(gs_main_channel[0] == '/')
    {
        int i_idx;
        char s_tmp[MP_SIZE_CHANNEL];

        memset(s_tmp, 0x00, sizeof(s_tmp));
        for(i_idx = 1; i_idx < MP_SIZE_CHANNEL; i_idx++)
        {
            if(gs_main_channel[i_idx] == 0x00)
                break;

            if(gs_main_channel[i_idx] == '/')
                s_tmp[i_idx - 1] = '.';
            else
                s_tmp[i_idx - 1] = gs_main_channel[i_idx];
        }
        strcpy(gs_main_channel, s_tmp);
    }
#endif

    /* Allow Module List */
    memset(value, ' ', sizeof(value));
    i_len = 0;
    memset(s_allow_module, 0x00, sizeof(s_allow_module));
    i_ret = COM_get_init_value(gs_svr_file, "StartOption", "AllowModuleList", value, &i_len);
    memcpy(s_allow_module, value, i_len);

    /* Stop Channel */
    memset(value, ' ', sizeof(value));
    i_len = 0;
    memset(gs_stop_channel, 0x00, sizeof(gs_stop_channel));
    i_ret = COM_get_init_value(gs_svr_file, "StartOption", "StopChannel", value, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "StopChannel");
        return MP_FALSE;
    }
    memcpy(gs_stop_channel, value, i_len);

#if defined(_TIBRV)
    if(gs_stop_channel[0] == '/')
    {
        int i_idx;
        char s_tmp[MP_SIZE_CHANNEL];

        memset(s_tmp, 0x00, sizeof(s_tmp));
        for(i_idx = 1; i_idx < MP_SIZE_CHANNEL; i_idx++)
        {
            if(gs_stop_channel[i_idx] == 0x00)
                break;

            if(gs_stop_channel[i_idx] == '/')
                s_tmp[i_idx - 1] = '.';
            else
                s_tmp[i_idx - 1] = gs_stop_channel[i_idx];
        }
        strcpy(gs_stop_channel, s_tmp);
    }
#endif


    /* Admin Channel */
    memset(value, ' ', sizeof(value));
    i_len = 0;
    memset(gs_admin_channel, 0x00, sizeof(gs_admin_channel));
    i_ret = COM_get_init_value(gs_svr_file, "StartOption", "AdminChannel", value, &i_len);
    if(i_ret == MP_FALSE) 
    {
        sprintf(s_ret, "AdminChannel");
        return MP_FALSE;
    }
    memcpy(gs_admin_channel, value, i_len);

#if defined(_TIBRV)
    if(gs_admin_channel[0] == '/')
    {
        int i_idx;
        char s_tmp[MP_SIZE_CHANNEL];

        memset(s_tmp, 0x00, sizeof(s_tmp));
        for(i_idx = 1; i_idx < MP_SIZE_CHANNEL; i_idx++)
        {
            if(gs_admin_channel[i_idx] == 0x00)
                break;

            if(gs_admin_channel[i_idx] == '/')
                s_tmp[i_idx - 1] = '.';
            else
                s_tmp[i_idx - 1] = gs_admin_channel[i_idx];
        }
        strcpy(gs_admin_channel, s_tmp);
    }
#endif

    /* Extra Channel */
    memset(value, ' ', sizeof(value));
    i_len = 0;
    memset(s_extra_channel, 0x00, sizeof(s_extra_channel));
    i_ret = COM_get_init_value(gs_svr_file, "StartOption", "ExtraChannel", value, &i_len);
    memcpy(s_extra_channel, value, i_len);

#if defined(_TIBRV)
    if(s_extra_channel[0] == '/')
    {
        int i_idx;
        char s_tmp[MP_SIZE_CHANNEL];

        memset(s_tmp, 0x00, sizeof(s_tmp));
        for(i_idx = 1; i_idx < MP_SIZE_CHANNEL; i_idx++)
        {
            if(s_extra_channel[i_idx] == 0x00)
                break;

            if(s_extra_channel[i_idx] == '/')
                s_tmp[i_idx - 1] = '.';
            else
                s_tmp[i_idx - 1] = s_extra_channel[i_idx];
        }
        strcpy(s_extra_channel, s_tmp);
    }
#endif

    /* Extra Allow Module List */
    memset(value, ' ', sizeof(value));
    i_len = 0;
    memset(s_extra_allow_module, 0x00, sizeof(s_extra_allow_module));
    i_ret = COM_get_init_value(gs_svr_file, "StartOption", "ExtraAllowModuleList", value, &i_len);
    memcpy(s_extra_allow_module, value, i_len);

    MAIN_store_channel_info();

    return MP_TRUE;
}

char* strsep_func(char** stringp, const char* delim)
{
    char* start = *stringp;
    char* p;

    p = (start != NULL) ? strpbrk(start, delim) : NULL;

    if (p == NULL)
    {
        *stringp = NULL;
    }
    else
    {
        *p = '\0';
        *stringp = p + 1;
    }

    return start;
}

char** split_string(char* s_str, const char c_delimiter)
{
    char** result    = 0;
    size_t count     = 0;
    char* tmp        = s_str;
    char* last_comma = 0;
    char delim[2];
    delim[0] = c_delimiter;
    delim[1] = 0;

    /* Count how many elements will be extracted. */
    while (*tmp)
    {
        if (c_delimiter == *tmp)
        {
            count++;
            last_comma = tmp;
        }
        tmp++;
    }

    /* Add space for trailing token. */
    count += last_comma < (s_str + strlen(s_str) - 1);

    /* Add space for terminating null string so caller
       knows where the list of returned strings ends. */
    count++;

    result = (char **)malloc(sizeof(char*) * count);

    if (result)
    {
        size_t idx  = 0;
        char* token;
        
        token = strsep_func(&s_str, delim);

        while (token)
        {
            *(result + idx++) = strdup(token);
            token = strsep_func(&s_str, delim);
        }
        *(result + idx) = 0;
    }

    return result;
}

/*******************************************************************************
    MAIN_store_channel_info()
        - Exit Program
    Return Value
    Arguments
*******************************************************************************/
void MAIN_store_channel_info()
{
    int i;
    int i_start;
    int i_end;
    int i_index;
    int m;
    int m_start;
    int m_end;
    int m_index;
    char s_allow_mod[100];

    int i_length;
    char **channels;
    char **options;
    char s_tmp[255];


    memset(ga_channel_mod, 0x00, sizeof(ga_channel_mod));
    gi_channel_count = 0;

    strcpy(ga_channel_mod[0].s_channel, gs_main_channel);
    ga_channel_mod[0].c_tune_mode = 'D';
    ga_channel_mod[0].i_allow_mod_count = 0;
    ga_channel_mod[0].i_scheduler_weight = gi_tibrv_scheduler_weight;
    ga_channel_mod[0].d_heartbeat_interval = gd_tibrv_heartbeat_interval;
    ga_channel_mod[0].d_activate_interval = gd_tibrv_activate_interval;
    gi_channel_count++;

    if(COM_isspace(s_allow_module, sizeof(s_allow_module)) == MP_FALSE)
    {
        i_start = 0;
        i_end = 0;
        for(i = 0, i_index = 0; i < (int)strlen(s_allow_module); i++)
        {
            if(s_allow_module[i] == ',')
            {
                i_end = i;
                memcpy(ga_channel_mod[0].s_allow_mod_list[i_index], s_allow_module + i_start, i_end - i_start);
                i_start = i + 1;
                i_index++;
            }
        }

        if(i_start < i)
        {
            i_end = i;
            memcpy(ga_channel_mod[0].s_allow_mod_list[i_index], s_allow_module + i_start, i_end - i_start);
            i_index++;
        }

        ga_channel_mod[0].i_allow_mod_count = i_index;
    }

    strcpy(ga_channel_mod[1].s_channel, gs_stop_channel);
    ga_channel_mod[1].c_tune_mode = 'S';
    ga_channel_mod[1].i_allow_mod_count = 0;
    gi_channel_count++;

    strcpy(ga_channel_mod[2].s_channel, gs_admin_channel);
    ga_channel_mod[2].c_tune_mode = 'S';
    ga_channel_mod[2].i_allow_mod_count = 0;
    gi_channel_count++;

    if(COM_isspace(s_extra_channel, sizeof(s_extra_channel)) == MP_FALSE)
    {
        LOG_head("Extra Channel Info ");

        channels = split_string(s_extra_channel, ';');

        if (channels)
        {
            int i;
            for (i = 0; *(channels + i); i++)
            {
                options = split_string(*(channels + i), ':');

                if (options)
                {
                    int k = 0;
                    // Channel Name
                    if (*(options + k)) 
                    {
                        i_length = strlen(*(options + k));
                        if (sizeof(ga_channel_mod[gi_channel_count].s_channel) < i_length)
                        {
                            i_length = sizeof(ga_channel_mod[gi_channel_count].s_channel);
                        }
                        memcpy(ga_channel_mod[gi_channel_count].s_channel, *(options + k), i_length); 

                        free(*(options + k));
                    }

                    k++;
                    // Tune Mode
                    if (*(options + k))
                    {
                        ga_channel_mod[gi_channel_count].c_tune_mode = (*(options + k))[0];

                        free(*(options + k));
                    }

                    k++;
                    // Scheduler Weight for Tibrv
                    if (*(options + k))
                    {
                        ga_channel_mod[gi_channel_count].i_scheduler_weight = COM_atoi(*(options +k), strlen(*(options +k)));
                        if (ga_channel_mod[gi_channel_count].i_scheduler_weight < 0 || ga_channel_mod[gi_channel_count].i_scheduler_weight > 65535) ga_channel_mod[gi_channel_count].i_scheduler_weight = 1;

                        free(*(options + k));

                        k++;
                        // Heartbeat Interval for Tibrv
                        if (*(options + k))
                        {
                            ga_channel_mod[gi_channel_count].d_heartbeat_interval = COM_atof(*(options +k), strlen(*(options +k)));
                            if (ga_channel_mod[gi_channel_count].d_heartbeat_interval < 0) ga_channel_mod[gi_channel_count].d_heartbeat_interval = 1.0;

                            free(*(options + k));
                        }
                        else 
                        {
                            ga_channel_mod[gi_channel_count].d_heartbeat_interval = 1.0;
                        }
                    
                        k++;
                        // Activate Interval for Tibrv
                        if (*(options + k))
                        {
                            ga_channel_mod[gi_channel_count].d_activate_interval = COM_atof(*(options +k), strlen(*(options +k)));
                            if (ga_channel_mod[gi_channel_count].d_activate_interval < 0) ga_channel_mod[gi_channel_count].d_activate_interval = 3.5;

                            free(*(options + k));
                        }
                        else
                        {
                            ga_channel_mod[gi_channel_count].d_activate_interval = 3.5;
                        }
                    }
                    else
                    {
                        ga_channel_mod[gi_channel_count].i_scheduler_weight = 1;
                        ga_channel_mod[gi_channel_count].d_heartbeat_interval = 1.0;
                        ga_channel_mod[gi_channel_count].d_activate_interval = 3.5;
                    }

                    LOG_add("Channel Name", MP_STR, sizeof(ga_channel_mod[gi_channel_count].s_channel), ga_channel_mod[gi_channel_count].s_channel);
                    LOG_add("tune mode", MP_CHR, ga_channel_mod[gi_channel_count].c_tune_mode);
                    LOG_add("scheduler weight", MP_INT, ga_channel_mod[gi_channel_count].i_scheduler_weight);
                    LOG_add("heartbeat interval", MP_DBL, ga_channel_mod[gi_channel_count].d_heartbeat_interval);
                    LOG_add("scheduler weight", MP_DBL, ga_channel_mod[gi_channel_count].d_activate_interval);


                    free(options);
                    gi_channel_count++;
                }
                free(*(channels + i));
            }
            free(channels);
        }

        COM_log_write(MP_LOG_ERROR, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

        /*
        i_start = 0;
        i_end = 0;
        for(i = 0; i < (int)strlen(s_extra_channel); i++)
        {
            if(s_extra_channel[i] == ';')
            {
                i_end = i - 2;
                memcpy(ga_channel_mod[gi_channel_count].s_channel, s_extra_channel + i_start, i_end - i_start);
                ga_channel_mod[gi_channel_count].c_tune_mode = s_extra_channel[i_end + 1];
                ga_channel_mod[gi_channel_count].i_allow_mod_count = 0;
                i_start = i + 1;
                gi_channel_count++;
            }
        }

        if(i_start < i)
        {
            i_end = i - 2;
            memcpy(ga_channel_mod[gi_channel_count].s_channel, s_extra_channel + i_start, i_end - i_start);
            ga_channel_mod[gi_channel_count].c_tune_mode = s_extra_channel[i_end + 1];
            ga_channel_mod[gi_channel_count].i_allow_mod_count = 0;
            gi_channel_count++;
        }

        */
    }

    if(COM_isspace(s_extra_allow_module, sizeof(s_extra_allow_module)) == MP_FALSE)
    {
        i_start = 0;
        i_end = 0;
        i_index = 2;
        for(i = 0; i < (int)strlen(s_extra_allow_module); i++)
        {
            if(s_extra_allow_module[i] == ';')
            {
                i_end = i;
                memset(s_allow_mod, 0x00, sizeof(s_allow_mod));
                memcpy(s_allow_mod, s_extra_allow_module + i_start, i_end - i_start);
                i_start = i + 1;
                i_index++;

                m_start = 0;
                m_end = 0;
                for(m = 0, m_index = 0; m < (int)strlen(s_allow_mod); m++)
                {
                    if(s_allow_mod[m] == ',')
                    {
                        m_end = m;
                        memcpy(ga_channel_mod[i_index].s_allow_mod_list[m_index], s_allow_mod + m_start, m_end - m_start);
                        m_start = m + 1;
                        m_index++;
                    }
                }

                if(m_start < m)
                {
                    m_end = m;
                    memcpy(ga_channel_mod[i_index].s_allow_mod_list[m_index], s_allow_mod + m_start, m_end - m_start);
                    m_index++;
                }

                ga_channel_mod[i_index].i_allow_mod_count = m_index;
            }
        }

        if(i_start < i)
        {
            i_end = i;
            memset(s_allow_mod, 0x00, sizeof(s_allow_mod));
            memcpy(s_allow_mod, s_extra_allow_module + i_start, i_end - i_start);
            i_index++;

            m_start = 0;
            m_end = 0;
            for(m = 0, m_index = 0; m < (int)strlen(s_allow_mod); m++)
            {
                if(s_allow_mod[m] == ',')
                {
                    m_end = m;
                    memcpy(ga_channel_mod[i_index].s_allow_mod_list[m_index], s_allow_mod + m_start, m_end - m_start);
                    m_start = m + 1;
                    m_index++;
                }
            }

            if(m_start < m)
            {
                m_end = m;
                memcpy(ga_channel_mod[i_index].s_allow_mod_list[m_index], s_allow_mod + m_start, m_end - m_start);
                m_index++;
            }

            ga_channel_mod[i_index].i_allow_mod_count = m_index;
        }
    }
}


/*******************************************************************************
    MAIN_exit_program()
        - Exit Program
    Return Value
    Arguments
*******************************************************************************/
void MAIN_exit_program()
{
    //Add by J.S. 2011.10.21 for Collect Service Info
    COM_collect_service_performance(0x0, 0x0, 'Y', 0.0);

    /**** Free Shared Pool ****/
    SLP_free_pool();

    /**** Free Services ****/
    COM_remove_modules();

    /**** Free Global TRSNode ****/
    TRS.free_node(g_node_var);

    /**** Free Memory Allocation Link ****/
    COM_free_mem_alloc_link();

    /**** Close Log ****/
    LOG_close();

    /**** Close DB Connection ****/
    DB_disconnect();
    
    /**** Close IOI Bus ****/
#if defined(_H101)
#if defined(WIN32) || defined(WIN64)
    //Delete by J.S. 2009.01.13 버턴을 눌러 종료시 예외 발생으로 삭제 함.
    //term();
#else
    term();
#endif

#elif defined(_TIBRV)
#endif
    
#if defined(WIN32) || defined(WIN64)
    /*
    CloseHandle(dispatch_thread_handle);
    */
    /**** Send Destroy Message ****/
    PostQuitMessage(0);
#endif

    {
        char s_trans_time[14];
        COM_get_date_time(s_trans_time);
        printf("End Time = [%.14s]\n", s_trans_time);
        printf("Successfully Terminated...\n");
    }

    /* Program End */
    exit(0);
}


/*******************************************************************************
    MAIN_db_connect()
        - Connect to Database
    Return Value
        - int : MP_TRUE or MP_FALSE
    Arguments
    Globals
        Used       : gc_db_connected, gs_tns_name, gs_database_user, gs_database_password
        Modified   : gc_db_connected
*******************************************************************************/
int MAIN_db_connect(void)
{
    if(gc_db_connected == 'Y')
    {
        DB_select_dual();

        //Add by J.S. 2011.09.19 RAC 전환시 Error 처리, Rollback 필요, Disconnet해서 재접속 유도함.
        if(DB_error_code == -25402)
        {
            DB_rollback();
            DB_disconnect();
        }
    }

    if(gc_db_connected != 'Y')
    {
        if(gc_use_local_db == 'Y')
        {
            DB_connect(1, gs_tns_name, gs_database_user, gs_database_password);
            if(DB_error_code != DB_SUCCESS)
            {
                LOG_head("DB Connection Error !!!");
                LOG_add("Error Code", MP_INT, DB_error_code);
                LOG_add("Error Msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
                LOG_add("TNS NAME", MP_STR, sizeof(gs_tns_name), gs_tns_name);
                LOG_add("USER", MP_STR, sizeof(gs_database_user), gs_database_user);
                //Modify by J.S. 2011.04.11 DB Password 노출 방지
                LOG_add("PASSWORD", MP_STR, strlen("*"), "*");
                //LOG_add("PASSWORD", MP_STR, sizeof(gs_database_password), gs_database_password);
                COM_log_write(MP_LOG_ERROR, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

                return MP_FALSE;
            }
        }
        else
        {
            DB_connect(2, gs_tns_name, gs_database_user, gs_database_password);
            if(DB_error_code != DB_SUCCESS)
            {
                LOG_head("DB Connection Error !!!");
                LOG_add("Error Code", MP_INT, DB_error_code);
                LOG_add("Error Msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
                LOG_add("TNS NAME", MP_STR, sizeof(gs_tns_name), gs_tns_name);
                LOG_add("USER", MP_STR, sizeof(gs_database_user), gs_database_user);
                //Modify by J.S. 2011.04.11 DB Password 노출 방지
                LOG_add("PASSWORD", MP_STR, strlen("*"), "*");
                //LOG_add("PASSWORD", MP_STR, sizeof(gs_database_password), gs_database_password);
                COM_log_write(MP_LOG_ERROR, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);

                return MP_FALSE;
            }

            LOG_head("### Success DB Connection !!!");
            LOG_add("TNS NAME", MP_STR, sizeof(gs_tns_name), gs_tns_name);
            LOG_add("USER", MP_STR, sizeof(gs_database_user), gs_database_user);
            COM_log_write(MP_LOG_ERROR, MP_LOG_E_SYSTEM, MP_LOG_CATE_SYSTEM);
        }
    }

    return MP_TRUE;
}

/*******************************************************************************
    MAIN_get_message()
        - Pre-Processing function
    Return Value
        - void
    Arguments
*******************************************************************************/
void MAIN_pre_message()
{
    memset(s_tran_start_time, ' ', sizeof(s_tran_start_time));
    memset(s_tran_end_time, ' ', sizeof(s_tran_end_time));
    DBC_init_mwiplotsts(&gs_lot_old_info);

    COM_get_date_time_msec(s_tran_start_time);

    /* Get Client Host Name */
    memset(gs_client_id, 0x00, sizeof(gs_client_id));
    if(COM_get_hostname_peer() != 0x00)
    {    
        //modify by J.S 
        //memcpy(gs_client_id, mioi_hostname_peer, MP_SIZE_CLIENT_ID);
        if(strlen(COM_get_hostname_peer()) < MP_SIZE_CLIENT_ID)
            strcpy(gs_client_id, COM_get_hostname_peer());
        else
            memcpy(gs_client_id, COM_get_hostname_peer(), MP_SIZE_CLIENT_ID - 1);
    }

    LOG_printf("GET MESSAGE FROM = [%s]", gs_client_id);
    LOG_write(gs_client_id,
              MP_LOG_SYSTEM,
              ' ', 
              MP_LOG_CATE_SYSTEM,
              'S');

    /**** DB Re-Connect ****/
    if(MAIN_db_connect() == MP_FALSE)
    {
        return;
    }

#if defined(WIN32) || defined(WIN64)
    WinSetTranCount();
    WinSetTransStatus(MP_TRUE);
#endif
}

/*******************************************************************************
    MAIN_post_message()
        - Post-Processing function
    Return Value
        - void
    Arguments
*******************************************************************************/
void MAIN_post_message(char *s_service_name)
{
    double d_tran_time;
    char s_msg[100];

    COM_get_date_time_msec(s_tran_end_time);
    COM_diff_time_millisec(&d_tran_time, s_tran_end_time, s_tran_start_time);

    if(s_service_name == 0x00)
    {
        strcpy(s_msg, "No service name");
        s_service_name = s_msg;
    }

    /* Write log */
    LOG_printf("TIME FOR TRANS = [%s] Start = [%.*s] End = [%.*s] Interval = [%f]", 
               s_service_name, 
               sizeof(s_tran_start_time), s_tran_start_time, 
               sizeof(s_tran_end_time), s_tran_end_time, 
               d_tran_time ); 

    LOG_write(gs_client_id,
              MP_LOG_SYSTEM,
              ' ', 
              MP_LOG_CATE_SYSTEM,
              'E');

#if defined(WIN32) || defined(WIN64)
    WinSetProcTime(d_tran_time);
    WinSetTransStatus(MP_FALSE);
#endif

    COM_print_unfreed_mem_status(s_service_name);

    /* 2007.01.17. Aiden Koo. */
    /* 모든 처리가 마무리된 다음에 종료하도록 위치 변경 */
    if(gc_stop_process == 'Y')
    {
        MAIN_exit_program();
    }

}

/*******************************************************************************
    MAIN_prologue()
        - Pre-Processing function
    Return Value
        - int : MP_TRUE or MP_FALSE
    Arguments
*******************************************************************************/
int  MAIN_prologue(TRSNode *in_node, TRSNode *out_node)
{
    char *s_service_name;

    /* Multi transaction 처리용 */
    gb_multi_transaction = MP_FALSE;
    memset(gs_multi_tran_key, ' ', sizeof(gs_multi_tran_key));
    gi_multi_tran_seq = 0;

    /* Apply Service Log level */
    if(TRS.get_member(in_node, IN_LOGLEVEL) != 0x00)
    {
        gi_log_level = TRS.get_char(in_node, IN_LOGLEVEL) - 48;
        if(gi_log_level < MP_LOG_LEVEL_DEBUG_WRITE || gi_log_level > MP_LOG_LEVEL_ERROR_WRITE)
        {
            gi_log_level = i_system_log_level;
        }
    }

    /* Write call service name to log */
    s_service_name = TRS.get_string(in_node, MSG_SERVICE_NAME);
    MAIN_display_status(s_service_name);

    if(strcmp(s_service_name, "ADM_Check_Process") != 0)
    {
        /* Write log */
        LOG_printf("TRANS = [%s]", s_service_name);
        LOG_write(gs_client_id,
                      MP_LOG_SYSTEM,
                  ' ', 
                  MP_LOG_CATE_SYSTEM,
                  'S');
    }

    gs_log_type.category = ' ';
    gs_log_type.e_type = ' ';
    gs_log_type.type = ' ';

    DB_init_service_total_query_time();

    if(COM_isnullspace(TRS.get_string(in_node, "JOB_PROC_ID")) == MP_FALSE)
    {
        char s_error_msg[MP_SIZE_FIELD_MSG];
        struct MBATPRCDEF_TAG MBATPRCDEF;
        struct MBATPRCSTS_TAG MBATPRCSTS;
        char s_sys_time[14];

        memset(s_error_msg, 0x00, MP_SIZE_FIELD_MSG);
        memset(s_sys_time, 0x00, sizeof(s_sys_time));
        DB_get_systime(s_sys_time);
        if(DB_error_code != DB_SUCCESS)
        {
            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("MAIN_prologue");
            LOG_add("DB_get_systime", MP_NVST);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        DBC_init_mbatprcdef(&MBATPRCDEF);
        TRS.copy(MBATPRCDEF.JOB_PROC_ID, sizeof(MBATPRCDEF.JOB_PROC_ID), in_node, "JOB_PROC_ID");
        DBC_select_mbatprcdef_for_update(1, &MBATPRCDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("MAIN_prologue");
            LOG_add("table", MP_NSTR, "MBATPRCDEF SELECT FOR UPDATE");
            LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCDEF.JOB_PROC_ID), MBATPRCDEF.JOB_PROC_ID);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        if(MBATPRCDEF.PROC_METHOD == 'S' && MBATPRCDEF.JOB_RUN_FLAG == 'Y')
        {
            LOG_head("MAIN_prologue");
            LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCDEF.JOB_PROC_ID), MBATPRCDEF.JOB_PROC_ID);
            LOG_add("error_msg", MP_NSTR, "Single processor already running...");
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        MBATPRCDEF.JOB_RUN_FLAG = 'Y';
        DBC_update_mbatprcdef(2, &MBATPRCDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            DB_rollback();

            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("MAIN_prologue");
            LOG_add("table", MP_NSTR, "MBATPRCDEF UPDATE");
            LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCDEF.JOB_PROC_ID), MBATPRCDEF.JOB_PROC_ID);
            LOG_add("JOB_RUN_FLAG", MP_CHR, MBATPRCDEF.JOB_RUN_FLAG);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        DBC_init_mbatprcsts(&MBATPRCSTS);
        TRS.copy(MBATPRCSTS.JOB_PROC_ID, sizeof(MBATPRCSTS.JOB_PROC_ID), in_node, "JOB_PROC_ID");
        memcpy(MBATPRCSTS.PROC_RUN_SUBNO, gs_subno, MP_SIZE_SUBNO);
        DBC_select_mbatprcsts_for_update(1, &MBATPRCSTS);
        if(DB_error_code != DB_NOT_FOUND && DB_error_code != DB_SUCCESS) 
        {
            DB_rollback();

            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("MAIN_prologue");
            LOG_add("table", MP_NSTR, "MBATPRCSTS SELECT FOR UPDATE");
            LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCSTS.JOB_PROC_ID), MBATPRCSTS.JOB_PROC_ID);
            LOG_add("PROC_RUN_SUBNO", MP_STR, sizeof(MBATPRCSTS.PROC_RUN_SUBNO), MBATPRCSTS.PROC_RUN_SUBNO);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        memcpy(MBATPRCSTS.START_TIME, s_sys_time, sizeof(MBATPRCSTS.START_TIME));
        MBATPRCSTS.STATUS_FLAG = 'P';

        memset(MBATPRCSTS.END_TIME, ' ', sizeof(MBATPRCSTS.END_TIME));
        memset(MBATPRCSTS.ERROR_MSG, ' ', sizeof(MBATPRCSTS.ERROR_MSG));
        memset(MBATPRCSTS.DB_ERROR_MSG, ' ', sizeof(MBATPRCSTS.DB_ERROR_MSG));
        MBATPRCSTS.ELAPSED_TIME = 0;

        if(DB_error_code == DB_NOT_FOUND)
        {
            MBATPRCSTS.LAST_HIST_SEQ = 0;
            DBC_insert_mbatprcsts(&MBATPRCSTS);
        }
        else
        {
            DBC_update_mbatprcsts(1, &MBATPRCSTS);
        }
        if(DB_error_code != DB_SUCCESS) 
        {
            DB_rollback();

            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("MAIN_prologue");
            LOG_add("table", MP_NSTR, "MBATPRCSTS INSERT/UPDATE");
            LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCSTS.JOB_PROC_ID), MBATPRCSTS.JOB_PROC_ID);
            LOG_add("PROC_RUN_SUBNO", MP_STR, sizeof(MBATPRCSTS.PROC_RUN_SUBNO), MBATPRCSTS.PROC_RUN_SUBNO);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        DB_commit();
    }

    return MP_TRUE;
}

/*******************************************************************************
    MAIN_epilogue()
        - Post-Processing function
    Return Value
        - int : TRUE or FALSE
    Arguments
*******************************************************************************/
int  MAIN_epilogue(TRSNode *in_node, TRSNode *out_node, MP_SERVICE_MODE service_mode, int service_result)
{
    char*                   s_service_name;
    //Add by J.S. 2011.10.21
    double d_tran_time;

    /* Restore log level */
    gi_log_level = i_system_log_level;

    /* Get Operation Name */
    s_service_name = TRS.get_string(in_node, MSG_SERVICE_NAME);

    if(strcmp(s_service_name, "ADM_Check_Process") != 0)
    {
        if(service_result == MP_SERVICE_NOT_FOUND)
        {
            MAIN_display_status("UNEXPECTED SERVICE");
            LOG_head("UNEXPECTED SERVICE");
        }
        else if(service_result == MP_SERVICE_FAIL)
        {
            MAIN_display_status("SERVICE FAIL");
            LOG_head("SERVICE FAIL");
        }
        else
        {
            MAIN_display_status("REPLY MESSAGE");
            LOG_head("REPLY MESSAGE");
        }

        LOG_write(gs_client_id, MP_LOG_INFORMATION, ' ',  MP_LOG_CATE_SYSTEM, 'E');
    }

    //Add by J.S. 2011.10.21 for save service info
    COM_get_date_time_msec(s_tran_end_time);
    COM_diff_time_millisec(&d_tran_time, s_tran_end_time, s_tran_start_time);

	//Add by J.S. 2011.12.05 for DST
	if(d_tran_time < 0)
	{
		d_tran_time = 0;
	}

    if(COM_isnullspace(TRS.get_string(in_node, "JOB_PROC_ID")) == MP_FALSE)
    {
        char s_error_msg[MP_SIZE_FIELD_MSG];
        struct MBATPRCDEF_TAG MBATPRCDEF;
        struct MBATPRCSTS_TAG MBATPRCSTS;
        struct MBATPRCHIS_TAG MBATPRCHIS;

        memset(s_error_msg, 0x00, MP_SIZE_FIELD_MSG);

        DBC_init_mbatprcdef(&MBATPRCDEF);
        TRS.copy(MBATPRCDEF.JOB_PROC_ID, sizeof(MBATPRCDEF.JOB_PROC_ID), in_node, "JOB_PROC_ID");
        DBC_select_mbatprcdef_for_update(1, &MBATPRCDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("MAIN_epilogue");
            LOG_add("table", MP_NSTR, "MBATPRCDEF SELECT FOR UPDATE");
            LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCDEF.JOB_PROC_ID), MBATPRCDEF.JOB_PROC_ID);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        MBATPRCDEF.JOB_RUN_FLAG = ' ';
        DBC_update_mbatprcdef(2, &MBATPRCDEF);
        if(DB_error_code != DB_SUCCESS) 
        {
            DB_rollback();

            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("MAIN_epilogue");
            LOG_add("table", MP_NSTR, "MBATPRCDEF UPDATE");
            LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCDEF.JOB_PROC_ID), MBATPRCDEF.JOB_PROC_ID);
            LOG_add("JOB_RUN_FLAG", MP_CHR, MBATPRCDEF.JOB_RUN_FLAG);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        DBC_init_mbatprcsts(&MBATPRCSTS);
        TRS.copy(MBATPRCSTS.JOB_PROC_ID, sizeof(MBATPRCSTS.JOB_PROC_ID), in_node, "JOB_PROC_ID");
        memcpy(MBATPRCSTS.PROC_RUN_SUBNO, gs_subno, MP_SIZE_SUBNO);
        DBC_select_mbatprcsts_for_update(1, &MBATPRCSTS);
        if(DB_error_code != DB_SUCCESS) 
        {
            DB_rollback();

            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("MAIN_epilogue");
            LOG_add("table", MP_NSTR, "MBATPRCSTS SELECT FOR UPDATE");
            LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCSTS.JOB_PROC_ID), MBATPRCSTS.JOB_PROC_ID);
            LOG_add("PROC_RUN_SUBNO", MP_STR, sizeof(MBATPRCSTS.PROC_RUN_SUBNO), MBATPRCSTS.PROC_RUN_SUBNO);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        memcpy(MBATPRCSTS.END_TIME, s_tran_end_time, sizeof(MBATPRCSTS.END_TIME));
        MBATPRCSTS.ELAPSED_TIME = d_tran_time;

        MBATPRCSTS.STATUS_FLAG = 'S';
        if(TRS.get_char(out_node, OUT_STATUSVALUE) == MP_FAIL_C)
        {
            MBATPRCSTS.STATUS_FLAG = 'F';
            strcpy(MBATPRCSTS.ERROR_MSG, TRS.get_string(out_node, OUT_MSG));
            strcpy(MBATPRCSTS.DB_ERROR_MSG, TRS.get_string(out_node, OUT_DBERRMSG));
        }

        MBATPRCSTS.LAST_HIST_SEQ += 1;

        TRS.copy(MBATPRCSTS.PROC_KEY_1, sizeof(MBATPRCSTS.PROC_KEY_1), out_node, "PROC_KEY_1");
        TRS.copy(MBATPRCSTS.PROC_KEY_2, sizeof(MBATPRCSTS.PROC_KEY_2), out_node, "PROC_KEY_2");
        TRS.copy(MBATPRCSTS.PROC_KEY_3, sizeof(MBATPRCSTS.PROC_KEY_3), out_node, "PROC_KEY_3");
        TRS.copy(MBATPRCSTS.PROC_KEY_4, sizeof(MBATPRCSTS.PROC_KEY_4), out_node, "PROC_KEY_4");
        TRS.copy(MBATPRCSTS.PROC_KEY_5, sizeof(MBATPRCSTS.PROC_KEY_5), out_node, "PROC_KEY_5");

        DBC_update_mbatprcsts(1, &MBATPRCSTS);
        if(DB_error_code != DB_SUCCESS) 
        {
            DB_rollback();

            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("MAIN_epilogue");
            LOG_add("table", MP_NSTR, "MBATPRCSTS UPDATE");
            LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCSTS.JOB_PROC_ID), MBATPRCSTS.JOB_PROC_ID);
            LOG_add("PROC_RUN_SUBNO", MP_STR, sizeof(MBATPRCSTS.PROC_RUN_SUBNO), MBATPRCSTS.PROC_RUN_SUBNO);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        DBC_init_mbatprchis(&MBATPRCHIS);
        memcpy(MBATPRCHIS.JOB_PROC_ID, MBATPRCSTS.JOB_PROC_ID, sizeof(MBATPRCHIS.JOB_PROC_ID));
        memcpy(MBATPRCHIS.PROC_RUN_SUBNO, MBATPRCSTS.PROC_RUN_SUBNO, sizeof(MBATPRCHIS.PROC_RUN_SUBNO));
        MBATPRCHIS.HIST_SEQ = MBATPRCSTS.LAST_HIST_SEQ;
        memcpy(MBATPRCHIS.START_TIME, MBATPRCSTS.START_TIME, sizeof(MBATPRCHIS.START_TIME));
        memcpy(MBATPRCHIS.END_TIME, MBATPRCSTS.END_TIME, sizeof(MBATPRCHIS.END_TIME));
        MBATPRCHIS.ELAPSED_TIME = MBATPRCSTS.ELAPSED_TIME;
        MBATPRCHIS.STATUS_FLAG = MBATPRCSTS.STATUS_FLAG;
        memcpy(MBATPRCHIS.ERROR_MSG, MBATPRCSTS.ERROR_MSG, sizeof(MBATPRCHIS.ERROR_MSG));
        memcpy(MBATPRCHIS.DB_ERROR_MSG, MBATPRCSTS.DB_ERROR_MSG, sizeof(MBATPRCHIS.DB_ERROR_MSG));
        memcpy(MBATPRCHIS.PROC_KEY_1, MBATPRCSTS.PROC_KEY_1, sizeof(MBATPRCHIS.PROC_KEY_1));
        memcpy(MBATPRCHIS.PROC_KEY_2, MBATPRCSTS.PROC_KEY_2, sizeof(MBATPRCHIS.PROC_KEY_2));
        memcpy(MBATPRCHIS.PROC_KEY_3, MBATPRCSTS.PROC_KEY_3, sizeof(MBATPRCHIS.PROC_KEY_3));
        memcpy(MBATPRCHIS.PROC_KEY_4, MBATPRCSTS.PROC_KEY_4, sizeof(MBATPRCHIS.PROC_KEY_4));
        memcpy(MBATPRCHIS.PROC_KEY_5, MBATPRCSTS.PROC_KEY_5, sizeof(MBATPRCHIS.PROC_KEY_5));

        DBC_insert_mbatprchis(&MBATPRCHIS);
        if(DB_error_code != DB_SUCCESS) 
        {
            DB_rollback();

            COM_get_message('1', "CMN-0003", s_error_msg);
            LOG_head("MAIN_epilogue");
            LOG_add("table", MP_NSTR, "MBATPRCHIS INSERT");
            LOG_add("JOB_PROC_ID", MP_STR, sizeof(MBATPRCHIS.JOB_PROC_ID), MBATPRCHIS.JOB_PROC_ID);
            LOG_add("PROC_RUN_SUBNO", MP_STR, sizeof(MBATPRCHIS.PROC_RUN_SUBNO), MBATPRCHIS.PROC_RUN_SUBNO);
            LOG_add("HIST_SEQ", MP_INT, MBATPRCHIS.HIST_SEQ);
            LOG_add("error_msg", MP_STR, sizeof(s_error_msg), s_error_msg);
            LOG_add("db_error_msg", MP_STR, sizeof(DB_error_msg), DB_error_msg);
            COM_log_write(MP_LOG_ERROR,MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
            return MP_FALSE;
        }

        DB_commit();
    }

    COM_collect_service_performance(in_node, out_node, 'N', d_tran_time);
    //End Add

    return MP_TRUE;
}

