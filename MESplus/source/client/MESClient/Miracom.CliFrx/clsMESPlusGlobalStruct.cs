using System;
using System.Collections.Generic;
using System.Text;

namespace Miracom.CliFrx
{
    public struct LanguageDataTag
    {
        public string Key;
        public string Lang_1;
        public string Lang_2;
        public string Lang_3;
    }

    public struct LotDataCharListValueListTag
    {
        public string value;
    }

    public struct LotDataCharListTag
    {
        public int char_seq_num;
        public string char_id;
        public int unit_seq_num;
        public string unit_id;
        public int value_seq_num;
        public char value_type;
        public int value_count;
        public int value_listsize_;
        public LotDataCharListValueListTag[] value_list;
        public string spec_out_mask;
        public int spec_out_count;
        public char rec_save_flag;
    }

    public struct LotDataTag
    {
        public char spec_out_flag;
        public string lot_id;
        public string tran_time;
        public string mat_id;
        public int mat_ver;
        public string flow;
        public string oper;
        public string meas_res_id;
        public string proc_flow;
        public string proc_oper;
        public string proc_res_id;
        public string col_set_id;
        public int col_set_version;
        public int count;
        public int char_listsize_;
        public LotDataCharListTag[] char_list;
    }

    public struct AlarmListTag //?뚮엺 ?댁슜????ν븳??
    {
        public char alarm_level;
        public char alarm_type;
        public string alarm_id;
        public string res_id;
        public string lot_id;
        public string alarm_subject;
        public string alarm_msg;
        public string source_id_1;
        public string source_desc_1;
        public string source_id_2;
        public string source_desc_2;
        public string source_id_3;
        public string source_desc_3;
        public string create_time;
        public string alarm_comment_1;
        public string alarm_comment_2;
        public string alarm_comment_3;
        public string alarm_comment_4;
        public string alarm_comment_5;
        public byte[] pdf_data;
        public byte[] img_data;
    }


    public struct FactoryShiftInfoTag
    {
        public bool bVariableShift;
        public int iShiftCount;
        public char cShift1DayFlag;
        public string sShift1StartTime;
        public char cShift2DayFlag;
        public string sShift2StartTime;
        public char cShift3DayFlag;
        public string sShift3StartTime;
        public char cShift4DayFlag;
        public string sShift4StartTime;
    }

    public struct SPCAlarmListTag //?뚮엺 ?댁슜????ν븳??
    {
        public string factory;
        public string alarm_id;
        public string chart_id;
        public int hist_seq;
        public string tran_time;
        public char lot_res_flag;
        public string lot_id;
        public string mat_id;
        public int mat_ver;
        public string flow;
        public int flow_seq_num;
        public string oper;
        public string proc_oper;
        public string res_id;
        public string proc_res_id;
        public string event_id;
        public string char_id;
        public string unit_id;
        public int unit_seq;
        public char xr_flag;
        public char ooc_type;
        public char alarm_level_flag;
        public string alarm_msg;
    }


    public struct MenuInfoTag
    {
        public string s_func_name;
        public string s_assembly_file;
        public string s_assembly_name;
        public char c_func_type;
        public string s_args;
    }

    public struct gtServerInfoTag
    {
        public string server_name;
        public int tot_count;
        public int proc_count;
    }

    public struct gtProcessInfoTag
    {
        public string server_name;
        public string process_name;
        public string channel;
        public string sub_no;
        public int check_seq;
        public int reply_count;
        public int reply_status_1;
        public int reply_status_2;
        public int shared_pool_status;
    }

    public struct BBSMessageTag
    {
        public string factory;
        public string main_menu_id;
        public string sub_menu_id;
        public int bbs_seq;
        public string tran_time;
        public string lot_id;
        public string sublot_id;
        public string oper;
        public string res_id;
        public string subres_id;
        public string msg_type;
        public string msg_title;
        public string msg_tag;
        public int reply_count;
        public char delete_flag;
        public string create_user_id;
        public string create_time;
        public string update_user_id;
        public string update_time;
        public char sys_msg_flag;
        public char popup_cycle;
        public char priority;
        public char apply_shift;
        public string apply_start_time;
        public string apply_end_time;
        public string area_id;
        public string sub_area_id;
        public string res_grp_id;
        public string mat_id;
        public string flow;
        public string rcv_user_id;
        public string sec_grp_id;
        public string prv_grp_id;
        public char modal_flag;
        public char auto_close_flag;
        public int auto_close_time;
        public char ack_flag;
        public string ack_time;
        public string ack_user_id;
        public string rcv_factory;
    }

    public struct gtBinLotInfoTag
    {
        public string bin_lot_id;
        public int bin_lot_hist_seq;
        public int bin_col_seq;
        public bool low_yield_flag;
    }

}
