using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SOI.OIFrx
{
    // ********************************************************************
    // 하단의 struct 명칭은 Framework에서 사용 중 이므로 사용할 수 없습니다.
    // LanguageDataTag
    // LotDataCharListValueListTag
    // LotDataCharListTag
    // LotDataTag
    // AlarmListTag    
    // FactoryShiftInfoTag
    // SPCAlarmListTag
    // MenuInfoTag
    // gtServerInfoTag
    // gtProcessInfoTag
    // BBSMessageTag
    // gtBinLotInfoTag
    // FuncCtrlList
    // ThemeColor
    // ********************************************************************

    #region Control

    public struct DownloadFileInfo
    {
        public string fileId;
        public string fileType;
        public int optionSeq;
    }

    #endregion
}
