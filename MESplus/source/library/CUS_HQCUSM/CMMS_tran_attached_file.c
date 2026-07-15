
/*******************************************************************************
    CMMS_tran_attached_file()
        - Main sub function of "CMMS attached file Get & Set" function
        - Setup service main business function
    Return Value
        - int : 1 (MP_TRUE) or 0 (MP_FALSE)
    Arguments
        - char *s_msg_code : Error Message Code
        - TRSNode *in_node : Input Message structure
        - TRSNode *out_node : Output Message structure
*******************************************************************************/
#include "CUS_HQCUSM_common.h"
#include "TRSCore_functions.h"
#include <io.h>
#include <direct.h>

int CMMS_set_attached_file(char *s_msg_code, 
						   char *tran_id, 
						   char *file_id, 
						   char *file_name, 
						   MBLOB m_blob, 
						   char *file_path)
{
	FILE   *blob_file;
	char   s_template_path[100];
	char   s_file_full_name[200];
	int  i_ret;
    int  i_len;

	if(m_blob.IS_NULL != 'Y')
	{
		memset(s_template_path, 0x00, sizeof(s_template_path));
		i_ret = COM_get_init_value(gs_com_file, "Directories", "MESplusMMSAttachDir", s_template_path, &i_len);
		if(i_ret == MP_FALSE) 
		{
			LOG_head("UALM_read_template_file : COM_get_init_value");
			LOG_add("gs_com_file", MP_NSTR, gs_com_file);
			LOG_add("s_key", MP_NSTR, "MESplusMMSAttachDir");
			COM_log_write(MP_LOG_DEBUG, MP_LOG_E_LOGIC, MP_LOG_CATE_SYSTEM);
			return MP_FALSE;
		}

		memset(s_file_full_name, 0x00, sizeof(file_name));

#if defined(WIN32) || defined(WIN64)
		sprintf(file_path, "%s\\%s", s_template_path, tran_id);    
#else
		sprintf(file_path, "%s/%s", s_template_path, tran_id);
#endif

		//Check & Create Folder 	
		if (access(file_path, 0) != 0)
		{
			if (mkdir(file_path) != 0)
			{
				strcpy(s_msg_code, "MMS-0004"); 
				return MP_FALSE;
			}
		}

		//Check & Create Folder 
#if defined(WIN32) || defined(WIN64)
		sprintf(file_path, "%s\\%s\\%s", s_template_path, tran_id, file_id);
#else
		sprintf(file_path, "%s/%s/%s", s_template_path, tran_id, file_id);
#endif
		if (access(file_path, 0) != 0)
		{
			if (mkdir(file_path) != 0)
			{
				strcpy(s_msg_code, "MMS-0004"); 
				return MP_FALSE;
			}
		}

#if defined(WIN32) || defined(WIN64)
		sprintf(file_path, "%s\\%s\\%s\\%s", s_template_path, tran_id, file_id, file_name);    
#else
		sprintf(file_path, "%s/%s/%s/%s", s_template_path, tran_id, file_id, file_name);  
#endif

		//Check File_path Size
		if(strlen(file_path) > 100)
		{
			strcpy(s_msg_code, "SPM-0013");
			return MP_FALSE;
		}
	
		blob_file = fopen(file_path, "wb");
		fwrite(m_blob.VALUE, sizeof(unsigned char), m_blob.SIZE, blob_file);
		fclose(blob_file);
	}

    return MP_TRUE;
} 

int CMMS_get_attached_file(char *s_msg_code,
                          TRSNode *out_node,
						  char *s_file_path,
                          char *s_put_member_name,
                          char c_add_fieldmsg)
{
    struct stat     status;             // file information structure
    int             i_status;           // file handling variable
    char            s_file_name[100];
    FILE            *fp;
    unsigned char   *blob_buffer;

    memset(s_file_name, 0x00, sizeof(s_file_name));
    COM_memcpy_add_null(s_file_name, s_file_path, sizeof(s_file_name));

    if(strlen(s_file_name) < 1) return MP_TRUE;

    fp = fopen(s_file_name, "rb");
    if (fp == 0x00)
    {
        strcpy(s_msg_code, "ALM-0043");

        if(c_add_fieldmsg == 'Y')
        {
            TRS.add_fieldmsg(out_node, "Attached File Name", MP_NSTR, s_file_name);
        }

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

#if defined(WIN32) || defined(WIN64)
    i_status = fstat(_fileno(fp), &status);
#else
    i_status = fstat(fileno(fp), &status);
#endif

    if (i_status == -1)
    {
        strcpy(s_msg_code, "ALM-0043");

        if(c_add_fieldmsg == 'Y')
        {
            TRS.add_fieldmsg(out_node, "Attached File Name", MP_NSTR, s_file_name);
        }

        gs_log_type.type = MP_LOG_ERROR;
        gs_log_type.e_type = MP_LOG_E_SYSTEM;
        gs_log_type.category = MP_LOG_CATE_COMMON;
        return MP_FALSE;
    }

    blob_buffer = (unsigned char*)COM_malloc(status.st_size, "COM_get_attached_file", s_file_name);
    fread(blob_buffer, status.st_size, 1, fp);

    TRS.set_blob(out_node, s_put_member_name, blob_buffer, status.st_size);

    fclose(fp);
    COM_free(blob_buffer);

    return MP_TRUE;
}
