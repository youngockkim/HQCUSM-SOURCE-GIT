using System;
using System.Collections.Generic;
using System.Text;

namespace Miracom.SVMCore
{
    public class ServiceMember
    {
        public string MODULE_NAME;
        public string SERVICE_NAME;
        public char DIRECTION;
        public int MEMBER_DEPTH;
        public string MEMBER_NAME;
        public string MEMBER_PRT;
        public int MEMBER_SEQ;
        public string MEMBER_TYPE;
        public string ARRAY_TYPE;
        public string MEMBER_DESC_1;
        public string MEMBER_DESC_2;
        public string MEMBER_DESC_3;
        public int MEMBER_SIZE;
        public char REQ_MEMBER_FLAG;
        public string PARENT_MEMBER_PATH;
        public char OVERRIDE_FLAG;
        public double RANGE_MIN;
        public double RANGE_MAX;
        public char USE_RANGE_FLAG;
        public string CREATE_USER_ID;
        public string CREATE_TIME;
        public string UPDATE_USER_ID;
        public string UPDATE_TIME;
        public string MEMBER_PATH;

        public ServiceMember()
        {
            MODULE_NAME = "";
            SERVICE_NAME = "";
            DIRECTION = ' ';
            MEMBER_DEPTH = 0;
            MEMBER_NAME = "";
            MEMBER_PRT = "";
            MEMBER_SEQ = 0;
            MEMBER_TYPE = "";
            MEMBER_DESC_1 = "";
            MEMBER_DESC_2 = "";
            MEMBER_DESC_3 = "";
            MEMBER_SIZE = 0;
            REQ_MEMBER_FLAG = ' ';
            PARENT_MEMBER_PATH = "";
            OVERRIDE_FLAG = ' ';
            RANGE_MIN = 0.0f;
            RANGE_MAX = 0.0f;
            USE_RANGE_FLAG = ' ';
            CREATE_USER_ID = "";
            CREATE_TIME = "";
            UPDATE_USER_ID = "";
            UPDATE_TIME = "";
            MEMBER_PATH = "";
        }

        public ServiceMember(string module, string service, string language, Member member)
        {
            MODULE_NAME = module;
            SERVICE_NAME = service;
            DIRECTION = member.Direction;
            MEMBER_DEPTH = member.Depth;
            MEMBER_NAME = member.Name;
            MEMBER_PRT = member.Prompt;
            MEMBER_SEQ = member.Sequence;
            MEMBER_TYPE = member.Type;
            MEMBER_DESC_1 = member.Desc1;
            MEMBER_DESC_2 = member.Desc2;
            MEMBER_DESC_3 = member.Desc3;            
            MEMBER_SIZE = member.Size;
            REQ_MEMBER_FLAG = member.RequireFlag;
            PARENT_MEMBER_PATH = member.ParentPath;
            OVERRIDE_FLAG = member.OverrideFlag;
            RANGE_MIN = member.RangeMin;
            RANGE_MAX = member.RangeMax;
            USE_RANGE_FLAG = member.UseRangeFlag;

            CREATE_USER_ID = member.CreateUserId;
            CREATE_TIME = member.CreateTime;
            UPDATE_USER_ID = member.UpdateUserId;
            UPDATE_TIME = member.UpdateTime;
            MEMBER_PATH = member.MemberPath;
        }
    }
}
