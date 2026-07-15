using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace Miracom.CliFrx
{
    public interface intMdiFormFunction
    {
        void ActiveMenu(string s_func_name);
        Control ActiveMenu(MenuInfoTag m_menu_tag);
        void FavoritesRefresh();
        //Add by J.S. 2009.01.07 for refresh main menu
        void MenuRefresh();

        void SetStatusMessage(string s_msg);
        void EnablePublishAlarm();
        void Progress_Start();
        void Progress_End();
        
        ImageList GetSmallIconList();
        ImageList GetToolBarIconList();
        
        #if _UTL
        bool PublishUTLMsgTune();
        void SetPublishMessage(string s_msg);
        bool ViewUTLPublishMessage(bool bActivated);
        #endif
        
        #if _ALM
        bool PublishALMMsgTune();
        void SetAlarmMessage();
        bool ViewALMPublishMessage();
        #endif
        
        #if _SPC
        bool PublishSPCMsgTune();
        bool ViewSPCPublishData(object SPC_Publish_Data_In);
        bool ViewSPCPublishMessage();
        #endif
        
        /* Add by DM KIM 2012.05.08 BBS Publish Message*/
        void EnablePublishBBS();
        bool PublishBBSMsgTune();
        void SetBBSMessage();
        bool ViewBBSPublishMessage();

        #if _RTD
        //RTD <-> WIP
        bool ViewWIPTranStartLot(bool bDispatcherFlag, string sLotID, string sResourceID);
        bool ViewWIPTranEndLot(bool bDispatcherFlag, string sLotID, string sResourceID);
        bool ViewWIPTranMoveLot(bool bDispatcherFlag, string sLotID);
        bool ViewWIPTranSkipLot(bool bDispatcherFlag, string sLotID);
        #endif
                
    }
}
